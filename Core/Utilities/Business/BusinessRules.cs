using Core.Results.Utilities;
using Core.Utilities.Results.DataResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if(logic.Success == false)
                {
                    return logic;
                }
                
            }
            return null;
        }
    }
}
