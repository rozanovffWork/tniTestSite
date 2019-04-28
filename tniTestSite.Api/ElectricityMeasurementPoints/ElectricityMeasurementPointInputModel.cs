using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class ElectricityMeasurementPointInputModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Объект потребления")]
        [Range(minimum:1, maximum:Int32.MaxValue)]
        public int ConsumptionObjectId { get; set; }

        public ElectricEnergyMeterInputModel ElectricEnergyMeter { get; set; }

        public PowerTransformerInputModel PowerTransformer { get; set; }


        public VoltageTransformerInputModel VoltageTransformer { get; set; }
    }


}
