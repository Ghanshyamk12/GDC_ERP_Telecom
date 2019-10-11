using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Telecom.Application.Interfaces;

namespace Telecom.Application.ViewModels
{
    public class InvoiceGeneration : IInvoicGeneration
    {
        Connection cons = new Connection();
        public InvoicingFlag GetFlagQuery(int flagType, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            InvoicingFlag invoicingFlag = new InvoicingFlag();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetFlag", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iFlagType", flagType);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        invoicingFlag.FlagStatus = Convert.ToBoolean(reader["bFlagStatus"].ToString());
                        invoicingFlag.UserName = reader["cUserName"].ToString();
                    }
                    reader.Close();
                }
                con.Close();
            }
            return invoicingFlag;
        }

        public bool UpdateFlagQuery(int flagType, int flag, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (SqlCommand cmd = new SqlCommand("spUpdateFlag", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@iFlagType", flagType);
                        cmd.Parameters.AddWithValue("@bFlagStatus", flag);

                        int item = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public IList<SelectListItem> ViewCompanyQuery(int CompanyNbr, string dbName, bool OnlyBookeepingCompany = false)
        {
            string connectionString = cons.GetConn(dbName);
            IList<SelectListItem> company = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spViewCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iCompanyNbr", CompanyNbr);
                    if (OnlyBookeepingCompany)
                        cmd.Parameters.AddWithValue("@iBookeepingCompany", 1);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    Company com;
                    while (reader.Read())
                    {
                        com = new Company
                        {
                            CCompany = reader["cCompany"].ToString(),
                            CCompanyUserName = reader["cCompanyUsedName"].ToString()
                        };
                        company.Add(new SelectListItem { Text = com.CCompany, Value = com.CCompany });
                    }
                    reader.Close();
                }
                con.Close();
            }

            return company;
        }

        public IList<SelectListItem> ViewInvoicePrintTypeQuery(int InvoicePrintType, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            IList<SelectListItem> invoice = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spViewInvoicePrintType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@iInvoicePrintType", InvoicePrintType);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string PrintTypeDescription = reader["cPrintTypeDescription"].ToString();
                        invoice.Add(new SelectListItem
                        {
                            Text = PrintTypeDescription,
                            Value = PrintTypeDescription
                        });
                    }
                    reader.Close();
                }
                con.Close();
            }
            return invoice;
        }

        public string GetCompanyNbrQuery(string companyName, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            string compNbr = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetCompanyNbr", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cCompanyName", companyName);


                    compNbr = Convert.ToString(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return compNbr;
        }

        public CompanyDetails GetCompanyQuery(int compnayNbr, string dbName)
        {
            string connectionString = cons.GetConn(dbName);

            CompanyDetails company = new CompanyDetails();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spGetCompany", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iCompanyNbr", compnayNbr);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        company.CompanyNbr = Convert.ToInt32(reader["iCompanyNbr"].ToString());
                        company.CompanyName = reader["cCompany"].ToString();
                        company.CompanyUserName = reader["cCompanyUsedName"].ToString();
                        company.CompanyAbbrev = reader["cCompanyAbbrev"].ToString();
                        company.Street = reader["cStreet"].ToString();

                        company.CompanyIndex = Convert.ToInt32(reader["iCountryIndex"].ToString());
                        company.ZipSuffix = reader["cZipSuffix"].ToString();
                        company.City = reader["cCity"].ToString();
                        company.MinCustomerNbr = Convert.ToInt32(reader["iMinCustomerNbr"].ToString());
                        company.MaxCustomerNbr = Convert.ToInt32(reader["iMaxCustomerNbr"].ToString());
                        company.MinInvoiceNbr = Convert.ToInt32(reader["iMinInvoiceNbr"].ToString());
                        company.MaxInvoiceNbr = Convert.ToInt32(reader["iMaxInvoiceNbr"].ToString());
                        company.MinDelayInterestNbr = Convert.ToInt32(reader["iMinDelayInterestNbr"].ToString());
                        company.MaxDelayInterestNbr = Convert.ToInt32(reader["iMaxDelayInterestNbr"].ToString());
                        company.StartInvoiceDay = Convert.ToInt32(reader["iStartInvoiceDay"].ToString());
                        company.VATNumber = reader["cVATNumber"].ToString();
                        company.AutoAssignPayment = Convert.ToBoolean(reader["bAutoAssignPayment"].ToString());
                        company.PrintTypeDescription = reader["cPrintTypeDescription"].ToString();

                    }
                    reader.Close();
                }
                con.Close();
            }
            return company;
        }

        public List<InvoiceGrid> GetAddressForInvoicingQuery(string company, string sMaxDate,
            int bExcludeMobileBusiness, int bSPlitBilling, string iBillingCycle, string dbName)
        {
            string connectionString = cons.GetConn(dbName);

            List<InvoiceGrid> invoice = new List<InvoiceGrid>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spGetAddressForInvoicing", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cCompany", company);
                    cmd.Parameters.AddWithValue("@bExcludeMobileBusiness", bExcludeMobileBusiness);
                    cmd.Parameters.AddWithValue("@dMaxDate", sMaxDate);
                    cmd.Parameters.AddWithValue("@bSplitBilling", bSPlitBilling);
                    cmd.Parameters.AddWithValue("@iTermOfpayment", iBillingCycle);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        InvoiceGrid data = new InvoiceGrid();
                        data.AddressNbr = Convert.ToInt32(reader["iAddressNbr"].ToString());
                        data.Name = reader["cName"].ToString();
                        data.BillCycle = Convert.ToInt32(reader["iBillCycle"].ToString());
                        data.Checked = true;
                        invoice.Add(data);
                    }
                    reader.Close();
                }
                con.Close();
            }
            return invoice;
        }

        public string GetLastInvoiceDateQuery(int customer, string dbName, string Company = "", int InvoiceType = 40,
            int InvoiceNbr = -1)
        {
            string connectionString = cons.GetConn(dbName);
            string lInvoiceDate = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetLastInvoiceDate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (customer > -1)
                        cmd.Parameters.AddWithValue("@iAddressNbr", customer);
                    else
                        /*cmd.Parameters.AddWithValue("@iAddressNbr", null);*/
                        cmd.Parameters.Add(new SqlParameter("@iAddressNbr", DBNull.Value));

                    cmd.Parameters.AddWithValue("@cCompany", Company);
                    cmd.Parameters.AddWithValue("@iInvoiceType", InvoiceType);

                    if (InvoiceNbr > -1)
                        cmd.Parameters.AddWithValue("@iInvoiceNbr", InvoiceNbr);



                    lInvoiceDate = Convert.ToString(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return lInvoiceDate;
        }

        public string GetNewInvoiceJobNbrQuery(string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            string InvoiceJobNbr = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetNewInvoiceJobNbr", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    InvoiceJobNbr = Convert.ToString(cmd.ExecuteScalar());
                }
                con.Close();
            }
            return InvoiceJobNbr;
        }

        public int InsertInvoiceJobQuery(string value, string company, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            int jobCreateStatus = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spInsertInvoiceJob", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iInvoiceJobNbr", value);
                    cmd.Parameters.AddWithValue("@cCompany", company);

                    jobCreateStatus = cmd.ExecuteNonQuery();
                }
                con.Close();
            }
            return jobCreateStatus;
        }

        public InvoicePrintType GetInvoicePrintTypeQuery(string invoicePrintType, string TextArgument, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            InvoicePrintType invoice = new InvoicePrintType();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetInvoicePrintType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cArgument", invoicePrintType);
                    cmd.Parameters.AddWithValue("@iArgumentType", TextArgument);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        invoice.CallPrintTypeNbr = Convert.ToInt32(reader["iCallPrintTypeNbr"].ToString());
                        invoice.PrintInvoiceDeliveryAddress = Convert.ToBoolean(reader["bPrintInvoiceDeliveryAddress"].ToString());
                        invoice.PrintTypeDescription = reader["cPrintTypeDescription"].ToString();
                        invoice.PrintTypeDetailLength = Convert.ToInt32(reader["iPrintTypeDetailLength"].ToString());
                        invoice.ReportPrintType = reader["ciReportPrintType"].ToString();
                    }
                }
                con.Close();
            }
            return invoice;
        }

        public string ViewTypeQuery(int TypeNumber, int TypeType, string dbName, int sortOrder = 2, int IsActive = 1)
        {
            string connectionString = cons.GetConn(dbName);
            string typeDescription = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetInvoicePrintType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iNbr", TypeNumber);
                    cmd.Parameters.AddWithValue("@iTypeType", TypeType);
                    cmd.Parameters.AddWithValue("@bActive", IsActive);
                    cmd.Parameters.AddWithValue("@iSortOrder", sortOrder);


                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        typeDescription = reader["cTypeDescription"].ToString();
                    }
                }
                con.Close();
            }
            return typeDescription;
        }
       
        public List<GeneralPricing> GetGeneralPricingForPricingQuery(int address,string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            List<GeneralPricing> pricings = new List<GeneralPricing>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetGeneralPricingForPricing", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iNbr", address);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        GeneralPricing generalPricing = new GeneralPricing();
                        generalPricing.AddressNbr = Convert.ToInt32(reader["iAddressNbr"].ToString());
                        generalPricing.BusinessNbr = Convert.ToInt32(reader["iBusinessNbr"].ToString());
                        generalPricing.ContractDate = DateTime.Parse(reader["dContractDate"].ToString());
                        generalPricing.GeneralPricingIndex = Convert.ToInt32(reader["iGeneralPricingIndex"].ToString());
                        generalPricing.IncludePeriodDescription = Convert.ToBoolean(reader["bIncludePeriodDescription"].ToString());
                        generalPricing.InvoiceAfterMonth = Convert.ToBoolean(reader["bInvoiceAfterMonth"].ToString());
                        generalPricing.InvoiceDescription = reader["cInvoiceDescription"].ToString();
                        generalPricing.InvoiceGroupNbr = Convert.ToInt32(reader["iInvoiceGroupNbr"].ToString());
                        generalPricing.MonthFrequency = Convert.ToInt32(reader["iMonthFrequency"].ToString());
                        generalPricing.Number = Convert.ToDecimal(reader["rNumber"].ToString());
                        generalPricing.Remark = reader["cRemark"].ToString();
                        generalPricing.ShowRemarkOnReport = Convert.ToInt32(reader["iShowRemarkOnReport"].ToString());
                        generalPricing.StartMonth = Convert.ToInt32(reader["iStartMonth"].ToString());
                        generalPricing.StartYear = Convert.ToInt32(reader["iStartYear"].ToString());
                        generalPricing.TotalMonths = Convert.ToInt32(reader["iTotalMonths"].ToString());
                        generalPricing.UnitPrice = Convert.ToDecimal(reader["mUnitPrice"].ToString());
                        generalPricing.VATPercentage = Convert.ToDecimal(reader["rVATPercentage"].ToString());

                        pricings.Add(generalPricing);
                    }
                }
                con.Close();
            }
            return pricings;
        }

        public PricingItem CountPricedItemsQuery(int GeneralPricingIndex, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            PricingItem pricingItem = new PricingItem();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spCountPricedItems", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iGeneralPricingIndex", GeneralPricingIndex);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pricingItem.TotalMonths = Convert.ToInt32(reader["TotalMonths"].ToString()); ;
                        pricingItem.TotalPricingItem = Convert.ToInt32(reader["PricedItemsCount"].ToString());
                    }
                }
                con.Close();
            }
            return pricingItem;
        }

        public PricedItemForPricing GetPricedItemForPricingQuery(int GeneralPricingIndex,int Year,int Month, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            PricedItemForPricing pricingItem = new PricedItemForPricing();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spCountPricedItems", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iGeneralPricingIndex", GeneralPricingIndex);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        pricingItem.GeneralPricingIndex = Convert.ToInt32(reader["iGeneralPricingIndex"].ToString()); ;
                        pricingItem.InvoiceNbr = Convert.ToInt32(reader["iInvoiceNbr"].ToString());
                        pricingItem.Month = Convert.ToInt32(reader["iMonth"].ToString()); ;
                        pricingItem.MonthPeriod = Convert.ToInt32(reader["iMonthPeriod"].ToString());
                        pricingItem.Number = Convert.ToInt32(reader["rNumber"].ToString()); ;
                        pricingItem.PricedItemsIndex = Convert.ToInt32(reader["iPricedItemsIndex"].ToString());
                        pricingItem.UnitPrice = Convert.ToInt32(reader["mUnitPrice"].ToString());
                        pricingItem.VATPercentage = Convert.ToInt32(reader["rVATPercentage"].ToString()); ;
                        pricingItem.Year = Convert.ToInt32(reader["iYear"].ToString());
                    }
                }
                con.Close();
            }
            return pricingItem;
        }

        public Boolean InsertPricedItemsQuery(int iGeneralPricingIndex,int FromMonth,int FromYear,int rNumber,float UnitPrice,
            decimal rVATPercentage,int iMonthFrequency, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            PricedItemForPricing pricingItem = new PricedItemForPricing();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand("spInsertPricedItems", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iGeneralPricingIndex", iGeneralPricingIndex);
                    cmd.Parameters.AddWithValue("@iMonth", FromMonth);
                    cmd.Parameters.AddWithValue("@iYear", FromYear);
                    cmd.Parameters.AddWithValue("@rNumber", rNumber);
                    cmd.Parameters.AddWithValue("@mUnitPrice", UnitPrice);
                    cmd.Parameters.AddWithValue("@rVATPercentage", rVATPercentage);
                    cmd.Parameters.AddWithValue("@iMonthPeriod", iMonthFrequency);
                }
                con.Close();
            }
            return false;
        }
    }
}
