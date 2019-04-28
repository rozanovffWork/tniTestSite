using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using tniTestSite.Api.ConsumptionObjectReport;

namespace tniTestSiteWeb.Services.Implementation
{

    public class ConsumptionObjectService : IConsumptionObjectService
    {
        private readonly ConsumptionObjectServiceConfiguration _config;
        private readonly IHttpService _httpService;

        public ConsumptionObjectService(ConsumptionObjectServiceConfiguration config, IHttpService httpService)
        {
            _httpService = httpService;
            _config = config;
        }

        public ConsumptionObjectViewModel[] GetConsumptionObjects()
        {
            KeyValuePair<string, string>[] content = new KeyValuePair<string, string>[0];
            string response = _httpService.GetAndReadAsString(_config.GetConsumptionObjectsUrl, content);
            return JsonConvert.DeserializeObject<ConsumptionObjectViewModel[]>(response);
        }
    }

    public class ConsumptionObjectServiceConfiguration
    {
        public string GetConsumptionObjectsUrl { get; set; }

        public static ConsumptionObjectServiceConfiguration GetFromDefaults()
        {
            var result = new ConsumptionObjectServiceConfiguration
            {
                GetConsumptionObjectsUrl = "http://localhost:8050/api/ConsumptionObjectReport",
            };

            return result;
        }
    }
}
