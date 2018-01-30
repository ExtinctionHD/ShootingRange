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
using System.ComponentModel;

namespace ShootingRange.classes.Menu
{
    /// <summary>
    /// Логика взаимодействия для ChoiceDilog.xaml
    /// </summary>
    public partial class ChoiceDialog : UserControl
    {
        public ChoiceDialog()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(ChoiceDialog),
            new PropertyMetadata("Title")
        );

        public string SubTitle
        {
            get { return (string)GetValue(SubTitleProperty); }
            set { SetValue(SubTitleProperty, value); }
        }
        static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register(
            "SubTitle",
            typeof(string),
            typeof(ChoiceDialog),
            new PropertyMetadata("SubTitle")
        );
        
        public string Left
        {
            get { return (string)GetValue(LeftProperty); }
            set { SetValue(LeftProperty, value); }
        }
        static readonly DependencyProperty LeftProperty = DependencyProperty.Register(
            "Left",
            typeof(string),
            typeof(ChoiceDialog),
            new PropertyMetadata("Left")
        );

        public string Right
        {
            get { return (string)GetValue(RightProperty); }
            set { SetValue(RightProperty, value); }
        }
        static readonly DependencyProperty RightProperty = DependencyProperty.Register(
            "Right",
            typeof(string),
            typeof(ChoiceDialog),
            new PropertyMetadata("Right")
        );

        public double ButtonsWidth
        {
            get { return (double)GetValue(ButtonsWidthProperty); }
            set { SetValue(ButtonsWidthProperty, value); }
        }
        static readonly DependencyProperty ButtonsWidthProperty = DependencyProperty.Register(
            "ButtonsWidth",
            typeof(double),
            typeof(ChoiceDialog),
            new PropertyMetadata((double)120)
        );

        public event EventHandler LeftButtonClick;
        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            LeftButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RightButtonClick;
        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            RightButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
