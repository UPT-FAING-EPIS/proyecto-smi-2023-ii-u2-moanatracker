namespace Moana.View.Medico;

public partial class ListadoRecetasMedico : ContentPage
{
	public ListadoRecetasMedico()
	{
		InitializeComponent();
        BindingContext = new RecetasViewModel();

    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
}