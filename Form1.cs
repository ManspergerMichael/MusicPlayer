using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TagLib.Id3v2;
using System.Diagnostics;
namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                      
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            
            //file diolog box is opened and user selects a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //file path is displayed
                textBox1.Text = openFileDialog1.FileName;
            }
            //file is loaded into the WMP and played.
            Player.URL = textBox1.Text;

            
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.pause();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            Player.Ctlcontrols.stop();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            string songName = "";
            //string artist = "";
            string album = "";

            //extract title and album names Need proper MP3 file           
            var file = TagLib.File.Create(textBox1.Text);
            songName = file.Tag.Title;
            album = file.Tag.Album;
            //MessageBox.Show(songName + " " + album);
            songName = songName.Trim();
            songName = songName.Replace(" ", "_");
            MessageBox.Show(songName);

            //open browser to wikipedia page
            string targetURL = "@https://en.wikipedia.org/wiki/" + songName;

            Process.Start("chrome",targetURL);
        }
    }
}
