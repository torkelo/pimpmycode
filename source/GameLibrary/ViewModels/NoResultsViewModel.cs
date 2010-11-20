namespace GameLibrary.ViewModels
{
    using System.ComponentModel.Composition;
    using Framework;

    [Export(typeof(NoResultsViewModel))]
    public class NoResultsViewModel
    {
        private string _searchText;

        public IResult AddGame()
        {
            return Show.Screen<AddGameViewModel>()
                .Configured(x => x.Title = _searchText);
        }

        public NoResultsViewModel WithTitle(string searchText)
        {
            _searchText = searchText;
            return this;
        }
    }
}