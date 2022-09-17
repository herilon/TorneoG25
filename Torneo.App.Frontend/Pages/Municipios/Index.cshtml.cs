using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Persistencia;
using Torneo.App.Dominio;

namespace Torneo.App.Frontend.Pages.Municipios
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        public IEnumerable<Municipio> municipios { get; set; }
        public bool ErrorEliminar { get; set; }

        public IndexModel(IRepositorioMunicipio repoMunicipio)
        {
            _repoMunicipio = repoMunicipio;
        }

        public void OnGet()
        {
            municipios = _repoMunicipio.GetAllMunicipios();
            ErrorEliminar = false;
/*
            foreach (var municipio in municipios)
            {
                Console.WriteLine(municipio.Nombre);
                foreach (var equipo in municipio.Equipos)
                {
                    Console.WriteLine("\t" + equipo.Nombre);
                }
            }
*/
        }

        public IActionResult OnPostDelete(int id)
        {
            try{
                _repoMunicipio.DeleteMunicipio(id);
                municipios = _repoMunicipio.GetAllMunicipios();
                return Page();
            }
            catch (Exception ex){
                municipios = _repoMunicipio.GetAllMunicipios();
                ErrorEliminar = true;
                return Page();
            }
        }

    }

}
