using DataCore;
using NAudio.Wave;
using System;

namespace masaustuProgrami.Sound
{
    /// <summary>
    /// Her bir kullanıcdan gelen sesleri çalan sınıf ve yöneten sınıf
    /// </summary>
    public class SoundPlayer : IDisposable
    {
        #region Variables

        private IWavePlayer player;

        private BufferedWaveProvider provider;

        private float volume = 1;

        #endregion

        #region Constructor

        public SoundPlayer(UserInfo userInfo)
        {
            UserInfo = userInfo;

            Initialize();
        }

        #endregion

        #region Priate Methods

        private void Initialize()
        {
            player = new WaveOut();
            provider = new BufferedWaveProvider(new WaveFormat());

            provider.DiscardOnBufferOverflow = true;
            player.Init(provider);
            player.Play(); // belki direk play edilmez
        }

        #endregion

        #region Properties

        public UserInfo UserInfo { get; private set; }

        public bool IsMuted { get; private set; }

        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;

                if (!IsMuted)
                    player.Volume = volume;
            }
        }

        #endregion

        #region Public Methods

        public void Play(byte[] data)
        {
            provider.AddSamples(data, 0, data.Length);
        }

        public void Stop()
        {
            player.Stop();
        }

        public void Mute()
        {
            volume = player.Volume;
            player.Volume = 0;


            IsMuted = true;
        }

        public void UnMute()
        {
            player.Volume = volume;

            IsMuted = false;
        }

        public void Dispose()
        {
            Stop();

            player.Dispose();
            provider.ClearBuffer();
        }

        #endregion
    }
}