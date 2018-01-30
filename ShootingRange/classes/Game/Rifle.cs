using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
using System.Windows.Threading;
using System.Media;
using ShootingRange.classes.Interface;

namespace ShootingRange.classes.Game
{
    class Rifle  // Реализует стрельбу
    {
        #region fields
        public const int TOTAL_BULLETS = 30;

        public static bool isNeedBolt;
        public static bool isShootAnimation;
        public static bool isBoltAnimation;
        public static bool isReloadAnimation;
        private static bool isReloadAnimPart1;

        public static int curBullets;
        public static int addBullets;
        private static int maxBulletsInMagazine;

        public static Image weaponModel;

        private static BitmapImage rifleModel;
        private static BitmapImage scopeModel;
        private static BitmapImage animatedShootZoomIn;
        private static BitmapImage animatedShootZoomOut;
        private static BitmapImage animatedBolt;
        private static BitmapImage animatedReload1;
        private static BitmapImage animatedReload2;

        private static Uri soundShoot;
        private static Uri soundBolt;
        private static Uri soundReload;
        private static Uri soundNoBullet;

        public struct TRecoilData
        {
            public DispatcherTimer timer;
            public Point initialPos;
            public int deltaY;
            public int ticksCount;
            public int maxTicksCount;
        }
        public static TRecoilData recoilData =  new TRecoilData();
        #endregion

        public Rifle(Image weaponModel, string weaponFolderName)
        {
            string weaponPath = "data/weapons/" + weaponFolderName + "/";

            InitBitmaps(weaponPath);
            InitWeaponSpecifications(weaponPath);
            InitSoundsUri(weaponPath);

            Rifle.weaponModel = weaponModel;
            isNeedBolt = false;
        }

        private static void InitBitmaps(string weaponPath)
        {
            rifleModel = StaticFunctions.LoadBitmapImage(weaponPath + "weapon.png");
            scopeModel = StaticFunctions.LoadBitmapImage(weaponPath + "scope.png");
            animatedShootZoomIn = StaticFunctions.LoadBitmapImage(weaponPath + "animShootZoomIn.gif");
            animatedShootZoomOut = StaticFunctions.LoadBitmapImage(weaponPath + "animShootZoomOut.gif");
            animatedBolt = StaticFunctions.LoadBitmapImage(weaponPath + "animBolt.gif");
            animatedReload1 = StaticFunctions.LoadBitmapImage(weaponPath + "animReload1.gif");
            animatedReload2 = StaticFunctions.LoadBitmapImage(weaponPath + "animReload2.gif");
        }

        private static void InitWeaponSpecifications(string weaponPath)
        {
            StreamReader sr = new StreamReader(weaponPath + "_specifications.ini");

            sr.ReadLine();
            maxBulletsInMagazine = Convert.ToInt32(sr.ReadLine());
            curBullets = maxBulletsInMagazine;
            addBullets = TOTAL_BULLETS - maxBulletsInMagazine;
            recoilData.deltaY = -Convert.ToInt32(sr.ReadLine());
            recoilData.maxTicksCount = Convert.ToInt32(sr.ReadLine());

            sr.Close();
        }
        
        private static void InitSoundsUri(string weaponPath)
        {
            soundShoot = new Uri(weaponPath + "soundShoot.wav", UriKind.Relative);
            soundBolt = new Uri(weaponPath + "soundBolt.wav", UriKind.Relative);
            soundReload = new Uri(weaponPath + "soundReload.wav", UriKind.Relative);
            soundNoBullet = new Uri(weaponPath + "soundNoBullet.wav", UriKind.Relative);
        }

        public static void Shoot(Point cursorPos, Point cursorScreenPos, bool isZoomIn, bool isAnimation)
        {
            if (isAnimation)
            {
                return;
            }
            if (curBullets == 0 || isNeedBolt)
            {
                StaticFunctions.PlaySound(soundNoBullet, GameModel.mediaPlayers);
                return;
            }

            curBullets--;
            InterfaceElements.bulletsCounter.ChangeBulletsCount(curBullets, addBullets);
            ListOfTargets.ControlOfHit(cursorPos, isZoomIn);
            StartShootAnimation(isZoomIn);
            StartRecoil(cursorScreenPos);
            isNeedBolt = true;
        }

        private static void StartRecoil(Point cursorScreenPos)
        {
            const int RECOIL_INTERVAL_IN_MILISECONDS = 25;

            recoilData.initialPos = cursorScreenPos;
            recoilData.ticksCount = 0;

            if (recoilData.timer != null)
            {
                recoilData.timer.Stop();
            }
            recoilData.timer = new DispatcherTimer();
            recoilData.timer.Interval = new TimeSpan(0, 0, 0, 0, RECOIL_INTERVAL_IN_MILISECONDS);
            recoilData.timer.Tick += new EventHandler(RecoilTick);
            recoilData.timer.Start();
        }

        private static void RecoilTick(object sender, EventArgs e)
        {
            Point cursorScreenPos = recoilData.initialPos;
            if (recoilData.ticksCount < recoilData.maxTicksCount / 2)
            {
                cursorScreenPos.Offset(0, recoilData.deltaY);
                recoilData.ticksCount++;
            }
            else
            {
                cursorScreenPos.Offset(0, -recoilData.deltaY);
                recoilData.ticksCount++;
            }

            GameModel.MoveCamera(cursorScreenPos);

            if (recoilData.ticksCount >= recoilData.maxTicksCount)
            {
                recoilData.timer.Stop();
            }
        }

        private static void StartShootAnimation(bool isZoomIn)
        {
            StaticFunctions.PlaySound(soundShoot, GameModel.mediaPlayers);

            isShootAnimation = true;

            if (isZoomIn)
            {
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedShootZoomIn);
            }
            else
            {
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedShootZoomOut);
            }
        }

        public static void CompleteShootAnimation(bool isZoomIn)
        {
            isShootAnimation = false;

            if (curBullets == 0 && addBullets == 0)
            {
                InterfaceElements.ShowVictoryDlg();
                return;
            }

            if (isZoomIn)
            {
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, null);
                weaponModel.Source = scopeModel;
            }
            else
            {
                StartBoltAnimation();
            }
        }

        public static void StartBoltAnimation()
        {
            StaticFunctions.PlaySound(soundBolt, GameModel.mediaPlayers);

            isBoltAnimation = true;

            WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedBolt);
        }

        public static void CompleteBoltAnimation()
        {
            WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, null);
            weaponModel.Source = rifleModel;

            isBoltAnimation = false;
            isNeedBolt = false;
        }
   
        public static void Reload(bool isZoomIn, bool isAnimation)
        {
            if (isZoomIn || isAnimation || addBullets == 0 || curBullets == maxBulletsInMagazine)
            {
                return;
            }

            StaticFunctions.PlaySound(soundReload, GameModel.mediaPlayers);

            StartReloadAnimation();
        }

        private static void StartReloadAnimation()
        {
            isReloadAnimation = true;

            if (!isReloadAnimPart1)
            {
                isReloadAnimPart1 = true;
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedReload1);
            }
            else
            {
                isReloadAnimPart1 = false;
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, animatedReload2);
            }
        }

        public static void CompleteReloadAnimation()
        {
            if (isReloadAnimPart1)
            {
                StartReloadAnimation();
            }
            else
            {
                WpfAnimatedGif.ImageBehavior.SetAnimatedSource(weaponModel, null);
                weaponModel.Source = rifleModel;

                isReloadAnimation = false;

                addBullets += curBullets;
                if (addBullets >= maxBulletsInMagazine)
                {
                    curBullets = maxBulletsInMagazine;
                }
                else
                {
                    curBullets = addBullets;
                }
                addBullets -= curBullets;

                InterfaceElements.bulletsCounter.ChangeBulletsCount(curBullets, addBullets);

                isNeedBolt = false;
            }
        }
    }

}
