using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab1_E.Helper;
using lab1_E.Model;
using lab1_E.ViewModel;

namespace lab1_E.View
{
    /// <summary>
    /// Логика взаимодействия для WindowOrder.xaml
    /// </summary>
    public partial class WindowOrder : Window
    {
        public WindowOrder()
        {
            InitializeComponent();

            OrderViewModel ordervm = new OrderViewModel();
            ListOrder.ItemsSource = ordervm.ListOrder;

            OrderTypeViewModel OrderTypevm = new OrderTypeViewModel();
            List<OrderType> orderTypes = new List<OrderType>();

            foreach (OrderType olf in OrderTypevm.ListOrderType)
            {
                orderTypes.Add(olf);
            }

            OrderVerietyViewModel OrderVerietyvm = new OrderVerietyViewModel();
            List<OrderVeriety> orderVerietys = new List<OrderVeriety>();

            foreach (OrderVeriety olf in OrderVerietyvm.ListOrderVeriety)
            {
                orderVerietys.Add(olf);
            }

            CurrencyViewModel Currencyvm = new CurrencyViewModel();
            List<Currency> Currencys = new List<Currency>();

            foreach (Currency olf in Currencyvm.ListCurrency)
            {
                Currencys.Add(olf);
            }

            ObservableCollection<OrderDPO> orders = new ObservableCollection<OrderDPO>();

            FindOrderType finderOrderType;
            FindOrderVeriety finderOrderVeriety;
            FindCurrency finderCurrency;

            foreach (var or in ordervm.ListOrder)
            {
                finderOrderType = new FindOrderType(or.OrderTypeID);
                OrderType orderType = orderTypes.Find(new Predicate<OrderType>(finderOrderType.OrderTypePredicate));

                finderOrderVeriety = new FindOrderVeriety(or.OrderVerietyID);
                OrderVeriety orderVeriety = orderVerietys.Find(new Predicate<OrderVeriety>(finderOrderVeriety.OrderVerietyPredicate));

                finderCurrency = new FindCurrency(or.CurrencyID);
                Currency currency = Currencys.Find(new Predicate<Currency>(finderCurrency.CurrencyPredicate));

                orders.Add(new OrderDPO 
                {
                    Id = or.Id,
                    OrderVerietyID = orderVeriety.Veriety,
                    OrderTypeID = orderType.Type,
                    CurrencyID = currency.CurrencyFull,
                    Tiker = or.Tiker,
                    Count = or.Count,
                    Type = or.Type,
                    Number = or.Number,
                    Data = or.Data,
                    Duration = or.Duration
                });
                ListOrder.ItemsSource = orders;
            }
        }
    }
}
