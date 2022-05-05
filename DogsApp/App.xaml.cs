using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DogsApp.Services;
using DogsApp.Views;

namespace DogsApp
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

           
            MainPage = new DogPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

