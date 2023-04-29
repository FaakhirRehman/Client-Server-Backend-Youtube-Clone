using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Client_Side
{
    public partial class Video : Form
    {
        public static string videotitle = String.Empty,
                              videofilePath = String.Empty,
                              videofileUploader = String.Empty;

        public static int videoViews = 0,
                           videoLikes = 0,
                           videoDislikes = 0;
        
        TcpClient tcpClient = null;

        public Video()
        {
            InitializeComponent();
            tcpClient = new TcpClient("127.0.0.1", 8888);
        }

        private void Video_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            videotitle = "Afraid of Technology";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);
            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            videotitle = "Cat Stuck in Screen Door";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);

            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            videotitle = "Jump Around Dog in Box";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);

            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            videotitle = "Kid scared of frog";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);

            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            videotitle = "Sideways Attacking Kitty";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);

            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            videotitle = "Weeeee!";

            NetworkStream networkStream = tcpClient.GetStream();
            StreamWriter streamWriter = new StreamWriter(networkStream);
            streamWriter.WriteLine(videotitle);

            streamWriter.Flush();

            StreamReader streamReader = new StreamReader(networkStream);
            DataTable dt = Deserialize(streamReader.ReadLine());

            PlayVideo playVideo = new PlayVideo();
            playVideo.Show();
        }

        private DataTable Deserialize(string json)
        {
            DataTable dt = new DataTable();
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            DataContractJsonSerializer ser = new DataContractJsonSerializer(dt.GetType());

            dt = ser.ReadObject(memoryStream) as DataTable;


            foreach (DataRow dataRow in dt.Rows)
            {
                videotitle = (string)dataRow[1];
                videofileUploader = (string)dataRow[2];
                videoViews = (int)dataRow[3];
                videoLikes = (int)dataRow[4];
                videoDislikes = (int)dataRow[5];
                videofilePath = (string)dataRow[6];
            }

            return dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
