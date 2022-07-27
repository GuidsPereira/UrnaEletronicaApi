using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrnaEletronica.Models;

public class Voto
{
    [Key] public int Id { get; set; }
    public DateTime DataVoto { get; set; }
    public int CandidatoId { get; set; }
    [ForeignKey("CandidatoId")] public virtual Candidato? Candidato { get; set; }
}