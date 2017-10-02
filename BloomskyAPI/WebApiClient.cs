using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Bloomsky.Api {
	public class WebApiClient{
		public string ApiKey { get; set; }

		public string ApiUrl { get; set; }

		public WebApiClient(string apiKey) {
			ApiKey = apiKey;
			ApiUrl = "HTTP://api.bloomsky.com/api/skydata/";
		}
		public WebApiClient(string apiKey, string apiUrl)  {
			ApiKey = apiKey;
			ApiUrl = apiUrl;
		}

		public async Task<List<Sky>> GetData() {
			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("Authorization", ApiKey);
			var json = await client.GetStringAsync(ApiUrl);
			return JsonConvert.DeserializeObject<List<Sky>>(json, Converter.Settings);
		}
	}
}
