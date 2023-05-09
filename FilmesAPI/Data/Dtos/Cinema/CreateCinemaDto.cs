using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinema
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O {0} é obrigatório.")]
        public string Nome { get; set; }
    }
}
