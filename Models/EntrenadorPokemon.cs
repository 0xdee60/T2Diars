using System;

namespace ProyDentoWeb.Models
{
    public class EntrenadorPokemon
    {
        
        public int idEntrenadorPokemon { get; set; }
        public DateTime fecha { get; set; }  
        public int idEntrenador { get; set; }
        public int idPokemon { get; set; }

        
              
        public Pokemon pokemon { get; set; }
        public Entrenador entrenador { get; set; }

    }
}