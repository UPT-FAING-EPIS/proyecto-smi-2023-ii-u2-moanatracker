using Supabase;
namespace Moana.View
{
    public partial class MainPageView : ContentPage
    {
        private readonly Client _supabaseClient;

        public MainPageView()
        {
            InitializeComponent();
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

        }
        private async void InAnimation()
        {
            await Task.WhenAll
            (
                this.mainFrame.ScaleTo(10, 0),
                this.mainFrame.FadeTo(0, 0)
            );

            await Task.WhenAll
            (
                this.mainFrame.ScaleTo(1, 500, Easing.SinIn),
                this.mainFrame.FadeTo(0.7, 500, Easing.SinOut)
            );
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Titulolbl.TextColor = Color.Parse("#44AAF6");
            Titulolbl.TextColor = Color.Parse("#4d79ff");
            FrameTab.IsVisible = false;
            await Task.WhenAll
            (
                this.mainFrame.FadeTo(0, 200, Easing.SinIn),
                this.mainFrame.ScaleTo(10, 200, Easing.SinOut)
            );

            AuthenticationService authService = new AuthenticationService(_supabaseClient);
            UserService userService = new UserService(_supabaseClient);

            await Navigation.PushAsync(new LoginPage(authService, userService));
            Navigation.RemovePage(this);

        }
    }
}