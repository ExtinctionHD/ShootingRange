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

namespace ShootingRange.classes.Menu
{
    /// <summary>
    /// Логика взаимодействия для StatsGrid.xaml
    /// </summary>
    public partial class StatsGrid : UserControl
    {
        public StatsGrid()
        {
            InitializeComponent();
        }

        public string Kills
        {
            get { return (string)GetValue(KillsProperty); }
            set { SetValue(KillsProperty, value); }
        }
        static readonly DependencyProperty KillsProperty = DependencyProperty.Register(
            "Kills",
            typeof(string),
            typeof(StatsGrid)
        );

        public string Headshots
        {
            get { return (string)GetValue(HeadshotsProperty); }
            set { SetValue(HeadshotsProperty, value); }
        }
        static readonly DependencyProperty HeadshotsProperty = DependencyProperty.Register(
            "Headshots",
            typeof(string),
            typeof(StatsGrid)
        );

        public string Accuracy
        {
            get { return (string)GetValue(AccuracyProperty); }
            set { SetValue(AccuracyProperty, value); }
        }
        static readonly DependencyProperty AccuracyProperty = DependencyProperty.Register(
            "Accuracy",
            typeof(string),
            typeof(StatsGrid)
        );

        public string KPS
        {
            get { return (string)GetValue(KPSProperty); }
            set { SetValue(KPSProperty, value); }
        }
        static readonly DependencyProperty KPSProperty = DependencyProperty.Register(
            "KPS",
            typeof(string),
            typeof(StatsGrid)
        );

        public string PlayTime
        {
            get { return (string)GetValue(PlayTimeProperty); }
            set { SetValue(PlayTimeProperty, value); }
        }
        static readonly DependencyProperty PlayTimeProperty = DependencyProperty.Register(
            "PlayTime",
            typeof(string),
            typeof(StatsGrid)
        );

        public string BonusTime
        {
            get { return (string)GetValue(BonusTimeProperty); }
            set { SetValue(BonusTimeProperty, value); }
        }
        static readonly DependencyProperty BonusTimeProperty = DependencyProperty.Register(
            "BonusTime",
            typeof(string),
            typeof(StatsGrid)
        );

        public event EventHandler ReturnButtonClick;
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            ReturnButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
