using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyDentoWeb.Models;

namespace ProyDentoWeb.BD.Maps
{
    public class EntrenadorPokemonMap : IEntityTypeConfiguration<EntrenadorPokemon>
    {
        public void Configure(EntityTypeBuilder<EntrenadorPokemon> builder)
        {
            builder.ToTable("EntrenadorPokemon");
            builder.HasKey(o => o.idEntrenadorPokemon);

            builder.HasOne(o => o.entrenador).WithMany(o => o.entrenadorPokemons).HasForeignKey(o=>o.idEntrenador);
            builder.HasOne(o => o.pokemon).WithMany().HasForeignKey(o=>o.idPokemon);
            
        }
    }
}