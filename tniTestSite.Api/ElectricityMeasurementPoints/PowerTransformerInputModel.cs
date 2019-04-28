using System.ComponentModel;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class PowerTransformerInputModel: ElectricApplianceInputModel
    {
        [DisplayName("Тип трансформатора тока")]
        public string PowerTransformerType { get; set; }

        [DisplayName("КТT (коэффициент трансформации)")]
        public double? PowerTransformationRatio { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(PowerTransformerType) && PowerTransformationRatio == null && base.IsEmpty();
        }
    }


}
