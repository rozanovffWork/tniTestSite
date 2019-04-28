using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tniTestSite.Api.ElectricityMeasurementPoints;
using tniTestSite.Data;
using tniTestSite.Data.Models;

namespace tniTestSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricityMeasurementPointsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ElectricityMeasurementPointsController(ApplicationDbContext context, IMapper mapper, ILogger<ElectricityMeasurementPointsController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/ElectricityMeasurementPoints
        [HttpGet]
        public IEnumerable<ElectricityMeasurementPointViewModel> GetElectricityMeasurementPoints()
        {
            DbSet<ElectricityMeasurementPoint> points = _context.ElectricityMeasurementPoints;
            ElectricityMeasurementPointViewModel[] result = _mapper.Map<ElectricityMeasurementPointViewModel[]>(points);
            return result;
        }


        // POST: api/ElectricityMeasurementPoints
        [HttpPost]
        public async Task<IActionResult> PostElectricityMeasurementPoint([FromBody] ElectricityMeasurementPointInputModel input)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                ElectricityMeasurementPoint dbObject = _mapper.Map<ElectricityMeasurementPoint>(input);

                dbObject.ElectricEnergyMeterId = await GetElectricEnergyMeterId(input.ElectricEnergyMeter).ConfigureAwait(false);
                if (dbObject.ElectricEnergyMeterId == null)
                {
                    dbObject.ElectricEnergyMeter = null;
                }

                dbObject.PowerTransformerId = await GetPowerTransformatorId(input.PowerTransformer).ConfigureAwait(false);
                if (dbObject.PowerTransformerId == null)
                {
                    dbObject.PowerTransformer = null;
                }

                dbObject.VoltageTransformerId = await GetVoltageTransformerId(input.VoltageTransformer).ConfigureAwait(false);
                if (dbObject.VoltageTransformerId == null)
                {
                    dbObject.VoltageTransformer = null;
                }

                _context.ElectricityMeasurementPoints.Add(dbObject);
                await _context.SaveChangesAsync();

                input.Id = dbObject.Id;

                return Ok(input);
                //return CreatedAtRoute("GetElectricityMeasurementPoint", new { id = input.Id }, input);
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e, e.Message);
                return BadRequest(e.Message);
            }


        }

        // DELETE: api/ElectricityMeasurementPoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectricityMeasurementPoint([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ElectricityMeasurementPoint electricityMeasurementPoint = await _context.ElectricityMeasurementPoints.FindAsync(id);
            if (electricityMeasurementPoint == null)
            {
                return NotFound();
            }

            _context.ElectricityMeasurementPoints.Remove(electricityMeasurementPoint);
            await _context.SaveChangesAsync();

            return Ok(electricityMeasurementPoint);
        }

        private async Task<int?> GetVoltageTransformerId(VoltageTransformerInputModel input)
        {
            if (input != null && !input.IsEmpty())
            {
                VoltageTransformer voltageTransformer = null;

                if (input.Id != null && input.Id != 0)
                {
                    voltageTransformer = await _context.VoltageTransformer.SingleOrDefaultAsync(w =>
                        w.Id == input.Id).ConfigureAwait(false);
                    if (voltageTransformer == null)
                    {
                        throw new NotSupportedException("VoltageTransformerViewModel.Id not found");
                    }
                }
                else
                {
                    voltageTransformer = _mapper.Map<VoltageTransformer>(input);
                    await _context.VoltageTransformer.AddAsync(voltageTransformer).ConfigureAwait(false);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    input.Id = voltageTransformer.Id;
                }

            }

            return null;
        }

        private async Task<int?> GetElectricEnergyMeterId(ElectricEnergyMeterInputModel input)
        {
            if (input != null && !input.IsEmpty())
            {
                ElectricEnergyMeter electricEnergyMeter = null;

                if (input.Id != null && input.Id != 0)
                {
                    electricEnergyMeter = await _context.ElectricEnergyMeters.SingleOrDefaultAsync(w =>
                        w.Id == input.Id).ConfigureAwait(false);
                    if (electricEnergyMeter == null)
                    {
                        throw new NotSupportedException("ElectricEnergyMeterViewModel.Id not found");
                    }
                }
                else
                {
                    electricEnergyMeter = _mapper.Map<ElectricEnergyMeter>(input);
                    await _context.ElectricEnergyMeters.AddAsync(electricEnergyMeter).ConfigureAwait(false);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    input.Id = electricEnergyMeter.Id;
                }

                return electricEnergyMeter.Id;
            }
            return null;
        }

        private async Task<int?> GetPowerTransformatorId(PowerTransformerInputModel input)
        {
            if (input != null && !input.IsEmpty())
            {
                PowerTransformer powerTransformer = null;

                if (input.Id != null && input.Id != 0)
                {
                    powerTransformer = await _context.PowerTransformers.SingleOrDefaultAsync(w =>
                        w.Id == input.Id).ConfigureAwait(false);
                    if (powerTransformer == null)
                    {
                        throw new NotSupportedException("PowerTransformerViewModel.Id not found");
                    }
                }
                else
                {
                    powerTransformer = _mapper.Map<PowerTransformer>(input);
                    await _context.PowerTransformers.AddAsync(powerTransformer).ConfigureAwait(false);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    input.Id = powerTransformer.Id;
                }

                return powerTransformer.Id;
            }

            return null;
        }


        private bool ElectricityMeasurementPointExists(int id)
        {
            return _context.ElectricityMeasurementPoints.Any(e => e.Id == id);
        }
    }
}