namespace Moana.View;

public partial class UserHomePage : ContentPage
{
	public UserHomePage(string nameuser)
	{
		InitializeComponent();
        BindingContext = new UserHomePageViewModel();
        ((UserHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();
    }

    private async void puerta_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPageView());

        Navigation.RemovePage(this);

    }

    private void user_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserConfig());

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new DetallePrescripcion());
    }
}

