
using Moana.View;

namespace Moana
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //var erick = "erick";
            MainPage = new NavigationPage(new MainPageView());

        }
    }
}