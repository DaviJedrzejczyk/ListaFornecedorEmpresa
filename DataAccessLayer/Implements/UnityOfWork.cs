using DataAccessLayer.Interfaces;
using Shared.ResponseFactory;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implements
{
    public class UnityOfWork : IUnityOfWork
    {
        private ICompanyDAL companyDal = null;
        private ISupplierDAL supplierDAL = null;

        private readonly ListDbContext _db;

        public UnityOfWork(ICompanyDAL _companyDal, ISupplierDAL _supplierDAL, ListDbContext listDbContext)
        {
            this.companyDal = _companyDal;
            this.supplierDAL = _supplierDAL;
            this._db = listDbContext;
        }

        public async Task<Response> Commit()
        {
            try
            {
                await _db.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public ICompanyDAL CompanyDAL
        {
            get
            {
                companyDal ??= new CompanyDAL(_db);
                return companyDal;
            }
        }

        public ISupplierDAL SupplierDAL
        {
            get
            {
                supplierDAL ??= new SupplierDAL(_db);
                return supplierDAL;
            }
        }

        public void Dispose() { _db.Dispose(); GC.SuppressFinalize(this); }
    }
}
