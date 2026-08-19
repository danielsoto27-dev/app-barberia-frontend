using AppGestorVentas.Classes;
using AppGestorVentas.ViewModels.OrdenViewModels;

namespace AppGestorVentas.Views.OrdenViews;

public partial class AdministracionOrdenView : ContentPage
{
    public AdministracionOrdenView(AdministracionOrdenViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void AgregarOrden(object sender, EventArgs e)
    {
        if (BindingContext is AdministracionOrdenViewModel vm)
        {
            await vm.CrearNuevaOrden();
        }
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (OperatingSystem.IsAndroid())
        {
            VistaEscritorio.IsEnabled = false;
            VistaEscritorio.IsVisible = false;
            VistaAndroid.IsVisible = true;
            VistaAndroid.IsEnabled = true;
            // C�digo espec�fico para Android
        }
        else if (OperatingSystem.IsWindows())
        {
            VistaAndroid.IsVisible = false;
            VistaAndroid.IsEnabled = false;
            VistaEscritorio.IsEnabled = true;
            VistaEscritorio.IsVisible = true;
        }

        //
        

        if (BindingContext is AdministracionOrdenViewModel viewModel)
        {
            viewModel.ConectarEvento();
            viewModel.EstablecerVisivilidadBotonPorRol();
#if WINDOWS
            // En Windows unpackaged el XamlRoot no está listo al primer OnAppearing;
            // esperamos un frame para que la ventana termine de renderizar.
            await Task.Delay(300);
#endif
            await viewModel.ObtenerListadoOrdenesAPI();
        }

    }





    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Aqu� colocas el c�digo que se ejecuta cuando la p�gina deja de estar activa

        if (BindingContext is AdministracionOrdenViewModel vm)
        {
            vm.DesconectarEvento();
        }
    }



}