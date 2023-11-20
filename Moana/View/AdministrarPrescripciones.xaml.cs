namespace Moana.View;

public partial class AdministrarPrescripciones : ContentPage
{
	public AdministrarPrescripciones()
	{
		InitializeComponent();
	}

    async private void Back_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();

    }

    async private void NewPrescription_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new NuevaPrescripcion());

    }

    async private void AssignUser_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ListadoPacientes());

    }
}