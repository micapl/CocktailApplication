using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using client.ViewModels.SocialViewModels;

namespace client.ViewModels
{
    public partial class SocialViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject? _currentPage;

        private readonly FriendsViewModel _friendsVm = new();
        private readonly HistoryViewModel _historyVm = new();
        private readonly StatisticsViewModel _statisticsVm = new();
    
        public SocialViewModel()
        {
            CurrentPage = null;
        }

        [RelayCommand]
        private void NavigateFriends() => CurrentPage = _friendsVm;
        
        [RelayCommand]
        private void NavigateHistory() => CurrentPage = _historyVm;

        [RelayCommand]
        private void NavigateStatistics() => CurrentPage = _statisticsVm;
    }
}