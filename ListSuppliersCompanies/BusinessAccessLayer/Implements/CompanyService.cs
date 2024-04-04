using BusinessLogicalLayer.Constants.Company;
using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.CompanyValidators;
using DataAccessLayer.Interfaces;
using Entities;
using Shared.ResponseFactory;
using Shared.Responses;

namespace BusinessLogicalLayer.Implements
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnityOfWork _unityOfWork;

        public CompanyService(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public async Task<Response> Insert(Company company)
        {
            try
            {

                Response response = new CompanyInsertValidator().Validate(company).ConvertToResponse();
                if (response.HasSuccess)
                {
                    response = await _unityOfWork.CompanyDAL.Insert(company);
                    if (response.HasSuccess)
                    {
                        await _unityOfWork.Commit();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                    }
                }

                return ResponseFactory.CreateInstance().CreateFailureResponse(response.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<Response> Update(Company company)
        {
            try
            {

                Response response = new CompanyInsertValidator().Validate(company).ConvertToResponse();
                if (response.HasSuccess)
                {
                    response = await _unityOfWork.CompanyDAL.Update(company);
                    if (response.HasSuccess)
                    {
                        await _unityOfWork.Commit();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                    }
                }

                return ResponseFactory.CreateInstance().CreateFailureResponse(response.Message);
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
                if (id >= 0)
                {
                    Response response = await _unityOfWork.CompanyDAL.Delete(id);
                    if (response.HasSuccess)
                    {
                        await _unityOfWork.Commit();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                    }
                }
                return ResponseFactory.CreateInstance().CreateFailureResponse(CompanyConstants.ERROR_MESSAGE_INVALID_ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureResponse(ex);
            }
        }

        public async Task<DataResponse<Company>> GetAll()
        {
            try
            {
                DataResponse<Company> data = await _unityOfWork.CompanyDAL.GetAll();
                if (data.HasSuccess)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessDataResponse<Company>(data.Items);
                }
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Company>(data.Message);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Company>(ex);
            }
        }

        public async Task<SingleResponse<Company>> GetById(int id)
        {
            try
            {
                if (id >= 0)
                {
                    SingleResponse<Company> single = await _unityOfWork.CompanyDAL.GetById(id);

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<Company>(single.Item);
                }
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Company>(CompanyConstants.ERROR_MESSAGE_INVALID_ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Company>(ex);
            }
        }
    }
}
