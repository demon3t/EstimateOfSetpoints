using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    public interface IDTO
    {
        public double MaximumUnbalanceCurrent();
        public double DTOTriggerSetpoint();
    }
}
