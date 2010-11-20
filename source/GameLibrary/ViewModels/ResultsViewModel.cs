using ConOverConf.Contracts.Data;

namespace GameLibrary.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using Framework;
    using Model;

    [Export(typeof(ResultsViewModel))]
    public class ResultsViewModel : ViewModelBase
    {
        public ResultsViewModel()
        {
            Results = new ObservableCollection<IndividualResultViewModel>();
        }

        public string Message
        {
            get
            {
                if(Results.Count == 1)
                    return "1 Match Found";
                return Results.Count + " Matches Found";
            }
        }

        public ObservableCollection<IndividualResultViewModel> Results { get; private set; }

        public ResultsViewModel With(IEnumerable<SearchResultDTO> searchResults)
        {
            Results.Clear();

            int number = 1;

            foreach(var result in searchResults)
            {
                Results.Add(new IndividualResultViewModel(result, number));
                number++;
            }

            NotifyOfPropertyChange(() => Message);
            return this;
        }
    }
}