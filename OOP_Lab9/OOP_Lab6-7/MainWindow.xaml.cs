using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace OOP_Lab6_7
{
    public partial class MainWindow : Window
    {
        private bool styleCheck = false;
        public MainWindow()
        {
            InitializeComponent();
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
            App.LanguageChanged += languageChanged;
            CultureInfo currLang = App.Language;
        }



        private void languageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;
        }

        private void buttonRu_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("ru-RU");
            App.Language = lang;
        }

        private void buttonEng_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo lang = new CultureInfo("en-US");
            App.Language = lang;
        }






        private void darkTheme_Click(object sender, RoutedEventArgs e)
        {
            if (styleCheck)
            {
                var uri = new Uri("./Styles/BlackTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = false;
            }
            else
            {
                var uri = new Uri("./Styles/WhiteTheme.xaml", UriKind.Relative);
                var resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                styleCheck = true;
            }
        }






        private void addFilm_Click(object sender, RoutedEventArgs e)
        {
            AddingFilm addingFilm = new AddingFilm();
            addingFilm.Show();
        }



        private void viewFilms_Click(object sender, RoutedEventArgs e)
        {
            ViewAllFilms viewAllFilms = new ViewAllFilms();
            viewAllFilms.Show();
            this.Close();
        }





        private void escButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }



        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }

        private void testUI_Click(object sender, RoutedEventArgs e)
        {
            MainWindowUser mainWindowUser = new MainWindowUser();
            mainWindowUser.Show();
        }
    }
}
