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
using System.Windows.Media.Effects;
using System.Runtime.InteropServices;
using System.Windows.Threading;
using System.Media;
using System.Timers;
using ShootingRange.classes.Menu;
using ShootingRange.classes.Game;

namespace ShootingRange.classes.Interface
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : UserControl
    {
        #region fields
        public const int ONE_TICK = 10;
        public int remainingMillisec;
        public int playTime;
        public DispatcherTimer timer = new DispatcherTimer
        {
            Interval = new TimeSpan(0, 0, 0, 0, ONE_TICK)
        };
        #endregion

        public Timer(int remainingMillisec)
        {
            InitializeComponent();
            this.remainingMillisec = remainingMillisec;
            playTime = remainingMillisec;
            timer.Tick += new EventHandler(TimerTick);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            remainingMillisec -= ONE_TICK;
            ChangeTime(remainingMillisec);

            if (remainingMillisec <= 0)
            {
                timer.Stop();
                InterfaceElements.ShowDefeatDlg();
            }
        }

        private void ChangeTime(int millisec)
        {
            string timeFormat = ConvertToTime(millisec);

            for (int i = 0; i < 8; i += 3)
            {
                Label lbl = (Label)grMain.Children[i];
                lbl.Content = timeFormat[i];
                lbl = (Label)grMain.Children[i + 1];
                lbl.Content = timeFormat[i + 1];
            }
        }

        public static string ConvertToTime(int millisec)
        {
            const int MILLISEC_IN_SEC = 1000;
            const int SEC_IN_MINUTE = 60;
            const int MIN_IN_HOUR = 60;

            int minutes = millisec / (MILLISEC_IN_SEC * SEC_IN_MINUTE);
            millisec %= (MILLISEC_IN_SEC * SEC_IN_MINUTE);

            int sec = millisec / MILLISEC_IN_SEC;
            millisec %= MILLISEC_IN_SEC;

            string timeFormat = "";
            if (minutes / MIN_IN_HOUR > 0)
            {
                int hour = minutes / MIN_IN_HOUR;
                minutes %= MIN_IN_HOUR;

                if (hour > 9)
                {
                    timeFormat += hour.ToString();
                }
                else
                {
                    timeFormat += "0" + hour.ToString();
                }
                timeFormat += ":";
            }
            if (minutes > 9)
            {
                timeFormat += minutes.ToString();
            }
            else
            {
                timeFormat += "0" + minutes.ToString();
            }
            timeFormat += ":";
            if (sec > 9)
            {
                timeFormat += sec.ToString();
            }
            else
            {
                timeFormat += "0" + sec.ToString();
            }
            timeFormat += ":";
            millisec /= 10;
            if (millisec > 9)
            {
                timeFormat += millisec.ToString();
            }
            else
            {
                timeFormat += "0" + millisec.ToString();
            }

            return timeFormat;
        }
    }
}
