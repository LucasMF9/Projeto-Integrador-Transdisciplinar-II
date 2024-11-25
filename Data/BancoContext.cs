using Microsoft.EntityFrameworkCore;
using SistemaSimplesDeEstacionamento.Models;

namespace SistemaDeControleDeEstacionamento.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
        {

        }
        public DbSet<EstacionamentoModel> Estacionamento { get; set; }
    }
}
