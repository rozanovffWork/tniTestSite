using System.Collections.Generic;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Расчетный прибор учета
    /// </summary>
    public class EstimatedMeteringDevice : BaseDbObject
    {

        public int ElectricitySupplyPointId { get; set; }

        public ElectricitySupplyPoint ElectricitySupplyPoint { get; set; }

        public List<TimeSet> TimeSets { get; set; }
    }
}
