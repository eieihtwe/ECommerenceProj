using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulky.DataAccess.Repository
{
    public class ApplicationUserRepository: Repository<ApplicationUser>,IApplicationUserRepository
    {
        private ApplicationDbContext _dbContext;
        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext= dbContext;
        }
    }
}
