using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNavigator
{
    public class ClusterNode : AbstractDataNode
    {
        public ClusterNode()
        {
            Name = "Cluster Node";
            Type = "hcsNode";
        }

        public ClusterNode(string ClusterName)
        {
            Name = ClusterName;
            Type = "hcsNode";
        }
    }
}
