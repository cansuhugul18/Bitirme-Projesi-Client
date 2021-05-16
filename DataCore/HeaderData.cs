namespace DataCore
{
    public class HeaderData
    {
        #region Degiskenler

        public long Id { get; set; }

        public DataTypes DataType { get; set; }

        public int DataLength { get; set; }

        /// <summary>
        /// 8 byte => Id
        /// 1 byte => Data Type
        /// 4 byte => Data Size (int int olarak kodlancak)
        /// </summary>
        public const int HeaderLength = 16; // Gonderilcek verinin başlık verisi boyutu. (bytes)

        #endregion

        #region Constructor

        public HeaderData(long id, DataTypes dataTypes, int dataLength)
        {
            Id = id;
            DataType = dataTypes;
            DataLength = dataLength;
        }

        #endregion

        #region Private Methods

        
        #endregion

        #region Public Methods

        public byte[] ToByteArray()
        {
            var headerData = new ByteArray(HeaderLength);

            headerData.Push(Id.ToByteArray());
            headerData.Push(DataType.ToByte());

            headerData.Push(DataLength.ToByteArray());

            return headerData.ToArray();
        }

        public static HeaderData FromByteArray(byte[] bytes)
        {
            var idBytes = new byte[8];

            idBytes[0] = bytes[0];
            idBytes[1] = bytes[1];
            idBytes[2] = bytes[2];
            idBytes[3] = bytes[3];
            idBytes[4] = bytes[4];
            idBytes[5] = bytes[5];
            idBytes[6] = bytes[6];
            idBytes[7] = bytes[7];

            var id = idBytes.ToLong();

            var dataType = bytes[8].ToDataTypes();

            var dataLengthBytes = new byte[4];
            dataLengthBytes[0] = bytes[9];
            dataLengthBytes[1] = bytes[10];
            dataLengthBytes[2] = bytes[11];
            dataLengthBytes[3] = bytes[12];

            var dataLength = dataLengthBytes.ToInt();

            return new HeaderData(id, dataType, dataLength);
        }

        #endregion
    }
}