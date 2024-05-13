using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final_Exam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountyPage : ContentPage
    {
        public CountyPage(List<string> counties)
        {
            InitializeComponent();
            countyListView.ItemsSource = counties;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}