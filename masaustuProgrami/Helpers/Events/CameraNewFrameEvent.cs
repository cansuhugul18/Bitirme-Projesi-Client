using System;
using System.Drawing;

namespace masaustuProgrami.Helpers.Events
{
    public delegate void CameraNewFrameEventHandler(object sender, CameraNewFrameEventArgs e);

    public class CameraNewFrameEventArgs : EventArgs
    {
        #region Properties

        public Image Image { get; private set; }

        #endregion

        #region Constructor

        public CameraNewFrameEventArgs(Image image)
        {
            Image = image;
        }

        #endregion
    }
}
