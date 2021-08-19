using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProyDentoWeb.Models;

namespace ProyDentoWeb.Controllers
{
    [Authorize]
    public class EntrenadorPokemonController:Controller
    {

        private PokemonContext cnx; 
        public IHostEnvironment _hostEnv;
        public EntrenadorPokemonController(PokemonContext _cnx, IHostEnvironment _configuration)
        {
            cnx = _cnx;
            _hostEnv= _configuration;
        }

        public ActionResult Index(int idEntrenador){
            return View(cnx.entrenadorPokemons.Where(o => o.idEntrenador == idEntrenador).Include(o => o.pokemon).ToList());
        }
    


        public ActionResult Create(int idPokemon){

            EntrenadorPokemon p= new EntrenadorPokemon();

            p.fecha = DateTime.Now;
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = cnx.entrenadors.Where(o => o.usuario == claim.Value).FirstOrDefault();
            
            p.idEntrenador =  user.idEntrenador;
            p.idPokemon = idPokemon;  
            cnx.entrenadorPokemons.Add(p);
            cnx.SaveChanges();
            return RedirectToAction("Index","Pokemon");
        }

        public ActionResult Delete(int id){
            var x = cnx.entrenadorPokemons.Where(o => o.idEntrenadorPokemon == id).FirstOrDefault();

            cnx.Remove(x);
            cnx.SaveChanges();

            return RedirectToAction("Index","Pokemon");
        }
    }
}