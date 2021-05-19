namespace ManagementApplication.Data
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public string Type { get; set; }

        public Instrument()
        {

        }

        public Instrument(Instrument instrument)
        {
            this.InstrumentId = instrument.InstrumentId;
            this.Name = instrument.Name;
            this.Code = instrument.Code;
            this.Price = instrument.Price;
            this.Description = instrument.Description;
            this.Rating = instrument.Rating;
            this.Quantity = instrument.Quantity;
            this.Image = instrument.Image;
            this.Type = instrument.Type;
        }
    }
}
