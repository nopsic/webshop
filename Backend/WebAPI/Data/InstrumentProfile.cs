using AutoMapper;
using WebAPI.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class InstrumentProfile : Profile
    {
        public InstrumentProfile()
        {
            this.CreateMap<Instrument, InstrumentModel>()
                .ReverseMap();

            this.CreateMap<UserData, UserDataModel>()
                .ReverseMap();
        }
    }
}
