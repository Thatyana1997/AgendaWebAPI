using AgendaWebAPI.Database;
using AgendaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgendaWebAPI.Controllers
{
    [Route("api/Contactos")]
    [ApiController]
    public class ContactoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactoModel>>> GetAllContacts()
        {
            return await _context.Contactos.ToListAsync();
        }

        // Agregar un nuevo contacto
        [HttpPost]
        public async Task<ActionResult<ContactoModel>> AddContact([FromBody] ContactoModel contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contactos.Add(contact);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetContactById), new { id = contact.IdContacto }, contact);
            }

            return BadRequest(ModelState);
        }

        // Obtener un contacto por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactoModel>> GetContactById(int id)
        {
            var contact = await _context.Contactos.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return contact;
        }

        // Actualizar un contacto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactoModel contact)
        {
            if (id != contact.IdContacto)
            {
                return BadRequest("El ID del contacto no coincide.");
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // Eliminar un contacto
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contactos.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactExists(int id)
        {
            return _context.Contactos.Any(e => e.IdContacto == id);
        }
    }
}
