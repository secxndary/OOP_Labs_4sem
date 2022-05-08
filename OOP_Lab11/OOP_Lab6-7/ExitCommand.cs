using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP_Lab6_7
{
    public class ExitCommand
    {
        public static RoutedCommand Exit { get; set; }

        static ExitCommand() => Exit = new RoutedCommand("Exit", typeof(MainWindow));
    }
}
