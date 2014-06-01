using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace wpf_app
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Point> GetData { get; set; }
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();

            GetData = new ObservableCollection<Point>();
            GetData.Add(new Point(0, rnd.Next(20)));
            GetData.Add(new Point(1, rnd.Next(20)));
            GetData.Add(new Point(2, rnd.Next(20)));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetData.Add(new Point(GetData.Last().X + 1, rnd.Next(20)));
        }
    }
}
