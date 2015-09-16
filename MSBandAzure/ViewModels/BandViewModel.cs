using MSBandAzure.Model;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace MSBandAzure.ViewModels
{
    public class BandViewModel : ViewModelBase
    {
        private Band _band;
        public BandViewModel(Band band)
        {
            _band = band;
        }

        public string BandName { get { return _band.Name; } }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { Set(ref _isBusy, value); }
        }

        public async Task Connect(object arg)
        {
            IsBusy = true;
            try
            {
                await _band.Connect();

            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
