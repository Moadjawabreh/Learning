using Learning.DataAccess.Data;
using Learning.DataAccess.Repository.IRepository;
using Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess.Repository
{
	public class CategRepository : Repository<Categ>, ICategRepsitory 
	{
		private readonly ApplicationDbContext _db;
		public CategRepository(ApplicationDbContext db) : base(db)
		{
			_db=db;

		}

		

		public void Update(Categ categ)
		{
			_db.categs.Update(categ);

		}
	}
}
