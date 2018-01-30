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
    /// Логика взаимодействия для GrBulletsCounter.xaml
    /// </summary>
    public partial class BulletsCounter : UserControl
    {
        public BulletsCounter()
        {
            InitializeComponent();
        }

        public void ChangeBulletsCount(int curBullets, int totalBullets)
        {
            this.curBullets.Content = Convert.ToString(curBullets);
            this.totalBullets.Content = Convert.ToString(totalBullets);
        }
    }
}
