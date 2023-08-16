using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricacionProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FabricacionProductoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.fabricacionProducto.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}", Name = "fabricacionProucto")]
        public ActionResult Get(int id)
        {
            try
            {

                var fabricacionProducto = _context.fabricacionProducto.FirstOrDefault(x => x.Id == id);

                if (fabricacionProducto == null)
                {
                    return NotFound();
                }
                return Ok(fabricacionProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST 
        [HttpPost]
        public ActionResult<fabricacionProducto> Post([FromBody] fabricacionProducto fabricacion)
        {

            try
            {
                _context.fabricacionProducto.Add(fabricacion);
                _context.SaveChanges();
                return CreatedAtRoute("fabricacionProducto", new { id = fabricacion.Id }, fabricacion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<fabricacion>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] fabricacionProducto fabricacion)
        {
            try
            {
                if (fabricacion.Id == id)
                {
                    _context.Entry(fabricacion).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("fabricacionProducto", new { id = fabricacion.Id }, fabricacion);
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

        // DELETE api/<fabricacion>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var fabricacion = _context.fabricacionProducto.FirstOrDefault(p => p.Id == id);

                if (fabricacion == null)
                {
                    return NotFound();
                }

                _context.fabricacionProducto.Remove(fabricacion);
                _context.SaveChanges();

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
