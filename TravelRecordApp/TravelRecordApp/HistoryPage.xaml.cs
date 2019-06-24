using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                PostListView.ItemsSource = posts;
            }
        }

        private void PostListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (PostListView.SelectedItem is Post selectedPost)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
    }
}