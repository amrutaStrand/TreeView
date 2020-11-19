﻿namespace Agilent.OpenLab.TreeViewUI
{
    #region

    using Agilent.OpenLab.Framework.UI.Module;

    using Microsoft.Practices.Unity;

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
        }

        #endregion

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

        #endregion
    }
}