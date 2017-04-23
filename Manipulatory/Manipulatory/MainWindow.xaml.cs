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

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public TcpClient mClient;
        public TcpClient client;
        public NetworkStream stream;
        public TcpListener tcpListener;
        public SerialPort Sp;
        // Połączenie z robotem
        private void bt_connect_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Sp = new SerialPort();
                Sp.Parity = Parity.Even;
                Sp.StopBits = StopBits.Two;
                Sp.DataBits = 8;
                Sp.PortName = "COM3";
                Sp.BaudRate = 9600;
               // tb_status.Text = cb_nr_port.Text;
                Sp.Open();
                tb_status.Text = "Connection established";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message.ToString());
            }
        }
        private void responseData()
        {
            byte[] message = new byte[64];
             // string men = new string(message);
           // tb_wh.AppendText("pozycja: " + Encoding.ASCII.GetBytes(message));
            int i;
            string data;
            while ((i = Sp.Read(message, 0, message.Length)) != 0)
            {
                data = System.Text.Encoding.ASCII.GetString(message, 0, i);
                tb_wh.AppendText(data);
            }
        }
        //Rozłączenie z robotem
        private void bt_disconnect_Click_1(object sender, RoutedEventArgs e)
        {
            Sp.Close();
        }
        private void bt_disconnect2_Click(object sender, RoutedEventArgs e)
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
        private void bt_go_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("GO \r");
        }
        private void bt_wh_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("WH \r");
            responseData();
        }
        private void bt_WH2_Click(object sender, RoutedEventArgs e)
        {
            Sp.Write("WH \r");
            responseData();
        }
        /// obsługa serwera
        //rozłączanie serwera 
        public void bt_server_stop_Click(object sender, RoutedEventArgs e)
        {
            ServerStop();
        }
        private void ServerStop()
        {
            // destrukcja klienta           
            client.Close();
            stream.Close();
            mClient.Close();

            client = null;
            mClient = null;
        }
        //inicjalizacja serwera 
        private void TcpServerRun()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 5004);
            tcpListener.Start();
            updateUI("listening");
            while (true)
            {
                client = tcpListener.AcceptTcpClient();
                updateUI("connected");
                Thread tcpHandlerThread = new Thread(new ParameterizedThreadStart(tcpHandler));
                tcpHandlerThread.Start(client);
            }
        }
        // otwarcie strumienia i odbiór ramki
        private void tcpHandler(object client)
        {
            byte[] message = new byte[50];
            String data = null;
            int i;
            while (true)
            { 
                mClient = (TcpClient)client;
                stream = mClient.GetStream();
                try
                {
                    while ((i = stream.Read(message, 0, message.Length)) != 0)
                    {

                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(message, 0, i);
                        //SendToRobot(System.Text.Encoding.ASCII.GetString(message, 0, i));         
                        //Sp.Write(System.Text.Encoding.ASCII.GetString(message, 0, i));
                        string messa = Encoding.ASCII.GetString(message);
                        updateUI("new message =' " + messa + "'");
                        Array.Clear(message, 0, message.Length);
                        messa = null;
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                }
            }
        }
        private void SendToRobot(string message)
        {
         //   Sp.Write(message);
            tb_position_list.AppendText(message + System.Environment.NewLine );
        }
        private void updateUI(string s)
        {
            tb_connect_android.Dispatcher.Invoke(
               DispatcherPriority.Normal,
               new Action(
                   () =>
                   {
                       tb_connect_android.AppendText(s + System.Environment.NewLine);
                   }
               )
           );
        }
        private void bt_SERVER_Click(object sender, RoutedEventArgs e)
        {
            Thread tcpServerRunThread = new Thread(new ThreadStart(TcpServerRun));
            tcpServerRunThread.Start();
        }
        private void bt_send_position_Click(object sender, RoutedEventArgs e)
        {
            string position = tb_console.Text;
            SendToRobot(position);
        }
        private void tb_connect_android_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_wh_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_Wh_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_console_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_position_list_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

