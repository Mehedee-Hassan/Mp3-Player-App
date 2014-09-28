using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mp3PlayerApp
{
    public partial class Mp3PlayerForm : Form
    {

        MusicPlayer aMusicPlayer ;
        public Mp3PlayerForm()
        {
            aMusicPlayer = new MusicPlayer();

            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            aMusicPlayer.Play();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            mp3FileOpenFileDialog.ShowDialog();
            string length = aMusicPlayer.GetMp3Length();

            endTimeLabel.Text = length.ToString();
        }

        private void mp3FileOpenFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            songLabel.Text = mp3FileOpenFileDialog.FileName;

            string[] nameOnly = songLabel.Text.Split(new char[]{'\\',' ','/'});
            songLabel.Text = nameOnly[nameOnly.Length - 1];


            aMusicPlayer.Open(mp3FileOpenFileDialog.FileName);
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            aMusicPlayer.Pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            aMusicPlayer.Stop();
        }

    }
}
