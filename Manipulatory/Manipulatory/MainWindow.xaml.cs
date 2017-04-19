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

        public void bt_server_stop_Click(object sender, RoutedEventArgs e)
            {
                Thread tcpServerRunThread = new Thread(new ThreadStart(TcpServerRun));
                tcpServerRunThread.Start();
            }

        private void TcpServerRun()
        {
            TcpListener tcpLisner = new TcpListener(IPAddress.Any, 5004);
            tcpLisner.Start();
            updateUI("listening");
            while (true)
            {
                TcpClient client = tcpLisner.AcceptTcpClient();
                updateUI("connected");
                Thread tcpHandlerThread = new Thread(new ParameterizedThreadStart(tcpHandler));
                tcpHandlerThread.Start(client);
            }


        }

        private void tcpHandler(object client)
        {
            TcpClient mClient = (TcpClient)client;
            NetworkStream stream = mClient.GetStream();
            byte[] message = new byte[1024];
            stream.Read(message, 0, message.Length);
            updateUI("new message = " + Encoding.ASCII.GetString(message));
            stream.Close();
            mClient.Close();

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
            //TcpServerRun();
            Thread tcpServerRunThread = new Thread(new ThreadStart(TcpServerRun));
            tcpServerRunThread.Start();
        }

        private void tb_connect_android_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}

