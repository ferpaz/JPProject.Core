using System.Collections.Generic;
using JPProject.EntityFrameworkCore.Interfaces;
using JPProject.EntityFrameworkCore.Repository;
using JPProject.Sso.Domain.Interfaces;
using JPProject.Sso.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JPProject.Sso.EntityFramework.Repository.Repository
{
    public class GlobalConfigurationSettingsRepository : Repository<GlobalConfigurationSettings>, IGlobalConfigurationSettingsRepository
    {
        public GlobalConfigurationSettingsRepository(IJpEntityFrameworkStore context) : base(context)
        {
        }

        public Task<GlobalConfigurationSettings> FindByKey(string key)
        {
            return DbSet.FirstOrDefaultAsync(f => f.Key == key);
        }

        public Task<List<GlobalConfigurationSettings>> All()
        {
            return DbSet.ToListAsync();
        }
    }
}
