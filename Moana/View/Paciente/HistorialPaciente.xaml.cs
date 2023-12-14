namespace Moana.View;

public partial class HistorialPaciente : ContentPage
{
	public HistorialPaciente()
	{
		InitializeComponent();
        HistorialViewModel viewModel = new HistorialViewModel();
        BindingContext = viewModel;
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
}