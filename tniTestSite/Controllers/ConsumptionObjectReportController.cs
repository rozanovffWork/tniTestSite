using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tniTestSite.Api.ConsumptionObjectReport;
using tniTestSite.Data;
using tniTestSite.Data.Models;
using tniTestSite.Models;
using tniTestSite.Service;

namespace tniTestSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionObjectReportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IGenericRepositoryService<ElectricEnergyMeter> _energyMeterRepositoryService;
        private readonly IGenericRepositoryService<PowerTransformer>    _powerTransformerRepositoryService;
        private readonly IGenericRepositoryService<VoltageTransformer>  _voltageTransformerRepositoryService;

        public ConsumptionObjectReportController(ApplicationDbContext context
            , IMapper mapper
            , ILogger<ConsumptionObjectReportController> logger
            , IGenericRepositoryService<ElectricEnergyMeter> energyMeterRepositoryService
            , IGenericRepositoryService<PowerTransformer> powerTransformerRepositoryService
            , IGenericRepositoryService<VoltageTransformer> voltageTransformerRepositoryService)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _energyMeterRepositoryService = energyMeterRepositoryService;
            _powerTransformerRepositoryService = powerTransformerRepositoryService;
            _voltageTransformerRepositoryService = voltageTransformerRepositoryService;
        }

        [HttpGet]
        public IActionResult GetConsumptionObjects()
        {
            try
            {
                var results = _context.ConsumptionObjects;
                var viewModel = _mapper.Map<ConsumptionObjectViewModel[]>(results);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        [HttpGet("ExpiredEnergyMeters")]
        public IActionResult ExpiredEnergyMeters([FromQuery]int сonsumptionObjectId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var results = _energyMeterRepositoryService.GetExpextedVerificationDate(сonsumptionObjectId);
                var viewModel = _mapper.Map<ElectricEnergyMeterViewModel[]>(results);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        [HttpGet("ExpiredPowerTransformator")]
        public IActionResult ExpiredPowerTransformator([FromQuery]int сonsumptionObjectId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var results = _powerTransformerRepositoryService.GetExpextedVerificationDate(сonsumptionObjectId);
                var viewModel = _mapper.Map<PowerTransformerViewModel[]>(results);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }

        [HttpGet("ExpiredVoltageTransformer")]
        public IActionResult ExpiredVoltageTransformer([FromQuery]int сonsumptionObjectId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var results = _voltageTransformerRepositoryService.GetExpextedVerificationDate(сonsumptionObjectId);
                var viewModel = _mapper.Map<VoltageTransformerViewModel[]>(results);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, ex.Message);
                throw;
            }
        }
    }
}