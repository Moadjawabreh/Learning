using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.DataAccess.Data;
using Learning.DataAccess.Repository.IRepository;

namespace Learning.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
		public ICategRepsitory categRepsitory { get; private set; }

        public IProductRepository productRepository { get; private set;}

        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _db = dbContext;
            categRepsitory = new CategRepository(_db);
            productRepository = new ProductRepository(_db);
        }

        public void Save()
		{
			_db.SaveChanges();
		}
	}
}
