using DataCore;

namespace masaustuProgrami.Views.Events
{
    public delegate void HandleViewModelDestroyEventHandler(object sender, HandleViewModelMountEventArgs args);

    public class HandleViewModelDestroyEventArgs
    {
        #region Properties

        public UserInfo UserInfo { get; private set; }

        public UserViewModel ViewModel { get; private set; }

        #endregion

        #region Constructor

        public HandleViewModelDestroyEventArgs(UserInfo userInfo, UserViewModel viewModel)
        {
            UserInfo = userInfo;
            ViewModel = viewModel;
        }

        #endregion
    }
}