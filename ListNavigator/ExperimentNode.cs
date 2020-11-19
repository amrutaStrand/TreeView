using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNavigator
{
    public class ExperimentNode : AbstractDataNode
    {
        public ExperimentNode()
        {
            Name = "MyExperiment";
            Type = "Experiment";
        }

        public ExperimentNode(string expName)
        {
            Name = expName;
            Type = "Experiment";
        }
    }
}
