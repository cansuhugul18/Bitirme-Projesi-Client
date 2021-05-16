using DataCore;

namespace masaustuProgrami.Views.Events
{
    public delegate void HandleViewModelMountEventHandler(object sender, HandleViewModelMountEventArgs args);

    public class HandleViewModelMountEventArgs
    {
        #region Properties

        public UserInfo UserInfo { get; private set; }

        public UserViewModel ViewModel { get; private set; }

        #endregion

        #region Constructor

        public HandleViewModelMountEventArgs(UserInfo userInfo, UserViewModel viewModel)
        {
            UserInfo = userInfo;
            ViewModel = viewModel;
        }

        #endregion
    }
}