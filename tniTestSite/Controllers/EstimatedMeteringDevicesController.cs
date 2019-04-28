using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tniTestSite.Api.EstimatedMeteringDevices;
using tniTestSite.Data;
using tniTestSite.Data.Models;
using tniTestSite.Models;

namespace tniTestSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimatedMeteringDevicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public EstimatedMeteringDevicesController(ApplicationDbContext context, IMapper mapper, ILogger<EstimatedMeteringDevicesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("getByYear{year}")]
        public async Task<IActionResult> GetEstimatedMeteringDevice([FromRoute] int year)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                int[] timeSetIds = _context.TimeSets
                    .Where(w =>
                        (w.DateStart.HasValue && w.DateStart.Value.Year == year)
                        || (w.DateFinish.HasValue && w.DateFinish.Value.Year == year))
                    .Select(s => s.EstimatedMeteringDeviceId)
                    .Distinct().ToArray();

                EstimatedMeteringDevice[] estimatedMeteringDevices =
                    await _context.EstimatedMeteringDevices
                        .Where(w => timeSetIds.Contains(w.Id))
                        .ToArrayAsync();

                //if (!estimatedMeteringDevices.Any())
                //{
                //    return NotFound();
                //}

                var viewModel = _mapper.Map<EstimatedMeteringDeviceViewModel[]>(estimatedMeteringDevices);
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