using System;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var post = new Post
            {
                Experience = ExperienceEntry.Text
            };

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var rows = conn.Insert(post);

                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully inserted", "Ok");
                else
                    DisplayAlert("Failure", "Experience Entry was not successfully inserted", "Ok");
            }
        }
    }
}