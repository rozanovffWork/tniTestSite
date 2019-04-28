using System;
using System.ComponentModel;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class VoltageTransformerInputModel : ElectricApplianceInputModel
    {
        [DisplayName("Тип трансформатора напряжения")]
        public string VoltageTransformerType { get; set; }

        [DisplayName("КТН (коэффициент трансформации)")]
        public double? VoltageTransformationRatio { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(VoltageTransformerType) && VoltageTransformationRatio == null && base.IsEmpty();
        }
    }


}
