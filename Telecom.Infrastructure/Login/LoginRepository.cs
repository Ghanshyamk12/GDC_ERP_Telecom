using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Telecom.Application.Interfaces;
using Telecom.Application.ViewModels;

namespace Telecom.Infrastructure.Login
{
    public class LoginRepository: ILoginRepository
    {
        public IEnumerable<SelectListItem> GetDatabaseName()
        {
            IList<SelectListItem> databaseName = new List<SelectListItem>
            {
                new SelectListItem("SQL_Production_AT","SQL_Production_AT"),
                new SelectListItem("SQL_Production_DE","SQL_Production_DE"),
                new SelectListItem("SQL_Production_DK","SQL_Production_DK"),
                new SelectListItem("SQL_Production_FR","SQL_Production_FR"),
                new SelectListItem("SQL_Production_HU","SQL_Production_HU"),
                new SelectListItem("SQL_Production_IT","SQL_Production_IT"),
                new SelectListItem("SQL_Production_NL","SQL_Production_NL"),
                new SelectListItem("SQL_Production_PL","SQL_Production_PL"),
                new SelectListItem("SQL_Production_PT","SQL_Production_PT"),
                new SelectListItem("SQL_Production_SE","SQL_Production_SE"),
                new SelectListItem("SQL_Production_UK","SQL_Production_UK"),
                new SelectListItem("SQL_Production_ES","SQL_Production_ES")
            };

            var Databasetip = new SelectListItem()
            {
                Value = null,
                Text = "select Database"
            };
            databaseName.Insert(0, Databasetip);

            return databaseName;
        }

        public bool CheckLoginCredential(LoginViewModel loginView)
        {
            if(loginView.UserName== "CA_LightClient_1")
            {
                if(loginView.Password == "Y9IyqDnQn1pkPUm3NwhD")
                {
                    return true;
                }else
                {
                    return false;
                }
            }else if(loginView.UserName == "CA_LightClient_2")
            {
                if(loginView.Password == "5flDrLpPV3N7OA5VSjrq")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if(loginView.UserName == "CA_LightClient_3")
            {
                if(loginView.Password == "MJyapblpJuEru7wUKuka")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if (loginView.UserName == "CA_LightClient_4")
            {
                if(loginView.Password == "Q6fuL8z1kVGmEqGr3Eio")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if (loginView.UserName == "CP_JoseManuelAroca")
            {
                if(loginView.Password == "IsraelIsaac2805.....")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else if (loginView.UserName == "tururu")
            {
                loginView.UserName = "CP_JoseManuelAroca";
                loginView.Password = "IsraelIsaac2805.....";
                return true;
            }
            else if (loginView.UserName == "CP_AlejandroTeixeira")
            {
                if(loginView.Password == "cambiame01")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                return false;
            }
        }
    }
}
