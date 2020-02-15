using IdentityServer4.EntityFramework.Entities;
using JPProject.Admin.Domain.Interfaces;
using JPProject.EntityFrameworkCore.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPProject.Admin.Infra.Data.Context;

namespace JPProject.Admin.Infra.Data.Repository
{
    public class ClientClaimRepository : Repository<ClientClaim>, IClientClaimRepository
    {
        public ClientClaimRepository(IConfigurationStore adminUiContext) : base(adminUiContext)
        {
        }

        public async Task<IEnumerable<ClientClaim>> GetByClientId(string clientId)
        {
            return await DbSet.Where(s => s.Client.ClientId == clientId).ToListAsync();
        }
    }
}