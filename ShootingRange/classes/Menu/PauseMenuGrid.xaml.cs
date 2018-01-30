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
    /// Логика взаимодействия для PauseMenuGrid.xaml
    /// </summary>
    public partial class PauseMenuGrid : UserControl
    {
        public PauseMenuGrid()
        {
            InitializeComponent();
        }
        
        public event EventHandler BtnResumeClick;
        private void btnResume_Click(object sender, EventArgs e)
        {
            BtnResumeClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler BtnRestartClick;
        private void btnRestart_Click(object sender, EventArgs e)
        {
            BtnRestartClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler BtnMainMenuClick;
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            BtnMainMenuClick?.Invoke(this, EventArgs.Empty);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    
}
