using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using client.ViewModels.HomeViewModels;

namespace client.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject? _currentPage;

        private readonly FavouritesViewModel _favouritesVm = new();
        private readonly MakeCocktailViewModel _makeCocktailVm = new();
        private readonly CocktailCategoriesViewModel _categoriesVm = new();
        private readonly BarViewModel _barVm = new();

        public HomeViewModel()
        {
            CurrentPage = null;
        }

        [RelayCommand]
        private void NavigateFavourites() => CurrentPage = _favouritesVm;
        
        [RelayCommand]
        private void NavigateMakeCocktail() => CurrentPage = _makeCocktailVm;

        [RelayCommand]
        private void NavigateCategories() => CurrentPage = _categoriesVm;

        [RelayCommand]
        private void NavigateBar() => CurrentPage = _barVm;
    }
}