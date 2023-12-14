using System.Collections.ObjectModel;
using System.ComponentModel;
using Supabase;
using Supabase.Interfaces;

namespace Moana.View;

public class PrescripcionItem : INotifyPropertyChanged
{
    
    private string _nombreMedicamento;
    public string NombreMedicamento
    {
        get { return _nombreMedicamento; }
        set
        {
            if (_nombreMedicamento != value)
            {
                _nombreMedicamento = value;
                OnPropertyChanged(nameof(NombreMedicamento));
            }
        }
    }

    private string _dosage;
    public string Dosage
    {
        get { return _dosage; }
        set
        {
            if (_dosage != value)
            {
                _dosage = value;
                OnPropertyChanged(nameof(Dosage));
            }
        }
    }

    private string _hora;
    public string Hora
    {
        get { return _hora; }
        set
        {
            if (_hora != value)
            {
                _hora = value;
                OnPropertyChanged(nameof(Hora));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class RecetasViewModel : INotifyPropertyChanged
{
    private ObservableCollection<PrescripcionItem> _prescripciones;

    public ObservableCollection<PrescripcionItem> Prescripciones
    {
        get { return _prescripciones; }
        set
        {
            if (_prescripciones != value)
            {
                _prescripciones = value;
                OnPropertyChanged(nameof(Prescripciones));
            }
        }
    }
    private readonly Client _supabaseClient;
    public RecetasViewModel()
    {
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
        Prescripciones = new ObservableCollection<PrescripcionItem>
        {
            new PrescripcionItem { NombreMedicamento = "Paracetamol", Dosage = "500mg", Hora = "En 8 horas" },
            new PrescripcionItem { NombreMedicamento = "Ibuprofeno", Dosage = "200mg", Hora = "En 1 hora" },
        };
        LoadPrescriptions();
    }
    public async void LoadPrescriptions()
    {
        try
        {
            Console.WriteLine("LoadPrescriptions method called");

            var test = "1";
            var prescripService = new PrescripcionService(_supabaseClient);
            var patientsList = await prescripService.GetPrescripcionesById(test);

            Console.WriteLine($"Number of Prescriptions: {patientsList.Count}");

            foreach (var patient in patientsList)
            {
                Console.WriteLine($"Prescripcion ID: {patient.Id}");
                Console.WriteLine($"Fecha Inicio: {patient.Fecha_inicio}");
                Console.WriteLine($"Fecha Fin: {patient.Fecha_fin}");
                Console.WriteLine($"Medico ID: {patient.fkIdMedico}");
                Console.WriteLine($"Paciente ID: {patient.fkIdPaciente}");
                Console.WriteLine();
            }

            Console.WriteLine("After loop");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener prescripciones: " + ex.Message);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
