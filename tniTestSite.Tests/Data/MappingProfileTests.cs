using AutoMapper;
using AutoMapper.Configuration;
using tniTestSite.Data;
using Xunit;

namespace tniTestSite.Tests.Data
{
    public class MappingProfileTests
    {
        [Fact]
        public void MappingProfile_VerifyMappings()
        {
            MappingProfile mappingProfile = new MappingProfile();
            var mapperConfigurationExpression = new MapperConfigurationExpression();
            mapperConfigurationExpression.AddProfile(mappingProfile);
            MapperConfiguration config = new MapperConfiguration(mapperConfigurationExpression);
            Mapper mapper = new Mapper(config);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
