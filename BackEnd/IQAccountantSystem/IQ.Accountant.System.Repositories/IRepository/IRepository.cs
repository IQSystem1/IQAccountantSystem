using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Entities.GR.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> Get();
        T Get(int id);
        T Insert(T entity);
        T Update(T entity);
        SuccessMessage Delete(int id);
    }
}
