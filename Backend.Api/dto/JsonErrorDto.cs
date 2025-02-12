using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.dto
{
    public class JsonErrorDto
    {
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }

        public JsonErrorDto(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}