using System;

namespace tniTestSite.Data.Models
{
    public class ElectricAppliance : BaseDbObject
    {
        public string Number { get; set; }

        public DateTime VerificationDate { get; set; }

        public int? ElectricityMeasurementPointId { get; set; }

        //[ForeignKey("ElectricityMeasurementPointId")]
        public ElectricityMeasurementPoint ElectricityMeasurementPoint { get; set; }
    }
}
