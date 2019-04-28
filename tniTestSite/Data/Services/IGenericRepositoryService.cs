using System.Linq;
using tniTestSite.Data.Models;

namespace tniTestSite.Service
{
    public interface IGenericRepositoryService<TEntity>
        where TEntity : ElectricAppliance
    {
        IQueryable<TEntity> GetExpextedVerificationDate(int measurementPointId);
    }
}
