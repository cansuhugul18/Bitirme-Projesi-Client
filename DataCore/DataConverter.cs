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
            return (byte[]) new ImageConverter().ConvertTo(image, typeof(byte[]));
        }

        public static Image ToImage(this byte[] bytes)
        {
            return (Image) new ImageConverter().ConvertFrom(bytes);
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

        #endregion
    }
}