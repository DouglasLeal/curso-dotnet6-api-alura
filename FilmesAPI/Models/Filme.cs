using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DisplayName("Título")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O {0} é obrigatório.")]
        [DisplayName("Gênero")]
        public string? Genero { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório.")]
        [Range(70, 600, ErrorMessage = "A {0} deve ser entre 30 e 600 minutos.")]
        [DisplayName("Duração")]
        public int Duracao { get; set; }
    }
}
