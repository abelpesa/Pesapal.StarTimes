using System;
using System.Collections.Generic;
using System.Text;

namespace StarTimes.DAL.Database
{
    public class DBInitializer
    {

        public static void InitializeDB(StarTimesContext starTimesContext)
        {

            starTimesContext.Database.EnsureCreated();
        
        }
    }
}
