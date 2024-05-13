using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Final_Exam
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadHolidays();
        }

        private async void LoadHolidays()
        {
            using (HttpClient client = new HttpClient())
            {
                string url = "https://date.nager.at/api/v2/publicholidays/2020/US";
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var holidays = JsonConvert.DeserializeObject<List<Holiday>>(content);
                    holidayListView.ItemsSource = holidays;
                }
                else
                {
                    await DisplayAlert("Error", "Failed to fetch holidays", "OK");
                }
            }
        }

        private async void OnHolidaySelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var holiday = e.SelectedItem as Holiday;
            if (holiday.Counties == null)
            {
                await DisplayAlert("No Counties", "There are no counties for this holiday", "OK");
            }
            else
            {
                await Navigation.PushAsync(new CountyPage(holiday.Counties));
            }

            holidayListView.SelectedItem = null;
        }
    }
}