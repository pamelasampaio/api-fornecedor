using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fornecedorApi.Data;
using fornecedorApi.Models;

namespace fornecedorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public FornecedorsController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedor()
        {
            return await _context.Fornecedor.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            _context.Fornecedor.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }
    }
}
