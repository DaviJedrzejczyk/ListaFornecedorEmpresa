using FluentValidation.Results;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Extensions
{
    internal static class DataResponseExtensions
    {
        public static DataResponse<T> ConvertToDataResponse<T>(this ValidationResult result, List<T> itens)
        {
            DataResponse<T> dataResponse = new();
            if (result.IsValid)
            {
                dataResponse.HasSuccess = true;
                dataResponse.Message = "Operação efetuada com sucesso.";
                dataResponse.Items = itens;
                return dataResponse;
            }

            StringBuilder builder = new();
            foreach (ValidationFailure fail in result.Errors)
            {
                builder.AppendLine(fail.ErrorMessage);
            }

            dataResponse.HasSuccess = false;
            dataResponse.Message = builder.ToString();
            return dataResponse;
        }
    }
}
