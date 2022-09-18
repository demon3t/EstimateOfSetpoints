using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    public interface IDZT
    {
        public double Rought_InitialCurrent();
        public double Rought_InitialCurrent_1_5();
        public double Rought_SecondDecelerationCoefficient();
        public double Rought_MaxiBrakingCurrent();
        public double Rought_ThirdDecelerationCoefficient();


        public double Sensitive_InitialCurrent();
        public double Sensitive_InitialCurrent_1_5();
        public double Sensitive_SecondDecelerationCoefficient();
        public double Sensitive_MaxUnbalanceCurrent();
        public double Sensitive_ThirdDecelerationCoefficient();
    }
}
