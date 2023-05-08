using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private static List<Filme> _filmes = new List<Filme>();

        [HttpPost]
        public void Adicionar([FromBody]Filme filme)
        {
            _filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
        }
    }
}
