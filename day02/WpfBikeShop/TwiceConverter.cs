﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfBikeShop
{
    public class TwiceConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString()) * 2;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
