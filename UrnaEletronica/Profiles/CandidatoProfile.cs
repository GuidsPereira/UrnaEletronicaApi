using AutoMapper;
using UrnaEletronica.Data.Dtos;
using UrnaEletronica.Models;

namespace UrnaEletronica.Profiles;

public class CandidatoProfile : Profile
{
    public CandidatoProfile()
    {
        CreateMap<CreateCandidatoDto, Candidato>();
        CreateMap<Candidato, ReadCandidatoDto>();
    }
}