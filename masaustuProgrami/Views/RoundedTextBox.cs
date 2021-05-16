using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace masaustuProgrami.Views
{
    public partial class RoundedTextBox : TextBox
    {
        [EditorBrowsable]
        public int Radius { get; set; } = 15;

        public RoundedTextBox()
        {
            InitializeComponent();
        }

        public RoundedTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // X-coordinate of upper-left corner or padding at start
            int nTopRect,// Y-coordinate of upper-left corner or padding at the top of the textbox
            int nRightRect, // X-coordinate of lower-right corner or Width of the object
            int nBottomRect,// Y-coordinate of lower-right corner or Height of the object
                            //RADIUS, how round do you want it to be?
            int nheightRect, //height of ellipse 
            int nweightRect //width of ellipse
        );

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, Radius, Radius)); //play with these values till you are happy
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(2, 3, this.Width, this.Height, Radius, Radius)); //play with these values till you are happy
        }
    }
}
