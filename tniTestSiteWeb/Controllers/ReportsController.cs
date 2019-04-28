using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using tniTestSite.Api.ConsumptionObjectReport;
using tniTestSite.Api.EstimatedMeteringDevices;
using tniTestSiteWeb.Services;

namespace tniTestSiteWeb.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IHttpService _httpService;
        private readonly ReportsControllerConfiguration _config;
        private readonly IConsumptionObjectService _consumptionObjectService;

        public ReportsController(IHttpService httpService, ReportsControllerConfiguration config, IConsumptionObjectService consumptionObjectService)
        {
            _httpService = httpService;
            _config = config;
            _consumptionObjectService = consumptionObjectService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEMDeviceByYear(int year)
        {
            KeyValuePair<string, string>[] content = new KeyValuePair<string, string>[0];
            string response = _httpService.GetAndReadAsString(_config.GetEMDeviceByYearUrl + year.ToString(), content);
            EstimatedMeteringDeviceViewModel[] result = JsonConvert.DeserializeObject<EstimatedMeteringDeviceViewModel[]>(response);
            return View(result);
        }

        public IActionResult GetConsumptionObjects()
        {
            var result = _consumptionObjectService.GetConsumptionObjects();
            return View(result);
        }

        public IActionResult GetExpiredEnergyMeters(int сonsumptionObjectId)
        {
            KeyValuePair<string, string>[] content = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("сonsumptionObjectId", сonsumptionObjectId.ToString()),
            };
            string response = _httpService.GetAndReadAsString(_config.GetExpiredEnergyMetersUrl, content);
            ElectricEnergyMeterViewModel[] result = JsonConvert.DeserializeObject<ElectricEnergyMeterViewModel[]>(response);
            return View(result);
        }

        public IActionResult GetExpiredPowerTransformator(int сonsumptionObjectId)
        {
            KeyValuePair<string, string>[] content = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("сonsumptionObjectId", сonsumptionObjectId.ToString()),
            };
            string response = _httpService.GetAndReadAsString(_config.GetExpiredPowerTransformatorUrl, content);
            PowerTransformerViewModel[] result = JsonConvert.DeserializeObject<PowerTransformerViewModel[]>(response);
            return View(result);
        }

        public IActionResult GetExpiredVoltageTransformer(int сonsumptionObjectId)
        {
            KeyValuePair<string, string>[] content = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>("сonsumptionObjectId", сonsumptionObjectId.ToString()),
            };
            string response = _httpService.GetAndReadAsString(_config.GetExpiredVoltageTransformerUrl, content);
            VoltageTransformerViewModel[] result = JsonConvert.DeserializeObject<VoltageTransformerViewModel[]>(response);
            return View(result);
        }
    }
}