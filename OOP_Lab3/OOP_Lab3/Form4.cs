using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OOP_Lab3
{
    public partial class Form4 : Form
    {
        public Form4() { InitializeComponent(); }
        public void richTextBox1_TextChanged(object sender, EventArgs e) { }

        public Form1 form1;
        List<Discipline> listOfDisciplines = new List<Discipline>();
        List<Discipline> listSearchCourseToSave = new List<Discipline>();
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchCourse.xml";


        public Form4(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            listOfDisciplines = form1.listOfDisciplines;
        }

        private void button1_Click(object sender, EventArgs e)   /// кнопка поиска; сразу выводит
        {
            DataTransfer.courseSearch = richTextBox1.Text;
            string searchCourseOut = "==============================================\n\n";
            string courseSearch = DataTransfer.courseSearch;

            var res = from dist in listOfDisciplines
                      where dist.Course.Contains(courseSearch)
                      select dist;
            foreach (Discipline dis in res)
                searchCourseOut += dis.ToString();
            MessageBox.Show(searchCourseOut);

            listSearchCourseToSave = res.ToList();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, listSearchCourseToSave);
            }

            Close();
        }
    }
}
