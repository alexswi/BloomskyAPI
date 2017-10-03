using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bloomsky.Api {

	public partial class Sky {
		[JsonProperty("FullAddress")]
		public string FullAddress { get; set; }

		[JsonProperty("DST")]
		public long DST { get; set; }

		[JsonProperty("BoundedPoint")]
		public string BoundedPoint { get; set; }

		[JsonProperty("ALT")]
		public long ALT { get; set; }

		[JsonProperty("CityName")]
		public string CityName { get; set; }

		[JsonProperty("DeviceID")]
		public string DeviceID { get; set; }

		[JsonProperty("Data")]
		public Data Data { get; set; }

		[JsonProperty("DeviceName")]
		public string DeviceName { get; set; }

		[JsonProperty("Storm")]
		public Storm Storm { get; set; }

		[JsonProperty("LON")]
		public double Longitude { get; set; }

		[JsonProperty("LAT")]
		public double Latitude { get; set; }

		[JsonProperty("NumOfFollowers")]
		public long NumOfFollowers { get; set; }

		[JsonProperty("RegisterTime")]
		public long RegisterTime { get; set; }

		[JsonProperty("PreviewImageList")]
		public List<string> PreviewImageList { get; set; }

		[JsonProperty("Searchable")]
		public bool Searchable { get; set; }

		[JsonProperty("UTC")]
		public double UTC { get; set; }

		[JsonProperty("StreetName")]
		public string StreetName { get; set; }

		[JsonProperty("VideoList")]
		public List<string> VideoList { get; set; }

		[JsonProperty("VideoList_C")]
		public List<string> VideoListC { get; set; }
	}

	public partial class Data {
		[JsonProperty("ImageURL")]
		public string ImageURL { get; set; }

		[JsonProperty("Rain")]
		public bool Rain { get; set; }

		[JsonProperty("Humidity")]
		public long Humidity { get; set; }

		[JsonProperty("DeviceType")]
		public string DeviceType { get; set; }

		[JsonProperty("ImageTS")]
		public long ImageTS { get; set; }

		[JsonProperty("Night")]
		public bool Night { get; set; }

		[JsonProperty("Luminance")]
		public long Luminance { get; set; }

		[JsonProperty("Pressure")]
		public double Pressure { get; set; }

		[JsonProperty("Temperature")]
		public double Temperature { get; set; }

		public double TemperatureC => 5.0 / 9.0 * (Temperature - 32);

		[JsonProperty("TS")]
		public long TS { get; set; }

		[JsonProperty("UVIndex")]
		public long UVIndex { get; set; }

		[JsonProperty("Voltage")]
		public long Voltage { get; set; }
	}


	public partial class Storm {
		[JsonProperty("SustainedWindSpeed")]
		public double SustainedWindSpeed { get; set; }

		public double SustainedWindSpeedKmh => SustainedWindSpeed * 1.60934;

		[JsonProperty("RainDaily")]
		public double RainDaily { get; set; }
		public double RainDailyMm => RainDaily * 2.54;

		[JsonProperty("24hRain")]
		public double The24hRain { get; set; }
		public double The24hRainMm => The24hRain * 2.54;

		[JsonProperty("RainRate")]
		public double RainRate { get; set; }
		public double RainRateMm => RainRate * 2.54;

		[JsonProperty("WindDirection")]
		public string WindDirection { get; set; }

		[JsonProperty("UVIndex")]
		public string UVIndex { get; set; }

		[JsonProperty("WindGust")]
		public double WindGust { get; set; }
		public double WindGustKmh => WindGust * 1.60934;
	}

	public partial class Sky {
		public static List<Sky> FromJson(string json) {
			return JsonConvert.DeserializeObject<List<Sky>>(json, Converter.Settings);
		}
	}

	public static class Serialize {
		public static string ToJson(this List<Sky> self) {
			return JsonConvert.SerializeObject(self, Converter.Settings);
		}
	}

	public class Converter {
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
		};
	}
}
