using System.ComponentModel.DataAnnotations;

namespace SistemaSimplesDeEstacionamento.Models
{
    public class EstacionamentoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do proprietário!")]
        public string NomeProprietario { get; set; }

        [Required(ErrorMessage = "Digite a marca e o modelo do veículo!")]
        public string MarcaModelo { get; set; }

        [Required(ErrorMessage = "Digite a cor do veículo!")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Digite a placa do veículo!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Digite a vaga para o veiculo!")]
        public string  Vaga { get; set; }

    }
}
