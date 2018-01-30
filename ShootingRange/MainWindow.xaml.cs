using ShootingRange.classes.Game;
using ShootingRange.classes.Interface;
using ShootingRange.classes.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace ShootingRange
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        GameModel gameModel;
        Soundtrack soundtrack;
        DispatcherTimer startGameTimer;

        public MainWindow()
        {
            InitializeComponent();

            startGameTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 200)
            };
            startGameTimer.Tick += new EventHandler(StartGameTimerTick);

            soundtrack = new Soundtrack();
        }

        private void StartGameTimerTick(object sender, EventArgs e)
        {
            startGameTimer.Stop();
            
            gameModel = new GameModel(grMain, grMainMenu.lvlPreview.LvlName, "M98B");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            grMainMenu.LvlsList = InitLevelsList();

            foreach (UIElement el in grMain.Children)
            {
                if (el is MainMenuGrid)
                {
                    el.Visibility = Visibility.Visible;
                }
                else
                {
                    el.Visibility = Visibility.Hidden;
                }
            }
        }

        private List<string> InitLevelsList()
        {
            List<string> levelsList = Directory.GetDirectories("data/levels").ToList();
            for (int i = 0; i < levelsList.Count; i++)
            {
                levelsList[i] = levelsList[i].Split('\\').Last();
            }
            return levelsList;
        }

        private void grGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (GameModel.isGameFreezed || !GameModel.isModelReady)
            {
                return;
            }

            Point cursorScreenPos = PointToScreen(e.GetPosition(this));
            GameModel.MoveCamera(cursorScreenPos);
        }

        private void grGame_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GameModel.isGameFreezed || !GameModel.isModelReady)
            {
                return;
            }

            Scope.ZoomIn(Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation);
        }

        private void grGame_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (GameModel.isGameFreezed || !GameModel.isModelReady)
            {
                return;
            }

            Scope.ZoomOut(Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation);
        }

        private void grGame_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (GameModel.isGameFreezed || !GameModel.isModelReady)
            {
                return;
            }

            Point cursorScreenPos = PointToScreen(e.GetPosition(this));
            bool isAnimation = Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation;
            Rifle.Shoot(e.GetPosition(this), cursorScreenPos, Scope.isZoomIn, isAnimation);
        }

        public void imgCharacterModel_AnimationCompleted(object sender, EventArgs e)
        {
            if (Rifle.isBoltAnimation)
            {
                Rifle.CompleteBoltAnimation();
            }
            if (Scope.isScopeAnimation)
            {
                Scope.CompleteScopeAnimation(Rifle.isNeedBolt);
            }
            if (Rifle.isShootAnimation)
            {
                Rifle.CompleteShootAnimation(Scope.isZoomIn);
            }
            if (Rifle.isReloadAnimation)
            {
                Rifle.CompleteReloadAnimation();
            }

            if (grGame.Visibility == Visibility.Visible
                    && dlgDefeat.Visibility == Visibility.Hidden
                    && dlgVictory.Visibility == Visibility.Hidden
                    && grStats.Visibility == Visibility.Hidden)
            {
                Scope.ControlScope(Mouse.RightButton, Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            BooleanToVisibilityConverter visibilityConverter = new BooleanToVisibilityConverter();
            
            if (e.Key == Key.Escape)
            {
                if ((bool)visibilityConverter.ConvertBack(grGame.Visibility, null, null, null)
                    && !(bool)visibilityConverter.ConvertBack(dlgDefeat.Visibility, null, null, null)
                    && !(bool)visibilityConverter.ConvertBack(dlgVictory.Visibility, null, null, null)
                    && !(bool)visibilityConverter.ConvertBack(grStats.Visibility, null, null, null)
                    && GameModel.isLoadTimerEnd)
                {
                    GameModel.Pause = !GameModel.Pause;
                }
            }
            if (e.Key == Key.R)
            {
                if (!GameModel.isModelReady)
                {
                    return;
                }

                Rifle.Reload(Scope.isZoomIn, Rifle.isBoltAnimation || Rifle.isShootAnimation || Rifle.isReloadAnimation || Scope.isScopeAnimation);
            }
            if (e.Key == Key.S)
            {
                Soundtrack.NextTrack();
            }
        }

        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            GameModel.Pause = false;

        }

        private void btnPauseRestart_Click(object sender, EventArgs e)
        {
            grLoadScreen.Visibility = Visibility.Visible;
            InterfaceElements.ShowDefeatDlg();

            startGameTimer.Start();
        }

        private void btnPauseMainMenu_Click(object sender, EventArgs e)
        {
            foreach (UIElement el in grMain.Children)
            {
                if (el is MainMenuGrid)
                {
                    el.Visibility = Visibility.Visible;
                }
                else
                {
                    el.Visibility = Visibility.Hidden;
                }
            }
            gameModel = null;
        }

        private void dlg_StartGame(object sender, EventArgs e)
        {
            grLoadScreen.Visibility = Visibility.Visible;
            grMainMenu.Visibility = Visibility.Hidden;

            startGameTimer.Start();
        }

        private void dlg_Continue(object sender, EventArgs e)
        {
            foreach (UIElement el in grMain.Children)
            {
                if (el is MainMenuGrid)
                {
                    el.Visibility = Visibility.Visible;
                }
                else
                {
                    el.Visibility = Visibility.Hidden;
                }
            }
            gameModel = null;
        }

        private void dlgVictory_ShowStats(object sender, EventArgs e)
        {
            InterfaceElements.ShowStats();
        }

        private void grStats_btnReturnClick(object sender, EventArgs e)
        {
            InterfaceElements.HideStats();
        }

        private void grGame_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                Soundtrack.PlayGameTrack();
            }
        }
    }
}
