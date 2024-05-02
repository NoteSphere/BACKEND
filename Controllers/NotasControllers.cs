using BACKEND.Data;
using BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BACKEND.Controllers{
[Route("api/[controller]")]//api/cstegorias/
[ApiController]
//simplifica la creacion de controladores API REsTful

public class NotasController : ControllerBase
{
    private readonly NotasContext _contex;
    public NotasController(NotasContext contex)
    {
        _contex = contex;
    }
    [HttpGet]
    public async Task <ActionResult<IEnumerable<Nota>>> GetNota()
    {
        return await _contex.Notas.ToListAsync();
    }
    //detalle
    [HttpGet("{id}")]
    public async Task<ActionResult<Nota>> GetNota(int id)
    {
        var Nota = await _contex.Notas.FindAsync(id);
        if (Nota == null)
        {
            return NotFound();
        }
        return Nota;
    }
    //crear
    [HttpPost]
    public async Task<ActionResult<Nota>> PostCategoria(Nota nota)
    {
        nota.Fecha = DateTime.Now;
        _contex.Notas.Add(nota);
        await _contex.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNota), new { id = nota.Id }, nota);
    }
    //eliminar
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNota(int id)
    {
        var nota = await _contex.Notas.FindAsync(id);
        if (nota == null)
        {
            return NotFound();
        }
        _contex.Notas.Remove(nota);
        await _contex.SaveChangesAsync();
        return NoContent();
    }
      //actualizar
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(int id, Nota nota)
    {
        if (id!= nota.Id)
        {
            return BadRequest();
        }
        _contex.Entry(nota).State = EntityState.Modified;
        await _contex.SaveChangesAsync();
        return NoContent();
    }

}
}