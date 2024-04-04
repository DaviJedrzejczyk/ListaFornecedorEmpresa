using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class DataResponse<T> : Response
    {

        public DataResponse(string message, bool hasSuccess, Exception exception, List<T> items) : base(message, hasSuccess, exception) => Items = items;
        public DataResponse()
        {

        }

        public List<T> Items { get; set; }
    }
}
