using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lib.AspNetCore.Mvc.JqGrid.Core.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Telecom.Application;
using Telecom.Application.Interfaces;
using Telecom.Application.ViewModels;

namespace Telecom.WebUI.Controllers
{
    public class InvoiceController : Controller
    {
        IInvoicGeneration _invoicGeneration;
        InvoicingFlag InvoicingFlag = null;
        ILogonTab _logonTab;
        public InvoiceController(ILogonTab logonTab, IInvoicGeneration invoicGeneration)
        {
            _logonTab = logonTab;
            _invoicGeneration = invoicGeneration;
        }

        [AcceptVerbs("GET")]
        public IActionResult Index()
        {
            string userName = HttpContext.Session.GetString("UserName");
            string databaseName = HttpContext.Session.GetString("Database_Name");

            InvoicingSelectionViewModel invoicingSelectionViewModel = new InvoicingSelectionViewModel();
            try
            {
                InvoicingFlag=_invoicGeneration.GetFlagQuery(StaticConstItems.InvoicingFlag, databaseName);
                if (InvoicingFlag.FlagStatus)
                {
                    ViewBag.InvoiceStatus = "Task is not permitted while invoicing is busy by user: " + InvoicingFlag.UserName;
                }
                else
                {
                    InvoicingFlag = _invoicGeneration.GetFlagQuery(StaticConstItems.GenerateRemindersFlag, databaseName);
                    if (InvoicingFlag.FlagStatus)
                    {
                        ViewBag.InvoiceStatus = "Task is not permitted while invoicing is busy by user: " + InvoicingFlag.UserName;
                    }
                }
                _invoicGeneration.UpdateFlagQuery(StaticConstItems.InvoicingFlag,0,databaseName);
                 float VAT = Convert.ToSingle(_logonTab.GetServerIniDataQuery(StaticConstItems.IniDefaultVATPercentage,
                    StaticConstItems.DefaultVAT.ToString(), databaseName));

                //------------------View all companies-----------------------------------------------
                IList<SelectListItem> companies =_invoicGeneration.ViewCompanyQuery(0, databaseName);
                companies.Insert(0, new SelectListItem() { Value="", Text=""});
                invoicingSelectionViewModel.Company = companies;
                
                //------------------------------Pricing----------------------------------------------
                IList<SelectListItem> invoice = _invoicGeneration.ViewInvoicePrintTypeQuery(0, databaseName);
                invoicingSelectionViewModel.InvoiceOption = invoice;

                
            }
            catch (Exception ex)
            {

            }
            List<string> invoiceType = new List<string>()
            {
                "Invoicing","Split biling"
            };

            invoicingSelectionViewModel.Action = new List<string>() { "Check", "Uncheck" };
            invoicingSelectionViewModel.InvoiceType=invoiceType;
            invoicingSelectionViewModel.BillingCycle = 23;
            invoicingSelectionViewModel.InvoiceDate = DateTime.Now.Date;
            return View(invoicingSelectionViewModel);
            

        }

        [HttpGet]
        public PartialViewResult GetInvoice(string companyName,bool checkRecurringInvoice,string billingCycle,
            bool chbExcludeMobile)
        {
            string userName = HttpContext.Session.GetString("UserName");
            string databaseName = HttpContext.Session.GetString("Database_Name");

            //---------------------------Getting data for invocing----------------------//
            string companyNbr=_invoicGeneration.GetCompanyNbrQuery(companyName, databaseName);
            CompanyDetails companyDetails = _invoicGeneration.GetCompanyQuery(Convert.ToInt32(companyNbr), 
                    databaseName);

            //invoicingSelectionViewModel.AutoAcAutoAssignPayment =--Checkbox status chang
            int startDay = companyDetails.StartInvoiceDay;
            string printTypeDisc = companyDetails.PrintTypeDescription;
            int i = 0;
            if (chbExcludeMobile)
                i = 1;
            DateTime? dMaxDate = DateTime.Parse("2030-01-01");
            int n = 0;
            if (checkRecurringInvoice)
                n = 2;
            dMaxDate = null;
            List<InvoiceGrid> invoiceGrids= _invoicGeneration.GetAddressForInvoicingQuery(companyName,dMaxDate.ToString(),i,n, billingCycle,databaseName);

            foreach(InvoiceGrid invoice in invoiceGrids)
            {
                
                if (n == 2)
                {

                }
            }
            //JqGridRequest jqGridRequest = new JqGridRequest();
            return PartialView(@"~/Views/Invoice/InvoiceTab/_InvoiceGrid.cshtml",invoiceGrids);
        }

        [AcceptVerbs("POST")]
        public IActionResult GridData(JqGridRequest request,int ? rowId)
        {
            //IQueryable<InvoiceGrid> charactersQueryable = (rowId.HasValue) ? StarWarsContext.Characters.AsQueryable().Where(character => character.HomeworldId == rowId.Value) : StarWarsContext.Characters.AsQueryable();
            //charactersQueryable = FilterCharacters(charactersQueryable, request);

            //int totalRecords = charactersQueryable.Count();

            //JqGridResponse response = new JqGridResponse()
            //{
            //    TotalPagesCount = (int)Math.Ceiling((float)totalRecords / (float)request.RecordsCount),
            //    PageIndex = request.PageIndex,
            //    TotalRecordsCount = totalRecords,
            //    UserData = new
            //    {
            //        Name = "Averages:",
            //        Height = StarWarsContext.Characters.Average(character => character.Height),
            //        Weight = StarWarsContext.Characters.Average(character => character.Weight)
            //    }
            //};

            //charactersQueryable = SortCharacters(charactersQueryable, request.SortingName, request.SortingOrder);

            //foreach (InvoiceGrid invoiceGrid in charactersQueryable.Skip(request.PageIndex * request.RecordsCount).Take(request.PagesCount * request.RecordsCount))
            //{
            //    response.Records.Add(new JqGridRecord(Convert.ToString(invoiceGrid.Id), invoiceGrid));
            //}

            //response.Reader.RepeatItems = false;

            //return new JqGridJsonResult(response);
            return View();
        }

        [HttpGet]
        public string GetInvoiceLastDate(int iValue,string company)
        {
            string userName = HttpContext.Session.GetString("UserName");
            string databaseName = HttpContext.Session.GetString("Database_Name");
            string dLastInvoiceDate = _invoicGeneration.GetLastInvoiceDateQuery(-1,databaseName,company);
            
            return dLastInvoiceDate;
        }
    }
}