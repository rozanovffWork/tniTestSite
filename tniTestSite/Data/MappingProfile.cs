using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tniTestSite.Api.ConsumptionObjectReport;
using tniTestSite.Api.ElectricityMeasurementPoints;
using tniTestSite.Api.EstimatedMeteringDevices;
using tniTestSite.Data.Models;
using tniTestSite.Models;

namespace tniTestSite.Data
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<ElectricityMeasurementPointInputModel, ElectricityMeasurementPoint>()
                .ForMember(m => m.ConsumptionObject, opt => opt.Ignore())
                .ForMember(m => m.TimeSets, opt => opt.Ignore());

            CreateMap<VoltageTransformerInputModel, VoltageTransformer>()
                .ForMember(m => m.ElectricityMeasurementPoint, opt=>opt.Ignore())
                .ForMember(m => m.ElectricityMeasurementPointId, opt => opt.Ignore());

            CreateMap<PowerTransformerInputModel, PowerTransformer>()
                .ForMember(m => m.ElectricityMeasurementPoint, opt => opt.Ignore())
                .ForMember(m => m.ElectricityMeasurementPointId, opt => opt.Ignore());

            CreateMap<ElectricEnergyMeterInputModel, ElectricEnergyMeter>()
                .ForMember(m => m.ElectricityMeasurementPoint, opt => opt.Ignore())
                .ForMember(m => m.ElectricityMeasurementPointId, opt => opt.Ignore());

            CreateMap<ElectricityMeasurementPoint, ElectricityMeasurementPointInputModel>();
            CreateMap<VoltageTransformer, VoltageTransformerInputModel>();
                
            CreateMap<PowerTransformer, PowerTransformerInputModel>();
            CreateMap<ElectricEnergyMeter, ElectricEnergyMeterInputModel>();

            CreateMap<EstimatedMeteringDevice, EstimatedMeteringDeviceViewModel>();

            CreateMap<ElectricEnergyMeter, ElectricEnergyMeterViewModel>();

            CreateMap<PowerTransformer, PowerTransformerViewModel>();

            CreateMap<VoltageTransformer, VoltageTransformerViewModel>();

            CreateMap<ElectricityMeasurementPoint, ElectricityMeasurementPointViewModel>();

            CreateMap<ConsumptionObject, ConsumptionObjectViewModel>();
            
        }
    }
}
