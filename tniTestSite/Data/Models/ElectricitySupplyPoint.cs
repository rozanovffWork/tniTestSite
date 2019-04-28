using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Точка поставки электроэнергии
    /// </summary>
    public class ElectricitySupplyPoint : BaseDbObject
    {
        public string Name { get; set; }

        //Maximum power, kW
        [Column(TypeName = "decimal(18, 4)")]
        public decimal MaximumPower { get; set; }

        public int ConsumptionObjectId { get; set; }

        public ConsumptionObject ConsumptionObject { get; set; }

        public List<EstimatedMeteringDevice> EstimatedMeteringDevices { get; set; }
    }
}
