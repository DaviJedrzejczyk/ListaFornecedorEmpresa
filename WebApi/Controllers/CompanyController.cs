using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using WebApi.Models.CompanyModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Company/")]
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
        public async Task<IActionResult> Index()
        {
            DataResponse<Company> response = await _companyService.GetAll();

            if (!response.HasSuccess) { return BadRequest(response.Message); }

            List<CompanyListViewModel> result = _mapper.Map<List<CompanyListViewModel>>(response.Items);

            return Ok(result);
        }

        [HttpPost("InsertCompany")]
        public async Task<IActionResult> InsertCompany(CompanyInsertViewModel companyInsertView)
        {
            Company company = _mapper.Map<Company>(companyInsertView);
            
            Response response = await _companyService.Insert(company);
            
            if (!response.HasSuccess) { return BadRequest(response.Message); }

            return Ok(response);
        }

        [HttpGet]
        public IActionResult InsertCompany()
        {
            return Ok();
        }

        [HttpGet("EditCompany")]
        public async Task<IActionResult> UpdateCompany(int id)
        {
            SingleResponse<Company> single = await _companyService.GetById(id);
            
            if (!single.HasSuccess) { return BadRequest(single.Message); }

            CompanyEditViewModel companyEditViewModel = _mapper.Map<CompanyEditViewModel>(single.Item);

            return Ok(companyEditViewModel);
        }

        [HttpPut("EditCompany")]
        public async Task<IActionResult> UpdateCompany(CompanyEditViewModel companyEditViewModel)
        {
            Company company = _mapper.Map<Company>(companyEditViewModel);

            Response response = await _companyService.Update(company);

            if (!response.HasSuccess) { return BadRequest(response); }

            return Ok(response);
        }

        [HttpDelete("DeleteCompany")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            Response response = await _companyService.Delete(id);

            if (!response.HasSuccess) { return BadRequest(response); }

            return Ok(response);
        }

    }
}
