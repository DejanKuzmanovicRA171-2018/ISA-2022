using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Exceptions
{
    public class BusinessException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public BusinessException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
