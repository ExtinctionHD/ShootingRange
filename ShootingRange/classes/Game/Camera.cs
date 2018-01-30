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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace ShootingRange.classes.Game
{
    public class Camera  // Реализует движение камеры
    {
        #region fields
        private const double BASIC_SCALE = 2;

        public static Point displayCenter;

        private static Image bg;
        private static Image bgScopeVert; 
        private static Image bgScopeHoriz;
        #endregion 

        public Camera(Image bg, Image bgScopeVert, Image bgScopeHoriz, string levelsFolderName, string weaponFolderName)
        {
            Camera.bg = bg;
            Camera.bgScopeVert = bgScopeVert;
            Camera.bgScopeHoriz = bgScopeHoriz;

            InitCanvases(weaponFolderName);
            InitImages(levelsFolderName, weaponFolderName);

            displayCenter = GetDisplayCenter();
            SetCursorInCenter();
            SetCameraInStartPosition();
        }

        private static void InitCanvases(string weaponFolderName)
        {
            double[] canvasData;
            string weaponPath = "data/weapons/" + weaponFolderName + "/";

            StreamReader sr = new StreamReader(weaponPath + "_scopeSize.ini");

            SetCanvasSize(bg, 1, 1, 0, 0);

            canvasData = StaticFunctions.ReadLineWithDouble(sr);
            SetCanvasSize(bgScopeVert, canvasData[0], canvasData[1], canvasData[2], canvasData[3]);

            canvasData = StaticFunctions.ReadLineWithDouble(sr);
            SetCanvasSize(bgScopeHoriz, canvasData[0], canvasData[1], canvasData[2], canvasData[3]);

            sr.Close();
        }

        private static void InitImages(string levelsFolderName, string weaponFolderName)
        {
            string levelsPath = "data/levels/" + levelsFolderName + "/";

            bg.Source = StaticFunctions.LoadBitmapImage(levelsPath + "bg.jpg");
            bgScopeVert.Source = StaticFunctions.LoadBitmapImage(levelsPath + "bgScope.jpg");
            bgScopeHoriz.Source = StaticFunctions.LoadBitmapImage(levelsPath + "bgScope.jpg");

            string weaponPath = "data/weapons/" + weaponFolderName + "/";
            StreamReader sr = new StreamReader(weaponPath + "_specifications.ini");

            bg.Height = SystemParameters.PrimaryScreenHeight * BASIC_SCALE;
            bgScopeVert.Height = bg.Height * StaticFunctions.ReadLineWithDouble(sr)[0];
            bgScopeHoriz.Height = bgScopeVert.Height;

            sr.Close();
        }

        private static void SetCanvasSize(Image bg, double widthCoef, double heightCoef, double leftCoef, double topCoef)
        {
            Canvas bgCanvas = (Canvas)bg.Parent;
            bgCanvas.Width = SystemParameters.PrimaryScreenWidth * widthCoef;
            bgCanvas.Height = SystemParameters.PrimaryScreenHeight * heightCoef;
            bgCanvas.Margin = new Thickness(SystemParameters.PrimaryScreenWidth * leftCoef, SystemParameters.PrimaryScreenHeight * topCoef, 0, 0);
        }

        private static double GetDpiFactor()
        {
            Window MainWindow = Application.Current.MainWindow;
            PresentationSource MainWindowPresentationSource = PresentationSource.FromVisual(MainWindow);
            Matrix m = MainWindowPresentationSource.CompositionTarget.TransformToDevice;

            return m.M11;
        }

        private static Point GetDisplayCenter()
        {
            Point p = new Point();

            double dpiFactor = GetDpiFactor();
            p.X = SystemParameters.PrimaryScreenWidth * dpiFactor / 2;
            p.Y = SystemParameters.PrimaryScreenHeight * dpiFactor / 2;

            return p;
        }

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public static void SetCursorInCenter()
        {
            SetCursorPos((int)displayCenter.X, (int)displayCenter.Y);
        }

        private static void SetCameraInStartPosition()
        {
            Canvas.SetLeft(bg, 0);
            Canvas.SetTop(bg, 0);

            Canvas.SetLeft(bgScopeVert, 0); 
            Canvas.SetTop(bgScopeVert, 0);

            Canvas.SetLeft(bgScopeHoriz, 0);
            Canvas.SetTop(bgScopeHoriz, 0);
        }

        public static void MoveBgs(Point cursorScreenPos)
        {    
            MoveImage(bg, cursorScreenPos);
            MoveImage(bgScopeVert, cursorScreenPos);
            MoveImage(bgScopeHoriz, cursorScreenPos);
            SetCursorInCenter();
        }

        private static void MoveImage(Image imgMove, Point cursorPos)
        {
            double zoom = imgMove.ActualHeight / (SystemParameters.PrimaryScreenHeight * BASIC_SCALE);

            Canvas.SetLeft(imgMove, Canvas.GetLeft(imgMove) - (cursorPos.X - displayCenter.X) * zoom);  // Перемещение по горизонтали
            Canvas.SetTop(imgMove, Canvas.GetTop(imgMove) - (cursorPos.Y - displayCenter.Y) * zoom);  // Перемещение по вериткали
            BorderControl(imgMove, zoom);
        }

        private static void BorderControl(Image imgMove, double zoom)
        {
            double screenW = SystemParameters.PrimaryScreenWidth;
            double screenH = SystemParameters.PrimaryScreenHeight;

            Canvas canvas = (Canvas)imgMove.Parent;
            double canvasOffsetW = (screenW - canvas.Width + canvas.Margin.Left) / 2;
            double canvasOffsetH = (screenH - canvas.Height + canvas.Margin.Top) / 2;

            if (Canvas.GetLeft(imgMove) > -screenW / 2 * (zoom - 1) - canvasOffsetW)  // Контроль слева
            {
                Canvas.SetLeft(imgMove, -screenW / 2 * (zoom - 1) - canvasOffsetW);
            }
            if (Canvas.GetLeft(imgMove) < screenW - (imgMove.ActualWidth - screenW / 2 * (zoom - 1)) - canvasOffsetW)  // Контроль справа
            {
                Canvas.SetLeft(imgMove, screenW - (imgMove.ActualWidth - screenW / 2 * (zoom - 1)) - canvasOffsetW);
            }
            if (Canvas.GetTop(imgMove) > -screenH / 2 * (zoom - 1) - canvasOffsetH)  // Контроль сверху
            {
                Canvas.SetTop(imgMove, -screenH / 2 * (zoom - 1) - canvasOffsetH);
            }
            if (Canvas.GetTop(imgMove) < screenH - (imgMove.ActualHeight - screenH / 2 * (zoom - 1)) - canvasOffsetH)  // Контроль снизу
            {
                Canvas.SetTop(imgMove, screenH - (imgMove.ActualHeight - screenH / 2 * (zoom - 1)) - canvasOffsetH);
            }
        }
    }
}
