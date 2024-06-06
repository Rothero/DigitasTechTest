using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler
{
    public  class ResponseBase
    {
        public int StatusCode {  get; set; }
        public string Title {  get; set; }
        public dynamic Result { get; set; }

    }
}
