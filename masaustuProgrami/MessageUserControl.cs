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
    public partial class MessageUserControl : UserControl
    {
        #region Variables

        string userName;

        string message;

        #endregion

        #region Constructor
        public MessageUserControl(string userName, string message)
        {
            this.userName = userName;

            this.message = message;

            InitializeComponent();

            WriteMessage();
         
        }
        public MessageUserControl(string message)
        {
            this.userName = "";

            this.message = message;

            InitializeComponent();

            OnlyWriteMessage();
        }

        #endregion

        #region public methods
        public void WriteMessage()
        {
            MessageLabel.Text = "" + userName + ": " + message;
        }

        public void OnlyWriteMessage()
        {
            MessageLabel.Text = message;
        }

        #endregion

    }
}
