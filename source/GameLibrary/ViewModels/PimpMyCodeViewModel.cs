using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using GameLibrary.Framework;

namespace GameLibrary.ViewModels
{
    [Export(typeof(PimpMyCodeViewModel3))]
    public class PimpMyCodeViewModel2 : ViewModelBase, IScreen
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
                NotifyOfPropertyChange(() => CanCancel);
            }
        }

        public PimpMyCodeViewModel2()
        {
            Title = "Design for Convention over Configuration";
            PresentedOn = new DateTime(2010, 11, 24);

        }

        public void Delete()
        {
            ShowWarning = true;
        }

        public bool CanCancel
        {
            get { return ShowWarning; }
        }

        public void Cancel()
        {
            ShowWarning = false;
        }

        public void Activate() {}
        public bool CanClose() { return true; }
    }
}