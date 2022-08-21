namespace ProjetoSemana11Api.Models
{
    // relação de N ,N cliente e vacina
    public class ClienteVacina
    {
        public int ClienteId{ get; set; }
        public int VacinaId { get; set; }
        public DateTime DataAplicacao { get; set; }
        public Cliente Cliente { get; set; }
        public Vacina Vacina{ get; set; }
    }
}
