using Learning.DataAccess.Data;
using Learning.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private ApplicationDbContext _db;
		internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
			dbSet = _db.Set<T>();
        }
        public void Add(T entity)
		{
			dbSet.Add(entity);

		}

		public void Delete(T entity)
		{
			dbSet.Remove(entity);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}

		public T Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query=query.Where(filter);
			return query.FirstOrDefault();
		}

		public IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}
	}
}
