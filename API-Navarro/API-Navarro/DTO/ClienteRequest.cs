using API_Navarro.Model;
using System.ComponentModel.DataAnnotations;

namespace API_Navarro.DTO
{
    public class ClienteRequest
    {
        [MinLength(2)]
        public string Nome { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public Cliente toModel()
            => new Cliente(Nome);
    }
}
