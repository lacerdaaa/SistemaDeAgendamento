namespace SistemaDeAgendamentos.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public string Servico { get; set; }
        public DateTime DataHora { get; set; }
    }
}
