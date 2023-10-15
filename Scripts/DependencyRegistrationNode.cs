namespace Survival.Scripts;

public partial class DependencyRegistrationNode : IServicesConfigurator
{
	public override void ConfigureServices(IServiceCollection services)
	{
		services.AddGodotServices();
		services.AddTransient<IService, Service>();
	}
}
