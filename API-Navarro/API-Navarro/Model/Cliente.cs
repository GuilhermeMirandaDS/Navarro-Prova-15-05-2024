using System.ComponentModel.DataAnnotations;

namespace API_Navarro.Model
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public List<Endereco> Enderecos {  get; set; }

        public Cliente(string nome) 
        {
            Nome = nome;
        }
    }
}
