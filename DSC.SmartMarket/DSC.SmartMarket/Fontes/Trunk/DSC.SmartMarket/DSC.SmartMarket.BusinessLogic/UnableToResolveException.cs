using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSC.SmartMarket.BusinessLogic
{
    public class UnableToResolveException : NullReferenceException
    {
        public UnableToResolveException(string message) : base(message)
        {
        }
    }
}
