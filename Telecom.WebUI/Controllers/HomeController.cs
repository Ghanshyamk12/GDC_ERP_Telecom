using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Telecom.Application;
using Telecom.Application.Interfaces;
using Telecom.Application.ViewModels;
using Telecom.WebUI.Models;

namespace Telecom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ILogonTab _logonTab;
        ILoginRepository _loginRepository;
        public HomeController(ILogonTab logonTab, ILoginRepository loginRepository)
        {
            _logonTab = logonTab;
            _loginRepository = loginRepository;
        }
        public IActionResult Index()
        {
            try
            {
                DefaultViewModel viewModel = new DefaultViewModel();
                string userName = HttpContext.Session.GetString("UserName");
                string databaseName = HttpContext.Session.GetString("Database_Name");

                if( userName!=null && databaseName != null)
                {
                    //----------------------Default event-------------------------------
                    //SQLDateFormat:= StrToInt64(fuGetServerIniDataQuery(iniSQLDateFormats, '2'));
                    
                   string SQLDataFormat_temp=_logonTab.GetServerIniDataQuery(StaticConstItems.IniSQLDateFormats,"2",databaseName);
                    int SqlDataFormate = 0;
                    if (SQLDataFormat_temp != null)
                        SqlDataFormate = Convert.ToInt32(SQLDataFormat_temp);

                    if (_logonTab.LogOnQuery(databaseName))
                    {
                        //----------Get User Details-------------------------
                        _logonTab.GetUserNameQuery(userName, databaseName);
                        //---------Set security level -----------------------

                        //---------Check Birthday date-------------
                        if (_logonTab.CheckBirthdayDate(StaticConstItems.BirthDate))
                        {
                            //ViewBag.Birthday=""
                        }
                    }
                    //------------------------Logon Tab---------------------------------
                    viewModel.UserTask = _logonTab.CountUserTask(userName, 1, databaseName);
                    viewModel.ResponseTask = _logonTab.CountResponseTask(userName, 1, databaseName);
                    viewModel.UserName = HttpContext.Session.GetString("UserName");
                    viewModel.SeletedDatabase = HttpContext.Session.GetString("Database_Name");
                    viewModel.DatabaseName = _loginRepository.GetDatabaseName();
                    if(HttpContext.Session.GetString("DatabaseSwap")=="true")
                        viewModel.DatabaseState = true;
                    else
                        viewModel.DatabaseState = false;
                }
                else
                {
                   return RedirectToAction("login", "Account");
                }                
                return View(viewModel);
            }catch(Exception ex)
            {
                if(ex is SqlException)
                    throw new Exception(ex.Message);
                else
                    throw new Exception(ex.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetSelectDatabase(string DatabaseName)
        {
            HttpContext.Session.SetString("Database_Name", DatabaseName);
            return RedirectToAction("Index", "Home");
        }

    }
}
