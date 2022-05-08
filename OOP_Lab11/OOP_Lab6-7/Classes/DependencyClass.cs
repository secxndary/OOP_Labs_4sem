using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_Lab6_7.Classes
{
    public class DependencyClass : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty NumberProperty;

        static DependencyClass()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DependencyClass));
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);
            NumberProperty = DependencyProperty.Register("Number", typeof(int), typeof(DependencyClass), metadata,
                new ValidateValueCallback(ValidateValue));
        }

        private static bool ValidateValue(object value)
        {
            int currentValue = (int)value;
            if (currentValue >= 0) // если текущее значение от нуля и выше
                return true;
            return false;
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            int currentValue = (int)baseValue;
            if (currentValue > 400)  // если больше 400, возвращаем 400
                return 400;
            return currentValue; // иначе возвращаем текущее значение
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }
    }
}
