using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public partial class CustomerTrade
    {
        public int CustomerTradeId { get; set; }
        public string? CustomerId { get; set; }
        public string? TradeId { get; set; }

        public virtual Trade? Trade { get; set; }
    }
}
