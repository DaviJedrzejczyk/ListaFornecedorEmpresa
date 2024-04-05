using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using WebApi.Models.SupplierModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;
    
        public HomeController(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        [HttpGet("Home")]
        public async Task<IActionResult> Index()
        {
            DataResponse<Supplier> response = await supplierService.GetAll();
            if (response.HasSuccess)
            {
                List<SupplierListViewModel> model = mapper.Map<List<SupplierListViewModel>>(response.Items);
                return Ok(model);
            }

            return BadRequest(response);
        }
    }
}
