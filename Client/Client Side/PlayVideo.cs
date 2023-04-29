using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Side
{
    public partial class PlayVideo : Form
    {
        String videoPath = String.Empty;
        public PlayVideo()
        {
            InitializeComponent();
        }

        private void PlayVideo_Load(object sender, EventArgs e)
        {
            label1.Text = Video.videotitle;
            label2.Text = Video.videofileUploader;
            label3.Text = Convert.ToString(Video.videoViews);
            label4.Text = Convert.ToString(Video.videoLikes);
            label5.Text = Convert.ToString(Video.videoDislikes);
            axWindowsMediaPlayer1.URL = Video.videofilePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
    }
}
