using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using ShootingRange.classes.Interface;
using System.Windows.Threading;
using ShootingRange.classes.Menu;

namespace ShootingRange.classes.Game
{
    class GameModel  // Инициализирует необходимые объекты
    {
        #region fields
        public static bool isModelReady = false;
        public static bool isGameFreezed = false;
        public static bool isLoadTimerEnd = false;

        private static bool isGamePause;
        public static bool Pause
        {
            set
            {
                if (value)
                {
                    isGamePause = value;
                    PauseGame();
                }
                else
                {
                    UnpauseGame();
                    isGamePause = value;
                }
            }
            get
            {
                return isGamePause;
            }
        }

        public static string lvlName;

        public static Grid grGame;
        public static PauseMenuGrid grPauseMenu;
        public static StatsGrid grStats;
        public static ChoiceDialog dlgDefeat;
        public static ChoiceDialog dlgVictory;
        public static Grid grLoadScreen;

        public static Camera camera;
        public static ListOfTargets listOfTargets;
        public static Rifle rifle;
        public static Scope scope;
        public static InterfaceElements interfaceElements;

        public static List<MediaPlayer> mediaPlayers;

        private static DispatcherTimer unfreezeTimer;
        private static DispatcherTimer loadTimer;
        #endregion

        public GameModel(Grid grMain, string levelsFolderName, string weaponFolderName)
        {
            isModelReady = false;
            isLoadTimerEnd = false;

            lvlName = levelsFolderName;

            grGame = (Grid)grMain.Children[0];
            grPauseMenu = (PauseMenuGrid)grMain.Children[1];
            dlgDefeat = (ChoiceDialog)grMain.Children[2];
            dlgVictory = (ChoiceDialog)grMain.Children[3];
            grStats = (StatsGrid)grMain.Children[4];
            grLoadScreen = (Grid)grMain.Children[grMain.Children.Count - 1];


            ClearGridGame();

            mediaPlayers = new List<MediaPlayer>();

            InitTimers();
            
            camera = new Camera(GetImageFromGridGame(1), GetImageFromGridGame(2), GetImageFromGridGame(3), levelsFolderName, weaponFolderName);
            rifle = new Rifle(GetImageFromGridGame(0), weaponFolderName);
            scope = new Scope(GetImageFromGridGame(1), GetImageFromGridGame(2), GetImageFromGridGame(3), GetImageFromGridGame(0), weaponFolderName);
            listOfTargets = new ListOfTargets(GetImageFromGridGame(1), GetImageFromGridGame(2), GetImageFromGridGame(3), levelsFolderName);
            interfaceElements = new InterfaceElements(grGame, grStats, dlgDefeat, dlgVictory);

            PrepareModel();
            
            isModelReady = true;
            loadTimer.Start();

            InterfaceElements.timer.timer.Start();
        }

        private static void InitTimers()
        {
            unfreezeTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 10)
            };
            unfreezeTimer.Tick += new EventHandler(UnfreezeTimerTick);

            loadTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1, 0)
            };
            loadTimer.Tick += new EventHandler(LoadTimerTick);
        }

        private static void ClearGridGame()
        {
            grGame.Children.RemoveRange(1, grGame.Children.Count);

            Canvas canvas = CreateCanvasWithImage("imgBg");
            grGame.Children.Add(canvas);

            canvas = CreateCanvasWithImage("imgBgScopeVert");
            canvas.ClipToBounds = true;
            grGame.Children.Add(canvas);

            canvas = CreateCanvasWithImage("imgBgScopeHoriz");
            canvas.ClipToBounds = true;
            grGame.Children.Add(canvas);
        }

        private Image GetImageFromGridGame(int index)
        {
            Canvas canvas = (Canvas)grGame.Children[index];
            return (Image)canvas.Children[0];
        }

        private static Canvas CreateCanvasWithImage(string imgName)
        {
            Canvas canvas = new Canvas()
            {
                Cursor = Cursors.None
            };

            Image img = new Image()
            {
                Name = imgName
            };
            Canvas.SetLeft(img, 0);
            Canvas.SetTop(img, 0);

            canvas.Children.Add(img);

            return canvas;
        }

        private static void PrepareModel()
        {
            Rifle.Shoot(new Point(0, 0), new Point(0, 0), true, false);
            Rifle.CompleteShootAnimation(true);
            Rifle.CompleteBoltAnimation();
            Rifle.recoilData.timer.Stop();

            Rifle.Shoot(new Point(0, 0), new Point(0, 0), false, false);
            Rifle.CompleteShootAnimation(false);
            Rifle.CompleteBoltAnimation();
            Rifle.recoilData.timer.Stop();

            Rifle.Reload(false, false);
            Rifle.CompleteReloadAnimation();
            Rifle.CompleteReloadAnimation();
            Rifle.addBullets += 2;
            InterfaceElements.bulletsCounter.ChangeBulletsCount(Rifle.curBullets, Rifle.addBullets);

            Scope.ZoomIn(false);
            Scope.CompleteScopeAnimation(true);
            Scope.ZoomOut(false);
            Scope.CompleteScopeAnimation(true);
            Rifle.CompleteBoltAnimation();

            FreezeGame();
            UnfreezeGame();

            Pause = false;
            dlgDefeat.Visibility = Visibility.Hidden;
            dlgVictory.Visibility = Visibility.Hidden;
            grStats.Visibility = Visibility.Hidden;
            grPauseMenu.Visibility = Visibility.Hidden;
            grGame.Visibility = Visibility.Visible;
        }

        private static void LoadTimerTick(object sender, EventArgs e)
        {
            loadTimer.Stop();
            isLoadTimerEnd = true;
            grLoadScreen.Visibility = Visibility.Hidden;
        }

        public static void MoveCamera(Point cursorScreenPos)
        {
            Camera.MoveBgs(cursorScreenPos);
            ListOfTargets.MoveTargets();
        }

        public static void FreezeGame()
        {
            if (isGameFreezed)
            {
                return;
            }

            const int BLUR_RADIUS = 30;

            isGameFreezed = true;
            
            InterfaceElements.timer.timer.Stop();
            if (Rifle.recoilData.timer != null)
            {
                Rifle.recoilData.timer.Stop();
            }
            
            var animationController = WpfAnimatedGif.ImageBehavior.GetAnimationController(Rifle.weaponModel);
            animationController.Pause();

            foreach (MediaPlayer mp in mediaPlayers)
            {
                mp.Pause();
            }

            foreach (UIElement el in grGame.Children)
            {
                if (el is InterfaceElContainer)
                {
                    el.Visibility = Visibility.Hidden;
                }
            }
            BlurEffect blur = new BlurEffect();
            blur.Radius = BLUR_RADIUS;
            grGame.Effect = blur;
        }

        public static void UnfreezeGame()
        {
            if (!isGameFreezed)
            {
                return;
            }

            grGame.Effect = null;

            for (int i = 0; i < grGame.Children.Count; i++)
            {
                if (grGame.Children[i] is InterfaceElContainer)
                {
                    grGame.Children[i].Visibility = Visibility.Visible;
                }
            }

            foreach (MediaPlayer mp in mediaPlayers)
            {
                mp.Play();
            }

            var animationController = WpfAnimatedGif.ImageBehavior.GetAnimationController(Rifle.weaponModel);
            animationController.Play();

            if (Rifle.recoilData.timer != null && Rifle.recoilData.ticksCount < Rifle.recoilData.maxTicksCount)
            {
                Rifle.recoilData.timer.Start();
            }
            if (InterfaceElements.timer.remainingMillisec > 0)
            {
                InterfaceElements.timer.timer.Start();
            }
            
            Camera.SetCursorInCenter();
            unfreezeTimer.Start();
        }
        
        private static void UnfreezeTimerTick(object sender, EventArgs e)
        {
            unfreezeTimer.Stop();
            isGameFreezed = false;
            Scope.ControlScope(Mouse.RightButton, Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation);
        }

        private static void PauseGame()
        {
            FreezeGame();

            grPauseMenu.Visibility = Visibility.Visible;
        }

        private static void UnpauseGame()
        {
            grPauseMenu.Visibility = Visibility.Hidden;

            UnfreezeGame();
        }
    }
}
