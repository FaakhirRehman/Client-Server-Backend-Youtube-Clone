using System;
using System.Net.Sockets;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(8888);
            server.Start();

            Console.WriteLine("Server Started!");

            Socket socket = server.AcceptSocket();

            NetworkStream networkStream = new NetworkStream(socket);
            StreamWriter streamWriter = new StreamWriter(networkStream);

            DataTable dt = new DataTable();

            Console.WriteLine("Server >> Client Connected!");

            while (socket.Connected)
            {
                StreamReader streamReader = new StreamReader(networkStream);

                dt = videoFetch(streamReader.ReadLine());

                dt.TableName = "video";

                string json = Serialize(dt);

                streamWriter.WriteLine(json);

                streamWriter.Flush();  
            }

            streamWriter.Close();
            networkStream.Close();
            socket.Close();   
        }

        private static string Serialize(DataTable dt)
        {
            
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(dt.GetType());

            ser.WriteObject(ms, dt);

            byte[] json = ms.ToArray();
            
            return Encoding.UTF8.GetString(json);
        }

        static DataTable videoFetch(string vidName)
        {
            string cs = @"Data Source=DESKTOP-7OA3VBT;Initial Catalog=YOUTUBE;Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            Console.WriteLine("Video Name is " + vidName);
            string query = "select * from video where videoName='" + vidName + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine(dataRow[0]);
                Console.WriteLine(dataRow[1]);
                Console.WriteLine(dataRow[2]);
                Console.WriteLine(dataRow[3]);
                Console.WriteLine(dataRow[4]);
                Console.WriteLine(dataRow[5]);
                Console.WriteLine(dataRow[6]);
            }

            return dt;
        }
    }
}