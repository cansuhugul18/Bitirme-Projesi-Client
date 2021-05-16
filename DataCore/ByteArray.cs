using System.Collections.Generic;

namespace DataCore
{
    public class ByteArray
    {
        #region Degiskenler

        private List<byte> Array = new List<byte>();

        public int Length { get; private set; }

        #endregion

        #region Constructor

        public ByteArray(int length = 0)
        {
            Length = length;
        }

        #endregion

        #region Public Methodlar

        public void Push(int number)
        {
            Array.AddRange(number.ToByteArray());
        }

        public void Push(long number)
        {
            Array.AddRange(number.ToByteArray());
        }

        public void Push(string s)
        {
            Array.AddRange(s.ToByteArray());
        }

        public void Push(byte b)
        {
            Array.Add(b);
        }

        public void Push(IEnumerable<byte> b)
        {
            Array.AddRange(b);
        }

        public byte[] ToArray()
        {
            if(Length <= 0)
                return Array.ToArray();

            var data = Array.ToArray();
            var array = new byte[Length];

            if(Length > data.Length)
            {
                for (int i = 0; i < data.Length; i++)
                    array[i] = data[i];
            }
            else
            {
                for (int i = 0; i < Length; i++)
                    array[i] = data[i];
            }
            
            return array;
        }

        #endregion

        #region Private Methodlar


        #endregion
    }
}
