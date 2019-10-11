using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Telecom.Application.ViewModels;

namespace Telecom.Application.Interfaces
{
    public interface ILoginRepository
    {
        IEnumerable<SelectListItem> GetDatabaseName();
        bool CheckLoginCredential(LoginViewModel loginView);
    }

    public interface ILogonTab
    {
        UserTask CountUserTask(string userName, int type,string dbName);
        ResponseTask CountResponseTask(string userName, int type, string dbName);
        bool LogOffQuery(Boolean resetCount, string dbName);
        bool LogOnQuery(string dbName);
        string GetServerIniDataQuery(int IniIndex, string Default, string dbName, int CompanyNbr=-1);
        UserDetailsViewModel GetUserNameQuery(string strUserName, string dbName);
        bool CheckBirthdayDate(string BirthDate);
    }

    public interface IInvoicGeneration
    {
        InvoicingFlag GetFlagQuery(int flagType, string dbName);
        bool UpdateFlagQuery(int flagType,int flag ,string dbName);
        IList<SelectListItem> ViewCompanyQuery(int CompanyNbr, string dbName, bool OnlyBookeepingCompany = false);
        IList<SelectListItem> ViewInvoicePrintTypeQuery(int InvoicePrintType, string dbName);
        string GetCompanyNbrQuery(string companyName, string dbName);
        CompanyDetails GetCompanyQuery(int compnayNbr, string dbName);
        List<InvoiceGrid> GetAddressForInvoicingQuery(string company, string sMaxDate,
            int bExcludeMobileBusiness, int bSPlitBilling, string iBillingCycle, string dbName);

        string GetLastInvoiceDateQuery(int customer, string dbName, string Company = "", int InvoiceType = 40,
            int InvoiceNbr = -1);
    }

    public interface IAddress
    {
        IList<AddressDetail> FindAddress(AddressDetail Address, int type, string dbName);
    }
}
