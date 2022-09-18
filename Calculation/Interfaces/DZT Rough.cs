using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    internal interface DZT_Rough
    {
        public double DZTMinimumInitialCurrent { get; set; }
        public double InitialCurrent();
        public double InitialCurrent_1_5();
        public double SecondDecelerationCoefficient();
        public double DetuningMaximumUnbalanceCurrent();
        public double ThirdDecelerationCoefficient();
        public bool SensitivityCoefficient();
    }
}
