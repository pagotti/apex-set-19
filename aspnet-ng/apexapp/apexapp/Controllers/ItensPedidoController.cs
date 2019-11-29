using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apexapp.Models;

namespace apexapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoController : ControllerBase
    {
        private readonly ApexAppContext _context;

        public ItensPedidoController(ApexAppContext context)
        {
            _context = context;
        }

        // GET: api/ItensPedido
        [HttpGet]
        public IEnumerable<ItemPedido> GetItensPedido()
        {
            return _context.ItensPedido;
        }

        // GET: api/ItensPedido/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemPedido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemPedido = await _context.ItensPedido.FindAsync(id);

            if (itemPedido == null)
            {
                return NotFound();
            }

            return Ok(itemPedido);
        }

        // PUT: api/ItensPedido/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPedido([FromRoute] int id, [FromBody] ItemPedido itemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemPedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItensPedido
        [HttpPost]
        public async Task<IActionResult> PostItemPedido([FromBody] ItemPedido itemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // buscar o preço do produto que está no item.
            Produto produto = _context.Produtos.Find(itemPedido.ProdutoId);
            itemPedido.Preco = produto.Preco;

            _context.ItensPedido.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPedido", new { id = itemPedido.Id }, itemPedido);
        }

        // DELETE: api/ItensPedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemPedido([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemPedido = await _context.ItensPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItensPedido.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return Ok(itemPedido);
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.Id == id);
        }
    }
}