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
    public partial class Form5 : Form
    {
        private void Form5_Load(object sender, EventArgs e) { }
        public Form5() { InitializeComponent(); }
        public void richTextBox1_TextChanged(object sender, EventArgs e) { }

        public Form1 form1;
        List<Discipline> listOfDisciplines = new List<Discipline>();
        IEnumerable<Discipline> listSearchSemesterToSave = new List<Discipline>();


        public Form5(Form1 f)
        {
            InitializeComponent();
            form1 = f;
            listOfDisciplines = form1.listOfDisciplines;
        }
    }
}
