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
using Microsoft.EntityFrameworkCore;
using OOP_Lab6_7.Classes;
using OOP_Lab6_7.EFCore;

namespace OOP_Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindowUser.xaml
    /// </summary>
    public partial class MainWindowUser : Window
    {
        public DBContext context;

        public MainWindowUser()
        {
            InitializeComponent();
            var sri = Application.GetResourceStream(new Uri("./Styles/arrow.cur", UriKind.Relative));
            var customCursor = new Cursor(sri.Stream);
            Cursor = customCursor;

            context = new DBContext();
            context.Movie.Load();
            mainFilmsListView.ItemsSource = context.Movie.Local.ToList();

        }


        private void escButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрытие окна



        private void buyTicket_Click(object sender, RoutedEventArgs e)
        {
            context = new DBContext();
            context.Schedule.Load();
            OrderTicket orderTicket = new OrderTicket();
            orderTicket.Owner = this;
            var selectedFilm = (sender as Button)?.DataContext as EFCore.Entities.Movie;
            var tickets = context.Schedule.Local.Where(x => x.Id_Movie == selectedFilm.Id).OrderBy(x => x.DateTime).ToList().Select(i => new Ticket
            {
                Id_Schedule = i.Id,
                Id_Movie = selectedFilm.Id,
                Title = selectedFilm.Title,
                Director = selectedFilm.Director,
                Genre = selectedFilm.Genre,
                Duration = selectedFilm.Duration,
                Rating = selectedFilm.Rating,
                DateTime = i.DateTime,
                Photo = selectedFilm.Photo
            });

            orderTicket.OrderTicketListView.ItemsSource = tickets;
            context.Movie.Load();
            orderTicket.DataContext = selectedFilm;

            orderTicket.Show();
        }
    }
}
