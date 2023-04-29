using AC_Razor_HTML_helper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AC_Razor_HTML_helper.Controllers
{
    public class EquiposController : Controller
    {
       public IActionResult Index()
       {
            var listaDeMarcas = (from m in _equiposDbContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listaTipoEquipo = (from m in _equiposDbContext.tipo_equipo
                                 select m).ToList();
            ViewData["listadoTipoEquipo"] = new SelectList(listaTipoEquipo, "id_tipo_equipo", "descripcion");

            var listaEstadoEquipo = (from m in _equiposDbContext.estados_equipo
                                   select m).ToList();
            ViewData["listadoEstadoEquipo"] = new SelectList(listaEstadoEquipo, "id_estados_equipo", "descripcion");

            //Extras
            var listadoDeEquipos = (from e in _equiposDbContext.equipos
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new{
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoEquipo"] = listadoDeEquipos;
            //Fin extras

            return View();
       }
        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

       private readonly equiposDbContext _equiposDbContext;
       public EquiposController(equiposDbContext equiposDbContext) {
            _equiposDbContext = equiposDbContext;
       }
    }
}
