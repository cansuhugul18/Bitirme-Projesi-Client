
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCore;
namespace masaustuProgrami.Video
{
    public class PixelData
    {

        #region Variables

        public Point point;

         public  Color color;
        #endregion

        #region Constructor
        public PixelData(Point point,Color color)
        {
            this.color = color;
            this.point = point;
        }
        
        public byte[] ToByteArray()
        {
            var data = new ByteArray();
           

            data.Push(point.X.ToByteArray());
            data.Push(point.Y.ToByteArray());
            data.Push(color.R);
            data.Push(color.G);
            data.Push(color.B);


            return data.ToArray();
        }

        public static PixelData FromByteArray(byte[] bytes)
        {
            var pointx = new byte[4];
            
            pointx[0] = bytes[0];
            pointx[1] = bytes[1];
            pointx[2] = bytes[2];
            pointx[3] = bytes[3];

            var X = pointx.ToInt();

            var pointy = new byte[4];

            pointy[0] = bytes[4];
            pointy[1] = bytes[5];
            pointy[2] = bytes[6];
            pointy[3] = bytes[7];

            var Y = pointy.ToInt();

            var colorbytearray = new byte[3];

            colorbytearray[0] = bytes[8];
            colorbytearray[1] = bytes[9];
            colorbytearray[2] = bytes[10];

            //TODO: rgb to byte array
            var color = colorbytearray.ToColor();


            return new PixelData(new Point(X, Y), color);




        }
      

        #endregion
    }

}
