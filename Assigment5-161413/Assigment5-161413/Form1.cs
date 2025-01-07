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
using System.Xml.Serialization;

namespace Assigment5_161413
{
    public partial class Form1 : Form
    {
        List<Person> persons = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person(textBox1.Text,double.Parse(textBox3.Text),double.Parse(textBox4.Text),textBox2.Text);
                persons.Add(person);

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = persons;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XMLFile|*.xml";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(dlg.FilterIndex == 1)
                {
                    List<Person> normal = new List<Person>();
                    foreach(Person p in persons)
                    {
                        if(p.BMILevel == Level.Normal)
                        {
                            normal.Add(p);
                        }
                    }

                    StreamWriter writer = new StreamWriter(dlg.FileName);
                    XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                    ser.Serialize(writer, normal);
                    writer.Close();
                }
            }
        }

        private void sortByFullNameAscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.key = 1;
            persons.Sort();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = persons;
        }

        private void sortByBMIDescToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.key= 2;
            persons.Sort();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = persons;
        }

        private void percentageOfMaleAndFemaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = from p in persons
                    where p.Gender == PersonGender.Male
                    select p;
            double maleperc = (r.Count()*1.0) / (persons.Count * 1.0) * 100;
            MessageBox.Show($"male percentage: {maleperc}%");
        }

        private void percentageOfFemalePersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = from p in persons
                    where p.Gender == PersonGender.Female
                    select p;
            double femaleperc = (r.Count() * 1.0) / (persons.Count * 1.0) * 100;
            MessageBox.Show($"female percentage: {femaleperc}%");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XMLFile|*.xml|TextFile|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FilterIndex == 1)
                {
                    StreamReader reader = new StreamReader(dlg.FileName);
                    XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                    persons.AddRange((List<Person>)ser.Deserialize(reader));
                    reader.Close();
                }
                else if (dlg.FilterIndex == 2)
                {
                    StreamReader reader = new StreamReader (dlg.FileName);
                    string line;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        string [] items = line.Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        if (items.Length == 4) { 
                            Person person = new Person(items[0], double.Parse(items[2]), double.Parse(items[3]), items[1]);
                            persons.Add(person);
                        }
                        

                    }
                    reader.Close();
                }
            }
        }

        private void exportAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XMLFile|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                ser.Serialize(writer, persons);
                writer.Close();
            }
        }
    }
}
