using System;
using System.Linq;
using tniTestSite.Data;
using tniTestSite.Data.Models;

namespace tniTestSite.Service.Implementation
{

    public class GenericRepositoryService<TEntity> : IGenericRepositoryService<TEntity>
        where TEntity : ElectricAppliance
    {
        private readonly ApplicationDbContext _context;

        public GenericRepositoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetExpextedVerificationDate(int сonsumptionObjectId)
        {

           var measurementPointsIds= _context.ElectricityMeasurementPoints
               .Where(w => w.ConsumptionObjectId == сonsumptionObjectId)
                .Select(s => s.Id).ToArray();

            return _context.Set<TEntity>()
                .Where(w => w.VerificationDate < DateTime.Now 
                            && w.ElectricityMeasurementPointId.HasValue 
                            && measurementPointsIds.Contains(w.ElectricityMeasurementPointId.Value));
        }
    }
}
