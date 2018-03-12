using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySongbook.Startup))]
namespace MySongbook
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
