using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;

    public EventosController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Eventos> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Eventos GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(
            e => e.EventoId == id)!;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Eventos eventos)
    {
        _context.Eventos.Add(eventos);
        await _context.SaveChangesAsync();

        return Ok(eventos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Eventos eventos)
    {
        if (eventos.EventoId == id)
        {
            _context.Entry(eventos).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Ok(eventos);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var evento = await _context.Eventos.FindAsync(id);

        _context.Eventos.Remove(evento);
        await _context.SaveChangesAsync();

        return Ok(evento);
    }
}