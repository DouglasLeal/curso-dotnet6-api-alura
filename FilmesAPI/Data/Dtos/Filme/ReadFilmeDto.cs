namespace FilmesAPI.Data.Dtos.Filme
{
    public class ReadFilmeDto
    {
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public int Duração { get; set; }
        public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    }
}
