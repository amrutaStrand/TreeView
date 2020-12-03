namespace Agilent.OpenLab.TreeViewUI
{
    #region

    using Agilent.OpenLab.Framework.UI.Common.Commands;
    using Agilent.OpenLab.Framework.UI.Layout.ModuleInterfaces;
    using System.Windows.Controls;
    using Infragistics.Controls.Menus;

    #endregion

    /// <summary>
    /// ITreeViewUIViewModel
    /// </summary>
    public interface ITreeViewUIViewModel : IBaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets the toggle command A.
        /// </summary>
        /// <remarks>
        /// </remarks>
        ToggleCommand<object> ToggleCommandA { get; }

        /// <summary>
        /// Gets the trigger command B.
        /// </summary>
        /// <remarks>
        /// </remarks>
        TriggerCommand<object> TriggerCommandB { get; }

        /// <summary>
        /// Gets the view.
        /// </summary>
        ITreeViewUIView View { get; }

        /// <summary>
        /// 
        /// </summary>
        TreeView testTree { get; set; }

        /// <summary>
        /// 
        /// </summary>
        XamDataTree testXamTree { get; set; }

        #endregion
    }
}