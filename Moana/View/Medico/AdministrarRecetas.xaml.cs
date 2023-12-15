using Moana.View.Medico;

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
        await Navigation.PushAsync(new AsignarRecetaPaciente());

    }

    async private void AssignUser_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ListadoRecetasMedico());

    }
}