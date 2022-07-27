using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Data;
using UrnaEletronica.Data.Dtos;
using UrnaEletronica.Data.Dtos.VotoDto;
using UrnaEletronica.Models;

namespace UrnaEletronica.Controllers;

[ApiController]
[Route("[controller]")]
public class VotoController : ControllerBase
{
    private readonly UrnaEletronicaContext _context;
    private readonly IMapper _mapper;

    public VotoController(UrnaEletronicaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarCandidato([FromBody] CreateVotoDto votoDto)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Legenda == votoDto.Legenda);
        //checar aqui se o candidato existe
        var voto = new Voto
        {
            CandidatoId = candidato.Id,
            DataVoto = DateTime.Now
        };
        _context.Votos.Add(voto);
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadVotoDto>>> RecuperaVotos()
    {
        return await _context.Votos.Select(voto => _mapper.Map<ReadVotoDto>(voto))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaVotoPorId(int id)
    {
        var voto = _context.Candidatos.FirstOrDefault(voto => voto.Id == id);
        if (voto != null)
        {
            var candidatoDto = _mapper.Map<ReadCandidatoDto>(voto);
            {
            }
            return Ok(voto);
        }

        return NotFound();
    }
}