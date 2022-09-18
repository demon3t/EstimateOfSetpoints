using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation.Interfaces
{
    internal interface DTO
    {
        public double MaximumUnbalanceCurrent();
        public double BTN { get; set; }
        public double DTOTriggerSetpoint();
    }
}
