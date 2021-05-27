using System;
using System.Drawing;

namespace DataCore
{
    public class DataHelper
    {
        #region  Degiskenler

        public static DataHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataHelper();

                return instance;
            }
        }

        private static DataHelper instance;

        #endregion

        #region Yapıcı Method

        private DataHelper()
        {
            Initailize();
        }

        #endregion

        #region Private Methods 

        private void Initailize()
        {

        }

        #endregion

        #region Public Methods

        public HeaderData GetHeaderData(long id, DataTypes dataType, int dataLength)
        {
            return new HeaderData(id, dataType, dataLength);
        }

        /// <summary>
        /// Gönderilicek veri data typeına göre byte dizisine çevirir
        /// </summary>
        /// <param name="dataType">Dönüştürülecek veri tipi</param>
        /// <param name="data">Dönüştürülecek veri</param>
        /// <returns></returns>
        public byte[] GetSendData(DataTypes dataType, object data)
        {
            switch (dataType)
            {
                case DataTypes.None:
                    throw new ArgumentException("Gecersiz veri tipi. Tip: " + dataType);
                case DataTypes.String:
                    return ((string) data).ToByteArray();
                case DataTypes.Image:
                    return ((Image) data).ToByteArray();
                case DataTypes.Sound:
                    return (byte[]) data;
                case DataTypes.PixelData:
                    return (byte[])data;
                case DataTypes.UserInfo:
                    return ((UserInfo)data).ToByteArray();
            }

            return null;
        }

        public object ProcessData(HeaderData header, byte[] data)
        {
            switch (header.DataType)
            {
                case DataTypes.None:
                    throw new ArgumentException("Gecersiz veri tipi.");
                case DataTypes.String:
                    return data.ToUTF8String();
                case DataTypes.Image:
                    return data.ToImage();
                case DataTypes.Sound:
                    return data;
                case DataTypes.PixelData:
                    return data;
                case DataTypes.UserInfo:
                    return UserInfo.FromByteArray(data);
            }

            return null;
        }

        #endregion
    }
}