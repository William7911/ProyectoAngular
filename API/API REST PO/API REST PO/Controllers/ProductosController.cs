using API_REST_PO.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_REST_PO.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductosController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetProductos()
    {
      // Simulamos datos desde el backend por ahora
      var productos = new List<Producto>
            {
                new Producto { Id = 1, Nombre = "Gaseosa 3 Litros", Precio = 15.50m, Disponible = true },
                new Producto { Id = 2, Nombre = "Lata de Frijoles", Precio = 8.00m, Disponible = false }
            };
      return Ok(productos);
    }
  }
}
