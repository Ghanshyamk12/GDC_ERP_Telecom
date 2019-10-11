using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Telecom.Application.DatabaseContext
{
    public class DataContext:DbContext
    {
       
        public DataContext(DbContextOptions<DataContext> conn):base(conn)
        {
        } 
    }
}
