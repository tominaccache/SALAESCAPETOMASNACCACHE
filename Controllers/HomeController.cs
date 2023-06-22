using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaEscape1.Models;

namespace SalaEscape1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
     public IActionResult tutorial()
    {
        return View();
    }

    public IActionResult Creditos()
    {
        return View();
    }
       public IActionResult victoria()
    {
        return View();
    }
      public IActionResult Comenzar()
    {
        //que no sea + que la ultima    
        escape.InicializarJuego();
        return View("habitacion"+escape.GetEstadoJuego());
    }
       

    [HttpPost] public IActionResult Habitacion(int sala, string clave){

/* Verifica que la sala que se está respondiendo coincida con EstadoJuego. En caso de estar resolviendo una sala incorrecta deberá devolver la view de la sala a resolver.
Luego Verifica que la clave ingresada sea la correcta. De ser así, retorna la View siguiente Habitacion. De lo contrario, vuelve a la misma vista y llena el ViewBag.Error informando al usuario que la respuesta escrita fue incorrecta.
En caso de estar resolviendo la última sala de manera correcta deberá ir a la View Victoria.*/


        if (escape.ResolverSala(sala,clave)==true && escape.GetEstadoJuego()<4)
        {
            return View("habitacion" + escape.GetEstadoJuego());
        }
        if (escape.GetEstadoJuego()>3)
        {
            return View("victoria");
        }
            ViewBag.Error="Tu clave es incorrecta";
            return View("habitacion" + escape.GetEstadoJuego());
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
