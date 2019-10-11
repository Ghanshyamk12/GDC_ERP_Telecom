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
    public class AccountController : Controller
    {
        ILoginRepository _loginRepository;
        public AccountController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel
            {
                DatabaseName = _loginRepository.GetDatabaseName()
            };
            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                if(_loginRepository.CheckLoginCredential(loginView))
                {
                    HttpContext.Session.SetString("Database_Name",loginView.SelectedDatabaseName);
                    HttpContext.Session.SetString("UserName", loginView.UserName);
                    HttpContext.Session.SetString("DatabaseSwap", "true");
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("Error", "Wrong User Credential");
            loginView.DatabaseName = _loginRepository.GetDatabaseName();

            return View(loginView);
        }

        public IActionResult Logout()
        {
            //Response.Cookies.Delete();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Account");
        }
    }
}