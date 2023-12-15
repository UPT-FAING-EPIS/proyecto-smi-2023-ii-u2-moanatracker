using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Moana.Models;
using Supabase;
using Supabase.Interfaces;

namespace Moana.View;

public class RecetasViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Receta> _listaRecetas;

    public ObservableCollection<Receta> ListaRecetas
    {
        get { return _listaRecetas; }
        set
        {
            if (_listaRecetas != value)
            {
                _listaRecetas = value;
                OnPropertyChanged();
            }
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private readonly Client _supabaseClient;
    public RecetasViewModel()
    {
        _supabaseClient = MauiProgram.CreateMauiApp().Services.GetRequiredService<Client>();
        LoadRecetas();
    }
    public async void LoadRecetas()
    {
        try
        {
            var recetasService = new RecetaService(_supabaseClient);
            var idMedico = await SecureStorage.GetAsync("IdMedico");

            ListaRecetas = new ObservableCollection<Receta>(await recetasService.GetRecetasbyMedico(Int32.Parse(idMedico)));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener prescripciones: " + ex.Message);
        }
    }
}
