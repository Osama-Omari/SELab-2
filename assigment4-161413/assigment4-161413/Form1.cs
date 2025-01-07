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

namespace assigment4_161413
{
    public partial class Form1 : Form
    {
        List<Person> persons = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Person p = new Person(double.Parse(textBox2.Text),double.Parse(textBox3.Text),textBox1.Text);
                persons.Add(p);

            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = persons;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "XMLFile|*.xml";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                ser.Serialize(writer,persons);
                writer.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "XMLFile|*.xml";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.FileName);
                XmlSerializer ser = new XmlSerializer(typeof(List<Person>));
                persons.AddRange((List<Person>) ser.Deserialize(reader));
                reader.Close();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
