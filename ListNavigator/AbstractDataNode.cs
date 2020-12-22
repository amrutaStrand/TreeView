using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.DataPresenter;
using ListNavigator.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Timers;

namespace ListNavigator
{
    public class AbstractDataNode : IDataNode, INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Notes { get; set; }

        public string HoverText { get; set; }

        //protected List<IDataNode> childrens;
        //public ObservableCollection<IDataNode> childrens;
        private ObservableCollection<IDataNode> childrens;
        public ObservableCollection<IDataNode> Childrens {
            get
            {
                return childrens;
            }
            set
            {
                childrens = value;
                OnPropertyChanged("Childrens");
            } 
        }
        protected ToolTip toolTip;
        protected TextBlock textBlock1;

        private Timer ClickTimer;
        private int ClickCounter;

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

        protected ActionCommand DeleteChilds;

        private void DeleteChildsExecute(object p)
        {
            int c = Childrens.Count();
            MessageBox.Show(string.Format("Removing all childs: Count is {0}", c));
            //Childrens.Clear();
            Childrens = new ObservableCollection<IDataNode>();
            UpdateNode();
        }

        #endregion

        private TreeViewItem node = new TreeViewItem();

        public TreeViewItem Node
        {
            get
            {
                UpdateNode();
                return node;
            }
            set
            {
                node = value;
                OnPropertyChanged("Node");
            }
        }

        public AbstractDataNode()
        {
            IncreaseFont = new ActionCommand(IncreaseFontExecute);
            DecreaseFont = new ActionCommand(DecreaseFontExecute);
            BoldFont = new ActionCommand(BoldFontExecute);
            NormalFont = new ActionCommand(NormalFontExecute);
            DeleteChilds = new ActionCommand(DeleteChildsExecute);

            //childrens = new List<IDataNode>();
            Childrens = new ObservableCollection<IDataNode>();
            toolTip = new ToolTip();
            textBlock1 = new TextBlock();
            //InitializeNode();
            textBlock1.ContextMenu = CreateContextMenu();
            //node.ContextMenu = CreateContextMenu();

            ClickTimer = new Timer(200);
            ClickTimer.Elapsed += new ElapsedEventHandler(EvaluateClicks);
        }

        protected void InitializeNode()
        {
            DockPanel dockPanel = new DockPanel();

            //get 'icon' corresponding to the node 'type' from resources and add it to the dockPanel
            dockPanel.Children.Add(Util.GetIcon(Type));

            //textBlock1 = new TextBlock();
            textBlock1.Margin = new System.Windows.Thickness(5);
            textBlock1.Text = Name;
            dockPanel.Children.Add(textBlock1);

            node.MouseDoubleClick += (sender, e) => e.Handled = true;

            textBlock1.MouseLeftButtonDown += TextBlock1_MouseLeftButtonDown;

            node.Header = dockPanel;

            toolTip.Content = HoverText;
            node.ToolTip = toolTip;
        }

        private void UpdateNode()
        {
            node.Items.Clear();

           
            //node.ExpandSubtree();

            foreach (IDataNode child in Childrens)
                node.Items.Add(child.Node);
        }

        private void TextBlock1_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if (e.ClickCount==1)
            //{
            //    MessageBox.Show(string.Format("Single clicked on {0} which is of type {1}", Name, Type));
            //}
            //if (e.ClickCount == 2)
            //{
            //    MessageBox.Show(string.Format("Double clicked on {0} which is of type {1}", Name, Type));
            //}
            ClickTimer.Stop();
            ClickCounter++;
            ClickTimer.Start();
        }

        private void EvaluateClicks(object source, ElapsedEventArgs e)
        {
            ClickTimer.Stop();
            if (ClickCounter == 1)
            {
                MessageBox.Show(string.Format("Single clicked on {0} which is of type {1}", Name, Type));
            }
            if (ClickCounter == 2)
            {
                MessageBox.Show(string.Format("Double clicked on {0} which is of type {1}", Name, Type));
            }
            ClickCounter = 0;
        }

        private void Node_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //if(node.IsMouseOver)
            //    MessageBox.Show( string.Format("Double clicked on {0} which is of type {1}", Name, Type));
            e.Handled = true;
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

            MenuItem delete = new MenuItem();
            delete.Header = "Delete all child";
            delete.Command = DeleteChilds;

            cm.Items.Add(fontUp);
            cm.Items.Add(fontDown);
            cm.Items.Add(bold);
            cm.Items.Add(normal);
            cm.Items.Add(delete);

            return cm;
        }

        public void AddChild(IDataNode node)
        {
            Childrens.Add(node);
        }

        public void RemoveChild(IDataNode node)
        {
            Childrens.Remove(node);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
