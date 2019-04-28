using Microsoft.Extensions.Logging;
using System;
using tniTestSite.Data.Models;

namespace tniTestSite.Data.Services.Implementation
{
    public class FillDataService : IFillDataService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public FillDataService(ApplicationDbContext context, ILogger<FillDataService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Fill()
        {
            try
            {
                Organization headOrg = new Organization()
                {
                    Name = "Ромашка",
                    Address = "ул.Бассеенная д.3"
                };

                _context.Organizations.Add(headOrg);
                _context.SaveChanges();

                SubsidiaryOrganization subsidiaryOrganization = new SubsidiaryOrganization()
                {
                    Name = "Ромашка полевая",
                    Address = "ул. Ярцувская д.14",
                    HeadOrganizationId = headOrg.Id,
                };

                _context.SubsidiaryOrganizations.Add(subsidiaryOrganization);
                _context.SaveChanges();

                ConsumptionObject consumptionObject = new ConsumptionObject
                {
                    Name = "ПС 110 / 10 Весна",
                    OrganizationId = subsidiaryOrganization.Id,
                };

                _context.ConsumptionObjects.Add(consumptionObject);
                _context.SaveChanges();

                ElectricitySupplyPoint electricitySupplyPoint = new ElectricitySupplyPoint()
                {
                    ConsumptionObjectId = consumptionObject.Id,
                    Name = "Точка поставки электроэнергии 1"
                };
                _context.ElectricitySupplyPoints.Add(electricitySupplyPoint);
                _context.SaveChanges();

                ElectricityMeasurementPoint electricityMeasurementPoint = new ElectricityMeasurementPoint()
                {
                    Name = "Точка измерения электроэнергии 1",
                    ConsumptionObjectId = consumptionObject.Id,
                };
                _context.ElectricityMeasurementPoints.Add(electricityMeasurementPoint);
                _context.SaveChanges();

                EstimatedMeteringDevice estimatedMeteringDevice = new EstimatedMeteringDevice
                {
                    ElectricitySupplyPointId = electricitySupplyPoint.Id,
                };

                _context.EstimatedMeteringDevices.Add(estimatedMeteringDevice);
                _context.SaveChanges();

                TimeSet[] timeSets = new TimeSet[]
                {
                    new TimeSet
                    {
                        EstimatedMeteringDeviceId = estimatedMeteringDevice.Id,
                        DateFinish = new DateTime(2018, 1, 1),
                        DateStart = new DateTime(2018, 3, 1),
                        ElectricityMeasurementPointId = electricityMeasurementPoint.Id,
                    }
                    //new TimeSet
                    //{
                    //    EstimatedMeteringDeviceId = estimatedMeteringDevice.Id,
                    //    DateFinish = new DateTime(2018, 3, 1),
                    //    DateStart = new DateTime(2018, 6, 1),
                    //    ElectricityMeasurementPointId = electricityMeasurementPoint.Id,
                    //}
                };
                _context.TimeSets.AddRange(timeSets);

                ElectricEnergyMeter electricEnergyMeter = new ElectricEnergyMeter
                {
                    ElectricityMeasurementPointId = electricityMeasurementPoint.Id,
                    CounterType = "трех фазный",
                    Number = "12394579",
                    VerificationDate = DateTime.Now.AddDays(-1)
                };
                _context.ElectricEnergyMeters.Add(electricEnergyMeter);


                PowerTransformer powerTransformer = new PowerTransformer
                {
                    ElectricityMeasurementPointId = electricityMeasurementPoint.Id,
                    Number = "12394579",
                    VerificationDate = DateTime.Now.AddDays(-1),
                    PowerTransformerType = "Тип Г",
                    PowerTransformationRatio = 1.0,
                };
                _context.PowerTransformers.Add(powerTransformer);

                VoltageTransformer voltageTransformer = new VoltageTransformer
                {
                    ElectricityMeasurementPointId = electricityMeasurementPoint.Id,
                    Number = "12394579",
                    VerificationDate = DateTime.Now.AddDays(-1),
                    VoltageTransformerType = "Тип Е",
                    VoltageTransformationRatio = 1.0,
                };
                _context.VoltageTransformer.Add(voltageTransformer);

                _context.SaveChanges();



            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, e, e.Message);
                throw;
            }
        }
    }
}
