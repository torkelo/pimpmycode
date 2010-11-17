using ConOverConf.Contracts.Queries;

namespace GameLibrary.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using Framework;
    using Model;

    [Export(typeof(SearchViewModel))]
    public class SearchViewModel : ViewModelBase, IScreen
    {
        private readonly NoResultsViewModel _noResults;
        private readonly ResultsViewModel _results;

        private object _searchResults;
        private string _searchText;

        [ImportingConstructor]
        public SearchViewModel(NoResultsViewModel noResults, ResultsViewModel results)
        {
            _noResults = noResults;
            _results = results;
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                NotifyOfPropertyChange(() => SearchText);
                NotifyOfPropertyChange(() => CanExecuteSearch);
            }
        }

        public object SearchResults
        {
            get { return _searchResults; }
            set
            {
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
            }
        }

        public bool CanExecuteSearch
        {
            get { return !string.IsNullOrEmpty(SearchText); }
        }

        public IEnumerable<IResult> ExecuteSearch()
        {
            var search = new SearchGames
            {
                SearchText = SearchText
            }.AsResult();

            yield return Show.Busy();
            yield return search;

            var hits = search.Response.Hits;

            if (hits.Count() == 0)
                SearchResults = _noResults.WithTitle(SearchText);
            else if (hits.Count() == 1 && hits.First().Title == SearchText)
            {
                var getGame = new GetGame
                {
                    Id = hits.First().Id
                }.AsResult();

                yield return getGame;
                yield return Show.Screen<ExploreGameViewModel>()
                    .Configured(x => x.WithGame(getGame.Response));
            }
            else SearchResults = _results.With(hits);

            yield return Show.NotBusy();
        }

        public IResult AddGame()
        {
            return Show.Screen<AddGameViewModel>()
                .Configured(x => x.Title = "New Game");
        }

        public IResult PimpMyCode()
        {
            return Show.Screen<PimpMyCodeViewModel>();
        }

        public void Activate()
        {
            SearchText = null;
            SearchResults = null;
        }

        public bool CanClose()
        {
            return true;
        }
    }
}