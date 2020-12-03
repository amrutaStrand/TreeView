namespace Agilent.OpenLab.TreeViewUI
{
    #region

    using Agilent.OpenLab.Framework.UI.Module;

    using Microsoft.Practices.Unity;

    using System.Windows.Controls;

    using ListNavigator;

    //using Infragistics.Windows.DataPresenter;

    using Infragistics.Controls.Menus;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    #endregion

    /// <summary>
    /// TreeViewUIViewModel
    /// </summary>
    /// <remarks>
    /// </remarks>
    public partial class TreeViewUIViewModel : BaseViewModel, ITreeViewUIViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewUIViewModel"/> class.
        /// </summary>
        /// <param name="container">
        /// The container. 
        /// </param>
        /// <remarks>
        /// </remarks>
        public TreeViewUIViewModel(IUnityContainer container)
            : base(container)
        {
            this.View = this.UnityContainer.Resolve<ITreeViewUIView>();
            this.View.Model = this;
            this.SubscribeEvents();
            this.InitializeCommands();

            testTree = CreateDataNodeTree();

            testXamTree = CreateXamDataTree();
        }

        #endregion

        private TreeView CreateSampleTree()
        {
            TreeView myTree = new TreeView();
            TreeViewItem treeViewItem = new TreeViewItem();
            treeViewItem.Header = "Samples";
            treeViewItem.Items.Add("Sample1");
            treeViewItem.Items.Add("Sample2");
            myTree.Items.Add(treeViewItem);
            return myTree;
        }

        private TreeView CreateDataNodeTree()
        {
            ExperimentNode experiment1 = new ExperimentNode("Experiment1");

            CompoundsGroupNode compoundsGroup = new CompoundsGroupNode("CompoundsGroup1");

            ClusterNode cluster = new ClusterNode("Cluster1");
            cluster.AddChild(new ExperimentNode("Experiment2"));

            ExperimentNode experiment3 = new ExperimentNode("Experiment3");
            experiment3.HoverText = "My experiment";
            experiment3.AddChild(new CompoundsGroupNode("CompoundsGroup2"));
            experiment3.AddChild(new CompoundsGroupNode("CompoundsGroup3"));

            cluster.AddChild(experiment3);

            experiment1.AddChild(compoundsGroup);
            experiment1.AddChild(cluster);

            return Util.GetTree(experiment1);
        }

        private XamDataTree CreateXamDataTree()
        {
            XamDataTree MyTree = new XamDataTree();

            ExperimentNode experiment1 = new ExperimentNode("Experiment1");

            CompoundsGroupNode compoundsGroup = new CompoundsGroupNode("CompoundsGroup1");

            ClusterNode cluster = new ClusterNode("Cluster1");
            cluster.AddChild(new ExperimentNode("Experiment2"));

            ExperimentNode experiment3 = new ExperimentNode("Experiment3");
            experiment3.HoverText = "My experiment";
            experiment3.AddChild(new CompoundsGroupNode("CompoundsGroup2"));
            experiment3.AddChild(new CompoundsGroupNode("CompoundsGroup3"));

            cluster.AddChild(experiment3);

            experiment1.AddChild(compoundsGroup);
            experiment1.AddChild(cluster);

            MyTree.ItemsSource = new ObservableCollection<IDataNode> { experiment1 };

            NodeLayout mylayout = new NodeLayout();
            mylayout.Key = "NodeLayout";
            //mylayout.TargetTypeName = "AbstractDataNode";
            //mylayout.TargetTypeName = "ExperimentNode";
            mylayout.TargetTypeName = "IDataNode";
            mylayout.DisplayMemberPath = "Name";

            MyTree.GlobalNodeLayouts.Add(mylayout);

            return MyTree;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view. 
        /// </value>
        /// <remarks>
        /// </remarks>
        public ITreeViewUIView View { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TreeView testTree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public XamDataTree testXamTree { get; set; }

        #endregion
    }
}