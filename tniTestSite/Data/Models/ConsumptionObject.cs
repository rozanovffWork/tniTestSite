using System.Collections.Generic;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Объект потребления
    /// </summary>
    public class ConsumptionObject : BaseDbObject
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int OrganizationId { get; set; }

        public SubsidiaryOrganization Organization { get; set; }

        public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; set; }

        public List<ElectricityMeasurementPoint> ElectricityMeasurementPoints { get; set; }
    }
}
