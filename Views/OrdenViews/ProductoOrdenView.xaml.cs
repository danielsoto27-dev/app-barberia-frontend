using AppGestorVentas.ViewModels.OrdenViewModels;

namespace AppGestorVentas.Views.OrdenViews;

public partial class ProductoOrdenView : ContentPage
{
	public ProductoOrdenView(ProductoOrdenViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        Shell.SetTabBarIsVisible(this, false);
        Shell.SetFlyoutBehavior(this, FlyoutBehavior.Disabled); // Deshabilita el boton del menu lateral
    }
}