using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using client.ViewModels.SettingsViewModels;

namespace client.ViewModels
{
    public partial class SettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject? _currentPage;

        private readonly LanguageViewModel _languageVm = new();

        public SettingsViewModel()
        {
            CurrentPage = null;
        }

        [RelayCommand]
        private void NavigateLanguage() => CurrentPage = _languageVm;
    }
}