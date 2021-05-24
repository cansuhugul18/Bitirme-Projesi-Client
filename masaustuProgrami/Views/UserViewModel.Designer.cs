
namespace masaustuProgrami.Views
{
    partial class UserViewModel
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.MicButton = new masaustuProgrami.Views.RoundButton();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.UserNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.White;
            this.UserNameLabel.Location = new System.Drawing.Point(0, 0);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(318, 182);
            this.UserNameLabel.TabIndex = 0;
            this.UserNameLabel.Text = "Name";
            this.UserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserNameLabel.Visible = false;
            this.UserNameLabel.MouseEnter += new System.EventHandler(this.Container_MouseEnter);
            this.UserNameLabel.MouseLeave += new System.EventHandler(this.Container_MouseLeave);
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BackColor = System.Drawing.Color.Transparent;
            this.PictureBox.Location = new System.Drawing.Point(0, 0);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Padding = new System.Windows.Forms.Padding(8);
            this.PictureBox.Size = new System.Drawing.Size(318, 182);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseEnter += new System.EventHandler(this.Container_MouseEnter);
            this.PictureBox.MouseLeave += new System.EventHandler(this.Container_MouseLeave);
            // 
            // MicButton
            // 
            this.MicButton.BackColor = System.Drawing.Color.DarkGray;
            this.MicButton.Image = global::masaustuProgrami.Properties.Resources.microphone;
            this.MicButton.Location = new System.Drawing.Point(134, 117);
            this.MicButton.Name = "MicButton";
            this.MicButton.RecessDepth = 0;
            this.MicButton.Size = new System.Drawing.Size(50, 50);
            this.MicButton.TabIndex = 3;
            this.MicButton.Text = null;
            this.MicButton.UseVisualStyleBackColor = false;
            this.MicButton.Visible = false;
            this.MicButton.Click += new System.EventHandler(this.MicButton_Click);
            // 
            // UserViewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.MicButton);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.UserNameLabel);
            this.Name = "UserViewModel";
            this.Size = new System.Drawing.Size(318, 182);
            this.Load += new System.EventHandler(this.UserCompoment_Load);
            this.SizeChanged += new System.EventHandler(this.UserCompoment_SizeChanged);
            this.MouseEnter += new System.EventHandler(this.Container_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Container_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.PictureBox PictureBox;
        private RoundButton MicButton;
    }
}
