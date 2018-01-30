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

namespace ShootingRange.classes.Interface
{
    /// <summary>
    /// Логика взаимодействия для KillsCounter.xaml
    /// </summary>
    public partial class KillsCounter : UserControl
    {
        #region fields
        public int killsCount;
        public int headshotCount;
        #endregion

        public KillsCounter()
        {
            InitializeComponent();

            killsCount = 0;
            lblKillsCount.Content = killsCount.ToString();
        }

        public void IncKillsCount()
        {
            killsCount++;
            lblKillsCount.Content = killsCount.ToString();
        }

        public void IncHeadshotCount()
        {
            headshotCount++;
        }
    }
}
