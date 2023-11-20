using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace Moana.View;

public partial class RecomendacionIA : ContentPage
{
    ObservableCollection<string> textos = new ObservableCollection<string>();

    public RecomendacionIA()
    {
		InitializeComponent();
        TextoListView.ItemsSource = textos;

        textos.Add("Paracetamol");
        textos.Add("Ibuprofeno");
    }
    private void OnEntryCompleted(object sender, EventArgs e)
    {
        var entry = (Entry)sender;
        if (!string.IsNullOrWhiteSpace(entry.Text))
        {
            textos.Add(entry.Text);
            entry.Text = string.Empty;
        }
    }
    private void OnSiguienteClicked(object sender, EventArgs e)
    {

    }
}