namespace Moana.View;
public partial class ListadoRecetas : ContentPage
{
    public ListadoRecetas()
	{
		InitializeComponent();
        RecetasViewModel viewModel = new RecetasViewModel();

        BindingContext = viewModel;
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
   
    }
}