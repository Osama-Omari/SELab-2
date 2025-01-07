using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assigment9_161413
{
    internal class Shape
    {

        Point topleft;
        Point lowerright;
        int width, height;

        public Shape (int x1, int  y1, int x2, int y2)
        {
            topleft = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            Lowerright = new Point(Math.Max(x1, x2), Math.Max(y1, y2));
            width = Math.Abs(x2 - x1);
            height = Math.Abs(y2 - y1);

        }

        public void Draw(Graphics g1,Graphics g2)
        {
            Pen p = new Pen(Color.Red,3);
            Point[] polygon1 = new Point[]
            {
                new Point(topleft.X, topleft.Y),
                new Point(topleft.X,lowerright.Y),
                new Point(topleft.X + width/2,lowerright.Y)
            };
            Point[] polygon2 = new Point[]
            {
                new Point(topleft.X + width/2,lowerright.Y),
                new Point(lowerright.X,lowerright.Y),
                new Point(lowerright.X,topleft.Y)

            };

            g1.DrawPolygon(p, polygon1);
            g1.DrawPolygon(p, polygon2);
            g2.DrawPolygon(p, polygon1);
            g2.DrawPolygon(p, polygon2);


        }

        public bool is_inside(Point p)
        {
            if (p.X >= topleft.X && p.Y >= topleft.Y && p.X <= Lowerright.X && p.Y <= Lowerright.Y)
                return true;
            return false;
        }

        public void select(Graphics g1)
        {
            Pen p = new Pen(Color.Blue,3);
            SolidBrush b = new SolidBrush(Color.Red);
            Point[] point1 = new Point[] {
                new Point(topleft.X + width / 2, topleft.Y)
            };
            g1.DrawRectangle(p,topleft.X -5, topleft.Y -5,width + 10,height + 10);
            g1.FillRectangle(b,topleft.X + width/2 - 8,topleft.Y - 8,10,10);
            g1.FillRectangle(b,topleft.X - 8,topleft.Y - 8 + height/2,10,10);
            g1.FillRectangle(b, topleft.X + width / 2 - 8, lowerright.Y + 3, 10, 10);
            g1.FillRectangle(b,lowerright.X + 3,lowerright.Y - height/2 ,10,10);






        }

        public void move(int dx, int dy)
        {
            topleft.X += dx;
            topleft.Y += dy;
            lowerright.X += dx;
            lowerright.Y += dy;
        }

        public Point Topleft { get => topleft; set => topleft = value; }
        public Point Lowerright { get => lowerright; set => lowerright = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }

        public override string ToString()
        {
            return $"{topleft.X}    {topleft.Y}     {lowerright.X}      {lowerright.Y}";
        }
    }
}
