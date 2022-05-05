
using Dogs.Models;

using Newtonsoft.Json;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using MonkeyCache.FileStore;

namespace DogsApp.Services
{
    public static class DogService
    {
        static string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android ?
                                         "http://10.0.2.2:7296" : "http://localhost:7296";


        public static IEnumerable<Dog> resultList;
        static HttpClient client;
       

        static DogService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }
        public static Task<IEnumerable<Dog>> GetDog() =>
           GetAsync<IEnumerable<Dog>>("api/Dog", "getdog");

        static async Task<T> GetAsync<T>(string url, string key, int mins = 1, bool forceRefresh = false)
        {
            var json = string.Empty;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(key);
            else if (!forceRefresh && !Barrel.Current.IsExpired(key))
                json = Barrel.Current.Get<string>(key);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await client.GetStringAsync(url);

                    Barrel.Current.Add(key, json, TimeSpan.FromMinutes(mins));
                }
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get information from server {ex}");
                throw ex;
            }
        }

        static Random random = new Random();
        public static async Task AddDog(string Name, int Age, string Breed, string Temperament, string Image)
        {
            
            var dog = new Dog
            {
                name = Name,
                age = Age,
                image = Image,
                temperament = Temperament,
                breed = Breed,
                id = random.Next(0, 10000)
            };

            var json = JsonConvert.SerializeObject(dog);
            var content =
                new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/Dog", content);

            if (!response.IsSuccessStatusCode)
            {
                
                    
            }
        }

        public static async Task RemoveDog(int id)
        {
            var response = await client.DeleteAsync($"{BaseUrl}/api/Dog");
            if (!response.IsSuccessStatusCode)
            {

            }
        }


    }
}