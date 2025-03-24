using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Api.Command.DtoOut
{
    public class ResultDto<T>
    {
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public T Obj { get; set; }

        public ResultDto(int resultCode, string resultMessage, T obj)
        {
            ResultCode = resultCode;
            ResultMessage = resultMessage;
            Obj = obj;
        }
    }
}
