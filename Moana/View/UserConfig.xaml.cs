using Supabase;

namespace Moana.View;

public partial class UserConfig : ContentPage
{
    private readonly Client _supabaseClient;

    public UserConfig()
	{
		InitializeComponent();
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        for (int i = 0; i < Navigation.NavigationStack.Count - 1; i++)
        {
            var page = Navigation.NavigationStack[i];
            Navigation.RemovePage(page);
        }

        AuthenticationService authService = new AuthenticationService(_supabaseClient);
        UserService userService = new UserService(_supabaseClient);

        await Navigation.PushAsync(new LoginPage(authService, userService));
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}