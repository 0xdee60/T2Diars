using Microsoft.EntityFrameworkCore;
using ProyDentoWeb.BD.Maps;

namespace ProyDentoWeb.Models
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {
            
        }

        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<Entrenador> entrenadors {get;set;}

        public DbSet<EntrenadorPokemon> entrenadorPokemons {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PokemonMap());
            modelBuilder.ApplyConfiguration(new EntrenadorMap());
            modelBuilder.ApplyConfiguration(new EntrenadorPokemonMap());
        }


    }
}