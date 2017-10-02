using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Bloomsky.Api;

namespace BloomskyApiConsoleApp {
	class Program {
		static void Main(string[] args) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var configuration = builder.Build();

			var x = new WebApiClient(configuration["apiKey"]);
			var ret = x.GetData().Result;
			Console.WriteLine($"Temp={ret.FirstOrDefault().Data.Temperature:F1}F");
		}
	}
}
