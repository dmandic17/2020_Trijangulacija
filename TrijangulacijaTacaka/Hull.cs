using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Klasa za rad sa konveksnim omotacem:

namespace TrijangulacijaTacaka
{
    public class Hull
    {
        List<PointF> points;
        PointF rightMostPoint;
        Dictionary<PointF, int> pointIndexDict;

        public PointF getNext(PointF point)
        {
            int currentIndex = pointIndexDict[point];
            int newIndex = (currentIndex + 1) % points.Count;
            return points[newIndex];
        }

        public int getNextIndex(int currentIndex)
        {
            return (currentIndex + 1) % points.Count;
        }

        public PointF getPrev(PointF point)
        {
            try
            {
                int currentIndex = pointIndexDict[point];
                int newIndex = (currentIndex - 1) % points.Count;
                if (newIndex < 0)
                {
                    newIndex = ~newIndex + 1;
                }
                return points[newIndex];
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return new PointF(0.0f, 0.0f);
            }
        }

        public int getPrevIndex(int currentIndex)
        {
            if (currentIndex == 0)
            {
                return this.points.Count - 1;
            }
            else
            {
                return currentIndex - 1;
            }
        }

        public Hull()
        {
        }

        public List<PointF> getPoints()
        {
            return this.points;
        }

        public Hull(List<PointF> points)
        {
            this.pointIndexDict = new Dictionary<PointF, int>();
            this.points = points;
        }

        public void setRightMost(PointF point)
        {
            this.rightMostPoint = point;
        }

        public PointF getRightMost()
        {
            return this.rightMostPoint;
        }

        public PointF getRightMostPoint()
        {  
            return new PointF();
        }

        public int getRightMostIndex()
        { 
            return 0;
        }
        public String printPointInfo(int index)
        {
            return "[" + points[index].X + ", " + points[index].Y + "]";
        }

        public int getLeftMostIndex()
        {  
            return 0;
        }
    }
}
