using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1ariketa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Process? p; 

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_lanzar_Click(object sender, RoutedEventArgs e)
        {
            p = Process.Start("C:\\Windows\\System32\\ftp.exe");
            lb_proceso.Content = $"FTP ID: {p.Id}";
        }

        private void bt_matar_Click(object sender, RoutedEventArgs e)
        {
            if (p != null && !p.HasExited)
            {
                p.Kill();
                lb_proceso.Content = "Proceso terminado";

            }
            else
            {
                lb_proceso.Content = "No hay proceso en ejecución";
                p.Kill();
            }
        }

        private void bt_mostrar_Click(object sender, RoutedEventArgs e)
        {
            Process[] procesos = Process.GetProcesses();
            cb_procesos.DisplayMemberPath = "ProcessName";
            cb_procesos.ItemsSource = procesos;
        }
    }
}