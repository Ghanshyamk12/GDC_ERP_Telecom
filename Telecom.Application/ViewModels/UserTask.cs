using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.ViewModels
{
    public class UserTask
    {
        public string TotalTasks { get; set; }
        public string DeadlineTasks { get; set; }
        public string OverDeadlineTasks { get; set; }
        public string AppointmentTasks { get; set; }
        public string OverAppointmentTasks { get; set; }
        public string NoDeadlineDates { get; set; }
        public string NoAppointmentDates { get; set; }
    }

    public class ResponseTask
    {
        public string TotalResponseTasks { get; set; }
        public string DeadlineResponseTasks { get; set; }
        public string OverDeadlineResponseTasks { get; set; }
        public string AppointmentResponseTasks { get; set; }
        public string OverAppointmentResponseTasks { get; set; }
        public string NoDeadlineDatesResponseTask { get; set; }
        public string NoAppointmentDatesResponseTask { get; set; }
    }
}
