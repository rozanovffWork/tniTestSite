using System;
using System.ComponentModel;

namespace tniTestSite.Api.ConsumptionObjectReport
{
    public class VoltageTransformerViewModel
    {
        [DisplayName("Тип трансформатора напряжения")]
        public string VoltageTransformerType { get; set; }

        [DisplayName("КТН (коэффициент трансформации)")]
        public double VoltageTransformationRatio { get; set; }

        [DisplayName("Номер")]
        public string Number { get; set; }

        [DisplayName("Дата поверки")]
        public DateTime VerificationDate { get; set; }
    }
}