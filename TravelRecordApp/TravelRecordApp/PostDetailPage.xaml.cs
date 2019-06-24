using System;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        private readonly Post _selectedPost;

        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();

            _selectedPost = selectedPost;

            ExperienceEntry.Text = selectedPost.Experience;
        }

        private void UpdateButton_OnClicked(object sender, EventArgs e)
        {
            _selectedPost.Experience = ExperienceEntry.Text;

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var rows = conn.Update(_selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully updated", "Ok");
                else
                    DisplayAlert("Failure", "Experience Entry was not successfully updated", "Ok");
            }
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var rows = conn.Delete(_selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Experience successfully deleted", "Ok");
                else
                    DisplayAlert("Failure", "Experience Entry was not successfully deleted", "Ok");
            }
        }
    }
}