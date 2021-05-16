using DataCore;
using masaustuProgrami.Sound;
using NAudio.Wave;
using System.Collections.Generic;

namespace masaustuProgrami.Helpers
{
    public class SoundHelper
    {
        #region Variables

        private static SoundHelper instance = null;

        private WaveInEvent recorder;

        private Dictionary<long, SoundPlayer> SoundPlayers = new Dictionary<long, SoundPlayer>();

        public SpeexCodec speexcodec = new SpeexCodec();

        #endregion

        #region Constructor

        private SoundHelper()
        {
            Initialize();
        }

        #endregion

        #region Properties

        public static SoundHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new SoundHelper();

                return instance;
            }
        }

        public Client Client { get; private set; }

        public bool IsRecording { get; private set; }

        public SoundPlayer this[long id]
        {
            get
            {
                if (SoundPlayers.TryGetValue(id, out var player))
                    return player;

                return null;
            }
        }

        public SoundPlayer this[UserInfo userInfo]
        {
            get
            {
                if (SoundPlayers.TryGetValue(userInfo.UserId, out var player))
                    return player;

                return null;
            }
        }

        #endregion

        #region Private Methods

        private void Initialize()
        {
            Client = Client.Instance;

            recorder = new WaveInEvent
            {
                DeviceNumber = 0,
                WaveFormat = new WaveFormat(44100, WaveInEvent.GetCapabilities(0).Channels)
            };

            recorder.DataAvailable += Recorder_DataAvailable;
        }

        #endregion

        #region Events

        private void Recorder_DataAvailable(object sender, WaveInEventArgs e)
        {
            // sıkıştırıp gönderme kısmını

            byte[] encoded = speexcodec.Encode(e.Buffer, 0, e.Buffer.Length);
            Client.Send(DataTypes.Sound, encoded);
        }

        #endregion

        #region Public Methods

        public void StartMic()
        {
            recorder.StartRecording();

            IsRecording = true;
        }

        public void StopMic()
        {
            recorder.StopRecording();

            IsRecording = false;
        }

        public void PlaySound(UserInfo userInfo, byte[] sound)
        {
            PlaySound(userInfo.UserId, sound);
        }

        public void PlaySound(long userId, byte[] sound)
        {
            if (SoundPlayers.TryGetValue(userId, out var player))
            {
                if (player.IsMuted)
                    return;

                byte[] decodedsound = speexcodec.Decode(sound, 0, sound.Length);
                player.Play(decodedsound);
            }
        }

        public void MuteUser(UserInfo userInfo)
        {
            if (SoundPlayers.TryGetValue(userInfo.UserId, out var player))
                player.Mute();
        }

        public void MuteUser(long userId)
        {
            if (SoundPlayers.TryGetValue(userId, out var player))
                player.Mute();
        }

        public void UnMuteUser(UserInfo userInfo)
        {
            if (SoundPlayers.TryGetValue(userInfo.UserId, out var player))
                player.UnMute();
        }

        public void UnMuteUser(long userId)
        {
            if (SoundPlayers.TryGetValue(userId, out var player))
                player.UnMute();
        }

        public void SetVolumeUser(UserInfo userInfo, float volume)
        {
            if (SoundPlayers.TryGetValue(userInfo.UserId, out var player))
                player.Volume = volume;
        }

        public void SetVolumeUser(long userId, float volume)
        {
            if (SoundPlayers.TryGetValue(userId, out var player))
                player.Volume = volume;
        }

        public void AddUser(UserInfo userInfo)
        {
            if (SoundPlayers.ContainsKey(userInfo.UserId))
                return;

            SoundPlayers.Add(userInfo.UserId, new SoundPlayer(userInfo));
        }

        public void RemoveUser(UserInfo userInfo)
        {
            var userId = userInfo.UserId;

            if (!SoundPlayers.ContainsKey(userId))
                return;

            var player = SoundPlayers[userId];

            SoundPlayers.Remove(userId);

            player.Dispose();
        }

        #endregion
    }
}