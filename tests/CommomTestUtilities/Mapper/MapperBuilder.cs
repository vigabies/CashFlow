using AutoMapper;
using CashFlow.Application.AutoMapper;

namespace CommonTestUtilities.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        var mapperConfig = new MapperConfiguration(
            cfg => cfg.AddProfile<AutoMapping>(),
            null
        );

        return mapperConfig.CreateMapper();
    }
}