using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Supabase.Interfaces;
using System;
using Moana.Models;
using Supabase;
namespace Moana.View
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;
        private readonly Client _supabaseClient;
        public LoginPage(AuthenticationService authService, UserService userService)
        {
            InitializeComponent();
            _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));

        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text.ToLower().Trim();
            var password = PasswordEntry.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ResultLabel.Text = "Introduce usuario y contraseña.";
                return;
            }

            var isAuthenticated = await _authService.Authenticate(email, password);

            if (isAuthenticated)
            {
                var user = await _userService.GetUser(email);
                var rolUser = user.Model.rolId.ToString();
                var nameUser = user.Model.Name.ToString();
                var IdUsuario = user.Model.Id;
                Console.WriteLine($"El id del usuario es {IdUsuario}");

                if (rolUser.Equals("3"))
                {
                   
                    await Navigation.PushAsync(new MedicoHomePage(nameUser));

                    Navigation.RemovePage(this);
                }
                else if (rolUser.Equals("4"))
                {
                    var pacienteService = new PacienteService(_supabaseClient);

                    //var IdPaciente = await pacienteService.GetPatientsbyIdUser();
                    //Console.WriteLine($"El id del paciente es{IdPaciente}");
                    await Navigation.PushAsync(new UserHomePage(nameUser));

                    Navigation.RemovePage(this);
                }
                else
                {
                    ResultLabel.Text = "Usuario no encontrado!";

                }
            }
            else
            {
                ResultLabel.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}