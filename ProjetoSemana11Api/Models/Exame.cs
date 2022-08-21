namespace ProjetoSemana11Api.Models
{
    public class Exame
    {
        // relação de 1 ,N cliente e vacina
        public int Id { get; set; }
        public string CodigoTuss { get; set; }
        public DateTime DataAgendamento { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
