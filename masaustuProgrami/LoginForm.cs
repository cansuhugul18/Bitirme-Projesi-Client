using System;
using System.Windows.Forms;

namespace masaustuProgrami
{
    public partial class LoginForm : Form
    {
        public static LoginForm Instance;

        public LoginForm()
        {
            InitializeComponent();

            Instance = this;
        }

        private void KatilRoundedButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KullaniciAdiTextBox.Text) || string.IsNullOrWhiteSpace(OdaIdTextBox.Text))
            {
                MessageBox.Show(this, "Lütfen gerekli kısımları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var mainform = new MainForm();
            mainform.Baglan(Convert.ToInt64(OdaIdTextBox.Text), KullaniciAdiTextBox.Text);
            mainform.Show();
            
            Hide();
        }

        private void OdaIdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}