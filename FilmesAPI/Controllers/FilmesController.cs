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
        public IActionResult Adicionar([FromBody]Filme filme)
        {
            id++;
            filme.Id = id;
            _filmes.Add(filme);

            return CreatedAtAction(nameof(BuscarPorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var filmes = _filmes.Skip(skip).Take(take);

            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = _filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            return Ok(filme);
        }
    }
}
