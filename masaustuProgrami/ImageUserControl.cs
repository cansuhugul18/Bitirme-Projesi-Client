using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace masaustuProgrami
{
    public partial class ImageUserControl : UserControl
    {
        #region Variables

        public string userName;

        public Image image;

        #endregion

        #region Constructor
        public ImageUserControl(string userName, Image image)
        {         
            this.userName=userName;
            this.image=image;
            
            InitializeComponent();
            Initialize();
        }

        #endregion
        #region public methods
        public void Initialize()
        {
            UserNameLabel.Text = "" + userName + ": ";

            PictureBox.Image = image;
        }
        #endregion
    }
}
