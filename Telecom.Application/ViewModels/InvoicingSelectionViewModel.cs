using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class InvoicingSelectionViewModel
    {
        public int BillingCycle { get; set; }
        public string SelectedCompany { get; set; }
        public IEnumerable<SelectListItem> Company { get; set; }
        public string SelectedInvoiceOption { get; set; }
        public IEnumerable<SelectListItem> InvoiceOption { get; set; }

        public string SelectedInvoiceType { get; set; }
        public List<String> InvoiceType { get; set; }
        public string FromFilter { get; set; }
        public string ToFilter { get; set; }
        public List<string> Action { get; set; }
        public string SelectedAction { get; set; }

        //Invoice Option tab
        public bool AutoAcAutoAssignPayment { get; set; }

        //Exclude price from
        public bool ExcludePricingFrom { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public bool GenerateRecurringInvoice { get; set; }
        public bool GenerateOneOffInvoice { get; set; }
        public string FindCustomer { get; set; }
        
    }
}
