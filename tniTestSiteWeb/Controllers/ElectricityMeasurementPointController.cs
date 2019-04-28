using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tniTestSiteWeb.Services;
using Newtonsoft.Json;
using tniTestSite.Api.ElectricityMeasurementPoints;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace tniTestSiteWeb.Controllers
{
    public class ElectricityMeasurementPointController : Controller
    {
        private readonly IHttpService _httpService;
        private readonly ElectricityMeasurementPointControllerConfiguration _config;
        private readonly IConsumptionObjectService _consumptionObjectService;

        public ElectricityMeasurementPointController(IHttpService httpService, ElectricityMeasurementPointControllerConfiguration config, IConsumptionObjectService consumptionObjectService)
        {
            _httpService = httpService;
            _config = config;
            _consumptionObjectService = consumptionObjectService;
        }

        public IActionResult Index()
        {
            var content = new KeyValuePair<string, string>[]
            {
                new KeyValuePair<string, string>(),
            };
            var response = _httpService.GetAndReadAsString(_config.ElectricityMeasurementPointsUrl, content);
            var result = JsonConvert.DeserializeObject<ElectricityMeasurementPointViewModel[]>(response);
            return View(result);
        }

        public IActionResult Create()
        {
            var objects = _consumptionObjectService.GetConsumptionObjects();
            ViewBag.ConsumptionObjects = new SelectList(objects, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ElectricityMeasurementPointInputModel model)
        {
            TryValidateModel(model);

            if (ModelState.IsValid)
            {
                var content = JsonConvert.SerializeObject(model);
                var response = _httpService.PostStringAndReadAsString(_config.ElectricityMeasurementPointsUrl, content);
                var measurementPoint = JsonConvert.DeserializeObject<ElectricityMeasurementPointInputModel>(response);
                return RedirectToAction(actionName: nameof(Index));
            }
            else
            {
                var objects = _consumptionObjectService.GetConsumptionObjects();
                ViewBag.ConsumptionObjects = new SelectList(objects, "Id", "Name");
            }

            return View(model);
        }
    }
}