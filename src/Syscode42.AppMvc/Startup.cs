using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Syscode42.AppMvc.App_Start;

[assembly: OwinStartup(typeof(Syscode42.AppMvc.Startup))]
namespace Syscode42.AppMvc
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			CultureConfig.RegisterCulture();
		}
	}
}
