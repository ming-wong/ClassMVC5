using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {

            return base.All().Where(p=>p.Active == true);
        }
        public IQueryable<Product> 取得前5筆資料()
        {
            return this.All().Take(5);
        }

        public Product Find(int id)
        {
            return this.All().FirstOrDefault(p => p.ProductId == id);
        }

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}