using FluentValidation.Results;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Extensions
{
    internal static class ResponseExtensions
    {
        public static Response ConvertToResponse(this ValidationResult result)
        {
            Response response = new();
            if (result.IsValid)
            {
                response.HasSuccess = true;
                response.Message = "Operação efetuada com sucesso.";
                return response;
            }

            StringBuilder builder = new();
            foreach (ValidationFailure fail in result.Errors)
            {
                builder.AppendLine(fail.ErrorMessage);
            }

            response.HasSuccess = false;
            response.Message = builder.ToString();
            return response;
        }
    }
}
