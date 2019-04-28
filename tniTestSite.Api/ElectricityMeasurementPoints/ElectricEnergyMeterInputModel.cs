using System.ComponentModel;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class ElectricEnergyMeterInputModel: ElectricApplianceInputModel
    {
        [DisplayName("Тип счетчика")]
        public string CounterType { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(CounterType) && base.IsEmpty();
        }
    }


}
