using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//using Infragistics.Windows.DataPresenter;

namespace ListNavigator
{
    public class Util
    {
        static public TreeView GetTree(IDataNode RootNode)
        {
            TreeView tree = new TreeView();
            tree.Items.Add(RootNode.GetItem());
            return tree;
        }
    }
}
