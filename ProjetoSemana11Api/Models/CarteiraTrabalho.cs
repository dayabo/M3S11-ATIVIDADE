namespace ProjetoSemana11Api.Models
{
    // relação de 1 ,1 cliente e carteira de trabalho
    public class CarteiraTrabalho
    {
        public int Id { get; set; }
        public string  PisPassep { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
