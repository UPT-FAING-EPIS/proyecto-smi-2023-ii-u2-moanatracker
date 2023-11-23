
namespace Moana.View;

public partial class DetallePrescripcion : ContentPage
{
	public DetallePrescripcion()
	{
		InitializeComponent();
	}

    private async void TomarDosis_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Dosis Tomada", "La dosis ha sido tomada con éxito.", "OK");
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}