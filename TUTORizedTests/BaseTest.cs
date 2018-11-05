using System;
using System.Collections.Generic;
using System.Text;

namespace TUTORizedTests
{
    public class BaseTest
    {

        protected readonly string _connection;
        public BaseTest()
        {
            _connection =
                "Server=tcp:tma.database.windows.net,1433;Initial Catalog=TMA;Persist Security Info=False;User ID=tmadev;Password=!qa@ws3ed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
