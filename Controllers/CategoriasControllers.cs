using BACKEND.Data;
using BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace BACKEND.Controllers{
[Route("api/[controller]")]//api/cstegorias/
[ApiController]
//simplifica la creacion de controladores API REsTful

public class CategoriasController : ControllerBase
{
    private readonly NotasContext _contex;
    public CategoriasController(NotasContext contex)
    {
        _contex = contex;
    }
    [HttpGet]
    public async Task <ActionResult<IEnumerable<Categoria>>> GetCategorias()
    {
        return await _contex.Categorias.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetCategoria(int id)
    {
        var categoria = await _contex.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return categoria;
    }
    //crear
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
    {
        _contex.Categorias.Add(categoria);
        await _contex.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategoria), new { id = categoria.Id }, categoria);
    }
    //eliminar
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await _contex.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }
        _contex.Categorias.Remove(categoria);
        await _contex.SaveChangesAsync();
        return NoContent();
    }
    //actualizar
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
    {
        if (id!= categoria.Id)
        {
            return BadRequest();
        }
        _contex.Entry(categoria).State = EntityState.Modified;
        await _contex.SaveChangesAsync();
        return NoContent();
    }
}
}