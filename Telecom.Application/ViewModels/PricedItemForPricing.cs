using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class PricedItemForPricing
    {
        public int PricedItemsIndex { get; set; }
        public int GeneralPricingIndex { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Number { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VATPercentage { get; set; }
        public int MonthPeriod { get; set; }
        public int InvoiceNbr { get; set; }
    }
}
