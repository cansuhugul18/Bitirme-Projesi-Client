using System;

namespace masaustuProgrami.Helpers.Events
{
    public delegate void CaptureDeviceErrorEventHandler(object sender, CaptureDeviceErrorEventArgs e);

    public class CaptureDeviceErrorEventArgs : EventArgs
    {
        #region Properties

        public string Message { get; private set; }

        #endregion

        #region Constrctor

        public CaptureDeviceErrorEventArgs(string message)
        {
            Message = message;
        }

        #endregion
    }
}
