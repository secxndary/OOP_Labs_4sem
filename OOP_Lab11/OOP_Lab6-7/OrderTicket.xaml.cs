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
using OOP_Lab6_7.EFCore;

namespace OOP_Lab6_7
{
    /// <summary>
    /// Логика взаимодействия для OrderTicket.xaml
    /// </summary>
    public partial class OrderTicket : Window
    {
        DBContext context;

        public OrderTicket()
        {
            InitializeComponent();
            context = new DBContext();
            context.Schedule.Load();
        }

        private void escButton_Click(object sender, RoutedEventArgs e) => this.Close(); // закрытие окна

    }
}
