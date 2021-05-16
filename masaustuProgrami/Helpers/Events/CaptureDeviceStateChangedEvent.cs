using System;

namespace masaustuProgrami.Helpers.Events
{
    public delegate void CaptureDeviceStateChangedEventHandler(object sender, CaptureDeviceStateChangedEventArgs e);

    public class CaptureDeviceStateChangedEventArgs : EventArgs
    {
        #region Propeties

        public bool State { get; set; }

        #endregion

        #region Constructor

        public CaptureDeviceStateChangedEventArgs(bool state)
        {
            State = state;
        }

        #endregion
    }
}
