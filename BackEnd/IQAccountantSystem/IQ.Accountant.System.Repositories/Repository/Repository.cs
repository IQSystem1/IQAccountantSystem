using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Entities.GR.Data;
using IQ.Accountant.System.Model;
using IQ.Accountant.System.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQ.Accountant.System.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IQAccountantSystemContext _context;
        private DbSet<T> entities;
        public Repository(IQAccountantSystemContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }
        public SuccessMessage Delete(int id)
        {
            SuccessMessage sm = new SuccessMessage();
            sm.isSuccess = false;
            sm.dateTime = DateTime.Now;
            try
            {
                var entity = entities.Find(id);
                if (entity == null)
                {
                    sm.message = "Entity is null";
                }
                else
                {
                    entities.Remove(entity);
                    _context.SaveChanges();
                    sm.isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                sm.message = ex.Message;
            }
            return sm;
        }

        public IEnumerable<T> Get()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.Find(id);
        }

        public T Insert(T entity)
        {
      
            
            try
            {
                if (entity == null)
                {
                    entity.ErrorMessage = "No Entity";
                }
                else
                {
                    entity.AddedDate = DateTime.Now;
                    entities.Add(entity);
                    _context.SaveChanges();
                }
                return entity;
            }
            catch (Exception ex)
            {

                entity.ErrorMessage = ex.Message;
                return entity;
            }

        }

        public T Update(T entity)
        {

            try
            {
                if (entity != null)
                {
                    entity.ModifiedDate = DateTime.Now;
                    entities.Update(entity);
                    _context.SaveChanges();
                    return entity;
                }
                return null;

            }
            catch
            {
                return null;
            }
        }


    }
}
