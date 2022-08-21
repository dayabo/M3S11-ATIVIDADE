namespace ProjetoSemana11Api.Models
{
    public class Cliente
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public CarteiraTrabalho CarteiraTrabalho { get; set; }
        public List<Exame> Exames{ get; set; }
        public List<ClienteVacina> Vacinas { get; set; }
    }
}
