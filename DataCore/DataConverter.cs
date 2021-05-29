using System;
using System.Drawing;
using System.Text;

namespace DataCore
{
    public static class DataConverter
    {
        #region Static Methods

        public static byte[] ToByteArray(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string ToUTF8String(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ToByteArray(this Image image)
        {
            try
            {
                return (byte[])new ImageConverter().ConvertTo(image, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }

        public static Image ToImage(this byte[] bytes)
        {
            try
            {
                return (Image)new ImageConverter().ConvertFrom(bytes);
            }
            catch
            {
                return null;
            }
        }

        public static byte ToByte(this DataTypes dataType)
        {
            return (byte) dataType;
        }

        public static DataTypes ToDataTypes(this byte b)
        {
            return (DataTypes)b;
        }


         
        public static byte[] ToByteArray(this int n)
        {
            return BitConverter.GetBytes(n);
        }

        public static byte[] ToByteArray(this long n)
        {
            return BitConverter.GetBytes(n);
        }

        public static int ToInt(this byte[] bytes)
        {
            return BitConverter.ToInt32(bytes, 0);
        }

        public static long ToLong(this byte[] bytes)
        {
            return BitConverter.ToInt64(bytes, 0);
        }

        public static Color ToColor(this byte[] bytes)
        {
            return Color.FromArgb(bytes[0],bytes[1],bytes[2]);
        }


        #endregion
    }
}