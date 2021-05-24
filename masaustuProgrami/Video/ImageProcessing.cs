using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Shared.Helpers;

namespace masaustuProgrami.Video
{
    class ImageProcessing
    {
        #region Variables

        Bitmap picOld, picNew;


        #endregion

        #region Constructor

        public ImageProcessing()
        {

            
        }
        #endregion
        #region public methods
        public byte[] Comparebitmap(Bitmap picOld, Bitmap picNew)
        {
            

            List<ColorPoint> ColorPointList = new List<ColorPoint>();
           

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

                    if (Math.Abs(colornewaverage-coloroldaverage)>50) //sadece biri de olabilir.
                    {
                        ColorPoint colorpoint = new ColorPoint(new Point(i, j), colornew);

                        ColorPointList.Add(colorpoint);

                    }

                }

            }
            byte[] colorpointarray = new byte[ColorPointList.Count];
            colorpointarray.CopyTo(ColorPointList);

            return colorpointarray;
        }

        #endregion


    }
}