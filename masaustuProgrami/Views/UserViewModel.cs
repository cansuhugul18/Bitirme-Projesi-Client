using DataCore;
using masaustuProgrami.Helpers;
using masaustuProgrami.Properties;
using masaustuProgrami.Sound;
using masaustuProgrami.Video;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace masaustuProgrami.Views
{
    public partial class UserViewModel : UserControl
    {
        #region Constructor

        public UserViewModel(UserInfo userInfo)
        {
            Debug.Assert(userInfo != null);

            UserInfo = userInfo;

            InitializeComponent();
            Initialize();
        }

        #endregion

        #region Properties

        public UserInfo UserInfo { get; private set; }

        public SoundPlayer SoundPlayer { get; private set; }

        public bool Muted
        {

            get => SoundPlayer.IsMuted;
            set
            {
                if (value)
                {
                    SoundPlayer.Mute();
                    MicButton.Image = Resources.microphone_mute;

                }
                else
                {
                    SoundPlayer.UnMute();
                    MicButton.Image = Resources.microphone;
                }
            }
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            UserNameLabel.Text = UserInfo.Username;

            SoundPlayer = SoundHelper.Instance[UserInfo];

            Debug.Assert(SoundPlayer != null);
        }

        private void UpdateMicButtonLocation()
        {
            var location = new Point
            {
                X = Width / 2 - MicButton.Width / 2,
                Y = Height - MicButton.Height - 16
            };

            MicButton.Location = location;
        }

        private void SetMicButtonVisible(bool visibility)
        {
            if (MicButton.Bounds.Contains(PointToClient(Control.MousePosition)))
                return;

            MicButton.Visible = visibility;
        }

        #endregion

        #region Event Handlers

        private void UserCompoment_Load(object sender, EventArgs e)
        {
            UpdateMicButtonLocation();
        }

        private void UserCompoment_SizeChanged(object sender, EventArgs e)
        {
            UpdateMicButtonLocation();
        }

        private void Container_MouseEnter(object sender, EventArgs e)
        {
            SetMicButtonVisible(true);
        }

        private void Container_MouseLeave(object sender, EventArgs e)
        {
            SetMicButtonVisible(false);
        }

        private void MicButton_Click(object sender, EventArgs e)
        {
            Muted = !Muted;
        }

        #endregion

        #region Public Methods

        public void ShowImage(Image image)
        {
            PictureBox.Invoke((MethodInvoker)delegate
            {
                PictureBox.Image = image;
            });
        }

        public void UpdateImage(byte[] data)
        {
            if (PictureBox.Image == null) return;

            PictureBox.Invoke((MethodInvoker)delegate
            {
                PictureBox.Image = ImageProcessing.Instance.ApplyPixelDataToImage((Bitmap)PictureBox.Image, ImageProcessing.Instance.GetPixelDataFrom(data));
            });
        }

        #endregion
    }
}
