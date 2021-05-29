using DataCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace masaustuProgrami.Video
{
    public class ImageProcessing
    {
        #region Variables

        private Bitmap picOld;
        private Bitmap picNew;

        private static ImageProcessing instance = null;

        public Client Client { get; private set; }

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

            UnsafeBitmap oldImage = new UnsafeBitmap(picOld);
            UnsafeBitmap newImage = new UnsafeBitmap(picNew);

            oldImage.LockBitmap();
            newImage.LockBitmap();

            ByteArray pointArray = new ByteArray();

            const int diff = 5;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var colorold = oldImage.GetPixel(i, j);
                    var colornew = newImage.GetPixel(i, j);

                    int coloroldaverage = (colorold.red + colorold.green + colorold.blue) / 3;
                    int colornewaverage = (colornew.red + colornew.green + colornew.blue) / 3;
                    int difference = colornewaverage - coloroldaverage;

                    if (Math.Abs(colorold.red - colornew.red) > diff || Math.Abs(colorold.green - colornew.green) > diff || Math.Abs(colorold.blue - colornew.blue) > diff)
                    {
                        PixelData colorpoint = new PixelData(new Point(i, j), Color.FromArgb(colornew.red,colornew.green,colornew.blue));
                        
                        byte[] colorpointbyte = colorpoint.ToByteArray();
                        
                        pointArray.Push(colorpointbyte);
                    }
                }
            }

            oldImage.UnlockBitmap();
            newImage.UnlockBitmap();

            Client.Send(DataTypes.PixelData, pointArray.ToArray());
        }

        public Image ApplyPixelDataToImage(Bitmap currentImage, IList<PixelData> colors)
        {
            UnsafeBitmap unsafeBitmap = new UnsafeBitmap(currentImage);
            unsafeBitmap.LockBitmap();

            foreach (PixelData color in colors)
                unsafeBitmap.SetPixel(color.point.X, color.point.Y, color.color);

            unsafeBitmap.UnlockBitmap();

            Console.WriteLine("C " + colors.Count);

            return unsafeBitmap.Bitmap;
        }

        public IList<PixelData> GetPixelDataFrom(byte[] data)
        {
            var list = new List<PixelData>();

            for(var i = 0; i < data.Length; i += 11)
            {
                var slice = new byte[11];

                for (var l = 0; l < 11; l++)
                    slice[l] = data[i + l];

                list.Add(PixelData.FromByteArray(slice));
            }

            //list.Add(PixelData.FromByteArray(data.Skip(i).Take(11).ToArray()));

            return list;
        }

        #endregion
    }
}