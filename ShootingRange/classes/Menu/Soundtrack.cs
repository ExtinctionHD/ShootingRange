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
    class Soundtrack
    {
        public static MediaPlayer player = new MediaPlayer
        {
            Volume = 0.1,
        };

        public static List<Uri> curPlaylist;
        private static List<Uri> gamePlaylist = new List<Uri>();
        private static List<Uri> menuPlaylist = new List<Uri>();

        public Soundtrack()
        {
            string[] gameTracksPath;
            string[] menuTracksPath;

            player.MediaEnded += MediaEnded;

            gameTracksPath = Directory.GetFiles("data/soundtrack/Game");
            menuTracksPath = Directory.GetFiles("data/soundtrack/Menu");

            foreach (string trackPath in gameTracksPath)
            {
                gamePlaylist.Add(new Uri(trackPath, UriKind.Relative));
            }
            foreach (string trackPath in menuTracksPath)
            {
                menuPlaylist.Add(new Uri(trackPath, UriKind.Relative));
            }
        }

        private void MediaEnded(object sender, EventArgs e)
        {
            NextTrack();
        }

        public static void NextTrack()
        {
            int i;
            do
            {
                i = StaticFunctions.myRandom.Next(curPlaylist.Count);
            }
            while (curPlaylist[i] == player.Source);

            player.Open(curPlaylist[i]);
            player.Play();
        }

        public static void PlayMenuTrack()
        {
            curPlaylist = menuPlaylist;

            player.Open(menuPlaylist[StaticFunctions.myRandom.Next(menuPlaylist.Count)]);
            player.Play();
        }

        public static void PlayGameTrack()
        {
            curPlaylist = gamePlaylist;

            player.Open(gamePlaylist[StaticFunctions.myRandom.Next(gamePlaylist.Count)]);
            player.Play();
        }
    }
}
