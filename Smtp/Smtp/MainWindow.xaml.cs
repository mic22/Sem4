using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using System.Xaml;

namespace Smtp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MailContentDefinition mcd;
        private IEnumerable<string> replaces;
        public MainWindow()
        {
            InitializeComponent();
            mcd = (MailContentDefinition)XamlServices.Load("data.xaml");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = new SmtpClient();
            foreach (var person in mcd.People)
            {
                string completed = Body.Text;
                completed
                    .Replace("{Firstname}", person.Firstname)
                    .Replace("{Lastname}", person.LastName)
                    .Replace("{Footer}", mcd.Footer);


                MailMessage message = new MailMessage("from@ath.pl", person.Email);
                message.Subject = "testowy";
                message.Body = completed;

                client.Send(message);
            }
        }
    }
}
