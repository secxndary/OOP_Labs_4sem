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
    public partial class Form2 : Form
    {
        public Form2() { InitializeComponent(); }
        public void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void Form2_Load(object sender, EventArgs e) { }
 
        public Form1 form1;     /// первая форма - поле второй формы, с которым будем работать
        /// для этого всем компонентам (текстбоксам), в которые я буду из 2ой формы передавать
        /// данные в первую, я задал модификатор Modifiers -> Public, это нарушает ООП,
        /// но зато из второй формы можно спокойно сразу менять значения первой

        /// дубликат списка дисциплин из первой формы; это пиздец по принципам ООП но мне пох)
        List<Discipline> listOfDisciplines = new List<Discipline>();
        List<Discipline> listSearchLectorNameToSave = new List<Discipline>();
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchLectorName.xml";


        public Form2(Form1 f)
        {                           /// передаю первую форму в качестве параметра
            InitializeComponent();  /// при инициализации второй формы и задаю
            form1 = f;              /// полю form1 значение этого параметра
            listOfDisciplines = form1.listOfDisciplines;
        }




        private void button1_Click(object sender, EventArgs e)   /// кнопка поиска; сразу выводит
        {
            DataTransfer.lectorSearch = richTextBox1.Text;
            string searchLectorOut = "==============================================\n\n";
            string lectorSearch = DataTransfer.lectorSearch;
            List<Discipline> lectorList = new List<Discipline>();

            var res = from dist in listOfDisciplines
                      where dist.lector.Name == lectorSearch
                      select dist;
            foreach (Discipline dis in res)
                searchLectorOut += dis.ToString();
            MessageBox.Show(searchLectorOut);

            listSearchLectorNameToSave = res.ToList();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, listSearchLectorNameToSave);
            }

            Close();
        }

    }
}
