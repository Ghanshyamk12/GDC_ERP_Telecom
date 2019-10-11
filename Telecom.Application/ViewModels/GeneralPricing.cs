using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class GeneralPricing
    {
        public int GeneralPricingIndex { get; set; }
        public int AddressNbr { get; set; }
        public int InvoiceGroupNbr { get; set; }

        public decimal Number { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VATPercentage { get; set; }

        public int MonthFrequency { get; set; }
        public int TotalMonths { get; set; }
        public DateTime? ContractDate { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public bool Enabled { get; set; }
        public string Remark { get; set; }
        public int ShowRemarkOnReport { get; set; }
        public string InvoiceDescription { get; set; }
        public bool IncludePeriodDescription { get; set; }
        public int BusinessNbr { get; set; }
        public bool InvoiceAfterMonth { get; set; }
    }
}
