using ManagementApplication.Data;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ManagementApplication.ViewModel
{
    public class InstrumentWindowViewModel : ViewModelBase
    {
        #region Fields

        private readonly InstrumentRepository _instrumentRepository = new InstrumentRepository();
        private Instrument _newInstrument;
        private Instrument _updateInstrument;
        private int _selectedId = 0;
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
                _newInstrument.InstrumentId = _selectedId;
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

            if (NewInstrument.Image == null)
            {
                MessageBox.Show("Need to add an image", "Error");
                return;
            }

            _instrumentRepository.Add(NewInstrument);

            if (await _instrumentRepository.SaveChangesAsync())
            {
                WindowLoaded(); 
                MessageBox.Show("Added Successfully", "Done");
                NewInstrument = new Instrument();
            }
        }

        public async void DeleteSelectedInstrument(Instrument instrument)
        {
            var existing = await _instrumentRepository.GetInstrumentAsync(instrument.Code);

            if (existing == null)
            {
                MessageBox.Show("Can't delete the instrument", "Error");
                return;
            }

            _instrumentRepository.Delete(existing);

            if (await _instrumentRepository.SaveChangesAsync())
            {
                WindowLoaded();
                MessageBox.Show("Deleted Successfully", "Done");
                UpdateInstrument = new Instrument();
            }
        }

        public void ChangeSelectedInstrument(Instrument instrument)
        {
            UpdateInstrument = new Instrument(instrument);
        }

        public async void UpdateSelectedInstrument(Instrument instrument)
        {

            var updatedInstrument = await _instrumentRepository.UpdateInstrumentAsync(_selectedId, instrument);

            if (updatedInstrument == null)
            {
                return;
            }
            else
            {
                await _instrumentRepository.SaveChangesAsync();
                MessageBox.Show("Updated Successfully", "Done");
                WindowLoaded();
                UpdateInstrument = new Instrument();
            }

            
        }

        public void SaveImage(Uri uri)
        {
            byte[] image = null;

            FileStream stream = new FileStream(uri.OriginalString, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(stream);

            image = binaryReader.ReadBytes((int)stream.Length);
            NewInstrument.Image = image;
        }

        public BitmapImage GetImage(byte[] array)
        {
            if (array == null)
            {
                return null;
            }

            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public void UpdateImage(Uri uri)
        {
            byte[] image = null;

            FileStream stream = new FileStream(uri.OriginalString, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(stream);

            image = binaryReader.ReadBytes((int)stream.Length);
            UpdateInstrument.Image = image;
        }

        public async void WindowLoaded()
        {
            var instruments = await _instrumentRepository.GetAllInstrumentsAsync();

            var list = instruments.ToList();

            InstrumentData = new ObservableCollection<Instrument>(list);
        }

        #endregion
    }
}
