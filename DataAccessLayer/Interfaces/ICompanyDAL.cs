using Entities;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICompanyDAL
    {
        Task<Response> Insert(Company company);
        Task<Response> Update(Company company);
        Task<Response> Delete(int id);
        Task<DataResponse<Company>> GetAll();
        Task<SingleResponse<Company>> GetById(int id);
    }
}
