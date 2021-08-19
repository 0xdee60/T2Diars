using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ProyDentoWeb.Models;

namespace ProyDentoWeb.Controllers
{


    [Authorize]
    public class PokemonController:Controller
    {


        private PokemonContext cnx; 
        public IHostEnvironment _hostEnv;
        public PokemonController(PokemonContext _cnx, IHostEnvironment _configuration)
        {
            cnx = _cnx;
            _hostEnv= _configuration;
        }




        [HttpGet]
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombres, string tipo,string imagen){
            validar(nombres,tipo,imagen);
            if(!ModelState.IsValid){
                return View();
            }


            Pokemon p = new Pokemon();
            p.nombres = nombres;
            p.tipo = tipo;
            p.imagen = @"~/wwwroot/images/" + imagen;

            cnx.pokemons.Add(p);
            cnx.SaveChanges();

            

            return RedirectToAction("Index","Pokemon");
        }

        public void validar(string nombres, string tipo,string imagen){
            foreach(var item in cnx.pokemons.ToList()){
                if(nombres == item.nombres){
                    ModelState.AddModelError("nb", "El campo Nombre ocupado"); 
                }
            }

            if(tipo == ""){
                ModelState.AddModelError("tp", "El campo Tipo es obligatorio"); 
            }

            if(imagen.ToString() == ""){
                ModelState.AddModelError("img", "El campo Imagen es obligatorio"); 
            }
        }
      
        public ActionResult Index(){

            return View(cnx.pokemons.ToList());
        }
    }
}