using FinalBoss.Api.Client;

namespace FinalBoss.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private readonly IFinalBossClient _client;

        public SearchViewModel()
        {
            Title = "Search";
        }
    }
}