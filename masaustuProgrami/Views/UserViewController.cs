using DataCore;
using masaustuProgrami.Views.Events;
using System;
using System.Collections.Generic;

namespace masaustuProgrami.Views
{
    public class UserViewController
    {
        #region Variables

        private static UserViewController instance;


        private Dictionary<long, UserViewModel> viewModels;

        #endregion

        #region Constructor

        private UserViewController()
        {
            Initialize();
        }

        #endregion

        #region Events

        public event HandleViewModelMountEventHandler OnViewlModelCreated;

        public event HandleViewModelDestroyEventHandler OnViewModelDestroy;

        #endregion

        #region Properties

        public static UserViewController Default
        {
            get
            {
                if (instance == null)
                    instance = new UserViewController();

                return instance;
            }
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            viewModels = new Dictionary<long, UserViewModel>();
        }

        #endregion

        #region Public Methods

        public void AddUser(UserInfo userInfo)
        {
            if (viewModels.ContainsKey(userInfo.UserId))
                throw new Exception("Kullanıcı zaten geçerli odada !");

            var viewModel = new UserViewModel(userInfo);

            viewModels.Add(userInfo.UserId, viewModel);

            OnViewlModelCreated?.Invoke(this, new HandleViewModelMountEventArgs(userInfo, viewModel));
        }

        public void RemoveUser(UserInfo userInfo)
        {
            if (viewModels.TryGetValue(userInfo.UserId, out var viewModel))
            {
                viewModels.Remove(userInfo.UserId);

                OnViewModelDestroy?.Invoke(this, new HandleViewModelMountEventArgs(userInfo, viewModel));
            }
        }

        public UserViewModel GetViewModel(UserInfo userInfo)
        {
            return GetViewModel(userInfo.UserId);
        }

        public UserViewModel GetViewModel(long id)
        {
            if (viewModels.TryGetValue(id, out var view))
                return view;

            return null;
        }


        #endregion
    }
}
