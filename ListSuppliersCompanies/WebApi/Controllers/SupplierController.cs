using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class SupplierController : Controller
    {
        [HttpGet("AllSuppliers")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost("InsertSupplier")]
        public IActionResult Insert() { return Ok(); }

        [HttpGet]
        public IActionResult InsertCompany()
        {
            return Ok();
        }

        [HttpGet("EditSupplier")]
        public IActionResult UpdateCompany()
        {
            return Ok();
        }

        [HttpPut("EditSupplier")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet("DeleteSupplier")]
        public IActionResult DeleteCompany()
        {
            return Ok();
        }

        [HttpDelete("DeleteSupplier")]
        public IActionResult Delete() { return Ok(); }
    }
}
