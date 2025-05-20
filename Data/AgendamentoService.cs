using SistemaDeAgendamentos.Models;
using System.Text.Json;

namespace SistemaDeAgendamentos.Data
{
    public class AgendamentoService
    {
        private readonly string _filePath = "agendamentos.json";

        public List<Agendamento> GetAll()
        {
            if (!File.Exists(_filePath))
                return new List<Agendamento>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Agendamento>>(json) ?? new List<Agendamento>();
        }

        public void SaveAll(List<Agendamento> agendamentos)
        {
            var json = JsonSerializer.Serialize(agendamentos);
            File.WriteAllText(_filePath, json);
        }

        public void Add(Agendamento agendamento)
        {
            var agendamentos = GetAll();
            agendamento.Id = agendamentos.Count > 0 ? agendamentos.Max(a => a.Id) + 1 : 1;
            agendamentos.Add(agendamento);
            SaveAll(agendamentos);
        }

        public void Update(Agendamento agendamento)
        {
            var agendamentos = GetAll();
            var index = agendamentos.FindIndex(a => a.Id == agendamento.Id);
            if (index >= 0)
            {
                agendamentos[index] = agendamento;
                SaveAll(agendamentos);
            }
        }

        public void Delete(int id)
        {
            var agendamentos = GetAll();
            var agendamento = agendamentos.FirstOrDefault(a => a.Id == id);
            if (agendamento != null)
            {
                agendamentos.Remove(agendamento);
                SaveAll(agendamentos);
            }
        }

        public Agendamento? GetById(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);
        }
    }
}
