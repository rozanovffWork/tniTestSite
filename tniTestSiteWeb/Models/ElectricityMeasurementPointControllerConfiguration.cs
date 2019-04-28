namespace tniTestSiteWeb.Controllers
{
    public class ElectricityMeasurementPointControllerConfiguration
    {
        public string ElectricityMeasurementPointsUrl { get; set; }

        public static ElectricityMeasurementPointControllerConfiguration GetFromDefaults()
        {
            var result = new ElectricityMeasurementPointControllerConfiguration
            {
                ElectricityMeasurementPointsUrl = "http://localhost:8050/api/ElectricityMeasurementPoints"
            };

            return result;

        }
    }
}