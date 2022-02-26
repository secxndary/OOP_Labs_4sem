using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    public partial class Form1 : Form
    {
        /// это все надо шобы тупа работало
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e) { }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { System.Diagnostics.Process.Start("https://www.belstu.by/fakultety"); }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }


        /// список, в котором хранятся все объекты
        public List<Discipline> listOfDisciplines = new List<Discipline>();
        /// путь по которому будем записывать в xml-файл один(!) объект
        string path = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\out.xml";
        /// счетчик кол-ва объектов для нижней строки состояния
        public int numOfObjects = 0;
        /// поля для даты\времени
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel;
        ToolStripLabel eventLabel;
        Timer timer;
        /// поля для передачи данных для сохранения
        IEnumerable<Discipline> listSearchLectorNameToSave = new List<Discipline>();



        public Form1() 
        {
            InitializeComponent();
            /// счетчик кол-ва объектов (сначала 0)
            toolStripStatusLabel1.Text += "0   ";
            /// код с метанита для таймера даты и времени
            infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            eventLabel = new ToolStripLabel();

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(eventLabel);

            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }


        public void ExceptionsCheck()   /// функция проверки всех ошибок
        {
            if (listBox4.SelectedItems.Count == 0)
                throw new Exception("Выберите кафедру.");
            if (checkedListBox1.CheckedItems.Count == 0)
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

            foreach (string item in checkedListBox1.CheckedItems)
                tempCourse.Add(item);
            foreach (string item in listBox3.SelectedItems)
                tempSpec.Add(item);

            if (radioButton1.Checked)
                tempRadio = radioButton1.Text;
            else if (radioButton2.Checked)
                tempRadio = radioButton2.Text;

            /// само заполнение этого объекта информацией через конструктор
            var discToAdd = new Discipline(richTextBox1.Text, comboBox1.Text,
                tempCourse, tempSpec, Int32.Parse(richTextBox3.Text),
                Int32.Parse(richTextBox4.Text), tempRadio, tempLect);


            var results = new List<ValidationResult>();
            var context = new ValidationContext(discToAdd);
            if (Validator.TryValidateObject(discToAdd, context, results, true))
            {
                /// вывод сообщения что всё окей
                listOfDisciplines.Add(discToAdd);
                MessageBox.Show("Дисциплина проходит валидацию.\nИнформация записана в объект!", "DisciplineRedact", MessageBoxButtons.OK);
            }
            else
            {
                foreach (var error in results)
                    MessageBox.Show($"Ошибка: {error.ErrorMessage}");
                MessageBox.Show("Дисциплина не проходит валидацию.\nИнформация не записана.");
            }
            eventLabel.Text = "Сохранено в объект.";


            /// а вот и код с третьей лабы для нижней строки состояния
            toolStripStatusLabel1.Text = "Кол-во объектов: " + listOfDisciplines.Count + "   ";
        }



        private void button2_Click(object sender, EventArgs e)  /// ввод в файл
        {
            /// обычный код для сериализации в XML
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, listOfDisciplines);
            }
            eventLabel.Text = "Сохранено в файл.";
            MessageBox.Show("Информация записана в XML!", "DisciplineRedact", MessageBoxButtons.OK);
        }



        private void button3_Click(object sender, EventArgs e)  /// вывод из файла
        {
            /// обычный код для десериализации из XML (привет метанит)
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFile = new List<Discipline>();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                listOutOfFile = (List<Discipline>)formatter.Deserialize(fs);
            }


            /// здесь до 158 строки всем полям формы присваиваем 
            /// значения из сохраненного в XML-файл объекта

            Discipline disOut = listOutOfFile[0];

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
            eventLabel.Text = "Выведено из файла.";

            /// сообщение о том что всё окей
            MessageBox.Show("Информация выведена!", "DisciplineRedact", MessageBoxButtons.OK);
        }

        /// кнопка о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eventLabel.Text = "О программе.";
            MessageBox.Show("Версия v.0.1\nВалдайцев Александр", "DisciplineRedact", MessageBoxButtons.OK);
        }

        /// кнопка вывода на экран списка записанных в лист дициплин
        private void button6_Click(object sender, EventArgs e)      
        {
            string result = "==============================================\n\n";
            foreach (Discipline dist in listOfDisciplines)
                result += dist.ToString();
            eventLabel.Text = "Выведено на экран.";
            MessageBox.Show(result);
        }

        /// открытие второй формы на нажатие меню -> поиск по лектору
        private void поЛекторуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2(this);
            eventLabel.Text = "Поиск по лектору.";
            newForm.Show();
        }

        /// открытие третьей формы на нажатие меню -> поиск по семестру
        private void поСеместруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 newForm = new Form3(this);
            eventLabel.Text = "Поиск по семестру.";
            newForm.Show();
        }

        /// открытие четвертой формы на нажатие меню -> поиск по курсу
        private void поКурсуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4(this);
            eventLabel.Text = "Поиск по курсу.";
            newForm.Show();
        }


        /// сортировка по кол-ву лекций
        private void поКолвуЛекцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Discipline> listSortLectures;
            var res = from d in listOfDisciplines
                      orderby d.NumberOfLections
                      select d;

            listSortLectures = res.ToList();

            string result = "==============================================\n\n";
            foreach (Discipline dist in listSortLectures)
                result += dist.ToString();


            string pathSortLectures = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\sortLectures.xml";
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            using (FileStream fs = new FileStream(pathSortLectures, FileMode.Create))
            {
                formatter.Serialize(fs, listSortLectures);
            }
            eventLabel.Text = "Отсортировано по лекциям.";
            MessageBox.Show(result);
        }


        /// сортировка по виду контроля
        private void поВидуКонтроляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Discipline> listSortControl;
            var res = from d in listOfDisciplines
                      orderby d.Control
                      select d;

            listSortControl = res.ToList();

            string result = "==============================================\n\n";
            foreach (Discipline dist in listSortControl)
                result += dist.ToString();

            string pathSortControl = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\sortControl.xml";
            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            using (FileStream fs = new FileStream(pathSortControl, FileMode.Create))
            {
                formatter.Serialize(fs, listSortControl);
            }
            eventLabel.Text = "Отсортировано по контролю.";
            MessageBox.Show(result);
        }


        /// вывести сохраненный в xml поиск по лектору
        private void поЛекторуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathSearchLector = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchLectorName.xml";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFileSearchLector = new List<Discipline>();

            using (FileStream fs = new FileStream(pathSearchLector, FileMode.OpenOrCreate))
            {
                listOutOfFileSearchLector = (List<Discipline>)formatter.Deserialize(fs);
            }

            string result = "==============================================\n\n";
            foreach (Discipline dist in listOutOfFileSearchLector)
                result += dist.ToString();
            eventLabel.Text = "Сохранено по лекторам.";
            MessageBox.Show(result);
        }


        /// вывести сохраненный в xml поиск по семестру
        private void поСеместруToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathSearchSemester = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchSemester.xml";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFileSearchSemester = new List<Discipline>();

            using (FileStream fs = new FileStream(pathSearchSemester, FileMode.OpenOrCreate))
            {
                listOutOfFileSearchSemester = (List<Discipline>)formatter.Deserialize(fs);
            }

            string result = "==============================================\n\n";
            foreach (Discipline dist in listOutOfFileSearchSemester)
                result += dist.ToString();
            eventLabel.Text = "Сохранено по семестрам.";
            MessageBox.Show(result);
        }


        /// вывести сохраненный в xml поиск по курсу
        private void поКурсуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathSearchCourse = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\searchCourse.xml";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFileSearchCourse = new List<Discipline>();

            using (FileStream fs = new FileStream(pathSearchCourse, FileMode.OpenOrCreate))
            {
                listOutOfFileSearchCourse = (List<Discipline>)formatter.Deserialize(fs);
            }

            string result = "==============================================\n\n";
            foreach (Discipline dist in listOutOfFileSearchCourse)
                result += dist.ToString();
            eventLabel.Text = "Сохранено по курсам.";
            MessageBox.Show(result);
        }


        /// десериализация и вывод на экран сортировки по лекциям
        private void поКолвуЛекцийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathSortLectures = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\sortLectures.xml";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFileSortLectures = new List<Discipline>();

            using (FileStream fs = new FileStream(pathSortLectures, FileMode.OpenOrCreate))
            {
                listOutOfFileSortLectures = (List<Discipline>)formatter.Deserialize(fs);
            }

            string result = "==============================================\n\n";
            foreach (Discipline dist in listOutOfFileSortLectures)
                result += dist.ToString();
            eventLabel.Text = "Сохранен сорт по лекциям.";
            MessageBox.Show(result);
        }

        /// десериализация и вывод на экран сортировки по типу контроля
        private void поВидуКонтроляToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string pathSortControl = @"C:\Users\valda\source\repos\semester #4\OOP_Labs\OOP_Lab3\OOP_Lab3\sortControl.xml";

            XmlSerializer formatter = new XmlSerializer(typeof(List<Discipline>));
            List<Discipline> listOutOfFileSortControl = new List<Discipline>();

            using (FileStream fs = new FileStream(pathSortControl, FileMode.OpenOrCreate))
            {
                listOutOfFileSortControl = (List<Discipline>)formatter.Deserialize(fs);
            }

            string result = "==============================================\n\n";
            foreach (Discipline dist in listOutOfFileSortControl)
                result += dist.ToString();
            eventLabel.Text = "Сохранен сорт по контролю.";
            MessageBox.Show(result);
        }



        /// кнопка ОЧИСТИТЬ
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            comboBox1.Text = "";
            richTextBox3.Text = "";
            richTextBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            maskedTextBox1.Text = "";
            richTextBox2.Text = "";
            for (int i = 0; i < listBox4.Items.Count; i++)
                listBox4.SetSelected(i, false);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            for (int i = 0; i < listBox3.Items.Count; i++)
                        listBox3.SetSelected(i, false);
            eventLabel.Text = "Очищено.";
        }


        /// кнопка УДАЛИТЬ
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listOfDisciplines.Clear();
            eventLabel.Text = "Удалено.";
            MessageBox.Show("Список дисциплин очищен.", "DisciplineRedact", MessageBoxButtons.OK);
        }


        /// поиск по нескольким критерям
        private void поНесколькимКритериямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 newForm = new Form6(this);
            newForm.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = (toolStrip1.Visible) ? false : true;
            button4.Visible = (button4.Visible) ? false : true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = true;
            button4.Visible = false;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "ООП";

        }
    }
}
