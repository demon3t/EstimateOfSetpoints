using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    internal interface Chose_PTN
    {
        public double PTNHigth { get; set; }
        public double PTNMedium { get; set; }
        public double PTNLower { get; set; }

        public bool VerifyPTNHigth();
        public bool VerifyPTNMedium();
        public bool VerifyPTNLower();
    }
}
