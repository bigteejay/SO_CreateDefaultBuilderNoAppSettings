using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args)
		{
			var builder = WebHost.CreateDefaultBuilder(args)
					.UseStartup<Startup>();

			string env = builder.GetSetting("environment");
			var envMsg = "ASPNETCORE_ENVIRONMENT/Environment variable ";
			if (string.IsNullOrWhiteSpace(env))
				throw new ArgumentNullException("environment", envMsg + "missing!");
			else
				Console.WriteLine(envMsg + "found!");

			string doSeed = builder.GetSetting("SeedDb");
			var seedMsg = "SeedDb in appsettings.json ";
			if (string.IsNullOrWhiteSpace(doSeed))
				throw new ArgumentNullException("SeedDb", seedMsg + "missing!");
			else
				Console.WriteLine(seedMsg + "found!");

			return builder.Build();
		}
	}
}
