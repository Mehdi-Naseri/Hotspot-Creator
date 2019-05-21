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

namespace HotspotCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Boolean boolStarted = false;



        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo ProcessStartInfo1 = new System.Diagnostics.ProcessStartInfo("cmd.exe");
            ProcessStartInfo1.RedirectStandardInput = true;
            ProcessStartInfo1.RedirectStandardOutput = true; // change this to false so you can see what is happening
            ProcessStartInfo1.RedirectStandardError = false; // change this to false to see any errors
            ProcessStartInfo1.UseShellExecute = false;
            ProcessStartInfo1.CreateNoWindow = false;
            System.Diagnostics.Process processCMD = System.Diagnostics.Process.Start(ProcessStartInfo1);

            if (!boolStarted)
            {
                //Key should be between 8 to 63 characters.
                //Replace '/C' with '/K' if you want to see th eresult in command Dos.
                string stringParams = "netsh wlan set hostednetwork mode=allow ssid=" + textboxName.Text + " key=" + passwordboxPass.Password;
                processCMD.StandardInput.WriteLine(stringParams);
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                MessageBox.Show(processCMD.StandardOutput.ReadLine());
                System.Diagnostics.Process.Start("cmd.exe", "/K netsh wlan start hostednetwork");
                buttonStart.Content = "Stop";
                boolStarted = true;
                textboxName.IsEnabled = false;
                passwordboxPass.IsEnabled = false;
            }
            else
            {
                textboxName.IsEnabled = false;
                passwordboxPass.IsEnabled = false;
                System.Diagnostics.Process.Start("cmd.exe", "/C netsh wlan stop hostednetwork");
                buttonStart.Content = "Start";
                boolStarted = false;
                textboxName.IsEnabled = true;
                passwordboxPass.IsEnabled = true;
            }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.ProcessStartInfo ProcessStartInfo1 = new System.Diagnostics.ProcessStartInfo("cmd.exe");

            ProcessStartInfo1.RedirectStandardInput = true;
            ProcessStartInfo1.RedirectStandardOutput = false; // change this to false so you can see what is happening
            ProcessStartInfo1.RedirectStandardError = false; // change this to false to see any errors
            ProcessStartInfo1.UseShellExecute = false;
            ProcessStartInfo1.CreateNoWindow = false;

            System.Diagnostics.Process console1 = System.Diagnostics.Process.Start(ProcessStartInfo1);
          //  console1.StandardInput.WriteLine("md c:\\testdir");
            console1.StandardInput.WriteLine("f:");
            console1.StandardInput.WriteLine("cd \\ESET"); 
        }
    }
}
