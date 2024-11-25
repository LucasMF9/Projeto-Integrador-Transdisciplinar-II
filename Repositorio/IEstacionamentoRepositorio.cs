using SistemaSimplesDeEstacionamento.Models;
using System.Collections.Generic;

namespace SistemaDeControleDeEstacionamento.Repositorio
{
    public interface IEstacionamentoRepositorio
    {
        EstacionamentoModel ListarPorId(int id);
        List<EstacionamentoModel> BuscarTodos();
        EstacionamentoModel Adicionar(EstacionamentoModel estacionamento);
        EstacionamentoModel Editar(EstacionamentoModel estacionamento);
        bool Apagar(int id);
        IEnumerable<EstacionamentoModel> Pesquisar(string nomeProprietario, string marcaModelo, string placa);
    }
}
