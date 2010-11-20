using ConOverConf.Contracts.Commands;

namespace GameLibrary.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.DataAnnotations;
    using System.Windows;
    using Framework;
    using Model;

    [Export(typeof(AddGameViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AddGameViewModel : ViewModelBase, IScreen
    {
        private string _notes;
        private double _rating;
        private string _title;
        private bool _wasSaved;

        [Required]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
                NotifyOfPropertyChange(() => CanAddGame);
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public double Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                NotifyOfPropertyChange(() => Rating);
            }
        }

        public bool CanAddGame
        {
            get { return IsValid; }
        }

        public IEnumerable<IResult> AddGame()
        {
            var add = new AddGameToLibrary
            {
                Title = Title,
                Notes = Notes,
                Rating = Rating
            }.AsResult();

            _wasSaved = true;

            yield return add;
            yield return Show.Screen<SearchViewModel>();
        }

        public void Activate() {}

        public bool CanClose()
        {
            return _wasSaved || MessageBox.Show(
                "Are you sure you want to cancel?  Changes will be lost.",
                "Unsaved Changes",
                MessageBoxButton.OKCancel
                ) == MessageBoxResult.OK;
        }
    }
}