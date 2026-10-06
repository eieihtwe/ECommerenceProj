using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bulky.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _dbContext;
        public CompanyRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Company obj)
        {
            _dbContext.Companies.Update(obj);
        }
    }
}
