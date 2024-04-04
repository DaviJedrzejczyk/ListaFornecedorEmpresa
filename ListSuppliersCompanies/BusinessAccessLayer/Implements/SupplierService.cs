using BusinessLogicalLayer.Constants.Supplier;
using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.SupplierValidators;
using DataAccessLayer.Interfaces;
using Entities;
using Shared.ResponseFactory;
using Shared.Responses;

namespace BusinessLogicalLayer.Implements
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnityOfWork _unityOfWork;

        public SupplierService(IUnityOfWork unityOfWork)
        {
            this._unityOfWork = unityOfWork;
        }

        public async Task<Response> Insert(Supplier supplier)
        {
            try
            {

                Response response = new SupplierValidator().Validate(supplier).ConvertToResponse();
                if (response.HasSuccess)
                {
                    response = await _unityOfWork.SupplierDAL.Insert(supplier);
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

        public async Task<Response> Update(Supplier supplier)
        {
            try
            {

                Response response = new SupplierValidator().Validate(supplier).ConvertToResponse();
                if (response.HasSuccess)
                {
                    response = await _unityOfWork.SupplierDAL.Update(supplier);
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
                    Response response = await _unityOfWork.SupplierDAL.Delete(id);
                    if (response.HasSuccess)
                    {
                        await _unityOfWork.Commit();
                        return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                    }
                }
                return ResponseFactory.CreateInstance().CreateFailureResponse(SupplierConstants.ERROR_MESSAGE_INVALID_ID);
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
                DataResponse<Supplier> data = await _unityOfWork.SupplierDAL.GetAll();
                if (data.HasSuccess)
                {
                    return ResponseFactory.CreateInstance().CreateSuccessDataResponse<Supplier>(data.Items);
                }
                return ResponseFactory.CreateInstance().CreateFailureDataResponse<Supplier>(data.Message);
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
                if (id >= 0)
                {
                    SingleResponse<Supplier> single = await _unityOfWork.SupplierDAL.GetById(id);

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse<Supplier>(single.Item);
                }
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>(SupplierConstants.ERROR_MESSAGE_INVALID_ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>(ex);
            }
        }

    }
}
