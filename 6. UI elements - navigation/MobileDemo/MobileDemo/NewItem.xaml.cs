﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        private void addNewItem_button_Clicked(object sender, EventArgs e)
        {

            Navigation.PopAsync();
        }
    }
}