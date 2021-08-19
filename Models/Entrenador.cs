using System;
using System.Collections.Generic;

namespace ProyDentoWeb.Models
{
    public class Entrenador
    {
        public int idEntrenador { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fechaNac { get; set; }
        public string usuario { get; set; }
        public string passwd { get; set; }

        
        public List<EntrenadorPokemon> entrenadorPokemons{get;set;}
        
    }
}