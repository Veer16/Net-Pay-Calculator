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

namespace MyAPP
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        App myApp;
        string fn, ln;
        int IRd;
        public Window1()
        {
            InitializeComponent();
            myApp = Application.Current as App;
            Contractor c = myApp.acontractor;
            c.GetContractorInfo(out fn , out ln , out IRd);
            msg.Content= "PaySlip of " + fn +" "+ln + ", IRD NO. " + IRd;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
