namespace tniTestSite.Data.Models
{
    /// <summary>
    /// трансформатор напряжения
    /// </summary>
    public class VoltageTransformer : ElectricAppliance
    {
        public string VoltageTransformerType { get; set; }

        public double VoltageTransformationRatio { get; set; }
    }
}
