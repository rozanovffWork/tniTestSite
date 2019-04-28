using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Интервал времени
    /// </summary>
    public class TimeSet : BaseDbObject
    {
        public DateTime? DateStart { get; set; }

        public DateTime? DateFinish { get; set; }

        public int ElectricityMeasurementPointId { get; set; }

        [ForeignKey("ElectricityMeasurementPointId")]
        public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }

        public int EstimatedMeteringDeviceId { get; set; }

        [ForeignKey("EstimatedMeteringDeviceId")]
        public EstimatedMeteringDevice EstimatedMeteringDevice { get; set; }
    }
}
