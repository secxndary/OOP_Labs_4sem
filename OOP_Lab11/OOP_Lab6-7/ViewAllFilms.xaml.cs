using System;
using System.Collections.Generic;
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
        DBContext context;

        public ViewAllFilms()
        {
            InitializeComponent();
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
                }
        }


        // Кнопка "Удалить"
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            context.Remove((EFCore.Entities.Movie)tableView.SelectedItem);
            context.SaveChanges();
            MessageBox.Show("Фильм удалён.", "Успешно!", MessageBoxButton.OK);
            tableView.ItemsSource = context.Movie.Local.ToList();
        }


        // Кнопка "Показать все фильмы"
        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            tableView.ItemsSource = context.Movie.Local.ToList();
        }


        // Кнопка "Отфильтровать"
        private void filterButton_Click(object sender, RoutedEventArgs e)
        {
            var listFull = context.Movie.Local.ToList();
            var listFilter = new List<EFCore.Entities.Movie>();
            foreach (var item in listFull)
                if (item.Genre == comboBoxFilterSelect.Text)
                    listFilter.Add(item);
            tableView.ItemsSource = listFilter;
        }


        // Кнопка "Поиск"
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var listFull = context.Movie.Local.ToList();
            var listSearch = new List<EFCore.Entities.Movie>();
            string pattern = @"^" + searchBox.myTextBox.Text + @"\w*";
            foreach (var item in listFull)
            {
                if (item.Title == searchBox.myTextBox.Text)
                    listSearch.Add(item);
                else if (Regex.IsMatch(item.Title, pattern))
                    listSearch.Add(item);
            }

            tableView.ItemsSource = listSearch;
        }


        // Кнопка "Добавить расписание"
        private void addScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            AddSchedule addSchedule = new AddSchedule();
            addSchedule.Show();
            var selectedFilm = (EFCore.Entities.Movie)tableView.SelectedItem;

        }
    }
}
