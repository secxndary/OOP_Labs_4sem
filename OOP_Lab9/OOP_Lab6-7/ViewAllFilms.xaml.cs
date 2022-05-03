using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ViewAllFilms.xaml
    /// </summary>
    public partial class ViewAllFilms : Window
    {
        private Cinema _listOfFilms;

        public ViewAllFilms()
        {
            InitializeComponent();
            _listOfFilms = DataTransfer.DeserializeFilms();
            tableView.ItemsSource = _listOfFilms.filmsList;
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }



        // Кнопка "Добавить еще фильм"
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddingFilm film = new AddingFilm();
            film.Show();
            tableView.ItemsSource = _listOfFilms.filmsList;
        }


        // Кнопка "Отредактировать"
        private void redactButton_Click(object sender, RoutedEventArgs e)
        {
            RedactingFilm edit = new RedactingFilm();
            edit.Owner = this;
            var filmEdit = (Movie)tableView.SelectedItem;
            if (tableView.SelectedItem != null)
                if (edit.ShowDialog() == false)
                {
                    filmEdit.Title = edit.filmName.Text;
                    filmEdit.Director = edit.filmDirector.Text;
                    filmEdit.Genre = edit.genre.Text;
                    filmEdit.Duration = int.Parse(edit.duration.Text);
                    filmEdit.Rating = edit.rating.Text;
                    filmEdit.Photo = edit.preview.Source.ToString();

                    foreach (Movie film in _listOfFilms.filmsList)
                        if (film == (Movie)tableView.SelectedItem)
                        {
                            _listOfFilms.filmsList[_listOfFilms.filmsList.IndexOf(film)] = filmEdit;
                            break;
                        }

                    DataTransfer.SerializeFilms(_listOfFilms);
                    tableView.ItemsSource = _listOfFilms.filmsList;
                }
        }


        // Кнопка "Удалить"
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            _listOfFilms.filmsList.Remove((Movie)tableView.SelectedItem);
            DataTransfer.SerializeFilms(_listOfFilms);
            MessageBox.Show("Фильм удалён.", "Успешно!", MessageBoxButton.OK);
        }


        // Кнопка "Показать все фильмы"
        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            _listOfFilms = DataTransfer.DeserializeFilms();
            tableView.ItemsSource = _listOfFilms.filmsList;
        }


        // Кнопка "Отфильтровать"
        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            _listOfFilms = DataTransfer.DeserializeFilms();
            var cinema = new Cinema();

            foreach (var item in _listOfFilms.filmsList)
                if (item.Genre == comboBoxFilterSelect.Text)
                    cinema.filmsList.Add(item);

            tableView.ItemsSource = cinema.filmsList;
        }


        // Кнопка "Поиск"
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            _listOfFilms = DataTransfer.DeserializeFilms();
            var cinema = new Cinema();
            foreach (var item in _listOfFilms.filmsList)
            {
                string pattern = @"^" + searchBox.myTextBox.Text + @"\w*";
                if (item.Title == searchBox.myTextBox.Text)
                {
                    cinema.filmsList.Add(item);
                }
                else if (Regex.IsMatch(item.Title, pattern))
                {
                    cinema.filmsList.Add(item);
                }
            }
            tableView.ItemsSource = cinema.filmsList;
        }



        // Кнопка "Назад"   (работает при добавлении нового фильма)
        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            var listOld = DataTransfer.DeserializeOld();
            tableView.ItemsSource = listOld.filmsList;
        }



        // Кнопка "Вперед"
        private void redoButton_Click(object sender, RoutedEventArgs e)
        {
            tableView.ItemsSource = _listOfFilms.filmsList;
        }
    }
}
