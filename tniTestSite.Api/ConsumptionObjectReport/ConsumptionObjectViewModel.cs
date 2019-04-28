using System.ComponentModel;

namespace tniTestSite.Api.ConsumptionObjectReport
{
    public class ConsumptionObjectViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }
    }
}