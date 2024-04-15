using MardocheDespagne_MAUI_demo.ViewModels;

namespace MardocheDespagne_MAUI_demo.Views;

public partial class MainPage : ContentPage
{
    private MainPageViewModel _viewMode;
    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetPersonListCommand.Execute(null);
    }
}