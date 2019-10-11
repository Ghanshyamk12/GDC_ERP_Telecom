using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class DefaultViewModel
    {
        public UserTask UserTask { get; set; }
        public ResponseTask ResponseTask { get; set; }
        public string UserName { get; set; }
        public string SeletedDatabase { get; set; }
        public IEnumerable<SelectListItem> DatabaseName { get; set; }
        public bool DatabaseState { get; set; }
        public string AddressNbr { get; set; }
        public String CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
