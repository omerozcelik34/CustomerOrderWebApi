using System.Reflection;

namespace CustomerOrderWebApi
{
    public static class Registration
    {
        public static void AddAplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        }
    }
}
