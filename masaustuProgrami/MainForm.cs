using DataCore;
using masaustuProgrami.Helpers;
using masaustuProgrami.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using masaustuProgrami.Video;

namespace masaustuProgrami
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        #region Degiskenler

        public static long ID; // Normalde kullanıcı giris yaptıgında alcaksın. Buda değişecek

        public static UserInfo UserInfo { get; set; }

        public delegate void PutTextDelegate(string text);

        public delegate void PutImagetDelegate(Image image);

        public static Form instance =null;

        public int framecount = 0;

        private Client Client { get; set; }

        private Dictionary<long, UserInfo> Users = new Dictionary<long, UserInfo>(); // Bu da burada olmıcak ilerde başka bir sınıf içinde olabilir

        #endregion

        #region Yapıcı Method

        public MainForm()
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

        

        public void Baglan(long roomId, string username)
        {
            MainForm.instance.Text = username+"-"+roomId.ToString();

            UserConnected(roomId, username);

            if (!Client.IsConnected)
                Client.Connect();
            
            else
                Client.Disconnect();
        }
        public void UserConnected(long roomId, string username)
        {
            ID = Convert.ToInt64(new Random().Next());

            UserInfo = new UserInfo(ID, roomId, username);
        }

        private void ClientOnConnectionChanged(bool state)
        {
            if (state)
            {
                ChatBoxGroupBox.Enabled = true;
                ResimGonderRoundedButton.Enabled = true;
                KameraAcRoundedButton.Enabled = true;
                MikrofonAcRoundedButton.Enabled = true;
             
                CikisYapRoundedButton.Enabled = true;

                Client.Send(DataTypes.UserInfo, UserInfo);
            }
            else
            {
                ChatBoxGroupBox.Enabled = false;
                ResimGonderRoundedButton.Enabled = false;
                KameraAcRoundedButton.Enabled = false;
                MikrofonAcRoundedButton.Enabled = false;
               
                CikisYapRoundedButton.Enabled = false;

                textboxMesaj.Clear();
                RichTextBox.Clear();


                if (CameraHelper.IsOpen)
                    CameraHelper.Close();

                //TODO: mainform.hide yapılabilir. loginform yeni oluşturabilir.

              //  Close();
            }
        }

      
        private void TextboxMesajTextChanged(object sender, EventArgs e)
        {
            btnmesajgonder.Enabled = textboxMesaj.Text.Length > 0;
        }

        private void textboxMesaj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                MesajGonderRoundedButton.PerformClick();
        }

        private void ResimGonderRoundedButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image dosyaları (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            Bitmap bitmap = new Bitmap(Image.FromFile(dialog.FileName));
            //UserCameraOutput.Image = bitmap;
            Client.Send(DataTypes.Image, Image.FromFile(dialog.FileName));

            /*
            Bitmap oldImage = new Bitmap(@"C:\Users\Cansu\Desktop\a.png");
            Bitmap newImage = new Bitmap(@"C:\Users\Cansu\Desktop\b.png");
            ImageProcessing.Instance.CompareBitmap(oldImage, newImage);

            */

        }


        private void MikrofonAcRoundedButton_Click(object sender, EventArgs e)
        { 
            
            if (!SoundHelper.Instance.IsRecording)
            {
                MikrofonAcRoundedButton.Text = "Mikrofonu Kapat";

                Invoke(new Action(() => SoundHelper.Instance.StartMic()));
            }
            else
            {
                MikrofonAcRoundedButton.Text = "Mikrofon Aç";

                Invoke(new Action(() => SoundHelper.Instance.StopMic()));
            }
        }
        
        private void MesajGonderRoundedButton_Click(object sender, EventArgs e)
        {
            // send veri tipi ve veri alıyor
            Client.Send(DataTypes.String, textboxMesaj.Text);

            RichTextBox.AppendText("" + UserInfo.Username + " : " + textboxMesaj.Text + "\n");

            textboxMesaj.Clear();

            textboxMesaj.Focus();
        }
        private void KameraAcRoundedButton_Click(object sender, EventArgs e)
        {
            framecount = 0;
            if (CameraHelper.IsOpen)
                CameraHelper.Close();
            else
                CameraHelper.Open();
        }
       

        private void ClientOnDataRead(HeaderData headerData, object data)
        {
            switch (headerData.DataType)
            {
                case DataTypes.None:
                    throw new ArgumentException("Gecersiz veri tipi.");
                case DataTypes.String:

                    var userInfo = Users[headerData.Id]; // Sozlukte olmayan bir Id ye erişmeye çalışırsan hata verir.

                    PrintMessage(userInfo.Username + ": " + (string)data);
                    break;

                case DataTypes.Image:

                    UserViewController.GetViewModel(headerData.Id)?.ShowImage((Image)data);

                    break;

                case DataTypes.Sound:

                    SoundHelper.Instance.PlaySound(headerData.Id, (byte[]) data);

                    break;

                case DataTypes.PixelData:
                    
                    UserViewController.GetViewModel(headerData.Id)?.UpdateImage((byte[])data);

                    break;

                case DataTypes.UserInfo:

                    try
                    {
                        var userinfo = (UserInfo)data;

                        Users.Add(userinfo.UserId, userinfo);
                        SoundHelper.Instance.AddUser(userinfo);

                        PrintMessage(userinfo.Username + " odaya katıldı.");

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

            LoginForm.Instance.Close();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        #region CameraHelper Events

        private void OpenCloseCameraButton_Click(object sender, EventArgs e)
        {
           //  framecount = 0;
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
                KameraAcRoundedButton.Text = "Kamera Kapat";
            }
            else
            {
                KameraAcRoundedButton.Text = "Kamera Aç";
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

        private void CikisYapRoundedButton_Click(object sender, EventArgs e)
        {
           
            UserViewController.RemoveUser(UserInfo);

            Users.Remove(ID);

            Client.Disconnect();

            
        }
    }
}
