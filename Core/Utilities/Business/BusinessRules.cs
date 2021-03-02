using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] ligics)
        {
            foreach (IResult logic in ligics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
