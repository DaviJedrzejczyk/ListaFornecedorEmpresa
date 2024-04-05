using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;


        public CompanyController(ICompanyService svc, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyService = svc;
        }

        [HttpGet("AllCompanys")]
        public IActionResult Index()
        {

            return Ok();
        }

        [HttpPost("InsertCompany")]
        public IActionResult Insert() { return Ok(); }

        [HttpGet]
        public IActionResult InsertCompany()
        {
            return Ok();
        }

        [HttpGet("EditCompany")]
        public IActionResult UpdateCompany()
        {
            return Ok();
        }

        [HttpPut("EditCompany")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet("DeleteCompany")]
        public IActionResult DeleteCompany()
        {
            return Ok();
        }

        [HttpDelete("DeleteCompany")]
        public IActionResult Delete() { return Ok(); }
    }
}
