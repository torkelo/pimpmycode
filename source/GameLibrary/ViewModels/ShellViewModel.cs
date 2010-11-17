using GameLibrary.Views;

namespace GameLibrary.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using Framework;

    [Export(typeof(IShell))]
    public class ShellViewModel : ScreenConductor, IShell
    {
        private bool _isBusy;

        [ImportingConstructor]
        public ShellViewModel(SearchViewModel firstScreen)
        {
            OpenScreen(firstScreen);
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                NotifyOfPropertyChange(() => IsBusy);
            }
        }

        public IEnumerable<IResult> Back()
        {
            yield return Show.Screen<SearchViewModel>();
        }

        public bool CanClose()
        {
            return ActiveScreen.CanClose();
        }
    }
}