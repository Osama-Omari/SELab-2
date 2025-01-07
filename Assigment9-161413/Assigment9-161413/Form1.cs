using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment9_161413
{
    public partial class Form1 : Form
    {
        Graphics g1, g2;
        Bitmap bimage;
        int x1, y1, x2, y2;
        bool is_move = false;
        List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            InitializeComponent();
            g1 = this.CreateGraphics();
            bimage = new Bitmap(this.Width, this.Height);
            g2 = Graphics.FromImage(bimage);
            g2.Clear(Color.White);
        }
        int index = -1;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
            
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].is_inside(new Point(x1, y1)))
                {
                    shapes[i].select(g1);
                    index = i;
                    is_move = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNGImage|*.png|TXTFile|*.txt";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(dlg.FilterIndex == 1)
                {
                     bimage.Save(dlg.FileName,System.Drawing.Imaging.ImageFormat.Png);
                }
                else if(dlg.FilterIndex == 2)
                {
                    StreamWriter write = new StreamWriter(dlg.FileName);
                    write.WriteLine("x1     y1      x2      y2");
                    foreach(Shape s in shapes)
                    {
                        write.WriteLine(s.ToString());
                    }
                    write.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(index != -1)
            {
                shapes.Remove(shapes[index]);
                index = -1;
                Redraw();
            }
            
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            int dx = x2 - x1;
            int dy = y2 - y1;
            if (is_move)
            {
                shapes[index].move(dx, dy);
                is_move = false;

                Redraw();
            }
            else {

                Shape shape = new Shape(x1,y1,x2,y2);
                shape.Draw(g1,g2);
                shapes.Add(shape);
             }
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Redraw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Redraw()
        {

            g1.Clear(Color.White);
            g2.Clear(Color.White);
            foreach (Shape s in shapes)
            {
                s.Draw(g1,g2);
            }
        }

    }
}
