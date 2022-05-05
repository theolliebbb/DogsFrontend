﻿using System;
using System.Collections.Generic;

using DogsApp.Views;
using Xamarin.Forms;

namespace DogsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
           
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//DogPage");
        }
    }
}

