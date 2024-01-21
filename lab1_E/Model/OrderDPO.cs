using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_E.Model
{
    class OrderDPO
    {
        public int Id { get; set; }
        public string OrderVerietyID { get; set; }
        public string OrderTypeID { get; set; }
        public string CurrencyID { get; set; }
        public string Tiker { get; set; }
        public int Count { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime Data { get; set; }
        public DateTime Duration { get; set; }

        public OrderDPO() { }

        public OrderDPO(int Id, string OrderVerietyID, string OrderTypeID, string CurrencyID, string Tiker, int Count, string Type, int Number, DateTime Data, DateTime Duration)
        {
            this.Id = Id;
            this.OrderVerietyID = OrderVerietyID;
            this.OrderTypeID = OrderTypeID;
            this.CurrencyID = CurrencyID;
            this.Tiker = Tiker;
            this.Count = Count;
            this.Type = Type;
            this.Number = Number;
            this.Data = Data;
            this.Duration = Duration;
        }
    }
}
