using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyDentoWeb.Models;

namespace ProyDentoWeb.BD.Maps
{
    public class EntrenadorMap : IEntityTypeConfiguration<Entrenador>
    {
        public void Configure(EntityTypeBuilder<Entrenador> builder)
        {
            builder.ToTable("Entrenador");
            builder.HasKey(o => o.idEntrenador);

            builder.HasMany(o => o.entrenadorPokemons).WithOne(o => o.entrenador).HasForeignKey(o => o.idEntrenador);

        }
    }
}