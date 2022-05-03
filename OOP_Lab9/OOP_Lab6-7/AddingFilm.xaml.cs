using System;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;
using OOP_Lab6_7.Classes;
using System.Windows.Input;

namespace OOP_Lab6_7
{
    public partial class AddingFilm : Window
    {
        private Movie _film;
        public Cinema _filmsList;
        private OpenFileDialog openFileDialog;

        public AddingFilm()
        {
            InitializeComponent();
            _film = new Movie();
            _filmsList = new Cinema();
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;
        }


        // Добавить фильм
        private void addFilmButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _film = new Movie(filmName.textBoxUC.Text, filmDirector.textBoxUC.Text, genre.Text,
                int.Parse(duration.Text), rating.textBoxUC.Text, openFileDialog.FileName);

                var deserializedList = DataTransfer.DeserializeFilms();
                DataTransfer.SerializeOld(deserializedList);            // сохранили в filmsOld.xml старый список фильмов

                if (deserializedList != null)
                    foreach (var item in deserializedList.filmsList)
                        _filmsList.Add(item);
                _filmsList.Add(_film);
                DataTransfer.SerializeFilms(_filmsList);


                MessageBox.Show($"Название: {filmName.textBoxUC.Text}\n" +
                    $"Режиссёр: {filmDirector.textBoxUC.Text}\nЖанр: {genre.Text}" +
                    $"\nДлительность: {duration.Text}\nРейтинг: " +
                    $"{rating.textBoxUC.Text}\nПуть к фото: {openFileDialog.FileName}",
                    "Добавлен фильм", MessageBoxButton.OK);
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
            filmName.textBoxUC.Text = "";
            filmDirector.textBoxUC.Text = "";
            genre.Text = "";
            duration.Text = "";
            rating.textBoxUC.Text = "";
            preview.Source = null;
        }


        private void escButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
