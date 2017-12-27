namespace BmsWpf.Services.Automapper
{
    using AutoMapper;

    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<AutomapperProfile>();
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
