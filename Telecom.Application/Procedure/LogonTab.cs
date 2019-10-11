using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Telecom.Application.ViewModels;
using Telecom.Application.Interfaces;

namespace Telecom.Application.Procedure
{
    public class LogonTab : ILogonTab
    {

        Connection cons = new Connection();

        public bool LogOffQuery(Boolean resetCount, string dbName)
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
                    using (SqlCommand cmd = new SqlCommand("spLogOff", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (resetCount)
                            cmd.Parameters.AddWithValue("@ResetLogOnCounter", 1);
                        else
                            cmd.Parameters.AddWithValue("@ResetLogOnCounter", 0);

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
        public bool LogOnQuery(string dbName)
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
                    using (SqlCommand cmd = new SqlCommand("spLogOn", con))
                    {
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

        public UserDetailsViewModel GetUserNameQuery(string strUserName,string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            UserDetailsViewModel userDetails = new UserDetailsViewModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spGetUserName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sUser", strUserName);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userDetails.HostName = reader["cHostName"].ToString();
                        userDetails.LoggedOn = Convert.ToInt32(reader["iLoggedOn"].ToString());
                        userDetails.RealUserName = reader["cRealName"].ToString();
                        userDetails.SecurityLevel = Convert.ToInt32(reader["iSecurityLevel"].ToString());
                        userDetails.ShortSearchList = Convert.ToBoolean(reader["bShortSearchList"].ToString());
                        userDetails.StartWithTasks = Convert.ToBoolean(reader["bStartWithTasks"].ToString());
                        userDetails.UserMessage = reader["cMessage"].ToString();
                        userDetails.UserName = reader["cUserName"].ToString();
                        userDetails.UserNbr = Convert.ToInt32(reader["iUserNbr"].ToString());
                        userDetails.BirthDate = string.IsNullOrEmpty(reader["dBirthdate"].ToString())? 
                            (DateTime?)null:DateTime.Parse(reader["dBirthdate"].ToString());
                    }
                    reader.Close();
                }
                con.Close();
            }
            if(userDetails.UserName != null)
            {
                StaticConstItems.BirthDate = userDetails.BirthDate.ToString();
                StaticConstItems.HostName = userDetails.HostName;
                StaticConstItems.LoggedOn = userDetails.LoggedOn;
                StaticConstItems.RealUserName = userDetails.RealUserName;
                StaticConstItems.SecurityLevel = userDetails.SecurityLevel;
                StaticConstItems.ShortSearchList = userDetails.ShortSearchList;
                StaticConstItems.StartWithTasks = userDetails.StartWithTasks;
                StaticConstItems.UserMessage = userDetails.UserMessage;
                StaticConstItems.UserName = userDetails.UserName;
                StaticConstItems.UserNbr = userDetails.UserNbr;
            }
            return userDetails;
        }
        public UserTask CountUserTask(string userName, int type, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            UserTask userTask = new UserTask();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    int time = con.ConnectionTimeout;
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spCountUserTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cUserName", userName);
                    cmd.Parameters.AddWithValue("@iUserType", type);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userTask.TotalTasks = reader["TotalTasks"].ToString();
                        userTask.DeadlineTasks = reader["DeadlineTasks"].ToString();
                        userTask.OverDeadlineTasks = reader["OverDeadlineTasks"].ToString();
                        userTask.AppointmentTasks = reader["AppointmentTasks"].ToString();
                        userTask.OverAppointmentTasks = reader["OverAppointmentTasks"].ToString();
                        userTask.NoDeadlineDates = reader["NoDeadlineDates"].ToString();
                        userTask.NoAppointmentDates = reader["NoAppointmentDates"].ToString();
                    }
                    reader.Close();
                }
                con.Close();
            }

            return userTask;

        }
        public ResponseTask CountResponseTask(string userName, int type, string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            ResponseTask userTask = new ResponseTask();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand("spCountUserTask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cUserName", userName);
                    cmd.Parameters.AddWithValue("@iUserType", type);

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        userTask.TotalResponseTasks = reader["TotalTasks"].ToString();
                        userTask.DeadlineResponseTasks = reader["DeadlineTasks"].ToString();
                        userTask.OverDeadlineResponseTasks = reader["OverDeadlineTasks"].ToString();
                        userTask.AppointmentResponseTasks = reader["AppointmentTasks"].ToString();
                        userTask.OverAppointmentResponseTasks = reader["OverAppointmentTasks"].ToString();
                        userTask.NoDeadlineDatesResponseTask = reader["NoDeadlineDates"].ToString();
                        userTask.NoAppointmentDatesResponseTask = reader["NoAppointmentDates"].ToString();
                    }
                    reader.Close();
                }
                con.Close();
            }

            return userTask;
        }

        public string GetServerIniDataQuery(int IniIndex, string Default, string dbName, int CompanyNbr = -1)
        {
            string connectionString = cons.GetConn(dbName);
            string data = String.Empty;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetServerIniData", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (CompanyNbr != -1)
                        cmd.Parameters.AddWithValue("@iCompanyNbr", CompanyNbr);
                    cmd.Parameters.AddWithValue("@iIniIndex", IniIndex);

                    con.Open();
                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        data = o.ToString();
                    }
                    con.Close();
                }
            }
            return data;
        }

        public bool CheckBirthdayDate(string BirthDate)
        {
            if(string.IsNullOrEmpty(BirthDate))
                return false;

            int day=DateTime.Now.Day;
            int month = DateTime.Now.Month;
            DateTime birthDay = DateTime.Parse(BirthDate);
            if (birthDay.Month == month && birthDay.Day == day)
                return true;

            return false;
        }
    }
}
