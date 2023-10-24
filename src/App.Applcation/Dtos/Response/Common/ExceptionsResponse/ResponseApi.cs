using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Applcation.Dtos.Response.Common
{
    public class ResponseApi<TData>:BaseResponse
    {
        public ResponseApi(int code=200):base(code)
        {
            
        }
        public string message { get; set; }
        public TData Data { get; set; }
        public static ResponseApi<TData> Response(               
                TData value, 
                string message,
                int code
             )
        {
            return new ResponseApi<TData>() { Data = value, message = message,status=code };
        }
    }
    
}
