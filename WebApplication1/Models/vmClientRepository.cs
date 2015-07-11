using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication1.Models
{   
	public  class vmClientRepository : EFRepository<vmClient>, IvmClientRepository
	{

	}

	public  interface IvmClientRepository : IRepository<vmClient>
	{

	}
}