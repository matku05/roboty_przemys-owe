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
            //  Console.WriteLine(Variables.ip_addr);
            IPAddress ipAd = IPAddress.Parse(Variables.ip_addr);
            //  IPAddress ipAd = IPAddress.Parse(Variables.ip_addr);
            TcpListener myList = new TcpListener(ipAd, 8001);

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

        public  void bt_SERVER_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Variables.ip_addr = CB_ip_adress.Text;
                //  Console.WriteLine(Variables.ip_addr);
                IPAddress ipAd = IPAddress.Parse(Variables.ip_addr);
                //  IPAddress ipAd = IPAddress.Parse(Variables.ip_addr);
                TcpListener myList = new TcpListener(ipAd, 8001);

                myList.Start();
                Socket s = myList.AcceptSocket();

                byte[] b = new byte[100];
                int k = s.Receive(b);
                
                tb_connect_android.Text = ("Recieved...");
                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(b[i]));

                ASCIIEncoding asen = new ASCIIEncoding();
                s.Send(asen.GetBytes("The string was recieved by the server."));
                Console.WriteLine("\nSent Acknowledgement");
                tb_connect_android.Text = ("Recieved..." +  "Sent Acknowledgement");
                /* clean up */
                s.Close();
                myList.Stop();
                tb_connect_android.Text = "połączono";

            }
            catch (Exception )
            {
                Console.WriteLine("bląd"  );
                tb_connect_android.Text = "nie połączono";
            }

           

        }

        public void bt_server_stop_Click(object sender, RoutedEventArgs e)
        {
            Socket s = myList.AcceptSocket();
            s.Close();
            myList.Stop();
            tb_connect_android.Text = "połączono";
        }
    }
}

