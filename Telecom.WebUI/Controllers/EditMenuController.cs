using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telecom.Application.Interfaces;
using Telecom.Application.ViewModels;

namespace Telecom.WebUI.Controllers
{
    public class EditMenuController : Controller
    {
        IAddress _address;
        public EditMenuController(IAddress address)
        {
            _address = address;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult FindAddress()
        {
            return PartialView(new AddressDetail());
        }

        [HttpPost]
        public ActionResult GetAddressDetails(AddressDetail Address)//, FormCollection collection,string Language
        {
            try
            {
                int type = Address.CustomerType;
                string databaseName = HttpContext.Session.GetString("Database_Name");

                IList<AddressDetail> addressDetails = _address.FindAddress(Address, type, databaseName);
                return Json(addressDetails);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }  
    }
}
