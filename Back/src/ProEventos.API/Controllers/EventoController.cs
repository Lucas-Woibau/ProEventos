using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;

    public EventoController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(
            e => e.EventoId == id)!;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento evento)
    {
        _context.Eventos.Add(evento);
        await _context.SaveChangesAsync();

        return Ok(evento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Evento evento)
    {
        if (evento.EventoId == id)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        return Ok(evento);
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