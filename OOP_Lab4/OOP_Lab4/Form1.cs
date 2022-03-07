using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace OOP_Lab4
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
            System.Diagnostics.Process.Start("https://www.belstu.by/fakultety");

        public List<Discipline> listOfDisciplines = new List<Discipline>();




        // вывести основной list на экран
        private void button4_Click_1(object sender, EventArgs e)
        {
            string result = "==============================================\n\n";
            listOfDisciplines = Director.listOfDisciplinesBuilder;
            foreach (Discipline dist in listOfDisciplines)
                result += dist.ToString();
            foreach (DisciplineClient dist in AbstractFactory.listAF)
                result += dist.ToString();
            MessageBox.Show(result);
        }



        // создать объект с помощью билдера
        private void button5_Click(object sender, EventArgs e)
        {
            // статический метод который вызывает своеобразный мейн, создает один
            // рандомный объект и сразу выводит его на экран
            Director.BuilderMain();     

            // проходимся по list из director, где хранятся все
            // созданные объекты, и выводим в MessageBox
            string result = "==============================================\n\n";
            foreach (Discipline dist in Director.listOfDisciplinesBuilder)  
                result += dist.ToString();

            MessageBox.Show(result);
        }



        // создать объект с абстрактной фабрикой
        private void button6_Click(object sender, EventArgs e)  
        {
            // вызываем мейн метод для создания рандомных объектов дисциплины с помощью абстракной фабрики
            AbstractFactory.AFMain();

            // проходимся по list из AbstractFactory, в котором находятся объекты
            // DisciplineClient, содержащие внутри себя поля DisciplineAF и
            // LectorAF - логически те же самые объекты дисциплины и лектора
            string result = "==============================================\n\n";
            foreach (DisciplineClient dist in AbstractFactory.listAF)  
                result += dist.ToString();
            MessageBox.Show(result);
        }
    }
}
