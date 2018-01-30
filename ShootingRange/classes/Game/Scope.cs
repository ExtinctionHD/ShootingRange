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
using System.Windows.Media.Imaging;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace ShootingRange.classes.Game
{
    public class Scope  // Реализацует прицеливание
    {
        #region fields
        private const double BLUR_RADIUS = 3;

        public static bool isScopeAnimation;
        public static bool isZoomIn;

        private static Image weaponModel;

        private static Image bg;
        private static Image bgScopeVert;
        private static Image bgScopeHoriz;

        private static BitmapImage weapon;
        private static BitmapImage scope;
        private static BitmapImage animatedZoomIn;
        private static BitmapImage animatedZoomOut;

        private static Uri soundZoomIn;
        private static Uri soundZoomOut;
        #endregion

        public Scope(Image bg, Image bgScopeVert, Image bgScopeHoriz, Image weaponModel, string weaponFolderName)
        {
            string weaponPath = "data/weapons/" + weaponFolderName + "/";

            InitBitmaps(weaponPath);
            InitSoundsUri(weaponPath);

            Scope.bg = bg;
            Scope.bgScopeVert = bgScopeVert;
            Scope.bgScopeHoriz = bgScopeHoriz;
            Scope.weaponModel = weaponModel;

            Scope.weaponModel.Height = SystemParameters.PrimaryScreenHeight;
            Scope.weaponModel.Visibility = Visibility.Visible;
        }

        private static void InitBitmaps(string weaponPath)
        {
            weapon = StaticFunctions.LoadBitmapImage(weaponPath + "weapon.png");
            scope = StaticFunctions.LoadBitmapImage(weaponPath + "scope.png");
            animatedZoomIn = StaticFunctions.LoadBitmapImage(weaponPath + "animZoomIn.gif");
            animatedZoomOut = StaticFunctions.LoadBitmapImage(weaponPath + "animZoomOut.gif");
        }

        private static void InitSoundsUri(string weaponPath)
        {
            soundZoomIn = new Uri(weaponPath + "soundZoomIn.wav", UriKind.Relative);
            soundZoomOut = new Uri(weaponPath + "soundZoomOut.wav", UriKind.Relative);
        }

        public static void ZoomIn(bool isAnimation)
        {
            if (isAnimation || isZoomIn)
            {
                return;
            }

            isZoomIn = true;
            StaticFunctions.PlaySound(soundZoomIn, GameModel.mediaPlayers);
            StartScopeAnimation(animatedZoomIn);
        }

        public static void ZoomOut(bool isAnimation)
        {
            if (isAnimation|| !isZoomIn)
            {
                return;
            }

            Canvas bgCanvas = (Canvas)bg.Parent;
            bgCanvas.Effect = null;

            Canvas bgScopeCanvas = (Canvas)bgScopeVert.Parent;
            bgScopeCanvas.Visibility = Visibility.Hidden;
            bgScopeCanvas = (Canvas)bgScopeHoriz.Parent;
            bgScopeCanvas.Visibility = Visibility.Hidden;

            isZoomIn = false;
            StaticFunctions.PlaySound(soundZoomOut, GameModel.mediaPlayers);
            StartScopeAnimation(animatedZoomOut);
        }

        private static void StartScopeAnimation(BitmapImage animatedSource)
        {
            isScopeAnimation = true;
            WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedSource);
        }

        public static void CompleteScopeAnimation(bool isNeedBolt)
        {
            if (isZoomIn)
            {
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, null);
                weaponModel.Source = scope;

                Canvas bgScopeCanvas = (Canvas)bgScopeVert.Parent;
                bgScopeCanvas.Visibility = Visibility.Visible;
                bgScopeCanvas = (Canvas)bgScopeHoriz.Parent;
                bgScopeCanvas.Visibility = Visibility.Visible;

                BlurEffect blur = new BlurEffect();
                blur.Radius = BLUR_RADIUS;

                Canvas bgCanvas = (Canvas)bg.Parent;
                bgCanvas.Effect = blur;

                isScopeAnimation = false;
            }
            else
            {
                isScopeAnimation = false;

                if (isNeedBolt)
                {
                    Rifle.StartBoltAnimation();
                }
                else
                {
                    WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, null);
                    weaponModel.Source = weapon;
                }
            }
        }

        public static void ControlScope(MouseButtonState rightButton, bool isAnimation)
        {
            if (rightButton == MouseButtonState.Pressed && !isZoomIn)
            {
                ZoomIn(isAnimation);
            }
            if (rightButton == MouseButtonState.Released && isZoomIn)
            {
                ZoomOut(isAnimation);
            }
        }
    }
}
