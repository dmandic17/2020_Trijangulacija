using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Klasa koja treba da odradi i sacuva trijangulaciju
//u nekom formatu pogodnom za crtanje


namespace TrijangulacijaTacaka
{
    public class SolverTriangulation
    {
        
        private List<Tuple<PointF, PointF>> solution = new List<Tuple<PointF, PointF>>();

        
        public Hull GetHull(List<PointF> pointList, int recurLevel, String side)
        {  //O(nlogn)
            if (pointList.Count <= 1)
            {
                Hull result = new Hull(pointList);
                result.setRightMost(pointList[pointList.Count - 1]);
                return result;
            }
            else
            {

                List<List<PointF>> sets = divideSet(pointList);

                Hull leftHull = GetHull(sets[0], recurLevel + 1, side += " left");
                Hull rightHull = GetHull(sets[1], recurLevel + 1, side += " right");

                Console.WriteLine(recurLevel + " " + side);
                Console.WriteLine("\tSize of left: " + leftHull.getPoints().Count);
                Console.WriteLine("\tSize of right: " + rightHull.getPoints().Count);


                return merge(leftHull, rightHull);
            }
        }

        //glavna metoda je spajanje:
        public Hull merge(Hull left, Hull right)
        {
            int rightMost = left.getRightMostIndex();
            int leftMost = right.getLeftMostIndex();

            int currentLeftIndex = rightMost;
            int currentRightIndex = leftMost;

            int upperLeft = -1;
            int upperRight = -1;
            int lowerLeft = -1;
            int lowerRight = -1;

            bool leftIndexChanged = false;
            bool rightIndexChanged = false;
            bool firstRight = true;
            bool firstLeft = true;

            //get upper common tangent
            while (leftIndexChanged || rightIndexChanged || firstLeft || firstRight)
            {
                if (firstRight || leftIndexChanged)
                {
                    firstRight = false;
                    upperRight = getRightUpper(left, right, currentLeftIndex, currentRightIndex);
                    if (upperRight == currentRightIndex)
                    {
                        leftIndexChanged = false;
                        rightIndexChanged = false;
                    }
                    else
                    {
                        rightIndexChanged = true;
                        currentRightIndex = upperRight;
                    }
                }
                if (firstLeft || rightIndexChanged)
                {
                    firstLeft = false;
                    upperLeft = getLeftUpper(left, right, currentLeftIndex, currentRightIndex);
                    if (upperLeft == currentLeftIndex)
                    {
                        leftIndexChanged = false;
                        rightIndexChanged = false;
                    }
                    else
                    {
                        leftIndexChanged = true;
                        currentLeftIndex = upperLeft;
                    }
                }
            }

            //get lower common tangentt
            currentLeftIndex = rightMost;
            currentRightIndex = leftMost;

            leftIndexChanged = false;
            rightIndexChanged = false;
            //iterate through at least once
            firstRight = true;
            firstLeft = true;
            while (leftIndexChanged || rightIndexChanged || firstLeft || firstRight)
            {
                if (firstLeft || rightIndexChanged)
                {
                    firstLeft = false;
                    lowerLeft = getLeftLower(left, right, currentLeftIndex, currentRightIndex);
                    if (lowerLeft == currentLeftIndex)
                    {
                        leftIndexChanged = false;
                        rightIndexChanged = false;
                    }
                    else
                    {
                        leftIndexChanged = true;
                        currentLeftIndex = lowerLeft;
                    }
                }

                if (firstRight || leftIndexChanged)
                {
                    firstRight = false;
                    lowerRight = getRightLower(left, right, currentLeftIndex, currentRightIndex);
                    if (lowerRight == currentRightIndex)
                    {
                        leftIndexChanged = false;
                        rightIndexChanged = false;
                    }
                    else
                    {
                        rightIndexChanged = true;
                        currentRightIndex = lowerRight;
                    }
                }
            }

            //join points
            List<PointF> resultPoints = new List<PointF>();
            //add up to (and including) upperLeft
            for (int i = 0; i <= upperLeft; i++)
            {
                resultPoints.Add(left.getPoints()[i]);
            }
            //add up to lowerRight
            for (int i = upperRight; i != lowerRight; i = right.getNextIndex(i))
            {
                resultPoints.Add(right.getPoints()[i]);
            }
            //add lowerRight
            resultPoints.Add(right.getPoints()[lowerRight]);
            //add from lowerLeft to beginning
            for (int i = lowerLeft; i != 0; i = left.getNextIndex(i))
            {
                resultPoints.Add(left.getPoints()[i]);
            }

            return new Hull(resultPoints);
        }

        //triangle orientation method:
        private int orientation(PointF p, PointF q, PointF r)
        { //O(1)
            float val = (q.Y - p.Y) * (r.X - q.X) -
                      (q.X - p.X) * (r.Y - q.Y);

            if (val == 0) return 0;  // colinear 

            return (val > 0) ? 1 : -1; // clock=1 or counterclock wise=-1 
        }
        

        private int getLeftUpper(Hull left, Hull right, int leftIndex, int rightIndex)
        { //O(n)
            List<PointF> leftPoints = left.getPoints();
            List<PointF> rightPoints = right.getPoints();
            while (calculateSlope(rightPoints[rightIndex], leftPoints[left.getPrevIndex(leftIndex)]) <
                  calculateSlope(rightPoints[rightIndex], leftPoints[leftIndex]))
            {
                leftIndex = left.getPrevIndex(leftIndex);
            }
            return leftIndex;
        }

        private int getRightUpper(Hull left, Hull right, int leftIndex, int rightIndex)
        { //O(n)
            List<PointF> rightPoints = right.getPoints();
            List<PointF> leftPoints = left.getPoints();
            while (calculateSlope(leftPoints[leftIndex], rightPoints[right.getNextIndex(rightIndex)]) >
                  calculateSlope(leftPoints[leftIndex], rightPoints[rightIndex]))
            {
                rightIndex = right.getNextIndex(rightIndex);
            }

            return rightIndex;
        }

        private int getLeftLower(Hull left, Hull right, int leftIndex, int rightIndex)
        { //O(n)
            List<PointF> leftPoints = left.getPoints();
            List<PointF> rightPoints = right.getPoints();
            while (calculateSlope(rightPoints[rightIndex], leftPoints[left.getNextIndex(leftIndex)]) >
                  calculateSlope(rightPoints[rightIndex], leftPoints[leftIndex]))
            {
                leftIndex = left.getNextIndex(leftIndex);
            }
            return leftIndex;
        }

        private int getRightLower(Hull left, Hull right, int leftIndex, int rightIndex)
        { //O(n)
            List<PointF> rightPoints = right.getPoints();
            List<PointF> leftPoints = left.getPoints();
            while (calculateSlope(leftPoints[leftIndex], rightPoints[right.getPrevIndex(rightIndex)]) <
                  calculateSlope(leftPoints[leftIndex], rightPoints[rightIndex]))
            {
                rightIndex = right.getPrevIndex(rightIndex);
            }
            return rightIndex;
        }

        private int getIndexForPoint(PointF point, Hull hull)
        {
            List<PointF> points = hull.getPoints();
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i].Equals(point))
                {
                    return i;
                }
            }
            return -100;
        }
        
        public List<List<System.Drawing.PointF>> divideSet(List<PointF> points)
        {
            List<PointF> leftSide = points.Take(points.Count / 2).ToList();
            List<PointF> rightSide = points.Skip(points.Count / 2).ToList();
            List<List<PointF>> result = new List<List<PointF>>();
            result.Add(leftSide);
            result.Add(rightSide);
            return result;
        }

        public Double calculateSlope(PointF left, PointF right)
        {
            return -(right.Y - left.Y) / (right.X - left.X);
        }

        //resenje:
        public List<Tuple<PointF, PointF>> solveProblem(List<PointF> points)
        {
            solution = new List<Tuple<PointF, PointF>>();
            Hull convex = GetHull(points, 0, "");
            return solution;
        }


    }
}
