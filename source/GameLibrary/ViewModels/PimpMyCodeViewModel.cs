using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using GameLibrary.Framework;

namespace GameLibrary.ViewModels
{
    [Export(typeof(PimpMyCodeViewModel))]
    public class PimpMyCodeViewModel : ViewModelBase, IScreen
    {
        public string Title { get; set; }
        public DateTime PresentedOn { get; set; }
        
        private bool _showWarning;
        public bool ShowWarning
        {
            get { return _showWarning; }
            set
            {
                _showWarning = value;
                NotifyOfPropertyChange(() => ShowWarning);
                CancelCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public PimpMyCodeViewModel()
        {
            Title = "Design for Convention over Configuration";
            PresentedOn = new DateTime(2010, 11, 24);

            CancelCommand = new DelegateCommand(Cancel, CanCancel);
            DeleteCommand = new DelegateCommand(Delete, null);
        }

        private void Delete(object obj)
        {
            ShowWarning = true;
        }

        private bool CanCancel(object arg)
        {
            return ShowWarning;
        }

        private void Cancel(object obj)
        {
            ShowWarning = false;
        }

        public void Activate() {}
        public bool CanClose() { return true; }
    }
}