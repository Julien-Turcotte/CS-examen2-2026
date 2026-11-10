namespace Guignolee.ViewModels.Pages
{
    public class ModifierDonViewModel : BaseViewModel
    {
        private DonViewModel _donEdit;
        public DonViewModel DonEdit
        {
            get { return _donEdit; }
            set
            {
                if (_donEdit != value)
                {
                    _donEdit = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ModifierDonViewModel(DonViewModel donViewModel)
        {
            DonEdit = donViewModel;
        }

    }
}
