using API_Navarro.Context;
using API_Navarro.DTO;
using API_Navarro.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Navarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {

        private readonly DataContext _dataContext;

        //public EnderecosController()
        //{
        //    _dataContext = new DataContext();
        //}

        // GET: api/<EnderecosController>
        [HttpGet]
        public ActionResult<List<Endereco>> Get()
        {
            return _dataContext.Endereco.ToList();

        }

        // GET api/<EnderecosController>/5
        [HttpGet("{id}")]
        public ActionResult<Endereco> Get(int id)
        {
            var endereco = _dataContext.Endereco.FirstOrDefault(x => x.EnderecoId == id);
            if (endereco == null)
            {
                return BadRequest("ID não existente");
            }
            return endereco;
        }

        // POST api/<EnderecosController>
        [HttpPost]
        public ActionResult<Endereco> Post([FromBody] EnderecoRequest enderecoRequest)
        {
            if (ModelState.IsValid)
            {
                var endereco = enderecoRequest.toModel();
                _dataContext.Endereco.Add(endereco);
                _dataContext.SaveChanges();
                return endereco;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<EnderecosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EnderecosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}

