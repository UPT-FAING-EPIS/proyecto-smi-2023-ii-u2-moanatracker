

namespace Moana.View;

public partial class MedicoHomePage : ContentPage
{
    public MedicoHomePage(string nameuser)
    {
        InitializeComponent();

        BindingContext = new MedicoHomePageViewModel();
        ((MedicoHomePageViewModel)BindingContext).NameUser = nameuser.ToUpper();

    }

    private void user_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new UserConfig());
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        if (Parent is FlyoutPage flyoutPage)
        {
            flyoutPage.IsPresented = !flyoutPage.IsPresented;
        }
    }
}