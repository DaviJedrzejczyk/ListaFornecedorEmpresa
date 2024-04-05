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
    public class CompanyDAL(ListDbContext listDbContext): ICompanyDAL
    {
        private readonly ListDbContext _db = listDbContext;

        public async Task<Response> Insert(Company company)
        {
            try
            {
                await _db.Companies.AddAsync(company);
                return ResponseFactory.CreateInstance().CreateSuccessResponse("Sucesso ao inserir a empresa!");
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
                Company? existingCompany = (await GetById(company.ID)).Item;

                if (existingCompany == null)
                {
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Empresa não encontrada!");
                }
                UpdateLines(company, existingCompany);

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
                Company? company = (await GetById(id)).Item;

                if (company == null)
                    return ResponseFactory.CreateInstance().CreateFailureResponse("Empresa não encontrada!");

                _db.Remove(company);

                return ResponseFactory.CreateInstance().CreateSuccessResponse("Empresa excluída com sucesso!");
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
                List<Company> companies = await _db.Companies.ToListAsync();
                return ResponseFactory.CreateInstance().CreateSuccessDataResponse(companies);
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
                Company? company = await _db.Companies.FirstOrDefaultAsync(x => x.ID == id);

                if (company == null)
                    return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Company>("Nenhuma empresa encontrada!");

                return ResponseFactory.CreateInstance().CreateSuccessSingleResponse(company);
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailureSingleResponse<Company>(ex);
            }
        }

        private static void UpdateLines(Company company, Company existingCompany)
        {
            existingCompany.UF = company.UF;
            existingCompany.CNPJ = company.CNPJ;
            existingCompany.FantasyName = company.FantasyName;
        }
    }
}
