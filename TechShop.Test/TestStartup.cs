namespace TechShop.Test
{
    using AutoMapper;
    using TechShop.Web.Infrastructure.Mapping;

    public class TestStartup
    {
        private static bool testsInitialize = false;

        public static void Initialize()
        {
            if (!testsInitialize)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialize = true;
            }
        }
    }
}
