using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class CompanyDetails
    {
        public int CompanyNbr { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUserName { get; set; }
        public string CompanyAbbrev { get; set; }
        public string Street { get; set; }
        public int CompanyIndex { get; set; }
        public string ZipSuffix { get; set; }
        public string City { get; set; }
        public int MinCustomerNbr { get; set; }
        public int MaxCustomerNbr { get; set; }
        public int MinInvoiceNbr { get; set; }
        public int MaxInvoiceNbr { get; set; }
        public int MinDelayInterestNbr { get; set; }
        public int MaxDelayInterestNbr { get; set; }
        public int StartInvoiceDay { get; set; }
        public string VATNumber { get; set; }
        public bool AutoAssignPayment { get; set; }
        public string PrintTypeDescription { get; set; }
    }
}
