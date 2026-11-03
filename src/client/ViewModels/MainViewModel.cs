using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace client.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private object? _currentView;

    public MainViewModel()
    {
        CurrentView = null;
    }
[RelayCommand]
private void NavigateHome() => CurrentView = new HomeViewModel();

[RelayCommand]
private void NavigateSearch() => CurrentView = new SearchViewModel();

[RelayCommand]
private void NavigateSocial() => CurrentView = new SocialViewModel();

[RelayCommand]
private void NavigateSettings() => CurrentView = new SettingsViewModel();

[RelayCommand]
private void NavigateLogin() => CurrentView = new LoginViewModel();

[RelayCommand]
private void Quit()
{
    if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
    {
        desktop.Shutdown();
    }
}
}