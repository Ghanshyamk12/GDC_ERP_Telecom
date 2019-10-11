using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class InvoiceGrid
    {
        public int AddressNbr { get; set; }
        public bool Checked { get; set; }
        public string Name { get; set; }
        public int BillCycle { get; set; }
    }
}
