using Supabase;

namespace Moana.View;

public partial class NuevaReceta : ContentPage
{
    private readonly Client _supabaseClient;
    public NuevaReceta()
	{
        InitializeComponent();
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();

	}

    async private void Button_Clicked(object sender, EventArgs e)
	{
        string email = CorreoEntry.Text;
        string password = "upt2023"; 
        string name = NombreEntry.Text;
        var userService = new UserService(_supabaseClient);
        
        var (success, errorMessage) = await userService.CreateUser(email, password, name);

        if (success)
        {
            await DisplayAlert("Create user ", "", "OK");
        }
        else
        {
             await DisplayAlert("not work", "not work", "OK");
        }
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}