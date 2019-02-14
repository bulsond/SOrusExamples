using DataLib.Abstractions;
using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLib.Repositories
{
    public class LabRepository : ILabRepository
    {
        //ctor
        public LabRepository(IConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public IConnection Connection { get; }


        #region IRepository
        public async Task<IEnumerable<Lab>> GetAsync()
        {
            string sql = "select LABID, DESCRIPTION from KNCHDATA.LABS;";
            string[] labStrs = await Connection.GetDataAsync(sql);

            var result = new List<Lab>();
            if (labStrs.Any())
            {
                foreach (var labStr in labStrs)
                {
                    string[] strs = labStr.Split(Connection.Separators,
                                           StringSplitOptions.RemoveEmptyEntries);

                    var lab = new Lab { Id = int.Parse(strs[0]), Description = strs[1] };
                    result.Add(lab);
                }
            }

            return result.AsEnumerable();
        }

        public async Task<Lab> GetAsync(int id)
        {
            string sql = $"select LABID, DESCRIPTION from KNCHDATA.LABS where LABID={id};";
            string[] labStrs = await Connection.GetDataAsync(sql);

            var result = new Lab();
            if (labStrs.Any())
            {
                string[] strs = labStrs[0].Split(Connection.Separators,
                                           StringSplitOptions.RemoveEmptyEntries);

                result.Id = int.Parse(strs[0]);
                result.Description = strs[1];
            }

            return result;
        }

        public async Task<int> AddAsync(Lab lab)
        {
            if (lab == null) throw new ArgumentNullException(nameof(lab));
            if (lab.Id != 0) throw new ArgumentException("Попытка создания новой записи, которая имеет ненулевой Id");

            string sql = $"insert into KNCHDATA.LABS (LABID, DESCRIPTION) " +
                $"values ({lab.Id}, {lab.Description});";

            return await Connection.UpdateDataAsync(sql);
        }

        public async Task<int> UpdateAsync(Lab lab)
        {
            if (lab == null) throw new ArgumentNullException(nameof(lab));
            if (lab.Id == 0) throw new ArgumentException("Попытка обновления записи, которая имеет нулевой Id");

            string sql = $"update KNCHDATA.LABS set DESCRIPTION={lab.Description} " +
                $"where LABID={lab.Id};";

            return await Connection.UpdateDataAsync(sql);
        }

        public async Task<int> RemoveAsync(Lab lab)
        {
            if (lab == null) throw new ArgumentNullException(nameof(lab));
            if (lab.Id == 0) throw new ArgumentException("Попытка удаления записи, которая имеет нулевой Id");

            string sql = $"delete from KNCHDATA.LABS where LABID={lab.Id};";

            return await Connection.UpdateDataAsync(sql);
        } 
        #endregion
    }
}
