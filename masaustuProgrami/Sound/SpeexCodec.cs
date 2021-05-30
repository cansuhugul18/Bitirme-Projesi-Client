using NAudio.Wave;
using NSpeex;
using System;
using System.Diagnostics;

namespace masaustuProgrami.Sound
{
    public class SpeexCodec
    {
        private readonly WaveFormat recordingFormat;
        private readonly SpeexDecoder decoder;
        private readonly SpeexEncoder encoder;
        private readonly WaveBuffer encoderInputBuffer;

        public SpeexCodec()
        {
            decoder = new SpeexDecoder(BandMode.UltraWide);
            encoder = new SpeexEncoder(BandMode.UltraWide);
            recordingFormat = new WaveFormat(16000, 16, 1);

            encoderInputBuffer = new WaveBuffer(recordingFormat.AverageBytesPerSecond);
        }

        // datayı ,kodlayıcının boyutuna göre daha küçük boyutlu data haline getiriyor. (sıkıştırıyor)
        public byte[] Encode(byte[] data, int offset, int length)
        {
            FeedSamplesIntoEncoderInputBuffer(data, offset, length);
            int samplesToEncode = encoderInputBuffer.ShortBufferCount;// mesela samplestoencode=8320 
            if (samplesToEncode % encoder.FrameSize != 0) // framesize=640
            {
                samplesToEncode -= samplesToEncode % encoder.FrameSize; //framesize tam boyutuna bölünecek 
            }
            var outputBufferTemp = new byte[length];
            // sıkıştırılmış sesin kaç byte olacağını döndürüyor encode fonksiyonu
            int bytesWritten = encoder.Encode(encoderInputBuffer.ShortBuffer, 0, samplesToEncode, outputBufferTemp, 0, length);
            var encoded = new byte[bytesWritten]; //sıkıştırılmış byte dizisi
            Array.Copy(outputBufferTemp, 0, encoded, 0, bytesWritten);
            ShiftLeftoverSamplesDown(samplesToEncode);
            Debug.WriteLine(
               $"NSpeex: In {length} bytes, encoded {bytesWritten} bytes [enc frame size = {encoder.FrameSize}]");
            return encoded;
        }

        private void ShiftLeftoverSamplesDown(int samplesEncoded)
        {
            int leftoverSamples = encoderInputBuffer.ShortBufferCount - samplesEncoded;
            Array.Copy(encoderInputBuffer.ByteBuffer, samplesEncoded * 2, encoderInputBuffer.ByteBuffer, 0, leftoverSamples * 2);
            encoderInputBuffer.ShortBufferCount = leftoverSamples;
        }

        private void FeedSamplesIntoEncoderInputBuffer(byte[] data, int offset, int length)
        {
            Array.Copy(data, offset, encoderInputBuffer.ByteBuffer, encoderInputBuffer.ByteBufferCount, length);
            encoderInputBuffer.ByteBufferCount += length;
        }
        // aldığımız verileri
        public byte[] Decode(byte[] data, int offset, int length)
        {
            var outputBufferTemp = new byte[length * 320];
            var wb = new WaveBuffer(outputBufferTemp);
            int samplesDecoded = decoder.Decode(data, offset, length, wb.ShortBuffer, 0, false);
            int bytesDecoded = samplesDecoded * 2;
            var decoded = new byte[bytesDecoded];
            Array.Copy(outputBufferTemp, 0, decoded, 0, bytesDecoded);
            Debug.WriteLine(
              $"NSpeex: In {length} bytes, decoded {bytesDecoded} bytes [dec frame size = {decoder.FrameSize}]");
            Console.WriteLine("" + decoded);
            return decoded;
        }

        public void Dispose()
        {
            // nothing to do
        }



    }
}
