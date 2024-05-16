using System.ComponentModel.DataAnnotations;

namespace API_Navarro.Model
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public int ClienteId { get; set; }
        public Endereco(string rua, int clienteId) 
        {
            Rua = rua;
            ClienteId = clienteId;
        }
    }
}
