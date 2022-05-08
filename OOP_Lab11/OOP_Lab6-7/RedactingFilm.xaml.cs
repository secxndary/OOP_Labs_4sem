using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;
using OOP_Lab6_7.Classes;
using System.Windows.Input;
using OOP_Lab6_7.EFCore;
using OOP_Lab6_7.EFCore.Entities;
using System.Linq;

namespace OOP_Lab6_7
{
    public partial class RedactingFilm : Window
    {
        public EFCore.Entities.Movie _film;
        //public Cinema _filmsList;
        private OpenFileDialog openFileDialog;
        DBContext context;

        public RedactingFilm()
        {
            InitializeComponent();
            //_film = new Movie();
            //_filmsList = new Cinema();
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
            context = new DBContext();
        }


        // Добавить фильм
        private void addFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _film = new EFCore.Entities.Movie(filmName.Text, filmDirector.Text, genre.Text,
                int.Parse(duration.Text), float.Parse(rating.Text), openFileDialog.FileName);
                //var selectedMovieDB = context.Movie.FirstOrDefault(x => x.Title == _film.Title);


                //var deserializedList = DataTransfer.DeserializeFilms();
                //if (deserializedList != null)
                //    foreach (var item in deserializedList.filmsList)
                //        _filmsList.Add(item);
                //_filmsList.Add(_film);
                //DataTransfer.SerializeFilms(_filmsList);




                // ====================================  EF CORE  ====================================

                //EFCore.Entities.Movie movie = new EFCore.Entities.Movie(filmName.Text, filmDirector.Text,
                //    genre.Text, int.Parse(duration.Text), float.Parse(rating.Text), openFileDialog.FileName);
                //context.Movie.Add(movie);
                //context.SaveChanges();

                // ====================================  EF CORE ====================================




                MessageBox.Show($"Название: {filmName.Text}\n" +
                    $"Режиссёр: {filmDirector.Text}\nЖанр: {genre.Text}" +
                    $"\nДлительность: {duration.Text}\nРейтинг: " +
                    $"{rating.Text}\nПуть к фото: {openFileDialog.FileName}",
                    "Добавлен фильм", MessageBoxButton.OK);

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show($"Заполните все поля.",
                    "Ошибка!", MessageBoxButton.OK);;
            }
            
        }


        // Добавить фото в фильм
        private void addPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    preview.Source = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Absolute));
                    //_film.Photo = openFileDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Выберите файл подходящего формата.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        // Очистить форму
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            filmName.Text = "";
            filmDirector.Text = "";
            genre.Text = "";
            duration.Text = "";
            rating.Text = "";
            preview.Source = null;
        }


        private void escButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
