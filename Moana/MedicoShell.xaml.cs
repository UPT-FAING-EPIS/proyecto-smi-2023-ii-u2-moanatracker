
using Moana.View;

namespace Moana
{
    public partial class MedicoShell : Shell
    {
        public MedicoShell(string nameUser)
        {
            InitializeComponent();

            // Configura la página MedicoHomePage y pasa el parámetro
            var medicoHomePage = new MedicoHomePage(nameUser);
            Routing.RegisterRoute("MedicoHomePage", typeof(MedicoHomePage));
            Items.Add(new ShellContent
            {
                Title = "",
                Content = medicoHomePage
            });
            CurrentItem = Items[0];
        }
    }
}