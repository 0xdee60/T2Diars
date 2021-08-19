using System.ComponentModel.DataAnnotations;

namespace ProyDentoWeb.Models
{
    public class Pokemon
    {
        public int idPokemon { get; set; }
      
        public string nombres { get; set; } 

      
        public string tipo { get; set; }

        
        public string imagen { get; set; }
    }
}