using Shared.Constants;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ResponseFactory
{
    public class ResponseFactory
    {
        private static ResponseFactory? _factory;

        public static ResponseFactory CreateInstance()
        {
            _factory ??= new ResponseFactory();
            return _factory;
        }
        public Response CreateSuccessResponse() => new()
        {
            HasSuccess = true,
            Message = ResponseConstants.SUCCESS_MESSAGE
        };
        public Response CreateSuccessResponse(string message) => new()
        {
            HasSuccess = true,
            Message = message
        };

        public Response CreateFailureResponse() => new()
        {
            HasSuccess = false,
            Message = ResponseConstants.FAILURE_MESSAGE
        };
        public Response CreateFailureResponse(string message) => new()
        {
            HasSuccess = false,
            Message = message
        };
        public Response CreateFailureResponse(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ex.Message,
            Exception = ex
        };
        public SingleResponse<T> CreateSuccessSingleResponse<T>(T item) => new()
        {
            HasSuccess = true,
            Message = ResponseConstants.SUCCESS_MESSAGE,
            Item = item
        };
        public SingleResponse<T> CreateFailureSingleResponse<T>() => new()
        {
            HasSuccess = false,
            Message = ResponseConstants.FAILURE_MESSAGE,
        };

        public SingleResponse<T> CreateFailureSingleResponse<T>(string message) => new()
        {
            HasSuccess = false,
            Message = message
        };

        public SingleResponse<T> CreateFailureSingleResponse<T>(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ResponseConstants.FAILURE_MESSAGE,
            Exception = ex
        };
        public DataResponse<T> CreateSuccessDataResponse<T>(List<T> dados) => new()
        {
            HasSuccess = true,
            Message = ResponseConstants.SUCCESS_MESSAGE,
            Items = dados,
        };
        public DataResponse<T> CreateFailureDataResponse<T>() => new()
        {
            HasSuccess = false,
            Message = ResponseConstants.FAILURE_MESSAGE,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(string message) => new()
        {
            HasSuccess = false,
            Message = message,
        };
        public DataResponse<T> CreateFailureDataResponse<T>(Exception ex) => new()
        {
            HasSuccess = false,
            Message = ResponseConstants.FAILURE_MESSAGE,
            Exception = ex
        };
    }
}
