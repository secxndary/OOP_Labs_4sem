using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OOP_Lab6_7.Classes;

namespace OOP_Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindowUser.xaml
    /// </summary>
    public partial class MainWindowUser : Window
    {
        private Cinema _listOfFilms;

        public MainWindowUser()
        {
            InitializeComponent();
            _listOfFilms = DataTransfer.DeserializeFilms();
            mainFilmsListView.ItemsSource = _listOfFilms.filmsList;
        }


        private void escButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // закрытие окна
        }


    }
}
