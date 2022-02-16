using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OOP_Lab1
{
    public partial class Form1 : Form
    {
        public string inputString { get; set; } /// в строке храним все данные

        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {  }


        private void button1_Click(object sender, EventArgs e)  /// вставить строку
        {
            inputString = TextBoxing.Text;
        }


        private void button2_Click(object sender, EventArgs e)  /// удалить гласные
        {
            string strWithoutVowels = inputString.ToLower();
            TextBoxing.Text = Regex.Replace(strWithoutVowels, "[eyuioa]", "");
        }


        private void button3_Click(object sender, EventArgs e)  /// удалить согласные
        {
            string strWithoutConsonants = inputString.ToLower();
            TextBoxing.Text = Regex.Replace(strWithoutConsonants, "[qwrtpsdfghjklzxcvbnm]", "");
        }


        private void button4_Click(object sender, EventArgs e)  /// вернуть изначальную строку
        {
            TextBoxing.Text = inputString;
        }


        private void button5_Click(object sender, EventArgs e)  /// длина строки
        {
            TextBoxing.Text = inputString.Length.ToString();
        }


        private void button6_Click(object sender, EventArgs e)  /// количество слов
        {
            int countWords = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            TextBoxing.Text = countWords.ToString();
        }


        private void button7_Click(object sender, EventArgs e)  /// кол-во предложений
        {
            string[] sentences = inputString.Split(new char[] { '.', '!', '?' });
            int countSentences = sentences.Where(t => t.Contains(',') == false).Count() - 1;
            TextBoxing.Text = countSentences.ToString();
        }


        private void button8_Click(object sender, EventArgs e)  /// ввести символ для его получения
        {
            TextBoxing.Text = "Введите индекс символа, который хотите \nполучить, и нажмите на кнопку *Вывести символ*:\n";
        }


        private void button9_Click(object sender, EventArgs e)  /// кнопка для запуска получения символа
        {
            string strIndexOfSymbol = TextBoxing.Text.Substring(TextBoxing.Text.Length - 1);
            int indexOfSymbol = int.Parse(strIndexOfSymbol);    /// в int переменную передается этот индекс
            if (indexOfSymbol > inputString.Length)
                throw new Exception("Некорректно введен индекс.");
            char newInputString = inputString[indexOfSymbol];
            TextBoxing.Text = newInputString.ToString();
        }


        private void button10_Click(object sender, EventArgs e) /// ввести символ который надо удалить
        {
            TextBoxing.Text = "Введите символ, который хотите удалить из \nтекста, и нажмите на кнопку *Удалить символы*:\n";
        }


        private void button11_Click(object sender, EventArgs e) /// кнопка для самого удаления символов
        {
            string deletingInputString = inputString;
            string symbolToDelete = TextBoxing.Text.Substring(TextBoxing.Text.Length - 1);
            char symbolChar = symbolToDelete.ToCharArray()[0];
            if (!inputString.Contains(symbolChar))
                throw new Exception("В строке нет такого символа!");
            deletingInputString = String.Join("", deletingInputString.Split(symbolChar, '\''));
            TextBoxing.Text = deletingInputString;
        }


        private void button12_Click(object sender, EventArgs e) /// запуск замены подстроки
        {
            TextBoxing.Text = "Введите подстроку, которую хотите заменить, и ту, на которую хотите заменить, и нажмите на кнопку *Заменить*:\n";
        }


        private void button13_Click(object sender, EventArgs e) /// кнопка для самой замены подстроки
        {
            string changingInputString = inputString;
            string[] threeStrings = TextBoxing.Text.Split('\n');
            string substringFrom = threeStrings[1];
            string substringTo = threeStrings[2];
            if (!inputString.Contains(substringFrom))
                throw new Exception("Такой подстроки нет в изначальной строке.");
            int indexFirst = changingInputString.IndexOf(substringFrom);
            TextBoxing.Text = changingInputString.Remove(indexFirst, substringFrom.Length).Insert(indexFirst, substringTo);
        }
    }
}
