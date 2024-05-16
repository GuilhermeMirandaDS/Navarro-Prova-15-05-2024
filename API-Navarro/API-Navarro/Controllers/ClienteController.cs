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
    public class ClienteController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ClienteController()
        {
            _dataContext = new DataContext();
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var clientes = _dataContext.Cliente.ToList();
            return clientes;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
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

        // PUT api/<ClienteController>/5
        [HttpPut]
        public ActionResult<Cliente> Put([FromBody] Cliente cliente)
        {
            var clienteENulo = _dataContext.Cliente.FirstOrDefault(cliente) == null;
            if (clienteENulo)
                ModelState.AddModelError("ClienteId", "Id do cliente não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Cliente.Update(cliente);
                _dataContext.SaveChanges();
                return cliente;
            }
            return BadRequest(ModelState);

        }

        // DELETE api/ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = _dataContext.Cliente.Find(id);
            if (cliente == null)
                ModelState.AddModelError("ClienteId", "Id do cliente não encontrado!");

            if (ModelState.IsValid)
            {
                _dataContext.Cliente.Remove(cliente);
                _dataContext.SaveChanges();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
