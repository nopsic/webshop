using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class InstrumentModel
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public int Quantity { get; set; }
        public string PictureName { get; set; }
        public string Type { get; set; }
    }
}
