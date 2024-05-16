using API_Navarro.Model;
using System.ComponentModel.DataAnnotations;

namespace API_Navarro.DTO
{
    public class EnderecoRequest
    {
        [MinLength(1)]
        public string Rua {  get; set; }

        [Required]
        public int ClienteId { get; set; }

        public Endereco toModel()
            => new Endereco(Rua, ClienteId);
    }
}
