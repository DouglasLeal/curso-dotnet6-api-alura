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
        private static int id = 0;

        [HttpPost]
        public void Adicionar([FromBody]Filme filme)
        {
            id++;
            filme.Id = id;
            _filmes.Add(filme);
            Console.WriteLine(filme.Id);
            Console.WriteLine(filme.Titulo);
        }

        [HttpGet]
        public IEnumerable<Filme> Listar([FromQuery]int skip = 0, [FromQuery]int take = 10)
        {
            return _filmes.Skip(skip).Take(take);
        }

        [HttpGet("{id}")]
        public Filme? BuscarPorId(int id)
        {
            return _filmes.FirstOrDefault(filme => filme.Id == id);
        }
    }
}
