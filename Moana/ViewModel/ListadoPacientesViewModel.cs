using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Graphics.Text;
using Moana.Models;
using Supabase;

namespace Moana.View
{
    public class ListadoPacientesViewModel : BindableObject
    {
        private readonly Client _supabaseClient;

        private ObservableCollection<Moana.Models.Receta> patients;
        private User selectedPatient;
        private bool isRefreshing;

        public ListadoPacientesViewModel()
        {
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
            InitializeCommands();
            LoadPatients();
        }

        public ObservableCollection<Moana.Models.Receta> Patients
        {
            get => patients;
            set
            {
                patients = value;
                OnPropertyChanged();
            }
        }

        public User SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                selectedPatient = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; private set; }
        public ICommand AddPatientCommand { get; private set; }
        public ICommand ShowPatientDetailsCommand { get; private set; }

        public bool IsRefreshing
        {
            get => isRefreshing;
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        private void InitializeCommands()
        {
            RefreshCommand = new Command(async () => await OnRefresh());
            AddPatientCommand = new Command(OnAddPatientClicked);
            ShowPatientDetailsCommand = new Command(OnShowPatientDetails);
        }

        private async Task OnRefresh()
        {
            IsRefreshing = true;
            await ReloadPatients();
            IsRefreshing = false;
        }

        private async Task ReloadPatients()
        {
            var pacienteService = new PacienteService(_supabaseClient);
            var idmedico= await SecureStorage.GetAsync("IdMedico");

            var recetasList = await pacienteService.GetPacientesbyMedico(Int32.Parse(idmedico));
            Patients.Clear();
            Patients = new ObservableCollection<Moana.Models.Receta>(recetasList);
        }

        private async void LoadPatients()
        {
            try
            {

                var pacienteService = new PacienteService(_supabaseClient);
                var iddelmedico = await SecureStorage.GetAsync("IdMedico");

                var recetasList = await pacienteService.GetPacientesbyMedico(Int32.Parse(iddelmedico));

                Patients = new ObservableCollection<Moana.Models.Receta>(recetasList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }

        private void OnAddPatientClicked()
        {
            var newPatient = new User { Name = "Nuevo Paciente" };
            //Patients.Add(newPatient);
        }

        private async void OnShowPatientDetails()
        {
            if (SelectedPatient != null)
            {
                var detallePacientePage = new DetallePaciente();
                detallePacientePage.SetPatientName(SelectedPatient.Name);
                await App.Current.MainPage.Navigation.PushAsync(detallePacientePage);
                SelectedPatient = null;
            }
        }
    }
}
