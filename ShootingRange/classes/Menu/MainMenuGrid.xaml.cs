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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ShootingRange.classes.Interface;

namespace ShootingRange.classes.Menu
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenuGrid : UserControl
    {
        public int i;

        public MainMenuGrid()
        {
            InitializeComponent();
        }

        private void controlMainMenu_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            lvlPreview.InitLabels(lvlPreview.LvlName);
            LoadStats();

            if ((bool)e.NewValue)
            {
                Soundtrack.PlayMenuTrack();
            }
        }

        private void LoadStats()
        {
            string path = "data/_stats.ini";
            
            Shoots = "0";
            Kills = "0";
            Headshots = "0";
            Winrate = "0 %";
            Accuracy = "0 % ";
            KPS = "0.00";
            PlayTime = "00:00:00";
            Games = "0";
            Score = "0";

            try
            {
                StreamReader sr = new StreamReader(path, Encoding.Default);
                
                const int STATS_N = 7;
                string[] stats = new string[STATS_N];  // Выстрелов, убийств, в голову, побед, поражений, время, счёт

                for (int i = 0; i < STATS_N; i++)
                {
                    stats[i] = sr.ReadLine();
                }
                sr.Close();

                Shoots = stats[0];
                Kills = stats[1];
                Headshots = stats[2];
                Winrate = (Convert.ToInt32(stats[3]) * 100 / (Convert.ToInt32(stats[3]) + Convert.ToInt32(stats[4]))).ToString() + "%";
                Accuracy = (Convert.ToInt32(stats[1]) * 100 / (Convert.ToInt32(stats[0]))).ToString() + "%";
                KPS = (Convert.ToInt32(stats[1]) / ((double)Convert.ToInt32(stats[5]) / 1000)).ToString("0.##");
                PlayTime = Timer.ConvertToTime(Convert.ToInt32(stats[5]));
                if (PlayTime.Length == 8)
                {
                    PlayTime = "00:" + PlayTime.Substring(0, 5);
                }
                else
                {
                    PlayTime = PlayTime.Substring(0, 8);
                }
                Games = (Convert.ToInt32(stats[3]) + Convert.ToInt32(stats[4])).ToString();
                Score = stats[6];
            }
            catch
            {
            }
        }

        public event EventHandler LvlPreviewClick;
        private void lvlPreview_Click(object sender, EventArgs e)
        {
            LvlPreviewClick?.Invoke(this, EventArgs.Empty);
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (i < LvlsList.Count - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            lvlPreview.LvlName = LvlsList[i];
        }
        
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
            }
            else
            {
                i = LvlsList.Count - 1;
            }
            lvlPreview.LvlName = LvlsList[i];
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public List<string> LvlsList
        {
            get { return (List<string>)GetValue(LvlsListProperty); }
            set
            {
                SetValue(LvlsListProperty, value);
                lvlPreview.LvlName = LvlsList[i];
            }
        }
        static readonly DependencyProperty LvlsListProperty = DependencyProperty.Register(
            "LvlsList",
            typeof(List<string>),
            typeof(MainMenuGrid)
        );

        public string Shoots
        {
            get { return (string)GetValue(ShootsProperty); }
            set { SetValue(ShootsProperty, value); }
        }
        static readonly DependencyProperty ShootsProperty = DependencyProperty.Register(
            "Shoots",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Kills
        {
            get { return (string)GetValue(KillsProperty); }
            set { SetValue(KillsProperty, value); }
        }
        static readonly DependencyProperty KillsProperty = DependencyProperty.Register(
            "Kills",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Headshots
        {
            get { return (string)GetValue(HeadshotsProperty); }
            set { SetValue(HeadshotsProperty, value); }
        }
        static readonly DependencyProperty HeadshotsProperty = DependencyProperty.Register(
            "Headshots",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Winrate
        {
            get { return (string)GetValue(WinrateProperty); }
            set { SetValue(WinrateProperty, value); }
        }
        static readonly DependencyProperty WinrateProperty = DependencyProperty.Register(
            "Winrate",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Accuracy
        {
            get { return (string)GetValue(AccuracyProperty); }
            set { SetValue(AccuracyProperty, value); }
        }
        static readonly DependencyProperty AccuracyProperty = DependencyProperty.Register(
            "Accuracy",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string KPS
        {
            get { return (string)GetValue(KPSProperty); }
            set { SetValue(KPSProperty, value); }
        }
        static readonly DependencyProperty KPSProperty = DependencyProperty.Register(
            "KPS",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string PlayTime
        {
            get { return (string)GetValue(PlayTimeProperty); }
            set { SetValue(PlayTimeProperty, value); }
        }
        static readonly DependencyProperty PlayTimeProperty = DependencyProperty.Register(
            "PlayTime",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Games
        {
            get { return (string)GetValue(GamesProperty); }
            set { SetValue(GamesProperty, value); }
        }
        static readonly DependencyProperty GamesProperty = DependencyProperty.Register(
            "Games",
            typeof(string),
            typeof(MainMenuGrid)
        );

        public string Score
        {
            get { return (string)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }
        static readonly DependencyProperty ScoreProperty = DependencyProperty.Register(
            "Score",
            typeof(string),
            typeof(MainMenuGrid)
        );
    }
}
