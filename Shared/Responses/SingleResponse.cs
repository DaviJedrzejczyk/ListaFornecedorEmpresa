using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class SingleResponse<T> : Response
    {
        public T Item { get; set; }

        public SingleResponse() { }

        public SingleResponse(string message, bool hasSuccess, Exception exception, T item) : base(message, hasSuccess, exception) => this.Item = item;
    }
}
