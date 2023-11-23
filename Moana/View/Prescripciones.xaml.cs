namespace Moana.View;
public partial class Prescripciones : ContentPage
{
	public Prescripciones()
	{
		InitializeComponent();
        PrescripcionesViewModel viewModel = new PrescripcionesViewModel();

        BindingContext = viewModel;
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}