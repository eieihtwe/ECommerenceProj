using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulky.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ShoppingCartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }

        public void Update(ShoppingCart obj)
        {
            _dbContext.shoppingCarts.Update(obj);
        }
    }
}
