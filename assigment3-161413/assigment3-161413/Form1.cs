using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace assigment3_161413
{
    public partial class Form1 : Form
    {
            Text  t;
           
        public Form1()
        {
             InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "text|*.txt";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(dlg.FilterIndex == 1)
                {
                    textBox1.Text = dlg.FileName;
                    StreamReader read = new StreamReader(dlg.FileName);
                    string s = read.ReadToEnd();
                    t = new Text(s);
    
                }

                
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = t.allword.Count.ToString();
            t.allword.Sort();
            foreach(string item in t.allword)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from itme in t.allword
                    orderby itme.Length descending
                    select itme;
            textBox3.Text = q.First();
        }
    }
}
