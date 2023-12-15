using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Moana.Models;
using Moana.View;
using Supabase;

namespace Moana.ViewModel
{
    public class AsignarRecetaPacViewModel : INotifyPropertyChanged
    {
        private Paciente selectedPatient;
        public Paciente SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                if (selectedPatient != value)
                {
                    selectedPatient = value;
                    OnPropertyChanged(nameof(SelectedPatient));
                }
            }
        }

        public void OnPatientSelected(Paciente patient)
        {
            SelectedPatient = patient;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Client _supabaseClient;

        private ObservableCollection<Moana.Models.Paciente> listadoPacientes;
        public ObservableCollection<Moana.Models.Paciente> ListadoPacientes
        {
            get { return listadoPacientes; }
            set
            {
                if (listadoPacientes != value)
                {
                    listadoPacientes = value;
                    OnPropertyChanged(nameof(ListadoPacientes));
                }
            }
        }

        public AsignarRecetaPacViewModel()
        {

            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
            LoadPatients();
        }

       

        private async void LoadPatients()
        {
            try
            {
                var pacienteService = new PacienteService(_supabaseClient);
                var pacientesList = await pacienteService.GetPacientes();
                ListadoPacientes = new ObservableCollection<Moana.Models.Paciente>(pacientesList);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
