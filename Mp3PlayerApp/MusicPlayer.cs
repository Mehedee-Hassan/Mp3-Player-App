using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Mp3PlayerApp
{
    class MusicPlayer
    {

        [DllImport("winmm.dll")]


        private static extern long mciSendString(string a ,StringBuilder b ,int c, IntPtr d   );


//        private static extern long mciSendString(string a, StringBuilder b, int c, int d);


        public void Open(string file)
        {

            string command = "open \"" + file + "\" type MPEGVideo alias MP3";
            mciSendString(command, null, 0, IntPtr.Zero);
            
        }

        public void Play()
        {
            string command = "play MP3";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Pause()
        {
            string command = "pause MP3";
            mciSendString(command, null, 0, IntPtr.Zero);
        }

        public void Stop()
        {
            string command = "stop MP3";
            mciSendString(command, null, 0, IntPtr.Zero);


            command = "close MP3";
            mciSendString(command, null, 0, IntPtr.Zero);
        }


        public string GetMp3Length()
        {


            string command = "status mediafile length";
            
            StringBuilder sb = new StringBuilder(128);


            mciSendString(command, sb, 128, IntPtr.Zero);

           // long songLength = Convert.ToInt64(sb.ToString());


            //return songLength;
            return sb.ToString();

        }

    }
}
