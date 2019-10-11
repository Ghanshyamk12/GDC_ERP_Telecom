using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class UserDetailsViewModel
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public int LoggedOn { get; set; }
        public int UserNbr { get; set; }
        public bool StartWithTasks { get; set; }
        public bool ShortSearchList { get; set; }
        public int SecurityLevel { get; set; }
        public DateTime? BirthDate { get; set; }
        public string UserMessage { get; set; }
        public string RealUserName { get; set; }
    }
}
