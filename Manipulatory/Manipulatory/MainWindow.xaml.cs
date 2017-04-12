using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net;
using System.Windows.Threading;
using System.IO.Ports;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Net.Sockets;




namespace Manipulatory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Variables
    {
        public static string ip_addr = "";
        public static int port;
        public static string tryb = "";

        public static bool wasd = false;



    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void zmienne()
        {
            Variables.ip_addr = CB_ip_adress.Text;
      
        }
        public SerialPort Sp;
        public delegate void NoArgDelegate();

       



        // Połączenie z robotem

        private void bt_connect_Click_1(object sender, RoutedEventArgs e)
        {
            try{
                Sp = new SerialPort();
                Sp.Parity = Parity.Even;
                Sp.StopBits = StopBits.Two;
                Sp.DataBits = 8;
                Sp.PortName = cb_nr_port.Text;
                tb_status.Text = cb_nr_port.Text;
                Sp.Open();
                tb_status.Text = "Connection established";

                }
            catch(Exception x){

                MessageBox.Show(x.Message.ToString());
            }
        }

        //Rozłączenie z robotem


        private void bt_disconnect_Click_1(object sender, RoutedEventArgs e)
        {
            Sp.Close();
        }

        //Sterowanie w osiach XYZ

        private void bt_x_left_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS -1,0,0 \r");
        }

        private void bt_x_right_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS 1,0,0 \r");
        }

        private void bt_y_left_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS 0,-1,0 \r");
        }

        private void bt_y_right_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS 0,1,0 \r");
        }

        private void bt_z_left_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS 0,0,-1 \r");
        }

        private void bt_z_right_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("DS 0,0,1 \r");
        }

        private void bt_gc_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("GC \r");
        }

        private void bt_disconnect2_Click(object sender, RoutedEventArgs e)
        {
            Sp.Close();
        }

        private void bt_go_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("GO \r");
        }
        TcpListener server = null;
        public  void bt_SERVER_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException xe)
            {
                Console.WriteLine("SocketException: {0}", xe);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();


        }

        public void bt_server_stop_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

