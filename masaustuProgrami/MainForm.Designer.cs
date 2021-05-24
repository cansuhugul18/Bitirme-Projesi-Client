namespace masaustuProgrami
{
    partial class MainForm
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
            this.btnmesajgonder = new System.Windows.Forms.Button();
            this.textboxMesaj = new System.Windows.Forms.TextBox();
            this.BtnResimAc = new System.Windows.Forms.Button();
            this.ChatBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.btnmicrophone = new System.Windows.Forms.Button();
            this.OpenCloseCameraButton = new System.Windows.Forms.Button();
            this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ChatBoxGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnmesajgonder
            // 
            this.btnmesajgonder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmesajgonder.Enabled = false;
            this.btnmesajgonder.Location = new System.Drawing.Point(161, 353);
            this.btnmesajgonder.Name = "btnmesajgonder";
            this.btnmesajgonder.Size = new System.Drawing.Size(64, 23);
            this.btnmesajgonder.TabIndex = 12;
            this.btnmesajgonder.Text = "Gonder";
            this.btnmesajgonder.UseVisualStyleBackColor = true;
            this.btnmesajgonder.Click += new System.EventHandler(this.BtnmesajgonderClick);
            // 
            // textboxMesaj
            // 
            this.textboxMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxMesaj.Location = new System.Drawing.Point(6, 355);
            this.textboxMesaj.Name = "textboxMesaj";
            this.textboxMesaj.Size = new System.Drawing.Size(149, 20);
            this.textboxMesaj.TabIndex = 10;
            this.textboxMesaj.TextChanged += new System.EventHandler(this.TextboxMesajTextChanged);
            // 
            // BtnResimAc
            // 
            this.BtnResimAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnResimAc.Enabled = false;
            this.BtnResimAc.Location = new System.Drawing.Point(622, 12);
            this.BtnResimAc.Name = "BtnResimAc";
            this.BtnResimAc.Size = new System.Drawing.Size(105, 23);
            this.BtnResimAc.TabIndex = 15;
            this.BtnResimAc.Text = "Resim Gönder";
            this.BtnResimAc.UseVisualStyleBackColor = true;
            this.BtnResimAc.Click += new System.EventHandler(this.BtnResimAcClick);
            // 
            // ChatBoxGroupBox
            // 
            this.ChatBoxGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatBoxGroupBox.Controls.Add(this.RichTextBox);
            this.ChatBoxGroupBox.Controls.Add(this.textboxMesaj);
            this.ChatBoxGroupBox.Controls.Add(this.btnmesajgonder);
            this.ChatBoxGroupBox.Enabled = false;
            this.ChatBoxGroupBox.Location = new System.Drawing.Point(622, 70);
            this.ChatBoxGroupBox.Name = "ChatBoxGroupBox";
            this.ChatBoxGroupBox.Size = new System.Drawing.Size(231, 381);
            this.ChatBoxGroupBox.TabIndex = 17;
            this.ChatBoxGroupBox.TabStop = false;
            this.ChatBoxGroupBox.Text = "Chat Box";
            // 
            // RichTextBox
            // 
            this.RichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox.Location = new System.Drawing.Point(0, 19);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(225, 328);
            this.RichTextBox.TabIndex = 13;
            this.RichTextBox.Text = "";
            // 
            // btnmicrophone
            // 
            this.btnmicrophone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmicrophone.Enabled = false;
            this.btnmicrophone.Location = new System.Drawing.Point(742, 12);
            this.btnmicrophone.Name = "btnmicrophone";
            this.btnmicrophone.Size = new System.Drawing.Size(105, 23);
            this.btnmicrophone.TabIndex = 21;
            this.btnmicrophone.Text = "Mikrofon Aç";
            this.btnmicrophone.UseVisualStyleBackColor = true;
            this.btnmicrophone.Click += new System.EventHandler(this.btnmicrophone_Click);
            // 
            // OpenCloseCameraButton
            // 
            this.OpenCloseCameraButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenCloseCameraButton.Enabled = false;
            this.OpenCloseCameraButton.Location = new System.Drawing.Point(622, 41);
            this.OpenCloseCameraButton.Name = "OpenCloseCameraButton";
            this.OpenCloseCameraButton.Size = new System.Drawing.Size(120, 23);
            this.OpenCloseCameraButton.TabIndex = 22;
            this.OpenCloseCameraButton.Text = "Kamera Aç";
            this.OpenCloseCameraButton.UseVisualStyleBackColor = true;
            this.OpenCloseCameraButton.Click += new System.EventHandler(this.OpenCloseCameraButton_Click);
            // 
            // FlowLayoutPanel
            // 
            this.FlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.FlowLayoutPanel.Name = "FlowLayoutPanel";
            this.FlowLayoutPanel.Size = new System.Drawing.Size(601, 439);
            this.FlowLayoutPanel.TabIndex = 23;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(865, 463);
            this.Controls.Add(this.FlowLayoutPanel);
            this.Controls.Add(this.OpenCloseCameraButton);
            this.Controls.Add(this.btnmicrophone);
            this.Controls.Add(this.ChatBoxGroupBox);
            this.Controls.Add(this.BtnResimAc);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "İstemci";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            
            this.ChatBoxGroupBox.ResumeLayout(false);
            this.ChatBoxGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnmesajgonder;
        private System.Windows.Forms.TextBox textboxMesaj;
        private System.Windows.Forms.Button BtnResimAc;
        private System.Windows.Forms.GroupBox ChatBoxGroupBox;
        private System.Windows.Forms.RichTextBox RichTextBox;
        private System.Windows.Forms.Button btnmicrophone;
        private System.Windows.Forms.Button OpenCloseCameraButton;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
    }
}