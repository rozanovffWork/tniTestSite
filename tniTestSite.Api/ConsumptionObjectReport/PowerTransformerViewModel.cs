using System;
using System.ComponentModel;

namespace tniTestSite.Api.ConsumptionObjectReport
{
    public class PowerTransformerViewModel
    {
        [DisplayName("Тип трансформатора тока")]
        public string PowerTransformerType { get; set; }

        [DisplayName("КТT (коэффициент трансформации)")]
        public double PowerTransformationRatio { get; set; }

        [DisplayName("Номер")]
        public string Number { get; set; }

        [DisplayName("Дата поверки")]
        public DateTime VerificationDate { get; set; }

    }
}