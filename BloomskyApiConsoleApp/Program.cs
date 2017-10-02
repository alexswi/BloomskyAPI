using System;
using System.IO;
using System.Linq;
using Bloomsky.Api;
using Microsoft.Extensions.Configuration;

namespace BloomskyApiConsoleApp {
	class Program {
		static void Main(string[] args) {
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var configuration = builder.Build();

			var x = new BloomskyApi(configuration["apiKey"]);
			var ret = x.GetData().Result;
			Console.WriteLine($"Temp={ret.FirstOrDefault().Data.Temperature:F1}F");
		}
	}
}
