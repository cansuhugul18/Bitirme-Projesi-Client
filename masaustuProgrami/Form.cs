using DataCore;
using masaustuProgrami.Helpers;
using masaustuProgrami.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace masaustuProgrami
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Degiskenler

        public static long ID; // Normalde kullanıcı giris yaptıgında alcaksın. Buda değişecek

        public static UserInfo UserInfo { get; set; }

        public delegate void PutTextDelegate(string text);

        public delegate void PutImagetDelegate(Image image);

        public static Form instance =null;

        public int framecount = 0;

        private bool micState = false;

        private Client Client { get; set; }

        private Dictionary<long, UserInfo> Users = new Dictionary<long, UserInfo>(); // Bu da burada olmıcak ilerde başka bir sınıf içinde olabilir

        #endregion

        #region Yapıcı Method

        public Form()
        {
            instance = this;

            InitializeComponent();

            Initialize();
        }

        #endregion

        #region Properties

        public CameraHelper CameraHelper => CameraHelper.Instance;

        public UserViewController UserViewController => UserViewController.Default;

        #endregion

        #region Private Methods

        private void Initialize()
        {
            Client = Client.Instance;

            Client.OnConnectionChanged += ClientOnConnectionChanged;
            Client.OnDataRead += ClientOnDataRead;

            Application.ApplicationExit += Application_ApplicationExit;

            CameraHelper.OnError += CameraHelper_OnError;
            CameraHelper.OnNewFrame += CameraHelper_OnNewFrame;
            CameraHelper.OnCaptureDeviceStateChanged += CameraHelper_OnCaptureDeviceStateChanged;

            UserViewController.OnViewlModelCreated += UserViewController_OnViewlModelCreated;
            UserViewController.OnViewModelDestroy += UserViewController_OnViewModelDestroy;
        }

        public void PrintMessage(string message)
        {
            if (RichTextBox.InvokeRequired)
            {
                var @delegate = new PutTextDelegate(PrintMessage);
                RichTextBox.Invoke(@delegate, message);
            }
            else
            {
                RichTextBox.AppendText(message + "\n");
            }
        }

        #endregion

        #region Events

        private void BtnbaglanClick(object sender, EventArgs e)
        {
            btnbaglan.Enabled = false;

            UserConnected();

            if (!Client.IsConnected)
                Client.Connect();
            else
                Client.Disconnect();

        }

        public void UserConnected()
        {
            ID = Convert.ToInt64(new Random().Next());

            UserInfo = new UserInfo(ID, Convert.ToInt64(textboxOdaId.Text), textboxKullaniciadi.Text);
        }

        private void ClientOnConnectionChanged(bool state)
        {
            if (state)
            {
                //CameraGroupBox.Enabled = true;
                ChatBoxGroupBox.Enabled = true;
                BtnResimAc.Enabled = true;
                OpenCloseCameraButton.Enabled = true;
                btnmicrophone.Enabled = true;

                btnbaglan.Text = "Bağlantıyı Kes";
                btnbaglan.Enabled = true;

                Client.Send(DataTypes.UserInfo, UserInfo);
            }
            else
            {
                //CameraGroupBox.Enabled = false;
                ChatBoxGroupBox.Enabled = false;
                BtnResimAc.Enabled = false;
                OpenCloseCameraButton.Enabled = false;
                btnmicrophone.Enabled = false;

                textboxMesaj.Clear();
                RichTextBox.Clear();

                btnbaglan.Text = "Bağlan";
                btnbaglan.Enabled = true;

                if (CameraHelper.IsOpen)
                    CameraHelper.Close();
            }
        }

        private void BtnmesajgonderClick(object sender, EventArgs e)
        {
            // send veri tipi ve veri alıyor
            Client.Send(DataTypes.String, textboxMesaj.Text);

            RichTextBox.AppendText("" + UserInfo.Username + " : " + textboxMesaj.Text + "\n");

            textboxMesaj.Clear();

            textboxMesaj.Focus();
        }

        private void TextboxMesajTextChanged(object sender, EventArgs e)
        {
            btnmesajgonder.Enabled = textboxMesaj.Text.Length > 0;
        }

        private void BtnResimAcClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image dosyaları (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            Bitmap bitmap = new Bitmap(Image.FromFile(dialog.FileName));
            //UserCameraOutput.Image = bitmap;
            Client.Send(DataTypes.Image, Image.FromFile(dialog.FileName));
        }

        private void ClientOnDataRead(HeaderData headerData, object data)
        {
            Console.WriteLine("LL: " + headerData.DataType);
 
            switch (headerData.DataType)
            {
                case DataTypes.None:
                    throw new ArgumentException("Gecersiz veri tipi.");
                case DataTypes.String:

                    var userInfo = Users[headerData.Id]; // Sozlukte olmayan bir Id ye erişmeye çalışırsan hata verir.

                    PrintMessage(userInfo.Username + ": " + (string)data);
                    break;

                case DataTypes.Image:

                    Console.WriteLine("AAA");

                    UserViewController.GetViewModel(headerData.Id)?.ShowImage((Image)data);

                    break;
                case DataTypes.Sound:
                    SoundHelper.Instance.PlaySound(headerData.Id, (byte[]) data);
                    break;

                case DataTypes.PixelData:
                    throw new NotImplementedException("Bu veritipi suanda desteklenmemktedir.");

                case DataTypes.UserInfo:

                    try
                    {
                        var userinfo = (UserInfo)data;

                        Users.Add(userinfo.UserId, userinfo);
                        SoundHelper.Instance.AddUser(userinfo);

                        PrintMessage(userinfo.Username + " odaya katıldı."); //bu kullanıcıları bir listede tutucam

                        UserViewController.AddUser(userinfo);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(this, error.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;
                default:
                    Console.WriteLine("DEFAULT");
                    break;
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Client.IsConnected)
                Client.Disconnect();

            if (CameraHelper.IsOpen)
                CameraHelper.Close();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        #region CameraHelper Events

        private void OpenCloseCameraButton_Click(object sender, EventArgs e)
        {
            framecount = 0;
            if (CameraHelper.IsOpen)
                CameraHelper.Close();
            else
                CameraHelper.Open();
        }

        private void CameraHelper_OnError(object sender, Helpers.Events.CaptureDeviceErrorEventArgs e)
        {
            MessageBox.Show(this, e.Message, "Kamera Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            CameraHelper.Close();
        }

        private void CameraHelper_OnNewFrame(object sender, Helpers.Events.CameraNewFrameEventArgs e)
        {
            Console.WriteLine("Frame");

            Client.Send(DataTypes.Image, e.Image);
        }

        private void CameraHelper_OnCaptureDeviceStateChanged(object sender, Helpers.Events.CaptureDeviceStateChangedEventArgs e)
        {
            if (e.State)
            {
                OpenCloseCameraButton.Text = "Kamera Kapat";
            }
            else
            {
                OpenCloseCameraButton.Text = "Kamera Aç";
            }
        }

        #endregion

        #region UserViewModelEvents

        private void UserViewController_OnViewlModelCreated(object sender, Views.Events.HandleViewModelMountEventArgs args)
        {
            FlowLayoutPanel.Invoke((MethodInvoker)delegate
            {
                FlowLayoutPanel.Controls.Add(args.ViewModel);
            });
        }

        private void UserViewController_OnViewModelDestroy(object sender, Views.Events.HandleViewModelMountEventArgs args)
        {
            FlowLayoutPanel.Invoke((MethodInvoker)delegate
            {
                FlowLayoutPanel.Controls.Remove(args.ViewModel);
            });
        }

        #endregion

        #endregion

        private void btnmicrophone_Click(object sender, EventArgs e)
        {
            if (!micState)
            {
                micState = true;
                btnmicrophone.Text = "Mikrofonu Kapat";

                Invoke(new Action(() => SoundHelper.Instance.StartMic()));
            }
            else
            {
                micState = false;
                btnmicrophone.Text = "Mikrofon Aç";

                Invoke(new Action(() => SoundHelper.Instance.StopMic()));
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var random = new Random();
            var un = "";

            for (var i = 0; i < 8; i++)
                un += (char)+random.Next(65, 90);

            textboxKullaniciadi.Text = un;
        }
    }
}
