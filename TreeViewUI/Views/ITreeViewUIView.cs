namespace Agilent.OpenLab.TreeViewUI
{
    /// <summary>
    /// ITreeViewUIView
    /// </summary>
    public interface ITreeViewUIView
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model. 
        /// </value>
        ITreeViewUIViewModel Model { get; set; }

        #endregion
    }
}