using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Assigment7_161413
{
    public enum Filling
    {
        yes,
        no
    }

    public enum TYPE
    {
        polygon,
        line
    };
    internal class Shape
    {



       TYPE shapetype; 
       Filling t;

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 5);
            SolidBrush brush = new SolidBrush(Color.Red);
            if (shapetype == TYPE.polygon) { 
                Point[] polygon = new Point[]
                {
                    new Point(topleftcorner.X, topleftcorner.Y + height/2),
                    new Point(topleftcorner.X + width/2, lowrightcorner.Y),
                    new Point(lowrightcorner.X , topleftcorner.Y + height/2),
                    new Point(topleftcorner.X + width/2,topleftcorner.Y)
                };
                if(t == Filling.no)
                    g.DrawPolygon(p, polygon);
                else
                    g.FillPolygon(brush, polygon);
            }
            else
            {
                g.DrawLine(p,topleftcorner,lowrightcorner);

            }
        }

        public Shape(int x1, int y1, int x2, int y2 , Filling T,TYPE tshape) { 
            topleftcorner = new Point(Math.Min(x1, x2), Math.Min(y1, y2));
            lowrightcorner = new Point(Math.Max(x1, x2), Math.Max(y1, y2));

            width = Math.Abs(x1- x2);
            height = Math.Abs(y1- y2);

            t = T;
            shapetype = tshape;

            if(shapetype == TYPE.line)
            {
                topleftcorner = new Point(x1,y1);
                lowrightcorner = new Point(x2,y2);
            }

        }



        Point topleftcorner;
        Point lowrightcorner;
        int width;
        int height;

        public Point Topleftcorner { get => topleftcorner; set => topleftcorner = value; }
        public Point Lowrightcorner { get => lowrightcorner; set => lowrightcorner = value; }
        public int Width { get => width; set => width = value; }
        public int Height { get => height; set => height = value; }
        public Filling T { get => t; set => t = value; }
        public TYPE Shapetype { get => shapetype; set => shapetype = value; }
    }
}
