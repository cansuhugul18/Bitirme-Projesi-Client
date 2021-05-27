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

        public List<ColorPoint> PointColorList = new List<ColorPoint>();

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
       

        public Bitmap PutPixel(long userId, byte[] colorpointarray) 
        {
           Bitmap oldImage = new Bitmap(@"C:\Users\Cansu\Desktop\a.png");

            PointColorList.CopyTo(colorpointarray);
          

            for (int i = 0; i < PointColorList.Count; i++)
            {

                ColorPoint colorPoint  = PointColorList[i];

               
                oldImage.SetPixel(colorPoint.point.X, colorPoint.point.Y, colorPoint.color);
               // TODO: yeni frame olacak.
          
            }
           
           return oldImage;


        }

        #endregion

        #region Event Handlers

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (IsOpen)
                Close();
        }

        int c = 0;
        int firstframe = 0;

        Bitmap oldimage;
        Bitmap newimage;
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
                      
            if (!IsOpen)
                return;
            
            if (firstframe == 0)
            {
                oldimage = eventArgs.Frame;
                OnNewFrame?.Invoke(this, new CameraNewFrameEventArgs(oldimage));
               
                firstframe++;
            }
            
            if(++c > 50)
            {
              //  OnNewFrame?.Invoke(this, new CameraNewFrameEventArgs(newimage=eventArgs.Frame));

                newimage = eventArgs.Frame;

                ImageProcessing.Instance.CompareBitmap(oldimage, newimage);

                c = 0;


            }  
        }


        #endregion
    }
}
