using ConOverConf.Contracts.Data;
using ConOverConf.Contracts.Queries;

namespace GameLibrary.ViewModels
{
    using System.Collections.Generic;
    using Framework;
    using Model;

    public class IndividualResultViewModel
    {
        private readonly SearchResultDTO _result;
        private readonly int _number;

        public IndividualResultViewModel(SearchResultDTO result, int number)
        {
            _result = result;
            _number = number;
        }

        public int Number
        {
            get { return _number; }
        }

        public string Title
        {
            get { return _result.Title; }
        }

        public IEnumerable<IResult> Open()
        {
            var getGame = new GetGame
            {
                Id = _result.Id
            }.AsResult();

            yield return Show.Busy();
            yield return getGame;
            yield return Show.Screen<ExploreGameViewModel>()
                .Configured(x => x.WithGame(getGame.Response));
            yield return Show.NotBusy();
        }
    }
}