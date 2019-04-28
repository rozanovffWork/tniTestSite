using System.Collections.Generic;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Точка измерения электроэнергии
    /// </summary>
    public class ElectricityMeasurementPoint: BaseDbObject
    {
        public string Name { get; set; }

        public int? ElectricEnergyMeterId { get; set; }

        public int? PowerTransformerId { get; set; }

        public int? VoltageTransformerId { get; set; }

        public int ConsumptionObjectId { get; set; }

        public ConsumptionObject ConsumptionObject { get; set; }

        //[ForeignKey("ElectricEnergyMeterId")]
        public ElectricEnergyMeter ElectricEnergyMeter { get; set; }

        //[ForeignKey("PowerTransformerId")]
        public PowerTransformer PowerTransformer { get; set; }

        //[ForeignKey("VoltageTransformerId")]
        public VoltageTransformer VoltageTransformer { get; set; }

        public List<TimeSet> TimeSets { get; set; }
    }
}
