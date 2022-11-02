using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CarShop
{
    class TotalPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<GoodSale> gs = ((Sale)value).GoodSales.ToList();
            double totalPrice = 0;
            foreach (var item in gs)
            {
                totalPrice += (double)(item.Count * item.Good.Price);
            }
            return totalPrice;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
