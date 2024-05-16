using API_Navarro.Context;
using API_Navarro.DTO;
using API_Navarro.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API_Navarro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ClientesController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return _dataContext.Cliente.ToList();
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _dataContext.Cliente.FirstOrDefault(x => x.ClienteId == id);
            if (cliente == null)
            {
                return BadRequest("ID não existente");
            }
            return cliente;
        }

        // POST api/<ClientesController>
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] ClienteRequest clienteRequest)
        {
            if (ModelState.IsValid)
            {
                var cliente = clienteRequest.toModel();
                _dataContext.Cliente.Add(cliente);
                _dataContext.SaveChanges();
                return cliente;
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

