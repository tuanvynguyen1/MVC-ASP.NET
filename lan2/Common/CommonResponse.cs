using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace lan2.Common
{
    public static class CommonResponse
    {

        /* <summary>
         *  Method Provide simple way to return an JsonData
         * </summary>
         * <param name="statusCode">The status code return to Web App.</param>
         * <param name="message">The Message return to Web App.</param>
         * <param name="Data">Object Data.</param>
         */
        public static ObjectResult objectResult(int statusCode, String message, Object? Data = null) { 
            return new ObjectResult(new
            {
                message = message,
                data = Data
            })
            {
                StatusCode = statusCode,
                ContentTypes = new MediaTypeCollection { "application/json" },
            };

        }
    }
}
