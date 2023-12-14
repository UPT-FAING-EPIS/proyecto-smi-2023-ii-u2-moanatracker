namespace Moana.View;

public partial class AdministrarRecetas : ContentPage
{
	public AdministrarRecetas()
	{
		InitializeComponent();
	}

    async private void Back_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();

    }

    async private void NewReceta_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new NuevaReceta());

    }

    async private void AssignUser_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ListadoPacientes());

    }
}