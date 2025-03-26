using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
        new Evento(){
            EventoId = 1,
            Tema = "Angular e .NET Core",
            Local = "BH",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyy"),
            ImagemUrl = "image.png"
            },
            new Evento(){
            EventoId = 2,
            Tema = "Angular",
            Local = "ES",
            Lote = "2º Lote",
            QtdPessoas = 350,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyy"),
            ImagemUrl = "image2.png"
            },
    };

    public EventoController()
    {
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(e => e.EventoId == id);
    }

    [HttpPost]
    public string Post()
    {
        return "exemplo de post";
    }

    [HttpDelete]
    public string Delete()
    {
        return "exemplo de delete";
    }
}
