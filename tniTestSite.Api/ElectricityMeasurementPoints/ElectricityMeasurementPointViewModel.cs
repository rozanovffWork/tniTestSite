using System.ComponentModel;

namespace tniTestSite.Api.ElectricityMeasurementPoints
{
    public class ElectricityMeasurementPointViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
    }
}