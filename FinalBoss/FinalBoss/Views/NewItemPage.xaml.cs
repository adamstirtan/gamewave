using System;
using System.Collections.Generic;
using System.ComponentModel;
using FinalBoss.Models;
using FinalBoss.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalBoss.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}