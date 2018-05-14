using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
namespace TicTacToe
{

    public class User
    {
        UdpClient My;
        UdpClient MyChat;
        public string MyIP;
        public string MyPort;
        public string MyPortChat;
        public string IP;
        public string Port;
        public string PortChat;

        public void Create()
        {
            My      = new UdpClient(new IPEndPoint(IPAddress.Parse(MyIP), Convert.ToInt32(MyPort)));
            MyChat  = new UdpClient(new IPEndPoint(IPAddress.Parse(MyIP), Convert.ToInt32(MyPortChat)));
        }
        public string Receive()
        {
            IPEndPoint ip = null;
            return Encoding.UTF8.GetString(My.Receive(ref ip));
        }
        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            My.Send(data, data.Length, IP, Convert.ToInt32(Port));
        }
        public string ReceiveChat()
        {
            IPEndPoint ip = null;
            return Encoding.UTF8.GetString(MyChat.Receive(ref ip));
        }
        public void SendChat(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            MyChat.Send(data, data.Length, IP, Convert.ToInt32(PortChat));
        }
    }

    public partial class MainWindow : Window
    {
        User user = new User();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Content.ToString() == "1Send")
            { user.Send("3"); }
            if (((Button)sender).Content.ToString() == "2Res-Sen")
            { MessageBox.Show("2Res-Sen"); }
            else
            { return; }
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            user.Create();
            Chat.IsEnabled = true;
            Chat.Text = "Vait your gamer...";
            await Task.Run(() =>
            {
                while (true)
                {
                    string messege = user.Receive();
                    if (messege != "")
                    { return; }                    
                }
            });
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            AddClient addClient = new AddClient(user);
            addClient.Show();
            StartButton.IsEnabled = true;
        }

        private void Leave_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}
