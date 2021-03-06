using System;
using System.Threading.Tasks;

namespace JPProject.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
