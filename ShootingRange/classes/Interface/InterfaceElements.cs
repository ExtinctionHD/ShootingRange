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
using System.IO;
using ShootingRange.classes.Game;
using ShootingRange.classes.Menu;

namespace ShootingRange.classes.Interface
{
    public class InterfaceElements
    {
        #region fields
        private readonly Brush interfaceForeground = Brushes.White;
        private const int START_REM_TIME = 5000;

        public static BulletsCounter bulletsCounter;
        public static Timer timer;
        public static KillsCounter killsCounter;

        public static StatsGrid grStats;
        public static ChoiceDialog dlgDefeat;
        public static ChoiceDialog dlgVictory;
        #endregion

        public InterfaceElements(Grid grGame, StatsGrid grStats,
                                 ChoiceDialog dlgDefeat, ChoiceDialog dlgVictory)
        {
            InterfaceElements.grStats = grStats;
            InterfaceElements.dlgDefeat = dlgDefeat;
            InterfaceElements.dlgVictory = dlgVictory;

            bulletsCounter = new BulletsCounter()
            {
                Foreground = interfaceForeground
            };

            timer =  new Timer(START_REM_TIME)
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(25, 0, 25, 15),
                Foreground = interfaceForeground
            };

            killsCounter = new KillsCounter()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(25, 25, 25, 0),
                Foreground = interfaceForeground
            };

            InterfaceElContainer container = new InterfaceElContainer(bulletsCounter)
            {
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom
            };
            Grid.SetZIndex(container, 2);
            grGame.Children.Add(container);

            container = new InterfaceElContainer(killsCounter, timer)
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Height = 200
            };
            Grid.SetZIndex(container, 2);
            grGame.Children.Add(container);
        }

        public static void ShowDefeatDlg()
        {
            GameModel.FreezeGame();
            GameModel.isModelReady = false;

            dlgDefeat.Visibility = Visibility.Visible;
            UpdateStats(Rifle.TOTAL_BULLETS - Rifle.curBullets - Rifle.addBullets, false);
        }

        public static void ShowVictoryDlg()
        {
            GameModel.FreezeGame();
            GameModel.isModelReady = false;

            CalculateStats();
            int score = CalculateScore();
            dlgVictory.SubTitle = "Результат: " + score.ToString();
            dlgVictory.Visibility = Visibility.Visible;

            UpdateRecord(GameModel.lvlName, score);
            UpdateStats(Rifle.TOTAL_BULLETS, true);
        }

        private static void CalculateStats()
        {
            int playTime = timer.playTime - timer.remainingMillisec;

            grStats.Kills = killsCounter.killsCount.ToString();
            grStats.Headshots = killsCounter.headshotCount.ToString();
            grStats.Accuracy = (killsCounter.killsCount * 100 / Rifle.TOTAL_BULLETS).ToString() + "%";
            grStats.KPS = (killsCounter.killsCount / ((double)playTime / 1000)).ToString("0.##");
            grStats.PlayTime = Timer.ConvertToTime(playTime);
            grStats.BonusTime = Timer.ConvertToTime(timer.remainingMillisec);
        }

        private static int CalculateScore()
        {
            int playTime = timer.playTime - timer.remainingMillisec;
            int result = (int)(((killsCounter.killsCount + killsCounter.headshotCount) / (double)playTime * 1000) * (timer.remainingMillisec + 1000));

            return result;
        }

        private static bool UpdateRecord(string lvlName, int score)
        {
            bool isNewRecord;
            string path = "data/levels/" + lvlName + "/_lvlData.ini";

            StreamReader sr = new StreamReader(path, Encoding.Default);
            string record = sr.ReadLine();
            string temp = sr.ReadToEnd();
            sr.Close();

            if (score > Convert.ToInt32(record))
            {
                isNewRecord = true;

                StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
                sw.WriteLine(score.ToString());
                sw.Write(temp);
                sw.Close();
            }
            else
            {
                isNewRecord = false;
            }

            return isNewRecord;
        }

        private static void UpdateStats(int shoots, bool isWin)
        {
            string path = "data/_stats.ini";

            StreamReader sr = new StreamReader(path, Encoding.Default);

            const int STATS_N = 7;
            string[] stats = new string[STATS_N];  // Выстрелов, убийств, в голову, побед, поражений, время, счёт

            if (!sr.EndOfStream)
            {
                for (int i = 0; i < STATS_N; i++)
                {
                    stats[i] = sr.ReadLine();
                }

                stats[0] = (Convert.ToInt32(stats[0]) + shoots).ToString();
                stats[1] = (Convert.ToInt32(stats[1]) + killsCounter.killsCount).ToString();
                stats[2] = (Convert.ToInt32(stats[2]) + killsCounter.headshotCount).ToString();
                stats[3] = (Convert.ToInt32(stats[3]) + Convert.ToInt32(isWin)).ToString();
                stats[4] = (Convert.ToInt32(stats[4]) + Convert.ToInt32(!isWin)).ToString();
                stats[5] = (Convert.ToInt32(stats[5]) + timer.playTime - timer.remainingMillisec).ToString();
                if (isWin)
                {
                    stats[6] = (Convert.ToInt32(stats[6]) + CalculateScore()).ToString();
                }
            }
            else
            {
                stats[0] = shoots.ToString();
                stats[1] = killsCounter.killsCount.ToString();
                stats[2] = killsCounter.headshotCount.ToString();
                stats[3] = Convert.ToInt32(isWin).ToString();
                stats[4] = Convert.ToInt32(!isWin).ToString();
                stats[5] = (timer.playTime - timer.remainingMillisec).ToString();
                if (isWin)
                {
                    stats[6] = CalculateScore().ToString();
                }
                else
                {
                    stats[6] = "0";
                }
            }
            sr.Close();

            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            for (int i = 0; i < STATS_N; i++)
            {
                sw.WriteLine(stats[i]);
            }
            sw.Close();
        }

        public static void ShowStats()
        {
            GameModel.FreezeGame();
            dlgVictory.Visibility = Visibility.Hidden;

            grStats.Visibility = Visibility.Visible;
        }

        public static void HideStats()
        {
            grStats.Visibility = Visibility.Hidden;
            dlgVictory.Visibility = Visibility.Visible;
        }
    }
}
