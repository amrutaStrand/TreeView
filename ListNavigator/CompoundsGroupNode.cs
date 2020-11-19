using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNavigator
{
    public class CompoundsGroupNode : AbstractDataNode
    {
        public CompoundsGroupNode()
        {
            Name = "CompoundGroups";
            Type = "CompoundGroups";
        }

        public CompoundsGroupNode(string CompoundGroupsName)
        {
            Name = CompoundGroupsName;
            Type = "CompoundGroups";
        }
    }
}
