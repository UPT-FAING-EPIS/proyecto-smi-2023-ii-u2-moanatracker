using System.Collections.ObjectModel;

namespace Moana.View;

public partial class AdministrarCitas : ContentPage
{
	public AdministrarCitas()
	{
		InitializeComponent();

        var citasMedicas = new List<CitaMedica>
            {
                new CitaMedica { Nombre = "Juan", Fecha = "15/02/2023", Hora = "5:00 pm" },
                new CitaMedica { Nombre = "María", Fecha = "16/02/2023", Hora = "4:30 pm" },
            };

        CitasCollectionView.ItemsSource = new ObservableCollection<CitaMedica>(citasMedicas);
    }
    public class CitaMedica
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();
    }
}