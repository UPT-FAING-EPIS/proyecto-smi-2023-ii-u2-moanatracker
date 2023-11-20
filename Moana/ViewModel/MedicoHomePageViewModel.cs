using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Moana.View
{
    public class MedicoHomePageViewModel : BindableObject
    {
        public ICommand AdministrarCitasCommand { get; private set; }
        public ICommand ListadoPacientesCommand { get; private set; }
        public ICommand AdministrarPrescripCommand { get; private set; }
        public ObservableCollection<CarouselItem> CarouselItems { get; set; }

        private string nameUser;

        public MedicoHomePageViewModel()
        {
            AdministrarCitasCommand = new Command(AdministrarCitas);
            ListadoPacientesCommand = new Command(ListadoPacientes);
            AdministrarPrescripCommand = new Command(AdministrarPrescripciones);
            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem
                {
                    Command = AdministrarCitasCommand,
                    Text = "Administrar Citas",
                    ImageSource = "book_medical.svg"
                },
                new CarouselItem
                {
                    Command = ListadoPacientesCommand,
                    Text = "Administrar Pacientes",
                    ImageSource = "users_medical.svg"
                },
                new CarouselItem
                {
                    Command = AdministrarPrescripCommand,
                    Text = "Administrar Prescripciones",
                    ImageSource = "clipboard_list_check.svg"
                }
            };
        }
        public class CarouselItem
        {
            public ICommand Command { get; set; }
            public string Text { get; set; }
            public string ImageSource { get; set; }
        }

        public string NameUser
        {
            get { return nameUser; }
            set
            {
                if (nameUser != value)
                {
                    nameUser = value;
                    OnPropertyChanged(nameof(Saludo));
                }
            }
        }

        public string Saludo
        {
            get
            {
                var now = DateTime.Now;
                if (now.Hour >= 0 && now.Hour < 12)
                {
                    return "Buenos días, Dr. " + NameUser;
                }
                else if (now.Hour >= 12 && now.Hour < 18)
                {
                    return "Buenas tardes, Dr. " + NameUser;
                }
                else
                {
                    return "Buenas noches, Dr. " + NameUser;
                }
            }
        }


        private async void AdministrarCitas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AdministrarCitas());
        }

        private async void ListadoPacientes()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ListadoPacientes());
        }

        private async void AdministrarPrescripciones()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AdministrarPrescripciones());
        }
    }
}
