using System;
namespace DogsApp.Services
{
	public class WebApi
	{
		public async void RefreshData()
		{
			var WebAPIUrl = "https://ej2services.syncfusion.com/production/web-services/api/Orders";
			//Set your REST API URL here.
			var uri = new Uri(WebAPIUrl);
		}
		public WebApi()
		{
		}
	}
}

