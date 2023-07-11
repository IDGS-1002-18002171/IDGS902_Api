using IDGS902_Api.Context;
using IDGS902_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS902_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GruposController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.alumnos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "alumnos")]
        public ActionResult Get(int id)
        {
            try
            {
                var alum = _context.alumnos.FirstOrDefault(x => x.Id == id);
                return Ok(alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Alumnos alum)
        {
            try
            {
                _context.alumnos.Add(alum);
                _context.SaveChanges();
                return CreatedAtRoute("alumnos", new { id = alum.Id }, alum);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumnos alum)
        {
            try
            {
                if (alum.Id == id)
                {
                    _context.Entry(alum).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("alumnos", new { id = alum.Id }, alum);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var alum = _context.alumnos.FirstOrDefault(alumnos => alumnos.Id == id);
                if (alum != null)
                {
                    _context.alumnos.Remove(alum);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
