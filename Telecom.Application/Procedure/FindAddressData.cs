using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Telecom.Application.ViewModels;

namespace Telecom.Application.Procedure
{
    public class FindAddressData
    {
        Connection cons = new Connection();

        public IList<AddressDetail> FindAddressNbr(string SearchString, int AddressType,string procedure ,string dbName)
        {
            string connectionString = cons.GetConn(dbName);
            IList<AddressDetail> addrssList = new List<AddressDetail>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                using (SqlCommand cmd = new SqlCommand(procedure, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SearchString", SearchString);
                    cmd.Parameters.AddWithValue("@AddressType", AddressType.ToString());

                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    AddressDetail com;
                    while (reader.Read())
                    {
                        com = new AddressDetail
                        {
                            AddressNbr = Convert.ToInt32(reader["Addressnumber"].ToString()),
                            Name = reader["Name"].ToString(),
                            Street = reader["Street"].ToString(),
                            Zipcode = int.TryParse(reader["Zip"].ToString(), out int tempVal) ? Int32.Parse(reader["Zip"].ToString()) : (int?)null,
                            City = reader["City"].ToString(),
                            Country = reader["Country"].ToString(),
                            Remark = reader["Remark"].ToString(),
                        };
                        addrssList.Add(com);
                    }
                    reader.Close();
                }
            }
            return addrssList;
        }
    }
}
