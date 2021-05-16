using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masaustuProgrami
{
    class UserInformation
    {
        #region Degiskenler

        public long usersId;

        public long roomId;

        public string username;
        #endregion

        public static UserInformation Instance
        {
            get
            {
                if (intance == null)
                    intance = new UserInformation();

                return intance;
            }
        }
        private static UserInformation intance = null;

        public const int UserDataLength = 32;
        public UserInformation(long usersId, long roomId, string username)
        {
            usersId = usersId;
            roomId = roomId;
            username = username;
        }

        public UserInformation()
        {
        }

        public byte[] ToByteArray(long usersId, long roomId, string username)
        {

            var userdata = new byte[UserDataLength];

            var idBytes = usersId.ToByteArray();
            userdata[0] = idBytes[0];
            userdata[1] = idBytes[1];
            userdata[2] = idBytes[2];
            userdata[3] = idBytes[3];
            userdata[4] = idBytes[4];
            userdata[5] = idBytes[5];
            userdata[6] = idBytes[6];
            userdata[7] = idBytes[7];

            var roomidbytes = roomId.ToByteArray();

            userdata[8] = roomidbytes[0];
            userdata[9] = roomidbytes[1];
            userdata[10] =roomidbytes[2];
            userdata[11] =roomidbytes[3];
            userdata[12] =roomidbytes[4];
            userdata[13] =roomidbytes[5];
            userdata[14] =roomidbytes[6];
            userdata[15] =roomidbytes[7];

            var usernamebytes = username.ToByteArray();
            userdata[16] = usernamebytes[0];
            userdata[17] = usernamebytes[1];
            userdata[18] = usernamebytes[2];
            userdata[19] = usernamebytes[3];
            userdata[20] = usernamebytes[4];
            userdata[21] = usernamebytes[5];
            userdata[22] = usernamebytes[6];
            userdata[23] = usernamebytes[7];



            // username için byte 
            return userdata;
        }

        }
}
