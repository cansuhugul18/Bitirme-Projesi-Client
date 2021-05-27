
namespace masaustuProgrami
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProgramAdiLabel = new System.Windows.Forms.Label();
            this.KullaniciAdiLabel = new System.Windows.Forms.Label();
            this.OdaIdLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.KatilRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.OdaIdTextBox = new masaustuProgrami.Views.RoundedTextBox(this.components);
            this.KullaniciAdiTextBox = new masaustuProgrami.Views.RoundedTextBox(this.components);
            this.SuspendLayout();
            // 
            // ProgramAdiLabel
            // 
            this.ProgramAdiLabel.AutoSize = true;
            this.ProgramAdiLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProgramAdiLabel.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ProgramAdiLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.ProgramAdiLabel.Location = new System.Drawing.Point(157, 34);
            this.ProgramAdiLabel.Name = "ProgramAdiLabel";
            this.ProgramAdiLabel.Size = new System.Drawing.Size(273, 59);
            this.ProgramAdiLabel.TabIndex = 0;
            this.ProgramAdiLabel.Text = "Hoş Geldiniz";
            // 
            // KullaniciAdiLabel
            // 
            this.KullaniciAdiLabel.AutoSize = true;
            this.KullaniciAdiLabel.BackColor = System.Drawing.Color.Transparent;
            this.KullaniciAdiLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KullaniciAdiLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.KullaniciAdiLabel.Location = new System.Drawing.Point(236, 120);
            this.KullaniciAdiLabel.Name = "KullaniciAdiLabel";
            this.KullaniciAdiLabel.Size = new System.Drawing.Size(118, 26);
            this.KullaniciAdiLabel.TabIndex = 1;
            this.KullaniciAdiLabel.Text = "Kullanıcı Adı";
            // 
            // OdaIdLabel
            // 
            this.OdaIdLabel.AutoSize = true;
            this.OdaIdLabel.BackColor = System.Drawing.Color.Transparent;
            this.OdaIdLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OdaIdLabel.ForeColor = System.Drawing.Color.LavenderBlush;
            this.OdaIdLabel.Location = new System.Drawing.Point(236, 196);
            this.OdaIdLabel.Name = "OdaIdLabel";
            this.OdaIdLabel.Size = new System.Drawing.Size(115, 26);
            this.OdaIdLabel.TabIndex = 1;
            this.OdaIdLabel.Text = "Oda  Kimliği";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(527, 340);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "v.0.1.0";
            // 
            // KatilRoundedButton
            // 
            this.KatilRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.KatilRoundedButton.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KatilRoundedButton.Location = new System.Drawing.Point(224, 281);
            this.KatilRoundedButton.Name = "KatilRoundedButton";
            this.KatilRoundedButton.Radius = 15;
            this.KatilRoundedButton.Size = new System.Drawing.Size(127, 40);
            this.KatilRoundedButton.TabIndex = 7;
            this.KatilRoundedButton.Text = "Katıl";
            this.KatilRoundedButton.UseMnemonic = false;
            this.KatilRoundedButton.UseVisualStyleBackColor = true;
            this.KatilRoundedButton.Click += new System.EventHandler(this.KatilRoundedButton_Click);
            // 
            // OdaIdTextBox
            // 
            this.OdaIdTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.OdaIdTextBox.Location = new System.Drawing.Point(187, 225);
            this.OdaIdTextBox.MaxLength = 10;
            this.OdaIdTextBox.Name = "OdaIdTextBox";
            this.OdaIdTextBox.Radius = 15;
            this.OdaIdTextBox.Size = new System.Drawing.Size(214, 31);
            this.OdaIdTextBox.TabIndex = 6;
            this.OdaIdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OdaIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OdaIdTextBox_KeyPress);
            // 
            // KullaniciAdiTextBox
            // 
            this.KullaniciAdiTextBox.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.KullaniciAdiTextBox.Location = new System.Drawing.Point(167, 149);
            this.KullaniciAdiTextBox.MaxLength = 20;
            this.KullaniciAdiTextBox.Name = "KullaniciAdiTextBox";
            this.KullaniciAdiTextBox.Radius = 15;
            this.KullaniciAdiTextBox.Size = new System.Drawing.Size(254, 31);
            this.KullaniciAdiTextBox.TabIndex = 5;
            this.KullaniciAdiTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::masaustuProgrami.Properties.Resources.login_backgorund;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KatilRoundedButton);
            this.Controls.Add(this.OdaIdTextBox);
            this.Controls.Add(this.KullaniciAdiTextBox);
            this.Controls.Add(this.OdaIdLabel);
            this.Controls.Add(this.KullaniciAdiLabel);
            this.Controls.Add(this.ProgramAdiLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hoş Geldiniz - Sohbete Katılın !";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ProgramAdiLabel;
        private System.Windows.Forms.Label KullaniciAdiLabel;
        private System.Windows.Forms.Label OdaIdLabel;
        private Views.RoundedTextBox KullaniciAdiTextBox;
        private Views.RoundedTextBox OdaIdTextBox;
        private Views.Events.RoundedButton KatilRoundedButton;
        private System.Windows.Forms.Label label1;
    }
}