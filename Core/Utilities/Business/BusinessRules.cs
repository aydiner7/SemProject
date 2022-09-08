using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        // İş motorumuz için çoklu method çalıştırabilme tekniği
        
        // params : Run içerisine istenildiği kadar IResult girilebilir.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    // kurala uymayan haberdar edilir.
                    return logic;
                }
            }
            return null;
        }
    }
}
