using System.Collections.ObjectModel;
using System.ComponentModel;

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

public class PrescripcionesViewModel : INotifyPropertyChanged
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

    public PrescripcionesViewModel()
    {
        Prescripciones = new ObservableCollection<PrescripcionItem>
        {
            new PrescripcionItem { NombreMedicamento = "Paracetamol", Dosage = "500mg", Hora = "En 8 horas" },
            new PrescripcionItem { NombreMedicamento = "Ibuprofeno", Dosage = "200mg", Hora = "En 1 hora" },
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
