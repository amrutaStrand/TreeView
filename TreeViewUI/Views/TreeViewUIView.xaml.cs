namespace Agilent.OpenLab.TreeViewUI
{
    #region

    using System.Windows;
    using System.Windows.Controls;

    #endregion

    /// <summary>
    /// Interaction logic for TreeViewUIView.xaml
    /// </summary>
    /// <remarks>
    /// </remarks>
    public partial class TreeViewUIView : ITreeViewUIView
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewUIView"/> class.
        /// </summary>
        /// <remarks>
        /// </remarks>
        public TreeViewUIView()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model. 
        /// </value>
        /// <remarks>
        /// </remarks>
        public ITreeViewUIViewModel Model
        {
            get
            {
                return this.DataContext as ITreeViewUIViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">
        /// The sender. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data. 
        /// </param>
        /// <remarks>
        /// </remarks>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //TextBlock textBlock = new TextBlock();
            //textBlock.Text = "Exploring OLCF";
            //testGrid.Children.Add(textBlock);
            testGrid.Children.Add(Model.testTree);
        }

        /// <summary>
        /// Called when [unload].
        /// </summary>
        /// <param name="sender">
        /// The sender. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data. 
        /// </param>
        /// <remarks>
        /// </remarks>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
        }

        #endregion
    }
}