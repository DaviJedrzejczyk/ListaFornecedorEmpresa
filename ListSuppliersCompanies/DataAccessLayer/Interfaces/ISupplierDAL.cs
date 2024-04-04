using Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ISupplierDAL
    {
        Task<Response> Insert(Supplier supplier);
        Task<Response> Update(Supplier supplier);
        Task<Response> Delete(int id);
        Task<DataResponse<Supplier>> GetAll();
        Task<SingleResponse<Supplier>> GetById(int id);
    }
}
