using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    internal interface IDTO
    {
        public double MaximumUnbalanceCurrent();
        public double DTOTriggerSetpoint();
    }
}
