using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrnaEletronica.Data.Dtos;

public class ReadCandidatoDto
{
    [Key] [Required] public int Id { get; set; }

    [Required(ErrorMessage = "Nome é Obrigatorio")]
    [Column("nome_completo")]
    public string? NomeCompleto { get; set; }

    [Required(ErrorMessage = "Nome do Vice é obrigatorio")]
    [Column("nome_vice")]
    public string? NomeVice { get; set; }

    [Required(ErrorMessage = "Data de Registro Obrigatoria")]
    [Column("data_registro")]
    public DateTime DataRegistro { get; set; }

    [Required(ErrorMessage = "Legenda Obrigatoria")]
    [Column("legenda")]
    public int Legenda { get; set; }
}