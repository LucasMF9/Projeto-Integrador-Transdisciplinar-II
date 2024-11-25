using SistemaDeControleDeEstacionamento.Data;
using SistemaSimplesDeEstacionamento.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeControleDeEstacionamento.Repositorio
{
    public class EstacionamentoRepositorio : IEstacionamentoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public EstacionamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<EstacionamentoModel> BuscarTodos()
        {
            return _bancoContext.Estacionamento.ToList();
        }
        public EstacionamentoModel ListarPorId(int id)
        {
            return _bancoContext.Estacionamento.FirstOrDefault(b => b.Id == id);
        }
        public IEnumerable<EstacionamentoModel> Pesquisar(string nomeProprietario, string marcaModelo, string placa)
        {
            var estacionamento = new EstacionamentoModel();
            var query = _bancoContext.Estacionamento.AsQueryable();

            if (!string.IsNullOrEmpty(nomeProprietario))
            {
                query = query.Where(e => e.NomeProprietario.Contains(nomeProprietario));
            }
            if (!string.IsNullOrEmpty(marcaModelo))
            {
                query = query.Where(e => e.MarcaModelo.Contains(marcaModelo));
            }
            if (!string.IsNullOrEmpty(placa))
            {
                query = query.Where(e => e.Placa.Contains(placa));
            }
            estacionamento.NomeProprietario = nomeProprietario;
            estacionamento.MarcaModelo = marcaModelo;
            estacionamento.Placa = placa;

            return query.ToList();
        }
        public EstacionamentoModel Editar(EstacionamentoModel estacionamento)
        {
            EstacionamentoModel estacionamentoDb = ListarPorId(estacionamento.Id);

            if (estacionamentoDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do item da lista");
            }

            estacionamentoDb.NomeProprietario = estacionamento.NomeProprietario;
            estacionamentoDb.MarcaModelo = estacionamento.MarcaModelo;
            estacionamentoDb.Cor = estacionamento.Cor;
            estacionamentoDb.Placa = estacionamento.Placa;
            estacionamentoDb.Vaga = estacionamento.Vaga;

            _bancoContext.Estacionamento.Update(estacionamentoDb);
            _bancoContext.SaveChanges();

            return estacionamentoDb;
        }
        public EstacionamentoModel Adicionar(EstacionamentoModel estacionamento)
        {
            _bancoContext.Estacionamento.Add(estacionamento);
            _bancoContext.SaveChanges();
            return estacionamento;
        }

        public bool Apagar(int id)
        {
            EstacionamentoModel estacionamentoDb = ListarPorId(id);

            if (estacionamentoDb == null)
            {
                throw new System.Exception("Houve um erro ao excluir o veículo");
            }
            _bancoContext.Estacionamento.Remove(estacionamentoDb);
            _bancoContext.SaveChanges();
            return true;
        }

    }
}
