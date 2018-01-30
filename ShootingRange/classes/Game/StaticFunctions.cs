using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

namespace ShootingRange.classes.Game
{
    static class StaticFunctions  // Дополнительные ф-ции
    {
        public static Random myRandom = new Random();

        public static BitmapImage LoadBitmapImage(string uri)
        {
            BitmapImage bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(Environment.CurrentDirectory + '\\' + uri, UriKind.Absolute);
            bitmap.EndInit();

            return bitmap;
        }

        public static double[] ReadLineWithDouble(StreamReader sr)
        {
            string[] dataStr = sr.ReadLine().Replace(".", ",").Split();
            double[] dataDouble = new double[dataStr.Length];

            for (int i = 0; i < dataStr.Length; i++)
            {
                dataDouble[i] = Convert.ToDouble(dataStr[i]);
            }

            return dataDouble;
        }

        public static void PlaySound(Uri sound, List<MediaPlayer> mediaPlayers)
        {
            if (!GameModel.isModelReady)
            {
                return;
            }

            mediaPlayers.Add(new MediaPlayer());

            MediaPlayer mp = mediaPlayers.Last();
            mp.Open(sound);           
            mp.Play();

            mediaPlayers.RemoveAll(x => x.Position == x.NaturalDuration);
        }
    }
}
