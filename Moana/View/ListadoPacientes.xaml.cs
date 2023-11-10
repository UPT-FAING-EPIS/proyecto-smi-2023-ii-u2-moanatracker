using Moana.Models;

namespace Moana.View;

public partial class ListadoPacientes : ContentPage
{

    public ListadoPacientes()
    {
        InitializeComponent();
        BindingContext = new ListadoPacientesViewModel();
    }
    private void OnPatientTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is User selectedPatient)
        {
            ((ListadoPacientesViewModel)BindingContext).SelectedPatient = selectedPatient;
            ((ListadoPacientesViewModel)BindingContext).ShowPatientDetailsCommand.Execute(null);

            ((ListView)sender).SelectedItem = null;
        }
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PopAsync();

    }
}
