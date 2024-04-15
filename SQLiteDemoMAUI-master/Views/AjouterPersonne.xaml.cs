using MardocheDespagne_MAUI_demo.ViewModels;

namespace MardocheDespagne_MAUI_demo.Views;

public partial class AjouterPersonne : ContentPage
{
    public AjouterPersonne(AjouterPersonneViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}