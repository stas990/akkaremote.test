using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AkkaRemote.Example.Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseKestrel()
				.UseUrls("http://*:50000", "http://*:50001")
				.UseStartup<Startup>();
	}
}
