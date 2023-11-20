using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel; 

namespace Moana.View
{
    public class UserHomePageViewModel : BindableObject
    {
        public ICommand PrescripcionesCommand { get; private set; }
        public ICommand HorariosPastillasCommand { get; private set; }
        public ObservableCollection<CarouselItem> CarouselItems { get; private set; }

        private string nameUser;
        public UserHomePageViewModel()
        {
            PrescripcionesCommand = new Command(Prescripciones);
            HorariosPastillasCommand = new Command(HorariosPastillas);
            CarouselItems = new ObservableCollection<CarouselItem>
            {
                new CarouselItem
                {
                    Command =  PrescripcionesCommand,
                    Text = "Ver prescripciones",
                    ImageSource = "book_medical.svg"
                },
                new CarouselItem
                {
                    Command = HorariosPastillasCommand,
                    Text = "Ver horarios pastillas",
                    ImageSource = "users_medical.svg"
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
                    return "Buenos días, usuario " + NameUser;
                }
                else if (now.Hour >= 12 && now.Hour < 18)
                {
                    return "Buenas tardes, usuario " + NameUser;
                }
                else
                {
                    return "Buenas noches, usuario " + NameUser;
                }
            }
        }

        private async void Prescripciones()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Prescripciones());
        }

        private async void HorariosPastillas()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new HorarioPastillas());
        }

   
    }
    
}
