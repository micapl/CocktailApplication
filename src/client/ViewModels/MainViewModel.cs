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

[ObservableProperty]
private double _sidebarWidth = 200;

public bool IsExpanded => SidebarWidth == 200;
public string MenuButtonContent => IsExpanded ? "Menu" : "";
public string SearchButtonContent => IsExpanded ? "Search" : "";
public string HomeButtonContent => IsExpanded ? "Home" : "";
public string SocialButtonContent => IsExpanded ? "Social" : "";
public string SettingsButtonContent => IsExpanded ? "Settings" : "";
public string QuitButtonContent => IsExpanded ? "Quit" : "";
public string LoginButtonContent => IsExpanded ? "Login" : "";

[RelayCommand]
private void ToggleMenu()
{
    SidebarWidth = SidebarWidth == 200 ? 80 : 200;

    OnPropertyChanged(nameof(IsExpanded));
    OnPropertyChanged(nameof(SearchButtonContent));
    OnPropertyChanged(nameof(HomeButtonContent));
    OnPropertyChanged(nameof(SocialButtonContent));
    OnPropertyChanged(nameof(SettingsButtonContent));
    OnPropertyChanged(nameof(QuitButtonContent));
    OnPropertyChanged(nameof(LoginButtonContent));
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