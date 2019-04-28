namespace tniTestSiteWeb.Controllers
{
    public class ReportsControllerConfiguration
    {
        public string GetExpiredEnergyMetersUrl { get; set; }
        public string GetExpiredPowerTransformatorUrl { get; set; }
        public string GetExpiredVoltageTransformerUrl { get; internal set; }
        public string GetEMDeviceByYearUrl { get; internal set; }
        public string GetConsumptionObjectsUrl { get; internal set; }

        public static ReportsControllerConfiguration GetFromDefaults()
        {
            var result = new ReportsControllerConfiguration
            {
                GetExpiredEnergyMetersUrl = "http://localhost:8050/api/ConsumptionObjectReport/ExpiredEnergyMeters",
                GetExpiredPowerTransformatorUrl = "http://localhost:8050/api/ConsumptionObjectReport/ExpiredPowerTransformator",
                GetEMDeviceByYearUrl = "http://localhost:8050/api/EstimatedMeteringDevices/getByYear",
                GetExpiredVoltageTransformerUrl = "http://localhost:8050/api/ConsumptionObjectReport/ExpiredVoltageTransformer",
                GetConsumptionObjectsUrl = "http://localhost:8050/api/ConsumptionObjectReport",

            };

            return result;
        }
            
    }
}