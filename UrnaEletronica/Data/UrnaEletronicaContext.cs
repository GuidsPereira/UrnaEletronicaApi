using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Models;

namespace UrnaEletronica.Data;

public class UrnaEletronicaContext : DbContext
{
    public UrnaEletronicaContext(DbContextOptions<UrnaEletronicaContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Candidato>()
            .HasMany(candidato => candidato.Votos)
            .WithOne(voto => voto.Candidato)
            .HasForeignKey(voto => voto.CandidatoId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<Candidato> Candidatos { get; set; }
    public DbSet<Voto> Votos { get; set; }
}