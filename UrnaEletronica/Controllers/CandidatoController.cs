using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Data;
using UrnaEletronica.Data.Dtos;
using UrnaEletronica.Models;

namespace UrnaEletronica.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatoController : ControllerBase
{
    private readonly UrnaEletronicaContext _context;
    private readonly IMapper _mapper;

    public CandidatoController(UrnaEletronicaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionarCandidato([FromBody] CreateCandidatoDto candidatoDto)
    {
        var candidato = _mapper.Map<Candidato>(candidatoDto);
        _context.Candidatos.Add(candidato);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaCandidatoPorId), new { candidato.Id }, candidato);
    }

    [HttpGet]
    public async Task<ActionResult<List<ReadCandidatoDto>>> RecuperaCandidatos()
    {
        return await _context.Candidatos.Select(candidato => _mapper.Map<ReadCandidatoDto>(candidato))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaCandidatoPorId(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato != null)
        {
            var candidatoDto = _mapper.Map<ReadCandidatoDto>(candidato);
            {
            }
            return Ok(candidatoDto);
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCandidato(int id)
    {
        var candidato = _context.Candidatos.FirstOrDefault(candidato => candidato.Id == id);
        if (candidato == null)
        {
            return NotFound();
        }

        _context.Remove(candidato);
        _context.SaveChanges();
        return NoContent();
    }
}