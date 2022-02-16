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

namespace OOP_Lab2
{
    public partial class Form1 : Form
    {
        public Form1()  /// всё до 31 строчки нам нужно тупа шобы работало
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.belstu.by/fakultety");
        }



        Discipline discipline = new Discipline();   /// в этот объект пишем всю инфу из формы
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab2\OOP_Lab2\out.xml";
        /// путь по которому будем записывать в xml-файл объект
        

        public void ExceptionsCheck()   /// функция проверки всех ошибок
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



        private void button1_Click(object sender, EventArgs e)  /// ввести дисциплину в объект
        {
            ExceptionsCheck();  /// вызов проверки корректности

            /// до 84 строчки временные переменные, которые нужны для того, чтобы 
            /// записать всю информацию в объект через его конструктор
            List<string> tempCourse = new List<string>();
            List<string> tempSpec = new List<string>();
            Lector tempLect = new Lector((string)listBox4.SelectedItem, maskedTextBox1.Text, richTextBox2.Text);
            string tempRadio = "";

            foreach (string item in checkedListBox1.SelectedItems)
                tempCourse.Add(item);
            foreach (string item in listBox3.SelectedItems)
                tempSpec.Add(item);

            if (radioButton1.Checked)
                tempRadio = radioButton1.Text;
            else if (radioButton2.Checked)
                tempRadio = radioButton2.Text;

            /// само заполнение этого объекта информацией через конструктор
            discipline = new Discipline(richTextBox1.Text, comboBox1.Text,
                tempCourse, tempSpec, Int32.Parse(richTextBox3.Text), 
                Int32.Parse(richTextBox4.Text), tempRadio, tempLect);

            /// вывод сообщения что всё окей
            MessageBox.Show("Информация записана в объект!", "DisciplineRedact", MessageBoxButtons.OK);
        }



        private void button2_Click(object sender, EventArgs e)  /// ввод в файл
        {
            /// обычный код для сериализации в XML
            XmlSerializer formatter = new XmlSerializer(typeof(Discipline));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, discipline);
            }

            MessageBox.Show("Информация записана в XML!", "DisciplineRedact", MessageBoxButtons.OK);
        }



        private void button3_Click(object sender, EventArgs e)  /// вывод из файла
        {
            /// обычный код для десериализации из XML (привет метанит)
            XmlSerializer formatter = new XmlSerializer(typeof(Discipline));
            Discipline disOut = new Discipline();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                disOut = (Discipline)formatter.Deserialize(fs);
            }


            /// здесь до 158 строки всем полям формы присваиваем 
            /// значения из сохраненного в XML-файл объекта
            richTextBox1.Text = disOut.Name;
            comboBox1.Text = disOut.Semester;
            richTextBox3.Text = disOut.NumberOfLections.ToString();
            richTextBox4.Text = disOut.NumberOfLabs.ToString();

            for (int i = 0; i < checkedListBox1.Items.Count; i++) 
                for (int j = 0; j < disOut.Course.Count; j++)
                {
                    /// отметить те курсы, которые были выбраны для записи в файл,
                    /// и убрать отметку с тех, кто не был выбран
                    if (checkedListBox1.Items[i].ToString() == disOut.Course[j].ToString())
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    else 
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }

            for (int i = 0; i < listBox3.Items.Count; i++)
                for (int j = 0; j < disOut.Speciality.Count; j++)
                {
                    /// то же самое: отмечаем выбранные записи и снимаем те которых не было
                    if (listBox3.Items[i].ToString() == disOut.Speciality[j].ToString())
                        listBox3.SetSelected(i, true);
                    else 
                        listBox3.SetSelected(i, false);
                }

            if (disOut.Control == radioButton1.Text)
                radioButton1.Checked = true;
            else if (disOut.Control == radioButton2.Text)
                radioButton2.Checked = true;

            maskedTextBox1.Text = disOut.lector.Name;
            for (int i = 0; i < listBox4.Items.Count; i++)
                if (disOut.lector.Department == listBox4.Items[i].ToString())
                    listBox4.SetSelected(i, true);
            richTextBox2.Text = disOut.lector.Auditorium;

            /// сообщение о том что всё окей
            MessageBox.Show("Информация выведена!", "DisciplineRedact", MessageBoxButtons.OK);
        }
    }
}
