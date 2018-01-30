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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace ShootingRange.classes.Game
{
    class Target  // Реализует цель
    {
        #region fields
        private const string TARGET_FOLDER = "data/Targets/";

        public double[] targetData;   
        private string targetUri;

        public Image targetImg;
        private Image targetImgScopeVert;
        private Image targetImgScopeHoriz;
        #endregion

        public Target(string targetUri, double[] targetData)
        {
            this.targetUri = targetUri;
            this.targetData = targetData;
            
            CreateTarget();
        }

        public void CreateTarget()
        {
            targetImg = CreateTargetImage(ListOfTargets.bg);
            targetImgScopeVert = CreateTargetImage(ListOfTargets.bgScopeVert);
            targetImgScopeHoriz = CreateTargetImage(ListOfTargets.bgScopeHoriz);
        }

        private Image CreateTargetImage(Image bg)
        {
            Image target = new Image()
            {
                Source = StaticFunctions.LoadBitmapImage(TARGET_FOLDER + targetUri),
                Height = bg.Height * targetData[2],
            };

            Canvas.SetLeft(target, bg.ActualWidth * targetData[0]);
            Canvas.SetTop(target, bg.ActualHeight * targetData[1] - target.ActualHeight);

            Canvas bgParent = (Canvas)bg.Parent;
            bgParent.Children.Add(target);

            return target;
        }

        public void RemoveTarget()
        {
            RemoveTargetImage(targetImg);
            RemoveTargetImage(targetImgScopeVert);
            RemoveTargetImage(targetImgScopeHoriz);
        }

        private void RemoveTargetImage(Image targetImg)
        {
            Canvas canvas = (Canvas)targetImg.Parent;
            canvas.Children.Remove(targetImg);
        }

        public void MoveTarget()
        {
            MoveTargetImage(targetImg, ListOfTargets.bg);
            MoveTargetImage(targetImgScopeVert, ListOfTargets.bgScopeVert);
            MoveTargetImage(targetImgScopeHoriz, ListOfTargets.bgScopeHoriz);
        }

        private void MoveTargetImage(Image target, Image bg)
        {
            Canvas.SetLeft(target, Canvas.GetLeft(bg) + bg.ActualWidth * targetData[0]);
            Canvas.SetTop(target, Canvas.GetTop(bg) + bg.ActualHeight * targetData[1] - target.ActualHeight);
        }
    }
}
