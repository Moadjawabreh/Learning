using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		 ICategRepsitory categRepsitory { get; }
		IProductRepository productRepository { get; }

		void Save();
	}
}
