using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorBiblioteca.Context;
using BlazorBiblioteca.Shared;

[ApiController]
[Route("api/[controller]")]
public class LibroController : ControllerBase
{
    private readonly LibroDBContext _context;

    public LibroController(LibroDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        return await _context.Libros.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Libro>> AddLibro(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLibros), new { id = libro.Id }, libro);
    }
}
