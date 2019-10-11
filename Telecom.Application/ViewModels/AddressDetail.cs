using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class AddressDetail
    {
        public int? AddressNbr { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int? StreetNbr { get; set; }
        public int? StreetBox { get; set; }
        public int? Zipcode { get; set; }
        public int? Zipsuffix { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool SetAsFlashRemarks { get; set; }
        public string Remark { get; set; }
        public int CustomerType { get; set; }
        public IList<SelectListItem> Company { get; set; }
        public IList<SelectListItem> MyProperty { get; set; }
        public int ScreenType { get; set; } //It represent Add, Edit or Delete
    }
}
