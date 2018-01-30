using ShootingRange.classes.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ShootingRange.classes.Game
{
    class ListOfTargets  // Реализует взаимодействие с целями
    {
        #region fields
        const int DEFAULT_TARGET_COST = 2000;
        const int TARGETS_IN_WAVE = 5;

        public static List<Target> curTargets;
        private static List<double[]> possibleTargets;

        public static Image bg;
        public static Image bgScopeVert;
        public static Image bgScopeHoriz;

        private static Canvas canvasBg;
        #endregion

        public ListOfTargets(Image bg, Image bgScopeVert, Image bgScopeHoriz, string levelsFolderName)
        {
            ListOfTargets.bg = bg;
            ListOfTargets.bgScopeVert = bgScopeVert;
            ListOfTargets.bgScopeHoriz = bgScopeHoriz;

            canvasBg = (Canvas)bg.Parent;

            InitPossibleTargets(levelsFolderName);
            curTargets = new List<Target>();
            SpawnRandomTargets(TARGETS_IN_WAVE);
        }

        private static void InitPossibleTargets(string levelsFolderName)
        {
            string levelsPath = "data/levels/" + levelsFolderName + "/";

            possibleTargets = new List<double[]>();

            StreamReader sr = new StreamReader(levelsPath + "_targetsData.ini");
            while (!sr.EndOfStream)
            {
                possibleTargets.Add(StaticFunctions.ReadLineWithDouble(sr));
            }

            sr.Close();
        }

        private static void SpawnRandomTargets(int count)
        {
            while (curTargets.Count < count)
            {
                AddRandomTarget();
            }
        }

        private static void AddRandomTarget()
        {
            int i = StaticFunctions.myRandom.Next(possibleTargets.Count);
            double[] targetData = possibleTargets[i];
            possibleTargets.Remove(possibleTargets[i]);

            curTargets.Add(new Target("target.png", targetData));
        }

        public static void MoveTargets()
        {
            for (int i = 0; i < curTargets.Count; i++)
            {
                curTargets[i].MoveTarget();
            }
        }

        public static void ControlOfHit(Point cursorPos, bool isZoomIn)
        {
            const double SCATTER_COEF = 0.05;

            bool isHeadshot = false;

            int scatter = (int)(SystemParameters.PrimaryScreenHeight * SCATTER_COEF);
            Image deadTargetImg;

            if (!isZoomIn)
            {
                cursorPos.Offset(StaticFunctions.myRandom.Next(-scatter, scatter), StaticFunctions.myRandom.Next(-scatter, scatter));
            }

            deadTargetImg = FindTarget(cursorPos, ref isHeadshot);
            DeleteTarget(deadTargetImg, isHeadshot);
        }

        private static Image FindTarget(Point cursorPos, ref bool isHeadshot)
        {
            Image result = null;

            foreach (Image img in canvasBg.Children)
            {
                if (img != bg)
                {
                    bool tempIsHeadshot = (cursorPos.X > (Canvas.GetLeft(img) + img.ActualWidth * 0.25) && cursorPos.X < (Canvas.GetLeft(img) + img.ActualWidth - img.ActualWidth * 0.25)) &&
                                          (cursorPos.Y > Canvas.GetTop(img) && cursorPos.Y < (Canvas.GetTop(img) + img.ActualHeight * 0.25));

                    bool isHorizHit = (cursorPos.X > (Canvas.GetLeft(img) + img.ActualWidth * 0.25) && cursorPos.X < (Canvas.GetLeft(img) + img.ActualWidth - img.ActualWidth * 0.25)) ||
                                      (cursorPos.Y > (Canvas.GetTop(img) + img.ActualHeight * 0.25) && cursorPos.X > Canvas.GetLeft(img) && cursorPos.X < (Canvas.GetLeft(img) + img.ActualWidth));
                    bool isVertHit = (cursorPos.Y > Canvas.GetTop(img) && cursorPos.Y < (Canvas.GetTop(img) + img.ActualHeight));

                    if (isHorizHit && isVertHit)
                    {
                        result = img;
                        isHeadshot = tempIsHeadshot;
                    }
                }
            }

            return result;
        }

        private static void DeleteTarget(Image deadTargetImg, bool isHeadshot)
        {
            if (deadTargetImg != null)
            {
                int targetCost = CalculateTargetCost(deadTargetImg.Height, isHeadshot);
                InterfaceElements.timer.remainingMillisec += targetCost;
                InterfaceElements.timer.playTime += targetCost;

                InterfaceElements.killsCounter.IncKillsCount();
                if (isHeadshot)
                {
                    InterfaceElements.killsCounter.IncHeadshotCount();
                }

                Target deadTarget = curTargets.Find(x => x.targetImg == deadTargetImg);
                deadTarget.RemoveTarget();
                curTargets.Remove(deadTarget);

                if (curTargets.Count == 0)
                {
                    SpawnRandomTargets(TARGETS_IN_WAVE);
                }
                possibleTargets.Add(deadTarget.targetData);
            }
        }

        private static int CalculateTargetCost(double targetHeight, bool isHeadshot)
        {
            const double DEFAULT_TARGET_SIZE_COEF = 0.05;

            double costCoef = Math.Sqrt(DEFAULT_TARGET_SIZE_COEF / (targetHeight / bg.Height));

            if (!isHeadshot)
            {
                costCoef = Math.Sqrt(costCoef);
            }

            return (int)(DEFAULT_TARGET_COST * costCoef);
        }
    }
}
