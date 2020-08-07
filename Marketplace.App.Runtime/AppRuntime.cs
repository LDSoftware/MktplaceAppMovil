using System.Configuration;
using Marketplace.App.Runtime.Interface;

namespace Marketplace.App.Runtime
{
	public static class AppRuntime
	{
		private static string marketwebclient;
		public static string MarketWebClient
		{
			get
			{
				if (AppRuntime.marketwebclient == null)
					AppRuntime.marketwebclient = ConfigurationManager.AppSettings["WebClient"].ToString();
				return AppRuntime.marketwebclient;
			}
		}

		private static IMarketData marketData;
		public static IMarketData MarketData
		{
			get
			{
				if (AppRuntime.marketData == null)
				{
					AppRuntime.marketData = new Implementation.MarketData();
				}

				return AppRuntime.marketData;
			}
		}

		private static ILiteDBData marketliteDB;
		public static ILiteDBData MarketliteDB
		{
			get
			{
				if (AppRuntime.marketliteDB == null)
					AppRuntime.marketliteDB = new Implementation.LiteDBService();
				return AppRuntime.marketliteDB;
			}
		}

		private static string litedbConnectionString;
		public static string LiteDbConnectionString
		{
			get; set;
		}
	}
}
