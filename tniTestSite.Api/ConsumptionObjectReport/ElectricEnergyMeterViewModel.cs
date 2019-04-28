using System;
using System.ComponentModel;

namespace tniTestSite.Api.ConsumptionObjectReport
{
    public class ElectricEnergyMeterViewModel
    {
        [DisplayName("Тип счетчика")]
        public string CounterType { get; set; }

        [DisplayName("Номер")]
        public string Number { get; set; }

        [DisplayName("Дата поверки")]
        public DateTime VerificationDate { get; set; }
    }
}