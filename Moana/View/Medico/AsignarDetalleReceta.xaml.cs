using System.Collections.ObjectModel;
using Moana.Models;
using Supabase;

namespace Moana.View.Medico;

public partial class AsignarDetalleReceta : ContentPage
{
    public ObservableCollection<DetalleReceta> DetallesReceta { get; set; }
    private readonly Client _supabaseClient;
    private readonly int _idreceta;
    public AsignarDetalleReceta(Receta recetacreada)
	{
		InitializeComponent();
        _idreceta = recetacreada.IdReceta;
        DetalleRecetaListView.ItemSelected += DetalleRecetaListView_ItemSelected;

        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
        DetallesReceta = new ObservableCollection<DetalleReceta>();
        DetalleRecetaListView.ItemsSource = DetallesReceta;

    }
    private async void DetalleRecetaListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
            return;

        var detalleRecetaSeleccionado = e.SelectedItem as DetalleReceta;


        await Navigation.PushAsync(new AsignarIndicacion(detalleRecetaSeleccionado));
        DetalleRecetaListView.SelectedItem = null;
    }

    private async void CrearDetalleR()
    {
        var detarecetasService = new DetalleRecetaService(_supabaseClient);

        DetalleReceta nuevoDetalleReceta = new DetalleReceta();

        nuevoDetalleReceta.ProductoFarmaceutico = DCIEntry.Text;
        nuevoDetalleReceta.Concentracion = ConcentracionEntry.Text;
        nuevoDetalleReceta.Cantidad = CantidadEntry.Text;
        nuevoDetalleReceta.FormaFarmaceutica = FormaEntry.Text;
        nuevoDetalleReceta.IdReceta = _idreceta;

        var detalleRecetacreada = await detarecetasService.CreateDetalleReceta(nuevoDetalleReceta);
        DetallesReceta.Add(detalleRecetacreada);
        limpiarentrys();

    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
    void limpiarentrys()
    {
        DCIEntry.Text = "";
        ConcentracionEntry.Text = "";
        CantidadEntry.Text = "";
        FormaEntry.Text = "";
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        CrearDetalleR();
    }
}