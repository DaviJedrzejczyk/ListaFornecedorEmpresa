using AutoMapper;
using BusinessLogicalLayer.Implements;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using WebApi.Models.SupplierModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Supplier")]
    public class SupplierController : Controller
    {
        private readonly IMapper _mapper;
        private ISupplierService _supplierService;
        private ICompanyService _companyService;

        public SupplierController(ISupplierService supplierService, IMapper mapper, ICompanyService companyService)
        {
            this._supplierService = supplierService;
            this._mapper = mapper;
            this._companyService = companyService;
        }


        [HttpGet("AllSuppliers")]
        public async Task<IActionResult> Index()
        {
            DataResponse<Supplier> response = await _supplierService.GetAll();
            if (response.HasSuccess)
            {
                List<SupplierListViewModel> model = _mapper.Map<List<SupplierListViewModel>>(response.Items);
                return Ok(model);
            }

            return BadRequest(response);
        }

        [HttpPost("InsertSupplier")]
        public async Task<IActionResult> InsertSupplier(SupplierInsertViewModel model)
        {
            Supplier supplier = _mapper.Map<Supplier>(model);

            Response response = await _supplierService.Insert(supplier);

            if (!response.HasSuccess) { return BadRequest(response.Message); }

            return Ok(response);
        }

        [HttpGet("InsertSupplier")]
        public async Task<IActionResult> InsertSupplier()
        {
            DataResponse<Company> response = await _companyService.GetAll();
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response.Items);
        }

        [HttpGet("EditSupplier")]
        public async Task<IActionResult> UpdateSupplier(int id)
        {
            SingleResponse<Supplier> response = await _supplierService.GetById(id);

            if (response.HasSuccess)
            {
                SupplierEditViewModel supplierEditViewModel = _mapper.Map<SupplierEditViewModel>(response.Item);
                return Ok(supplierEditViewModel);
            }

            return BadRequest(response);
        }

        [HttpPut("EditSupplier")]
        public async Task<IActionResult> UpdateSupplier(SupplierEditViewModel supplierEditViewModel)
        {
            Supplier supplier = _mapper.Map<Supplier>(supplierEditViewModel);

            Response response = await _supplierService.Update(supplier);

            if (!response.HasSuccess) { return BadRequest(response); }

            return Ok(response);
        }

        [HttpDelete("DeleteSupplier")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            Response response = await _supplierService.Delete(id);

            if (!response.HasSuccess) { return BadRequest(response); }
            
            return Ok(response);
        }
    }
}
