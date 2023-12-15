
using Moana.Models;
using Moana.View;
using Moana.View.Medico;

namespace Moana
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPageView());

        }
    }
}