using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.DataPresenter;
using ListNavigator.Commands;

namespace ListNavigator
{
    public class AbstractDataNode : IDataNode
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }

        public string HoverText { get; set; }

        protected List<IDataNode> childrens;
        protected ToolTip toolTip;
        protected TextBlock textBlock1;

        #region Commands and thier execute methods

        protected ActionCommand IncreaseFont;

        private void IncreaseFontExecute(object p)
        {
            textBlock1.FontSize += 3; 
        }

        protected ActionCommand DecreaseFont;

        private void DecreaseFontExecute(object p)
        {
            textBlock1.FontSize -= 3;
        }

        protected ActionCommand BoldFont;

        private void BoldFontExecute(object p)
        {
            textBlock1.FontWeight = FontWeights.Bold;
        }

        protected ActionCommand NormalFont;

        private void NormalFontExecute(object p)
        {
            textBlock1.FontWeight = FontWeights.Normal;
        }

        #endregion

        public AbstractDataNode()
        {
            IncreaseFont = new ActionCommand(IncreaseFontExecute);
            DecreaseFont = new ActionCommand(DecreaseFontExecute);
            BoldFont = new ActionCommand(BoldFontExecute);
            NormalFont = new ActionCommand(NormalFontExecute);

            childrens = new List<IDataNode>();
            toolTip = new ToolTip();
            textBlock1 = new TextBlock();
            textBlock1.ContextMenu = CreateContextMenu();
        }

        private TreeViewItem node = new TreeViewItem();

        public TreeViewItem GetItem()
        {
            node.Items.Clear();

            DockPanel dockPanel = new DockPanel();

            //get 'icon' corresponding to the node 'type' from resources and add it to the dockPanel
            dockPanel.Children.Add(Util.GetIcon(Type));

            textBlock1.Margin = new System.Windows.Thickness(5);
            textBlock1.Text = Name;
            //textBlock1.MouseRightButtonDown += TextBlock1_MouseRightButtonDown;
            dockPanel.Children.Add(textBlock1);

            node.Header = dockPanel;

            toolTip.Content = HoverText;
            node.ToolTip = toolTip;

            //node.ExpandSubtree();

            foreach (IDataNode child in childrens)
                node.Items.Add(child.GetItem());

            return node;
        }

        private void TextBlock1_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Right clicked on " + (sender as TextBlock).Text);
        }

        private ContextMenu CreateContextMenu()
        {
            ContextMenu cm = new ContextMenu();

            MenuItem fontUp = new MenuItem();
            fontUp.Header = "Increase Font";
            fontUp.Command = IncreaseFont;

            MenuItem fontDown = new MenuItem();
            fontDown.Header = "Decrease Font";
            fontDown.Command = DecreaseFont;

            MenuItem bold = new MenuItem();
            bold.Header = "Bold Font";
            bold.Command = BoldFont;

            MenuItem normal = new MenuItem();
            normal.Header = "Normal Font";
            normal.Command = NormalFont;

            cm.Items.Add(fontUp);
            cm.Items.Add(fontDown);
            cm.Items.Add(bold);
            cm.Items.Add(normal);

            return cm;
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
