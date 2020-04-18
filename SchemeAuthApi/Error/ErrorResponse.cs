using System.Collections.Generic;
using System.Text.Json;

namespace SchemeAuthApi.Error
{
    public class ErrorResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> ErrorDetail { get; set; }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this,
                new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}
