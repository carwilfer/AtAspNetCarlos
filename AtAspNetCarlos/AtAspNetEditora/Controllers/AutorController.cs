using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using Repository.Context;

namespace AtAspNetEditora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly EditoraContext _context;

        public AutorController(EditoraContext context)
        {
            _context = context;
        }

        // GET: api/Autor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores()
        {
            return await _context.Autores.Include(x => x.Livros).ToListAsync();
        }

        // GET: api/Autor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autores.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autor/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }
            var autorold = _context.Autores.Find(id);
            autorold.Nome = autor.Nome;
            autorold.Sobrenome = autor.Sobrenome;
            autorold.Email = autor.Email;
            autorold.DataNascimento = autor.DataNascimento;

            _context.Autores.Update(autorold);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autor
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        // DELETE: api/Autor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Autor>> DeleteAutor(int id)
        {
            var autor = await _context.Autores.Include(x => x.Livros).FirstOrDefaultAsync(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    foreach (var item in autor.Livros)
                    {
                        _context.Livros.Remove(item);
                    }
                    _context.Autores.Remove(autor);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            return NoContent();
        }

        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
