using DataLib.Abstractions;
using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLib.Repositories
{
    public class KnchRepository : IKnchRepository
    {
        //ctor
        public KnchRepository(IConnection connection)
        {
            Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public IConnection Connection { get; }

        public Task<int> AddAsync(Knch entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Knch>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Knch> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveAsync(Knch entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Knch entity)
        {
            throw new NotImplementedException();
        }
    }
}
