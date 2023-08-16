using IDGS903_Api.Context;
using IDGS903_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace IDGS903_Api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class PedidoController : Controller
        {
            private readonly AppDbContext _context;
            public PedidoController(AppDbContext context)
            {
                _context = context;
            }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.pedido.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
            public ActionResult<Pedido> Post([FromBody] Pedido pedido)
            {
                try
                {
                    //Console.WriteLine(pedido);

                    // Do not set pedido.Id explicitly

                    _context.pedido.Add(pedido);
                    _context.SaveChanges();

                    return  CreatedAtRoute("Pedido", new { id = pedido.Id }, pedido);
                }
                catch (Exception ex)
                {
                return BadRequest(ex.Message);
            }
            }

        }
    }
