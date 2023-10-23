using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class GenericResponseModel<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Response { get; set; }
        public string ValidationResults { get; set; }
        public IEnumerable<T> Datas { get; set; }
   
        public void Success(T data,int statusCode = 200, params string[] Message)
        {
            Data = data;
            StatusCode = statusCode;
            Response = new List<string>(Message);
        }    

        public void Error(int statusCode = 400,params string[] ErrorMessage)
        {
            Data = default(T);
            StatusCode = statusCode;
            Errors = new List<string>(ErrorMessage);
        }

        public void Deleted(int statusCode = 202,params string[] Message)
        {
            StatusCode = statusCode;
            Response = new List<string>(Message);
        }
         public void AllEntities(IEnumerable<T> List,int statusCode = 200, params string[] Message)
         {
            Datas = List;
            StatusCode = statusCode;
            Response = new List<string>(Message);
         }
         public void validationError(string ErrorMessage)
         {
            ValidationResults = ErrorMessage;
         }
    }
}
