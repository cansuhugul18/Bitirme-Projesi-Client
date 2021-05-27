using System;
using DataCore;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Shared.Helpers;


namespace masaustuProgrami.Video
{
    public class ImageProcessing
    {
        #region Variables

        Bitmap picOld, picNew;

        private static ImageProcessing instance = null;

        public Client Client { get; private set; }

        public List<ColorPoint> ColorPointList = new List<ColorPoint>();

        #endregion

        #region Properties
        public static ImageProcessing Instance
        {
            get
            {
                if (instance == null)
                    instance = new ImageProcessing();

                return instance;
            }
        }
        #endregion

        #region Constructor

        private ImageProcessing()
        {
            Initialize();
            
        }


        #endregion


        #region private methods

        private void Initialize()
        {
            Client = Client.Instance;


        }

        #endregion


        #region public methods

        public void CompareBitmap(Bitmap picOld, Bitmap picNew)
        {
           
            int width = picOld.Width;

            int height = picOld.Height;

            Color colorold, colornew;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    colorold = picOld.GetPixel(i, j);

                    colornew = picNew.GetPixel(i, j);

                    int coloroldaverage = (colorold.R + colorold.G + colorold.B) / 3;

                    int colornewaverage = (colornew.R + colornew.G + colornew.B)/3;

                    int difference = colornewaverage - coloroldaverage;


                    if (Math.Abs(difference)>50) 
                    {
                        ColorPoint colorpoint = new ColorPoint(new Point(i, j), colornew);

                        ColorPointList.Add(colorpoint);

                    }

                }

            }

            byte[] colorpointarray = new byte[ColorPointList.Count];

            colorpointarray.CopyTo(ColorPointList);

            ColorPointList.Clear();

            Client.Send(DataTypes.PixelData, colorpointarray);
        }

        #endregion


    }
}