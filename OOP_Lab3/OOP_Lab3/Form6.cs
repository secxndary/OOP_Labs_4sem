using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab3
{
    public partial class Form6 : Form
    {
        public Form1 form1;
        List<Discipline> listOfDisciplines = new List<Discipline>();
        List<Discipline> listSearchCourseToSave = new List<Discipline>();
        List<string> listChecked = new List<string>();
        List<string> listSearches = new List<string>();
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchCourse.xml";


        public Form6(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            listOfDisciplines = form1.listOfDisciplines;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.CheckedItems)
                listChecked.Add(item.ToString());

            //listSearches.Add(richTextBox1.Text);
            //listSearches.Add(richTextBox2.Text);
            //listSearches.Add(richTextBox3.Text);
            string searchLectorOut = "==============================================\n\n";
            string searchSemesterOut = "==============================================\n\n";
            string searchCourseOut = "==============================================\n\n";

            string lectorSearch = richTextBox1.Text;
            string semesterSearch = richTextBox2.Text;
            string courseSearch = richTextBox3.Text;

            List<Discipline> resLector;
            List<Discipline> resSemester;
            List<Discipline> resCourse;


            if (lectorSearch != "" && semesterSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.lector.Name == lectorSearch
                          && dist.Semester == semesterSearch
                          select dist;
                foreach (Discipline dis in res)
                    searchLectorOut += dis.ToString();
                MessageBox.Show(searchLectorOut);
            }
            else if (lectorSearch != "" && courseSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.lector.Name == lectorSearch
                          && dist.Course.Contains(courseSearch)
                          select dist;
                foreach (Discipline dis in res)
                    searchLectorOut += dis.ToString();
                MessageBox.Show(searchLectorOut);
            }
            else if (semesterSearch != "" && courseSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.Semester == semesterSearch
                          && dist.Course.Contains(courseSearch)
                          select dist;
                foreach (Discipline dis in res)
                    searchLectorOut += dis.ToString();
                MessageBox.Show(searchLectorOut);
            }
            else if (semesterSearch != "" && courseSearch != "" && lectorSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.Semester == semesterSearch
                          && dist.Course.Contains(courseSearch)
                          && dist.lector.Name == lectorSearch
                          select dist;
                foreach (Discipline dis in res)
                    searchLectorOut += dis.ToString();
                MessageBox.Show(searchLectorOut);
            }


            else if (lectorSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.lector.Name == lectorSearch
                          select dist;
                foreach (Discipline dis in res)
                    searchLectorOut += dis.ToString();
                resLector = res.ToList();
                MessageBox.Show(searchLectorOut);
            }
            else if (semesterSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.Semester == semesterSearch
                          select dist;
                foreach (Discipline dis in res)
                    searchSemesterOut += dis.ToString();
                resSemester = res.ToList();
                MessageBox.Show(searchSemesterOut);
            }
            else if (courseSearch != "")
            {
                var res = from dist in listOfDisciplines
                          where dist.Course.Contains(courseSearch)
                          select dist;
                foreach (Discipline dis in res)
                    searchCourseOut += dis.ToString();
                resCourse = res.ToList();
                MessageBox.Show(searchCourseOut);
            }

        }
    }
}
