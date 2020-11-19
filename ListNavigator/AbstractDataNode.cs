using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Infragistics.Windows.DataPresenter;

namespace ListNavigator
{
    public class AbstractDataNode : IDataNode
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string notes;
        public string hoverText;
        public List<IDataNode> childrens;

        public AbstractDataNode()
        {
            childrens = new List<IDataNode>();
        }

        private TreeViewItem node = new TreeViewItem();

        public TreeViewItem GetItem()
        {
            node.Items.Clear();

            DockPanel dockPanel = new DockPanel();

            //get 'icon' corresponding to the node 'type' from resources and add it to the dockPanel

            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = Name;
            dockPanel.Children.Add(textBlock1);

            node.Header = dockPanel;

            //node.ExpandSubtree();

            foreach (IDataNode child in childrens)
                node.Items.Add(child.GetItem());

            return node;
        }

        public void AddChild(IDataNode node)
        {
            childrens.Add(node);
        }

        public void RemoveChild(IDataNode node)
        {
            childrens.Remove(node);
        }
    }
}
