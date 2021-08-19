using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProyDentoWeb.BD;
using ProyDentoWeb.Models;

namespace ProyDentoWeb.Controllers
{
    public class AuthController : Controller
    {
        private PokemonContext cnx; 
        public readonly IConfiguration configuration;
        public AuthController(PokemonContext _cnx, IConfiguration _configuration)
        {
            cnx = _cnx;
            configuration = _configuration;
        }

        [HttpGet]
        public ActionResult Login(){

            return View();
        }

         [HttpPost]
        public ActionResult Login(string usuario, string password){
            
            var user = cnx.entrenadors.Where(o => o.usuario == usuario && o.passwd == CreateHash(password)).FirstOrDefault();

            
            if(user == null){
                return View();
            }
            
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, usuario)
                };
                var claimsIdentity = new ClaimsIdentity(claims,"Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                
                HttpContext.SignInAsync(claimsPrincipal);
                
                return RedirectToAction("Index","Home");
        }

        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }





    }
}
