

namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
    public MedicoHomePage(string nameuser)
    {
        InitializeComponent();

        BindingContext = new MedicoHomePageViewModel();
        ((MedicoHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();

    }

    private async void puerta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageView());

        Navigation.RemovePage(this);

    }

    private void config_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Config", "Config", "OK");

    }

    private void user_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("User", "User", "OK");

    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        if (Parent is FlyoutPage flyoutPage)
        {
            flyoutPage.IsPresented = !flyoutPage.IsPresented;
        }
    }
}