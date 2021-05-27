
namespace masaustuProgrami.Views
{
    partial class RoundedTextBox
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
            this.components = new System.ComponentModel.Container();
            this.roundedButton1 = new masaustuProgrami.Views.Events.RoundedButton(this.components);
            this.SuspendLayout();
            // 
            // roundedButton1
            // 
            this.roundedButton1.Location = new System.Drawing.Point(0, 0);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Radius = 15;
            this.roundedButton1.Size = new System.Drawing.Size(75, 23);
            this.roundedButton1.TabIndex = 0;
            this.roundedButton1.Text = "roundedButton1";
            this.roundedButton1.UseVisualStyleBackColor = true;
            this.ResumeLayout(false);

        }

        #endregion

        private Events.RoundedButton roundedButton1;
    }
}
