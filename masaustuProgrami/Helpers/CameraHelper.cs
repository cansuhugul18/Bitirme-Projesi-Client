using AForge.Video;
using AForge.Video.DirectShow;
using DataCore;
using masaustuProgrami.Helpers.Events;
using System;
using System.Drawing;
using System.Windows.Forms;
using masaustuProgrami.Video;
using System.Collections.Generic;
using VisioForge.Shared.Helpers;
using Org.BouncyCastle.Utilities;

namespace masaustuProgrami.Helpers
{
    public sealed class CameraHelper
    {
        #region Variables

        private static CameraHelper instance = null;

        private VideoCaptureDevice videoCaptureDevice;

        private int deviceIndex = 0;

        private bool isOpen = false;

        private Bitmap oldimage;

        private Bitmap newimage;

        private long frameCount = 0;

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
                frameCount = 0;

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

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {                      
            if (!IsOpen)
                return;

            /*

            if (frameCount++ > 25)
            {
                OnNewFrame?.Invoke(this, new CameraNewFrameEventArgs((Bitmap)eventArgs.Frame.Clone()));
                frameCount = 0;
            }

            return;
            */

            if (frameCount++ == 0)
            {
                oldimage = (Bitmap) eventArgs.Frame.Clone();
                OnNewFrame?.Invoke(this, new CameraNewFrameEventArgs(oldimage));

                return;
            }

            if (frameCount++ % 20 != 0)
                return;

            newimage = (Bitmap)eventArgs.Frame.Clone();

            ImageProcessing.Instance.CompareBitmap(oldimage, newimage);

            oldimage.Dispose();
            eventArgs.Frame.Dispose();

            oldimage = newimage;
        }

        #endregion
    }
}
