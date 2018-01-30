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
using System.Windows.Media.Animation;
using ShootingRange.classes.Game;
using System.IO;

namespace ShootingRange.classes.Menu
{
    /// <summary>
    /// Логика взаимодействия для LvlPreview.xaml
    /// </summary>
    public partial class LvlPreview : UserControl
    {
        Storyboard rectangeShow;
        Storyboard rectangeHide;
        Storyboard contentShow;
        Storyboard contentHide;

        public LvlPreview()
        {
            InitializeComponent();

            BitmapImage bitmap = new BitmapImage();

            if (LvlName != null)
            {
                imgLvl.Source = LoadLvlImage(LvlName);
                InitLabels(LvlName);
            }
        }
        
        private BitmapImage LoadLvlImage(string lvlName)
        {
            string uri = "data/levels/" + lvlName + "/preview.jpg";

            return StaticFunctions.LoadBitmapImage(uri);
        }

        public void InitLabels(string lvlName)
        {
            if (lvlName == null)
            {
                return;
            }

            string uri = "data/levels/" + lvlName + "/_lvlData.ini";
            StreamReader sr = new StreamReader(uri, Encoding.Default);

            lblRecord.Content = "Рекорд: " + sr.ReadLine();
            lblTitle.Content = (sr.ReadLine()).ToUpper();

            sr.Close();
        }

        private Storyboard InitOpacityAnimation(FrameworkElement el, double from, double to, double time, double priority)
        {
            DoubleAnimation opaciytAnimation = new DoubleAnimation();
            opaciytAnimation.From = from;
            opaciytAnimation.To = to;
            opaciytAnimation.Duration = new Duration(TimeSpan.FromSeconds(time));
            opaciytAnimation.BeginTime = TimeSpan.FromSeconds(priority * time);

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opaciytAnimation);
            Storyboard.SetTargetName(opaciytAnimation, el.Name);
            Storyboard.SetTargetProperty(opaciytAnimation, new PropertyPath(OpacityProperty));

            return storyboard;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            double time = 0.2;

            rectangeShow = InitOpacityAnimation(rctDark, rctDark.Opacity, 1, time * 2, 0);
            rectangeShow.Begin(this);

            contentShow = InitOpacityAnimation(lblTitle, lblTitle.Opacity, 1, time, 0);
            contentShow.Begin(this);

            contentShow = InitOpacityAnimation(lblRecord, lblRecord.Opacity, 1, time, 1);
            contentShow.Begin(this);

            contentShow = InitOpacityAnimation(btnStart, btnStart.Opacity, 1, time, 2);
            contentShow.Begin(this);
        }

        private void controlLvlPreview_MouseLeave(object sender, MouseEventArgs e)
        {
            double time = 0.2;

            rectangeHide = InitOpacityAnimation(rctDark, rctDark.Opacity, 0, time * 2, 1);
            rectangeHide.Begin(this);

            contentHide = InitOpacityAnimation(btnStart, btnStart.Opacity, 0, time, 0);
            contentHide.Begin(this);

            contentHide = InitOpacityAnimation(lblRecord, lblRecord.Opacity, 0, time, 1);
            contentHide.Begin(this);

            contentHide = InitOpacityAnimation(lblTitle, lblTitle.Opacity, 0, time, 2);
            contentHide.Begin(this);
        }

        public event EventHandler LvlPreviewClick;
        private void lvlPreview_Click(object sender, RoutedEventArgs e)
        {
            LvlPreviewClick?.Invoke(this, EventArgs.Empty);
        }

        public string LvlName
        {
            get { return (string)GetValue(LvlNameProperty); }
            set
            {
                SetValue(LvlNameProperty, value);
                imgLvl.Source = LoadLvlImage(LvlName);
                InitLabels(LvlName);
            }
        }
        static readonly DependencyProperty LvlNameProperty = DependencyProperty.Register(
            "LvlName",
            typeof(string),
            typeof(LvlPreview)
        );
    }
}

