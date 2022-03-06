using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace OOP_Lab4
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            System.Diagnostics.Process.Start("https://www.belstu.by/fakultety");


        public List<Discipline> listOfDisciplines = new List<Discipline>();
        //Discipline discipline = new Discipline();
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab2\OOP_Lab2\out.xml";
        /// путь по которому будем записывать в xml-файл объект (оставляем из 2 лабы)


        public void ExceptionsCheck()
        {
            if (listBox4.SelectedItems.Count == 0)
                throw new Exception("Выберите кафедру.");
            if (checkedListBox1.SelectedItems.Count == 0)
                throw new Exception("Выберите курс.");
            if (listBox3.SelectedItems.Count == 0)
                throw new Exception("Выберите специальность.");
            if (!radioButton1.Checked && !radioButton2.Checked)
                throw new Exception("Выберите тип контроля.");
            if (richTextBox2.Text == "")
                throw new Exception("Введите номер аудитории.");
            if (richTextBox1.Text == "")
                throw new Exception("Введите название дисциплины.");
            if (comboBox1.Text == "")
                throw new Exception("Введите номер семестра.");
            if (richTextBox3.Text == "")
                throw new Exception("Введите кол-во лекций.");
            if (richTextBox4.Text == "")
                throw new Exception("Введите кол-во лабораторных.");
            if (maskedTextBox1.Text == "")
                throw new Exception("Введите имя преподавателя.");
        }



        private void button1_Click_1(object sender, EventArgs e)    // ввод в List
        {
            ExceptionsCheck();
            List<string> tempCourse = new List<string>();
            List<string> tempSpec = new List<string>();
            Lector tempLect = new Lector((string)listBox4.SelectedItem, maskedTextBox1.Text, richTextBox2.Text);
            string tempRadio = "";
            foreach (string item in checkedListBox1.CheckedItems)
                tempCourse.Add(item);
            foreach (string item in listBox3.SelectedItems)
                tempSpec.Add(item);
            if (radioButton1.Checked)
                tempRadio = radioButton1.Text;
            else if (radioButton2.Checked)
                tempRadio = radioButton2.Text;



            Discipline discipline = new WebDiscipline(richTextBox1.Text, comboBox1.Text,
                tempCourse, tempSpec, Int32.Parse(richTextBox3.Text),
                Int32.Parse(richTextBox4.Text), tempRadio, tempLect);

            listOfDisciplines.Add(discipline);
            MessageBox.Show("Информация записана в объект!", "DisciplineRedact", MessageBoxButtons.OK);
        }


        private void button4_Click_1(object sender, EventArgs e)    // list на экран
        {
            string result = "==============================================\n\n";
            foreach (Discipline dist in listOfDisciplines)
                result += dist.ToString();
            MessageBox.Show(result);
        }


        private void button3_Click_1(object sender, EventArgs e) { }   // из файла в форму
        //{
        //    XmlSerializer formatter = new XmlSerializer(typeof(Discipline));
        //    Discipline disOut = new Discipline();

        //    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        //    {
        //        disOut = (Discipline)formatter.Deserialize(fs);
        //    }
        //    richTextBox1.Text = disOut.Name;
        //    comboBox1.Text = disOut.Semester;
        //    richTextBox3.Text = disOut.NumberOfLections.ToString();
        //    richTextBox4.Text = disOut.NumberOfLabs.ToString();

        //    for (int i = 0; i < checkedListBox1.Items.Count; i++)
        //        for (int j = 0; j < disOut.Course.Count; j++)
        //        {
        //            if (checkedListBox1.Items[i].ToString() == disOut.Course[j].ToString())
        //                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
        //            else
        //                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
        //        }

        //    for (int i = 0; i < listBox3.Items.Count; i++)
        //        for (int j = 0; j < disOut.Speciality.Count; j++)
        //        {
        //            if (listBox3.Items[i].ToString() == disOut.Speciality[j].ToString())
        //                listBox3.SetSelected(i, true);
        //            else
        //                listBox3.SetSelected(i, false);
        //        }

        //    if (disOut.Control == radioButton1.Text)
        //        radioButton1.Checked = true;
        //    else if (disOut.Control == radioButton2.Text)
        //        radioButton2.Checked = true;

        //    maskedTextBox1.Text = disOut.lector.Name;
        //    for (int i = 0; i < listBox4.Items.Count; i++)
        //        if (disOut.lector.Department == listBox4.Items[i].ToString())
        //            listBox4.SetSelected(i, true);
        //    richTextBox2.Text = disOut.lector.Auditorium;

        //    MessageBox.Show("Информация выведена!", "DisciplineRedact", MessageBoxButtons.OK);
        //}


        private void button2_Click_1(object sender, EventArgs e) { }    // записать в файл

        //{
        //    XmlSerializer formatter = new XmlSerializer(typeof(Discipline));
        //    using (FileStream fs = new FileStream(path, FileMode.Create))
        //    {
        //        formatter.Serialize(fs, discipline);
        //    }
        //    MessageBox.Show("Информация записана в XML!", "DisciplineRedact", MessageBoxButtons.OK);
        //}






        private void button5_Click(object sender, EventArgs e)  // create with builder
        {
            Director.BuilderMain();
            
            string result = "==============================================\n\n";
            foreach (Discipline dist in Director.listOfDisciplinesBuilder)
                result += dist.ToString();
            MessageBox.Show(result);
        }
    }
}
