using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application
{
    public static class StaticConstItems
    {
        public static int IniSQLDateFormats { get;} = 10;

        //---------------------User Details--------------------//
        public static string HostName { get; set; }
        public static string UserName { get; set; }
        public static int LoggedOn { get; set; }
        public static int UserNbr { get; set; }

        public static bool StartWithTasks { get; set; }
        public static bool ShortSearchList { get; set; }
        public static int SecurityLevel { get; set; }
        public static string BirthDate { get; set; }
        public static string UserMessage { get; set; }
        public static string RealUserName { get; set; }

        //-----------------Flag type---------------------
        public static int InvoicingFlag { get; } = 479;
        public static int GenerateRemindersFlag { get; } = 491;
        public static int PricingSimFlag { get; } = 868;
        public static int ReverseBillingSimFlag { get; } = 1359;
        public static int PrintingInvoicesFlag { get; } = 2152;

        public static int IniDefaultVATPercentage { get; } = 28;
        public static int DefaultVAT { get; } = 21;
    }
}
