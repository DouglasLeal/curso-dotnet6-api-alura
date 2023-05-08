using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Filme;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody]CreateFilmeDto dto)
        {
            Filme filme = _mapper.Map<Filme>(dto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarPorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var filmes = _context.Filmes.Skip(skip).Take(take);

            return Ok(filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return NotFound();

            return Ok(filme);
        }
    }
}
