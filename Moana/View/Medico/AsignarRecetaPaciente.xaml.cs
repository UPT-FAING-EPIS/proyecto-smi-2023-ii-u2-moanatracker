using Moana.ViewModel;
using Moana.Models;
using Microsoft.Maui.Controls;
using Moana.View;
namespace Moana.View.Medico;

public partial class AsignarRecetaPaciente : ContentPage
{
	public AsignarRecetaPaciente()
	{
		InitializeComponent();
		 BindingContext = new AsignarRecetaPacViewModel();

            // Agregar controlador de eventos para el evento ItemTapped
            patientListView.ItemTapped += OnPatientTapped;

    }
	
 private async void OnPatientTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Models.Paciente selectedPatient)
            {
                (BindingContext as AsignarRecetaPacViewModel)?.OnPatientSelected(selectedPatient);
				var IdPaciente =  selectedPatient.IdPaciente;
                await Navigation.PushAsync(new NuevaReceta(IdPaciente));

                patientListView.SelectedItem = null;
            }
        }
    private void Back_Tapped(object sender, TappedEventArgs e)
    {
		Navigation.PopAsync();
    }
}