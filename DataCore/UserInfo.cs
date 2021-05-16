using System;

namespace DataCore
{
    public  class UserInfo
    {
        public long UserId { get; set; }

        public long RoomId { get; set; }

        public string Username { get; set; }


        public UserInfo(long userId, long roomId, string username)
        {
            UserId = userId;
            RoomId = roomId;
            Username = username;
        }

        public byte[] ToByteArray()
        {
            var data = new ByteArray();

            data.Push(UserId.ToByteArray());
            data.Push(RoomId.ToByteArray());
            data.Push(Username.ToByteArray());
           
            return data.ToArray();
        }

        public static UserInfo FromByteArray(byte[] bytes)
        {
            var useridBytes = new byte[8];
            
            useridBytes[0] = bytes[0];
            useridBytes[1] = bytes[1];
            useridBytes[2] = bytes[2];
            useridBytes[3] = bytes[3];
            useridBytes[4] = bytes[4];
            useridBytes[5] = bytes[5];
            useridBytes[6] = bytes[6];
            useridBytes[7] = bytes[7];
            
            var userid = useridBytes.ToLong();

            var roomidbytes = new byte[8];
            roomidbytes[0] = bytes[8];
            roomidbytes[1] = bytes[9];
            roomidbytes[2] = bytes[10];
            roomidbytes[3] = bytes[11];
            roomidbytes[4] = bytes[12];
            roomidbytes[5] = bytes[13];
            roomidbytes[6] = bytes[14];
            roomidbytes[7] = bytes[15];

            var roomid = roomidbytes.ToLong();

            //yukarda toplamda 16 byte veri var geri kalan ise kullanıcı ismi olmakta

            var usernamebytes = new byte[bytes.Length - 16];

            Array.Copy(bytes, 16, usernamebytes, 0, usernamebytes.Length); 

            var username = usernamebytes.ToUTF8String();

            return new UserInfo(userid, roomid, username);
        }
    }
}
