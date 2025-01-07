using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment7_161413
{
    public partial class Form1 : Form
    {
        Filling x = Filling.no;
        Graphics g;
        int x1, y1, x2, y2;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            x = Filling.no; 
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            x = Filling.yes;
        }

        

            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                x1 = e.X; y1 = e.Y;

            }

            private void Form1_MouseUp(object sender, MouseEventArgs e)
            {

                Shape shape;
                x2 = e.X; y2 = e.Y;
                if (e.Button == MouseButtons.Left) {
                    if (x == Filling.no)
                    {
                        shape = new Shape(x1, y1, x2, y2, Filling.no, TYPE.polygon);
                    }
                    else
                    {
                        shape = new Shape(x1, y1, x2, y2, Filling.yes, TYPE.polygon);
                    }
                }
                else
                    shape = new Shape(x1, y1, x2, y2, x, TYPE.line);
                shape.Draw(g);
            }


        }
    }

