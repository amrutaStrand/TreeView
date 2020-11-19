namespace Agilent.OpenLab.ControllerModule
{
    #region

    using Agilent.OpenLab.Framework.UI.Module;

    using Microsoft.Practices.Unity;

    #endregion

    public partial class ControllerModuleViewModel : BaseViewModel, IControllerModuleViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ControllerModuleViewModel" /> class.
        /// </summary>
        /// <param name = "container">The container.</param>
        public ControllerModuleViewModel(IUnityContainer container)
            : base(container)
        {
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        #endregion                    
    }
}