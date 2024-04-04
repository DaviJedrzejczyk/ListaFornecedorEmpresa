using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Shared.ResponseFactory;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implements
{
    public class SupplierDAL(ListDbContext listDbContext) : ISupplierDAL
    {
        private readonly ListDbContext _db = listDbContext;

        public async Task<Response> Insert(Supplier supplier)
        {
            try
            {
                await _db.Suppliers.AddAsync(supplier);
                return ResponseFactory.CreateInstance().CreateSuccessResponse("Sucesso ao inserir o fornecedor no sistema!");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Update(Supplier supplier)
        {
            try
            {
                Supplier? existingSupplier = (await GetById(supplier.ID)).Item; ;

                if (existingSupplier == null)
                {
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Fornecedor não encontrado!");
                }

                existingSupplier = supplier;

                return ResponseFactory.CreateInstance().CreateSuccessResponse("Edição efetuada com sucesso!");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Delete(int id)
        {
            try
            {
                Supplier? supplier = (await GetById(id)).Item;

                if (supplier == null)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Fornecedor não encontrado!");

                _db.Remove(supplier);

                return ResponseFactory.CreateInstance().CreateSuccessResponse("Fornecedor excluído com sucesso!");
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<DataResponse<Supplier>> GetAll()
        {
            try
            {
                List<Supplier> suppliers = await _db.Suppliers.ToListAsync();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(suppliers);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Supplier>(ex);
            }
        }

        public async Task<SingleResponse<Supplier>> GetById(int id)
        {
            try
            {
                Supplier? supplier = await _db.Suppliers.FirstOrDefaultAsync(x => x.ID == id);

                if (supplier == null)
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>("Nenhum fornecedor encontrado!");

                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(supplier);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>(ex);
            }
        }

       
    }
}
