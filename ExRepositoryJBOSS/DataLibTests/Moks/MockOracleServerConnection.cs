using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibTests.Moks
{
    //фейковый тестовый класс, который
    //подменяет собой реальный класс 
    //для соединения и работы с Oracle,
    //который вам придется написать самому.
    class MockOracleServerConnection
    {
        internal string[] Getdata(string sqlRequest)
        {
            if (string.IsNullOrEmpty(sqlRequest))
                throw new ArgumentException(nameof(sqlRequest));

            var all = "select LABID, DESCRIPTION from KNCHDATA.LABS;";
            var id = "select LABID, DESCRIPTION from KNCHDATA.LABS where LABID=345;";
            


            string[] result = null;
            if (sqlRequest.Equals(all))
            {
                result = new[]
                {
                    "456;testlab1",
                    "123;testlab2",
                    "345;testlab3",
                };
            }
            if (sqlRequest.Equals(id))
            {
                result = new[]
                {
                    "345;testlab3",
                };
            }

            return result;
        }

        internal int Updatedata(string sqlRequest, int userId, string userName)
        {
            if (string.IsNullOrEmpty(sqlRequest))
                throw new ArgumentException(nameof(sqlRequest));
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException(nameof(userName));

            var insert = "insert into KNCHDATA.LABS (LABID, DESCRIPTION) " +
                $"values (0, testlab4);";

            var update = $"update KNCHDATA.LABS set DESCRIPTION=testlab3 " +
                $"where LABID=345;";

            var delete = $"delete from KNCHDATA.LABS where LABID=345;";

            if (sqlRequest.Equals(insert))
            {
                return 0;
            }
            if (sqlRequest.Equals(update))
            {
                return 0;
            }
            if (sqlRequest.Equals(delete))
            {
                return 0;
            }

            return -1;
        }
    }
}
