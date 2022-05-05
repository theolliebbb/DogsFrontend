using System;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Dogs.Models;
using Newtonsoft.Json;
using DogsApp.Models;
using Xamarin.Essentials;

namespace DogsApp.Views
{
	public partial class NewDog : ContentPage
	{
		static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
										 "http://10.0.2.2:7296" : "http://localhost:7296";



		static HttpClient client;

		public List<AgePicker> ageList = new List<AgePicker>();
		public List<BreedPicker> breedList = new List<BreedPicker>();
		public List<TemperamentPicker> tempList = new List<TemperamentPicker>();

		public NewDog()
		{

			InitializeComponent();
			client = new HttpClient
			{
				BaseAddress = new Uri(BaseUrl)
			};
			for (int i = 1; i < 20; i++)
			{
				string istring = i.ToString();
				AgePicker age = new AgePicker()
				{
					num = i,
				};
				ageList.Add(age);
			}

			DogAge.ItemsSource = ageList;
			List<string> breeds = new List<string>()
			{
				"French Bulldog", "Golden Retriever", "American Eskimo"
			};
			foreach (string i in breeds)
			{
				BreedPicker breeder = new BreedPicker()
				{
					breed = i,
				};
				breedList.Add(breeder);
			}

			DogBreed.ItemsSource = breedList;

			List<string> temps = new List<string>()
			{
				"Feisty", "Sleepy", "Sweet"
			};
			foreach (string i in temps)
			{
				TemperamentPicker temper = new TemperamentPicker()
				{
					temp = i,
				};
				tempList.Add(temper);
			}

			DogTemp.ItemsSource = tempList;
		}

	
	

        async void saveBtn_Clicked(System.Object sender, System.EventArgs e)
        {
			var client = new HttpClient();
			string pic;
			string selectedB;
			string selectedT;
			int selectedbIndex = DogBreed.SelectedIndex;
			if (DogBreed.SelectedIndex == 0)
            {
				pic = "https://www.purina-arabia.com/sites/default/files/2021-02/BREED%20Hero_0051_french_bulldog.jpg";

				selectedB = "French Bulldog";
			}
			else if (DogTemp.SelectedIndex == 1)
			{
				pic = "https://images.saymedia-content.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cfl_progressive%2Cq_auto:eco%2Cw_1200/MTc0MDk2MzYxNjM1OTgwODY2/what-you-should-know-about-owning-a-golden-retriever.jpg";
				selectedB = "Golden Retriever";
			}
			else 
			{
				pic = "https://www.thesprucepets.com/thmb/ny5RVV_9AdETqzlL1YmQuCPkG-I=/1880x1880/smart/filters:no_upscale()/American_Eskimo_Dog_1-2ae6659955ec4885b25bfb25220e7f60.jpg";
				selectedB = "American Eskimo";
			}

			if (DogTemp.SelectedIndex == 0)
			{
				selectedT = "Feisty";
			}
			else if (DogTemp.SelectedIndex == 1)
			{
				selectedT = "Sleepy";
			}
			else
			{
				selectedT = "Sweet";
			}
			int result = DogAge.SelectedIndex + 1;
			try
			{
				
				Services.DogService.AddDog(DogName.Text, result, selectedB, selectedT, pic);
				DisplayAlert("Alright", $"{DogName.Text} the {result} year(s) old {selectedT} {selectedB} has been SPAWNED!", "ALRIGHT!");
			}
			catch
            {
				DisplayAlert("HEY!", "INPUT ALL PARAMS", "WOW!");
            }
			

		}

        void backBtn_Clicked(System.Object sender, System.EventArgs e)
        {
			var detailPage = new DogPage();

		 Navigation.PushModalAsync(detailPage);
		}

    }
}

