using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Teste.Estagio.Models;
using Teste.Estagio.Data;

namespace Teste.Estagio.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
   [HttpGet("/animes")]

   public IActionResult Get([FromServices] AppDbContext context)
    => Ok(context.Animes.ToList());
   

   [HttpGet("/animes/{id}")]
   public IActionResult GetById(
      [FromServices] AppDbContext context,
      [FromRoute] int id
   )
   {
      var anime = context.Animes.FirstOrDefault(a => a.Id == id);
      if (anime == null)
      {
         return NotFound();
      }
      return Ok(anime);
   }

   [HttpPost("/animes")]
   public IActionResult Post(
      [FromServices] AppDbContext context,
      [FromBody] AnimeModel anime)
   {
      if (anime == null)
      {
         return BadRequest();
      }
      else if (string.IsNullOrEmpty(anime.Title))
      {
         return BadRequest("Title is required.");
      }
      else if (string.IsNullOrEmpty(anime.Genre))
      {
         return BadRequest("Genre is required.");
      }
      else if (anime.Episodes < 0)
      {
         return BadRequest("Episodes cannot be negative.");
      }
      else if (string.IsNullOrEmpty(anime.Studio))
      {
         return BadRequest("Studio is required.");
      }
      else if (anime.Score < 0.0f || anime.Score > 10.0f)
      {
         return BadRequest("Score must be between 0.0 and 10.0.");
      }


      context.Animes.Add(anime);
      context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = anime.Id }, anime);
   }

   [HttpPut("/animes/{id}")]
   public IActionResult Put(
      [FromServices] AppDbContext context,
      [FromRoute] int id,
      [FromBody] AnimeModel anime 
   )
   {
      var existingAnime = context.Animes.FirstOrDefault(a => a.Id == id);
      if (existingAnime == null)
      {
         return NotFound();
      }

      existingAnime.Title = anime.Title;
      existingAnime.Genre = anime.Genre;
      existingAnime.Episodes = anime.Episodes;
      existingAnime.Studio = anime.Studio;
      existingAnime.Score = anime.Score;
      existingAnime.Watched = anime.Watched;

      context.Animes.Update(existingAnime);
      context.SaveChanges();
      return Ok(existingAnime);
   }

   [HttpDelete("/animes/{id}")]
   public IActionResult Delete(
      [FromServices] AppDbContext context,
      [FromRoute] int id
   )
   {
      var anime = context.Animes.FirstOrDefault(a => a.Id == id);
      if (anime == null)
      {
         return NotFound();
      }

      context.Animes.Remove(anime);
      context.SaveChanges();
      return NoContent();
   }




}
