using System;
using System.Collections.Generic;
using System.Net.Http;
using Dogs.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Essentials;
using MvvmHelpers;
using System.Threading.Tasks;
using DogsApp.Services;

namespace DogsApp.Views
{
	public partial class DogPage : ContentPage
	{
		public List<Dog> Dogs;
		static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
										 "http://10.0.2.2:7296" : "http://localhost:7296";



		static HttpClient client;

		public DogPage()
		{
			InitializeComponent();


			Show();

		}

		async void MakeDog_Clicked(System.Object sender, System.EventArgs e)
		{
			var detailPage = new NewDog();

			await Navigation.PushModalAsync(detailPage);
		}
		public async Task Show()
		{
			var httpClient = new HttpClient();
			var resultJson3 = await httpClient.GetStringAsync("http://localhost:7296/api/Dog");
			var resultBig = JsonConvert.DeserializeObject<DogLister>(resultJson3);
			try
			{
				
				
				List.ItemsSource = resultBig.DogList;
			}
			catch
			{
				DisplayAlert($"error", $"{Dogs.ToString()}", "error");
				var resultBig2 = JsonConvert.DeserializeObject<DogLister>(resultJson3);
				try
				{


					List.ItemsSource = resultBig2.DogList;
				}
				catch
				{
					DisplayAlert($"error", $"{Dogs.ToString()}", "error");
				}
			}


		}

		async void GetDog_Clicked(System.Object sender, System.EventArgs e)
		{
			var httpClient = new HttpClient();
			var resultJson3 = await httpClient.GetStringAsync("http://localhost:7296/api/Dog");
			Dog[] dogs;
			try
			{
				
				dogs = JsonConvert.DeserializeObject<Dog[]>(resultJson3);

				List.ItemsSource = dogs;
			}
			catch
			{
				DisplayAlert($"error", $"{resultJson3}", "error");
			}


		}

        void Deletes_Clicked(object sender, ItemTappedEventArgs e)
        {
			var item = e.Item as Dog;
			DogService.RemoveDog(item.id);
        }
    }
}

