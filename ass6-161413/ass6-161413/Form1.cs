using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ass6_161413
{
    public partial class Form1 : Form
    {

        Pen p = new Pen(Color.Black, 7);
        Pen p2 = new Pen(Color.Red,7);
        SolidBrush brush = new SolidBrush(Color.Yellow);

        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point[] shape = new Point[] {
                    new Point(e.X, e.Y),
                    new Point(e.X,e.Y+80),
                    new Point(e.X + 200 , e.Y + 70),
                    new Point(e.X+200,e.Y)
                };
                Point[] shape2 = new Point[] {
                    new Point(e.X,e.Y+100),
                    new Point(e.X,e.Y+170),
                    new Point(e.X + 200 , e.Y+170),
                    new Point(e.X+200,e.Y + 90),
                };

                g.DrawPolygon(p, shape);
                g.DrawPolygon(p, shape2);

            }
            else if(e.Button == MouseButtons.Right)
            {

                Point[] shape = new Point[] {
                    new Point(e.X, e.Y),
                    new Point(e.X,e.Y+80),
                    new Point(e.X + 200 , e.Y + 70),
                    new Point(e.X+200,e.Y)
                };
                Point[] shape2 = new Point[] {
                    new Point(e.X,e.Y+100),
                    new Point(e.X,e.Y+170),
                    new Point(e.X + 200 , e.Y+170),
                    new Point(e.X+200,e.Y + 90),
                };
                g.DrawPolygon(p2, shape);
                g.DrawPolygon(p2, shape2);

                g.FillPolygon(brush, shape);
                g.FillPolygon (brush, shape2);

            }

        }
    }
}
