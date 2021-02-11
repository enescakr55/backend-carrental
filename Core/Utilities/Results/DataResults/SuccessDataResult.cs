using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.DataResults
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }
        public SuccessDataResult() : base(default, true)
        {

        }
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
    }
}
