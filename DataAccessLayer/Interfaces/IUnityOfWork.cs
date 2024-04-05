using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnityOfWork
    {
        ICompanyDAL CompanyDAL { get; }
        ISupplierDAL SupplierDAL { get; }
        Task<Response> Commit();
    }
}
