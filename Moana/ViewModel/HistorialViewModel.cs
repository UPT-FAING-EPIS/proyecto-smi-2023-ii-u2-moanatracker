using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Moana.View
{
    public class HistorialItem : INotifyPropertyChanged
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

        private string _fechaHoraTomada;
        public string FechaHoraTomada
        {
            get { return _fechaHoraTomada; }
            set
            {
                if (_fechaHoraTomada != value)
                {
                    _fechaHoraTomada = value;
                    OnPropertyChanged(nameof(FechaHoraTomada));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class HistorialViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HistorialItem> _historialPaciente;

        public ObservableCollection<HistorialItem> HistorialPaciente
        {
            get { return _historialPaciente; }
            set
            {
                if (_historialPaciente != value)
                {
                    _historialPaciente = value;
                    OnPropertyChanged(nameof(HistorialPaciente));
                }
            }
        }

        public HistorialViewModel()
        {
            HistorialPaciente = new ObservableCollection<HistorialItem>
            {
                new HistorialItem { NombreMedicamento = "Paracetamol", Dosage = "500mg", FechaHoraTomada = "2023-11-23 08:00 AM" },
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
