using API_Navarro.Model;
using System.ComponentModel.DataAnnotations;

namespace API_Navarro.DTO
{
    public class ClienteResponse
    {
        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }

        public ClienteResponse(Cliente cliente)
        {
            Nome = cliente.Nome;
            Enderecos = cliente.Enderecos;
        }
    }
}
