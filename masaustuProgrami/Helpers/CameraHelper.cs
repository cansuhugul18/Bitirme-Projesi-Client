using AForge.Video;
using AForge.Video.DirectShow;
using masaustuProgrami.Helpers.Events;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace masaustuProgrami.Helpers
{
    public sealed class CameraHelper
    {
        #region Variables

        private static CameraHelper instance = null;

        private VideoCaptureDevice videoCaptureDevice;

        private int deviceIndex = 0;

        private bool isOpen = false;

        #endregion

        #region Constructor

        private CameraHelper()
        {
            Initialize();
        }

        #endregion

        #region Properties

        public bool IsOpen
        {
            get => isOpen;
            private set
            {
                isOpen = value;

                OnCaptureDeviceStateChanged?.Invoke(this, new CaptureDeviceStateChangedEventArgs(isOpen));
            }
        }

        public static CameraHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new CameraHelper();

                return instance;
            }
        }

        #endregion

        #region Events

        public event CaptureDeviceErrorEventHandler OnError;
        
        public event CameraNewFrameEventHandler OnNewFrame;
        
        public event CaptureDeviceStateChangedEventHandler OnCaptureDeviceStateChanged;

        #endregion

        #region Private Methods

        private void Initialize()
        {
            deviceIndex = Properties.Settings.Default.SelectedCameraIndex;

            Application.ApplicationExit += Application_ApplicationExit;
        }

        private bool IsDeviceAvaiable(ref FilterInfo deviceInfo)
        {
            var deviceList = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if(deviceList.Count == 0)
            {
                OnError?.Invoke(this, new CaptureDeviceErrorEventArgs("Cihazınıza bağlı kamera bulunamadı!"));

                return false;
            }

            if(deviceIndex > deviceList.Count)
                deviceIndex = 0;

            deviceInfo = deviceList[deviceIndex];

            return true;
        }

        #endregion

        #region Public Methods

        public void Open()
        {
            if (IsOpen)
                return;

            FilterInfo deviceInfo = null;

            if (!IsDeviceAvaiable(ref deviceInfo))
                return;

            videoCaptureDevice = new VideoCaptureDevice(deviceInfo.MonikerString);
            //videoCaptureDevice.VideoResolution = videoCaptureDevice.VideoCapabilities[3];
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;

            videoCaptureDevice.Start();
            
            IsOpen = true;
        }

        public void Close()
        {
            if (!IsOpen)
                return;

            videoCaptureDevice.NewFrame -= VideoCaptureDevice_NewFrame;

            videoCaptureDevice.SignalToStop();
            videoCaptureDevice.Stop();

            videoCaptureDevice = null;

            IsOpen = false;
        }

        public void ChangeDeviceIndex(int deviceIndex) // ayar menüsünde listbox olur ordan kullanıcı seçer.
        {
            this.deviceIndex = deviceIndex;
            Properties.Settings.Default.SelectedCameraIndex = deviceIndex;

            if (IsOpen)
            {
                Close();

                Open();
            }
        }

        #endregion

        #region Event Handlers

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (IsOpen)
                Close();
        }

        int c = 0;

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (!IsOpen)
                return;

            if(++c > 25)
            {
                OnNewFrame?.Invoke(this, new CameraNewFrameEventArgs((Image)eventArgs.Frame));

                c = 0;
            }


            //eventArgs.Frame.Dispose();
        }

        #endregion
    }
}
