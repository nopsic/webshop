using ManagementApplication.Data;
using Microsoft.AspNetCore.Routing;
using System.Collections.ObjectModel;
using System.Linq;

namespace ManagementApplication.ViewModel
{
    public class InstrumentWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly InstrumentRepository _instrumentRepository = new InstrumentRepository();
        private Instrument _newInstrument;
        private Instrument _updateInstrument;
        private string _selectedCode = "";
        private ObservableCollection<Instrument> _collection;

        #endregion

        #region Properties

        public DelegateCommand NewInstrumentClickCommand { get; private set; }
        public DelegateCommand UpdateCommand { get; private set; }

        public ObservableCollection<Instrument> InstrumentData
        {
            get
            {
                return _collection;
            }
            set 
            {
                _collection = value;
                OnPropertyChanged("InstrumentData");
            }
        }

        public Instrument NewInstrument
        {
            get
            {
                return _newInstrument;
            }
            set
            {
                _newInstrument = value;
                _newInstrument.Code = _selectedCode;
                OnPropertyChanged("NewInstrument");
            }
        }

        public Instrument UpdateInstrument 
        { 
            get
            {
                return _updateInstrument;
            }
            set
            {
                _updateInstrument = value;
                OnPropertyChanged("UpdateInstrument");
            }
        }

        #endregion

        #region Constructor

        public InstrumentWindowViewModel()
        {
            NewInstrumentClickCommand = new DelegateCommand(param => AddInstrument());
            UpdateCommand = new DelegateCommand(param => UpdateSelectedInstrument(UpdateInstrument));

            NewInstrument = new Instrument();

            UpdateInstrument = new Instrument();
        }

        #endregion

        #region Public methods

        public async void AddInstrument()
        {
            var existing = await _instrumentRepository.GetInstrumentAsync(NewInstrument.Code);

            if (existing != null) 
            {
                return;
            }

            _instrumentRepository.Add(NewInstrument);

            if (await _instrumentRepository.SaveChangesAsync())
            {
                Window_Loaded();
                NewInstrument = new Instrument();
            }
        }

        public async void DeleteSelectedInstrument(Instrument instrument)
        {
            var existing = await _instrumentRepository.GetInstrumentAsync(instrument.Code);

            if (existing == null)
            {
                return;
            }

            _instrumentRepository.Delete(instrument);

            if (await _instrumentRepository.SaveChangesAsync())
            {
                Window_Loaded();
                UpdateInstrument = new Instrument();
            }
        }

        public void ChangeSelectedInstrument(Instrument instrument)
        {
            UpdateInstrument = new Instrument(instrument);
        }

        public async void UpdateSelectedInstrument(Instrument instrument)
        {

            var updatedInstrument = await _instrumentRepository.UpdateInstrumentAsync(_selectedCode, instrument);

            if (updatedInstrument == null)
            {
                return;
            }
            else
            {
                await _instrumentRepository.SaveChangesAsync();
                Window_Loaded();
                UpdateInstrument = new Instrument();
            }

            
        }

        public async void Window_Loaded()
        {
            var instruments = await _instrumentRepository.GetAllInstrumentsAsync();

            var list = instruments.ToList();

            InstrumentData = new ObservableCollection<Instrument>(list);
        }

        #endregion
    }
}
