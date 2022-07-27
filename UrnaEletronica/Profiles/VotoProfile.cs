using AutoMapper;
using UrnaEletronica.Data.Dtos.VotoDto;
using UrnaEletronica.Models;

namespace UrnaEletronica.Profiles;

public class VotoProfile : Profile
{
    public VotoProfile()
    {
        CreateMap<CreateVotoDto, Voto>();
        CreateMap<Voto, ReadVotoDto>();
    }
}