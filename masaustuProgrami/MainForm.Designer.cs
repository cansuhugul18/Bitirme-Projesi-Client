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
            this.components = new System.ComponentModel.Container();
            this.btnmesajgonder = new System.Windows.Forms.Button();
            this.textboxMesaj = new System.Windows.Forms.TextBox();
            this.ChatBoxGroupBox = new System.Windows.Forms.GroupBox();
            this.MesajGonderRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.RichTextBox = new System.Windows.Forms.RichTextBox();
            this.FlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CikisYapRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.ResimGonderRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.KameraAcRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.MikrofonAcRoundedButton = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.ChatBoxGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnmesajgonder
            // 
            this.btnmesajgonder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnmesajgonder.Enabled = false;
            this.btnmesajgonder.Location = new System.Drawing.Point(161, 276);
            this.btnmesajgonder.Name = "btnmesajgonder";
            this.btnmesajgonder.Size = new System.Drawing.Size(64, 23);
            this.btnmesajgonder.TabIndex = 12;
            this.btnmesajgonder.Text = "Gonder";
            this.btnmesajgonder.UseVisualStyleBackColor = true;
            // 
            // textboxMesaj
            // 
            this.textboxMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxMesaj.Location = new System.Drawing.Point(6, 413);
            this.textboxMesaj.Name = "textboxMesaj";
            this.textboxMesaj.Size = new System.Drawing.Size(132, 20);
            this.textboxMesaj.TabIndex = 10;
            this.textboxMesaj.TextChanged += new System.EventHandler(this.TextboxMesajTextChanged);
            this.textboxMesaj.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textboxMesaj_KeyDown);
            // 
            // ChatBoxGroupBox
            // 
            this.ChatBoxGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatBoxGroupBox.Controls.Add(this.MesajGonderRoundedButton);
            this.ChatBoxGroupBox.Controls.Add(this.RichTextBox);
            this.ChatBoxGroupBox.Controls.Add(this.textboxMesaj);
            this.ChatBoxGroupBox.Controls.Add(this.btnmesajgonder);
            this.ChatBoxGroupBox.Enabled = false;
            this.ChatBoxGroupBox.Location = new System.Drawing.Point(622, 12);
            this.ChatBoxGroupBox.Name = "ChatBoxGroupBox";
            this.ChatBoxGroupBox.Size = new System.Drawing.Size(231, 439);
            this.ChatBoxGroupBox.TabIndex = 17;
            this.ChatBoxGroupBox.TabStop = false;
            this.ChatBoxGroupBox.Text = "Chat Box";
            // 
            // MesajGonderRoundedButton
            // 
            this.MesajGonderRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MesajGonderRoundedButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MesajGonderRoundedButton.Location = new System.Drawing.Point(144, 410);
            this.MesajGonderRoundedButton.Name = "MesajGonderRoundedButton";
            this.MesajGonderRoundedButton.Radius = 15;
            this.MesajGonderRoundedButton.Size = new System.Drawing.Size(72, 25);
            this.MesajGonderRoundedButton.TabIndex = 14;
            this.MesajGonderRoundedButton.Text = "Gönder";
            this.MesajGonderRoundedButton.UseMnemonic = false;
            this.MesajGonderRoundedButton.UseVisualStyleBackColor = true;
            this.MesajGonderRoundedButton.Click += new System.EventHandler(this.MesajGonderRoundedButton_Click);
            // 
            // RichTextBox
            // 
            this.RichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RichTextBox.Location = new System.Drawing.Point(0, 19);
            this.RichTextBox.Name = "RichTextBox";
            this.RichTextBox.ReadOnly = true;
            this.RichTextBox.Size = new System.Drawing.Size(225, 383);
            this.RichTextBox.TabIndex = 13;
            this.RichTextBox.Text = "";
            // 
            // FlowLayoutPanel
            // 
            this.FlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FlowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FlowLayoutPanel.Location = new System.Drawing.Point(12, 59);
            this.FlowLayoutPanel.Name = "FlowLayoutPanel";
            this.FlowLayoutPanel.Size = new System.Drawing.Size(601, 392);
            this.FlowLayoutPanel.TabIndex = 23;
            // 
            // CikisYapRoundedButton
            // 
            this.CikisYapRoundedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CikisYapRoundedButton.BackColor = System.Drawing.SystemColors.Control;
            this.CikisYapRoundedButton.Enabled = false;
            this.CikisYapRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CikisYapRoundedButton.Location = new System.Drawing.Point(504, 12);
            this.CikisYapRoundedButton.Name = "CikisYapRoundedButton";
            this.CikisYapRoundedButton.Radius = 15;
            this.CikisYapRoundedButton.Size = new System.Drawing.Size(94, 23);
            this.CikisYapRoundedButton.TabIndex = 24;
            this.CikisYapRoundedButton.Text = "Çıkış Yap";
            this.CikisYapRoundedButton.UseMnemonic = false;
            this.CikisYapRoundedButton.UseVisualStyleBackColor = true;
            this.CikisYapRoundedButton.Click += new System.EventHandler(this.CikisYapRoundedButton_Click);
            // 
            // ResimGonderRoundedButton
            // 
            this.ResimGonderRoundedButton.BackColor = System.Drawing.SystemColors.Control;
            this.ResimGonderRoundedButton.Enabled = false;
            this.ResimGonderRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ResimGonderRoundedButton.Location = new System.Drawing.Point(22, 12);
            this.ResimGonderRoundedButton.Name = "ResimGonderRoundedButton";
            this.ResimGonderRoundedButton.Radius = 15;
            this.ResimGonderRoundedButton.Size = new System.Drawing.Size(95, 23);
            this.ResimGonderRoundedButton.TabIndex = 26;
            this.ResimGonderRoundedButton.Text = "Resim Gönder";
            this.ResimGonderRoundedButton.UseMnemonic = false;
            this.ResimGonderRoundedButton.UseVisualStyleBackColor = true;
            this.ResimGonderRoundedButton.Click += new System.EventHandler(this.ResimGonderRoundedButton_Click);
            // 
            // KameraAcRoundedButton
            // 
            this.KameraAcRoundedButton.Enabled = false;
            this.KameraAcRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.KameraAcRoundedButton.Location = new System.Drawing.Point(173, 12);
            this.KameraAcRoundedButton.Name = "KameraAcRoundedButton";
            this.KameraAcRoundedButton.Radius = 15;
            this.KameraAcRoundedButton.Size = new System.Drawing.Size(94, 23);
            this.KameraAcRoundedButton.TabIndex = 26;
            this.KameraAcRoundedButton.Text = "Kamera Aç";
            this.KameraAcRoundedButton.UseMnemonic = false;
            this.KameraAcRoundedButton.UseVisualStyleBackColor = true;
            this.KameraAcRoundedButton.Click += new System.EventHandler(this.KameraAcRoundedButton_Click);
            // 
            // MikrofonAcRoundedButton
            // 
            this.MikrofonAcRoundedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MikrofonAcRoundedButton.BackColor = System.Drawing.SystemColors.Control;
            this.MikrofonAcRoundedButton.Enabled = false;
            this.MikrofonAcRoundedButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.MikrofonAcRoundedButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.MikrofonAcRoundedButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MikrofonAcRoundedButton.Location = new System.Drawing.Point(341, 12);
            this.MikrofonAcRoundedButton.Name = "MikrofonAcRoundedButton";
            this.MikrofonAcRoundedButton.Radius = 15;
            this.MikrofonAcRoundedButton.Size = new System.Drawing.Size(94, 23);
            this.MikrofonAcRoundedButton.TabIndex = 26;
            this.MikrofonAcRoundedButton.Text = "Mikrofon Aç";
            this.MikrofonAcRoundedButton.UseMnemonic = false;
            this.MikrofonAcRoundedButton.UseVisualStyleBackColor = true;
            this.MikrofonAcRoundedButton.Click += new System.EventHandler(this.MikrofonAcRoundedButton_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(865, 463);
            this.Controls.Add(this.MikrofonAcRoundedButton);
            this.Controls.Add(this.KameraAcRoundedButton);
            this.Controls.Add(this.ResimGonderRoundedButton);
            this.Controls.Add(this.CikisYapRoundedButton);
            this.Controls.Add(this.FlowLayoutPanel);
            this.Controls.Add(this.ChatBoxGroupBox);
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
        private System.Windows.Forms.GroupBox ChatBoxGroupBox;
        private System.Windows.Forms.RichTextBox RichTextBox;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
        private Views.Events.RoundedButton CikisYapRoundedButton;
        private Views.Events.RoundedButton ResimGonderRoundedButton;
        private Views.Events.RoundedButton KameraAcRoundedButton;
        private Views.Events.RoundedButton MikrofonAcRoundedButton;
        private Views.Events.RoundedButton MesajGonderRoundedButton;
    }
}