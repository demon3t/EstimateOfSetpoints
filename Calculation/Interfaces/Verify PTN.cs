using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    internal interface IVerify_PTN
    {
        public bool VerifyPTNHigth();
        public bool? VerifyPTNMedium();
        public bool VerifyPTNLower();
    }
}
