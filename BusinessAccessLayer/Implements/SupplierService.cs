using BusinessLogicalLayer.Constants.Supplier;
using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Validators.CommonsValidators;
using BusinessLogicalLayer.Validators.SupplierValidators;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;
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
                supplier.Company = GetCompany(supplier.CompanyId).Result.Item;

                Response response = ValidateFields(supplier);

                if (response.HasSuccess)
                {
                    response = new SupplierInsertValidator().Validate(supplier).ConvertToResponse();
                    if (response.HasSuccess)
                    {
                        supplier.InsertDate = DateTime.Now;

                        response = await _unityOfWork.SupplierDAL.Insert(supplier);
                        if (response.HasSuccess)
                        {
                            await _unityOfWork.Commit();
                            return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                        }
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
                supplier.Company = (await _unityOfWork.CompanyDAL.GetById(supplier.CompanyId)).Item;
                Response response = ValidateFields(supplier);

                if (response.HasSuccess)
                {
                    response = new SupplierEditValidator().Validate(supplier).ConvertToResponse();
                    if (response.HasSuccess)
                    {
                        response = await _unityOfWork.SupplierDAL.Update(supplier);
                        if (response.HasSuccess)
                        {
                            await _unityOfWork.Commit();
                            return ResponseFactory.CreateInstance().CreateSuccessResponse(response.Message);
                        }
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

                    return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(single.Item);
                }
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>(SupplierConstants.ERROR_MESSAGE_INVALID_ID);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Supplier>(ex);
            }
        }

        private async Task<SingleResponse<Company>> GetCompany(int id)
        {
            try
            {
                return await _unityOfWork.CompanyDAL.GetById(id);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Company>(ex);
            }
        }

        private Response ValidateFields(Supplier supplier)
        {
            if (ValidateCnpj(supplier.CNPJ) && ValidateCPF(supplier.CPF))
                return ResponseFactory.CreateInstance().CreateFailureResponse(SupplierConstants.ERROR_CPF_AND_CNPJ_NOT_EMPTY);

            if (!ValidateRG(supplier.RG, supplier.CPF))
                return ResponseFactory.CreateInstance().CreateFailureResponse(SupplierConstants.ERROR_RG_EMPTY);

            if(!VerifyRgAndCnpjInSameInsert(supplier.RG, supplier.CNPJ))
                return ResponseFactory.CreateInstance().CreateFailureResponse(SupplierConstants.ERROR_RG_AND_CNPJ_NOT_EMPTY);

            if (!VerifyAgeAndState(supplier.CPF, supplier.BirthDate, supplier.Company.UF))
                return ResponseFactory.CreateInstance().CreateFailureResponse(SupplierConstants.ERROR_MESSAGE_INVALID_AGE);


            return ResponseFactory.CreateInstance().CreateSuccessResponse();
        }


        private bool VerifyAgeAndState(string? cpf, DateTime? age, BrasilianEstates state)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                if (ValidateDateBirth(age.Value) || BrasilianEstates.PR == state)
                {
                    return true;
                }
                else if (state != BrasilianEstates.PR)
                {
                    return true;
                }
                return false;
            }

            return true;
        }

        private bool ValidateDateBirth(DateTime date)
        {
            DateTime actualDate = DateTime.Today;
            int age = actualDate.Year - date.Year;

            if (date.Date > actualDate.AddYears(-age))
                age--;

            return age >= 18;
        }

        private bool ValidateCnpj(string? cnpj)
        {
            if (!string.IsNullOrWhiteSpace(cnpj))
                return CnpjValidator.ValidateCnpj(cnpj);

            return false;
        }

        private bool ValidateCPF(string? cpf)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
                return CpfValidator.ValidateCpf(cpf);

            return false;
        }

        private bool ValidateRG(string? rg, string? cpf)
        {
            if (string.IsNullOrWhiteSpace(rg) && !string.IsNullOrWhiteSpace(cpf))
                return false;

            return true;
        }

        private bool VerifyRgAndCnpjInSameInsert(string? rg, string? cnpj)
        {
            if (!string.IsNullOrWhiteSpace(rg) && !string.IsNullOrWhiteSpace(cnpj))
                return false;

            return true;
        }
      
    }
}
