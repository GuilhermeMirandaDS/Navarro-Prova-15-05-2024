using API_Navarro.Context;
using API_Navarro.DTO;
using API_Navarro.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_Navarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly DataContext _dataContext;

    public EnderecoController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<EnderecoController>
        [HttpGet]
        public ActionResult<List<Endereco>> Get()
        {
            var enderecos = _dataContext.Endereco.ToList<Endereco>();
            return enderecos;
        }

        // GET api/<EnderecoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EnderecoController>
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

        // PUT api/<EnderecoController>/5
        [HttpPut]
        public ActionResult<Endereco> Put([FromBody] Endereco endereco)
        {
            var enderecoENulo = _dataContext.Endereco.FirstOrDefault(endereco) == null;
            if (enderecoENulo)
                ModelState.AddModelError("EnderecoId", "Id do endereco não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Endereco.Update(endereco);
                _dataContext.SaveChanges();
                return endereco;
            }
            return BadRequest(ModelState);

        }

        // DELETE api/EnderecoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var endereco = _dataContext.Endereco.Find(id);
            if (endereco == null)
                ModelState.AddModelError("EnderecoId", "Id do endereco não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Endereco.Remove(endereco);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}