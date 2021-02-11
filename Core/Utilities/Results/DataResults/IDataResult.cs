using Core.Results.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.DataResults
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
