using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class InvoicePrintType
    {
        //public int InvoicePrintType { get; set; }
        public string PrintTypeDescription { get; set; }
        public int CallPrintTypeNbr { get; set; }
        public int PrintTypeDetailLength { get; set; }
        public bool PrintInvoiceDeliveryAddress { get; set; }
        public string ReportPrintType { get; set; }


    }
}
