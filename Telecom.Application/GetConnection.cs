using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application
{
    public class Connection
    {
        private string SQL_Production_AT { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_AT;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;Connection Timeout=10";
        private string SQL_Production_DE { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_DE;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_DK { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_DK;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_FR { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_FR;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_HU { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_HU;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_IT { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_IT;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_NL { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_NL;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_PL { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_PL;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_PT { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_PT;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_SE { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_SE;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_UK { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_UK;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        private string SQL_Production_ES { get; } = "Data Source=10.196.108.132;Initial Catalog=GDC_ERP_ES;User ID=CA_LightClient;Password=DtCRg1B19MflxQJPM&32LHliR;";
        public string GetConn(string name)
        {
            if (name == "SQL_Production_AT")
                return SQL_Production_AT;
            else if (name == "SQL_Production_DE")
                return SQL_Production_DE;
            else if (name == "SQL_Production_DK")
                return SQL_Production_DK;
            else if (name == "SQL_Production_FR")
                return SQL_Production_FR;
            else if (name == "SQL_Production_HU")
                return SQL_Production_HU;
            else if (name == "SQL_Production_IT")
                return SQL_Production_IT;
            else if (name == "SQL_Production_NL")
                return SQL_Production_NL;
            else if (name == "SQL_Production_PL")
                return SQL_Production_PL;
            else if (name == "SQL_Production_PT")
                return SQL_Production_PT;
            else if (name == "SQL_Production_SE")
                return SQL_Production_SE;
            else if (name == "SQL_Production_UK")
                return SQL_Production_UK;
            else if (name == "SQL_Production_ES")
                return SQL_Production_ES;
            else
                return null;
        }
    }
}
