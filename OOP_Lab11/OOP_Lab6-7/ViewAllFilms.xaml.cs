using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using OOP_Lab6_7.Classes;
using OOP_Lab6_7.EFCore;

namespace OOP_Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для ViewAllFilms.xaml
    /// </summary>
    public partial class ViewAllFilms : Window
    {
        private Cinema _listOfFilms;
        DBContext context;

        public ViewAllFilms()
        {
            InitializeComponent();
            _listOfFilms = DataTransfer.DeserializeFilms();
            //tableView.ItemsSource = _listOfFilms.filmsList;
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;

            context = new DBContext();
            context.Movie.Load();
            tableView.ItemsSource = context.Movie.Local.ToList();

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
            tableView.ItemsSource = context.Movie.Local.ToList();

            //tableView.ItemsSource = _listOfFilms.filmsList;
        }


        // Кнопка "Отредактировать"
        private void redactButton_Click(object sender, RoutedEventArgs e)
        {
            RedactingFilm edit = new RedactingFilm();
            edit.Owner = this;
            var filmEdit = (EFCore.Entities.Movie)tableView.SelectedItem;
            var selectedMovieDB = context.Movie.FirstOrDefault(x => x.Title == filmEdit.Title);     // заменить на guid
            context.Movie.Remove(selectedMovieDB);
            context.SaveChanges();

            if (tableView.SelectedItem != null)
                if (edit.ShowDialog() == false)
                {
                    filmEdit.Id = new Guid();
                    filmEdit.Title = edit.filmName.Text;
                    filmEdit.Director = edit.filmDirector.Text;
                    filmEdit.Genre = edit.genre.Text;
                    filmEdit.Duration = int.Parse(edit.duration.Text);
                    filmEdit.Rating = float.Parse(edit.rating.Text);
                    filmEdit.Photo = edit.preview.Source.ToString();

                    context.Movie.Add(filmEdit);
                    context.SaveChanges();

                    tableView.ItemsSource = context.Movie.Local.ToList();


                    //foreach (var film in _listOfFilms.filmsList)
                    //    if (film == (EFCore.Entities.Movie)tableView.SelectedItem)
                    //    {
                    //        _listOfFilms.filmsList[_listOfFilms.filmsList.IndexOf(film)] = filmEdit;
                    //        break;
                    //    }

                    //DataTransfer.SerializeFilms(_listOfFilms);
                    //tableView.ItemsSource = _listOfFilms.filmsList;
                }
        }


        // Кнопка "Удалить"
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            context.Remove((EFCore.Entities.Movie)tableView.SelectedItem);
            context.SaveChanges();
            MessageBox.Show("Фильм удалён.", "Успешно!", MessageBoxButton.OK);
            tableView.ItemsSource = context.Movie.Local.ToList();


            //_listOfFilms.filmsList.Remove((Classes.Movie)tableView.SelectedItem);
            //DataTransfer.SerializeFilms(_listOfFilms);
        }


        // Кнопка "Показать все фильмы"
        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            tableView.ItemsSource = context.Movie.Local.ToList();

            //_listOfFilms = DataTransfer.DeserializeFilms();
            //tableView.ItemsSource = _listOfFilms.filmsList;
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
