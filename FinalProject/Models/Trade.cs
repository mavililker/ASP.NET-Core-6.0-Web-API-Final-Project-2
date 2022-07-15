using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class Trade
    {
        public Trade()
        {
            CustomerTrades = new HashSet<CustomerTrade>();
        }

        public string TradeId { get; set; } = null!;
        public string? Service { get; set; }
        public int? Price { get; set; }
        public DateOnly? Date { get; set; }

        public virtual ICollection<CustomerTrade> CustomerTrades { get; set; }
    }
}
