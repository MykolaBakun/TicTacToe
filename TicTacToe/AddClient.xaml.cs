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
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class AddClient : Window
    {
        User user;
        public AddClient(User us)
        {
            user = us;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyIP.Text == "")
            {
                return;
            }
            if (MyPort.Text == "")
            {
                return;
            }
            if (IP.Text == "")
            {
                return;
            }
            if (Port.Text == "")
            {
                return;
            }
            user.MyIP = MyIP.Text;
            user.MyPort = MyPort.Text;
            user.MyPortChat = MyPortChat.Text;
            user.IP = IP.Text;
            user.Port = Port.Text;
            user.PortChat = PortChat.Text;
            this.Close();
        }
    }
}
