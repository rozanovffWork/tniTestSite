namespace tniTestSite.Data.Models
{
    /// <summary>
    /// Силовой трансформатор
    /// </summary>
    public class PowerTransformer : ElectricAppliance
    {
        public string PowerTransformerType { get; set; }

        public double PowerTransformationRatio { get; set; }
    }
}
