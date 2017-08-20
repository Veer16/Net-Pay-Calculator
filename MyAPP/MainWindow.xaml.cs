using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MyAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int iRD, nHour, noChild;
        string fn, ln;
        Boolean isMarried;
        Window1 win;
        App myApp = Application.Current as App;

        private void IRDNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If a user only want to enable numeric value IRD field, then uncomment this code //
            /*
                        int iValue = -1;
                        if (Int32.TryParse(IRDNo.Text, out iValue) == false)
                        {
                            TextChange textChange = e.Changes.ElementAt<TextChange>(0);
                            int iAddedLength = textChange.AddedLength;
                            int iOffset = textChange.Offset;
                            IRDNo.Text = IRDNo.Text.Remove(iOffset, iAddedLength);
                        }
                        */
            if (IRDNo.Text != "")
            {
                try
                {

                    msg.Content = "";
                    IRDerrorlbl.Content = "";
                    canvas.Background = Brushes.LightGray;
                    calculate2.IsEnabled = true;
                    iRD = Convert.ToInt32(IRDNo.Text);
                }
                catch (Exception ex)
                {
                    SystemSounds.Exclamation.Play();
                    IRDerrorlbl.Content = ex.Message;
                    calculate2.IsEnabled = false;
                }
                
            }
            else
                IRDerrorlbl.Content = "";
            
        }
        //To disable white spaces//
       private void IRDNo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                SystemSounds.Exclamation.Play();
                e.Handled = true;
                SystemSounds.Exclamation.Play();
                IRDerrorlbl.Content = "White spaces are not allowed  ";

            }
        }


        private void fnamebox_TextChanged(object sender, TextChangedEventArgs e)
        {

            Regex regx1 = new Regex(@"^[a-zA-Z\s]*$");

            Regex regx2 = new Regex(@"^\A\s{1}");
            Regex regx3 = new Regex(@"\s{2,}");
            string firstname = Convert.ToString(fnamebox.Text);
            msg.Content = "";

            if (!regx1.IsMatch(firstname))
            {
                SystemSounds.Exclamation.Play();
                error.Content = "First name format is incorrect";
                fnamebox.Focus();
                calculate2.IsEnabled = false;
            }

            else if (regx2.IsMatch(firstname))
            {
                SystemSounds.Exclamation.Play();
                error.Content = "No white spaces are allowed at the starting of the name ";
                fnamebox.Focus();
                calculate2.IsEnabled = false;

            }
            else if (regx3.IsMatch(firstname))
            {
                error.Content = "Multiple white spaces are not allowed";
                fnamebox.Focus();
                calculate2.IsEnabled = false;
            }

            else
            {
                calculate2.IsEnabled = true;
                error.Content = "";
                canvas.Background = Brushes.LightGray;
                fn = fnamebox.Text;
            }
        }



        private void lnamebox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regx1 = new Regex(@"^[a-zA-Z\s]*$");

            Regex regx2 = new Regex(@"^\A\s{1}");
            Regex regx3 = new Regex(@"\s{2,}");
            string lastname = Convert.ToString(lnamebox.Text);
            msg.Content = "";

            if (!regx1.IsMatch(lastname))
            {
                SystemSounds.Exclamation.Play();
                lnerror.Content = "First name format is incorrect";
                lnamebox.Focus();
                calculate2.IsEnabled = false;
            }

            else if (regx2.IsMatch(lastname))
            {
                SystemSounds.Exclamation.Play();
                lnerror.Content = "No white spaces are allowed at the starting of the name ";
                lnamebox.Focus();
                calculate2.IsEnabled = false;

            }
            else if (regx3.IsMatch(lastname))
            {
                SystemSounds.Exclamation.Play();
                lnerror.Content = "Multiple white spaces are not allowed";
                lnamebox.Focus();
                calculate2.IsEnabled = false;
            }

            else
            {
                calculate2.IsEnabled = true;
                lnerror.Content = "";
                canvas.Background = Brushes.LightGray;
                ln = lnamebox.Text;
            }
        }

        private void nohourbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nohourbox.Text != "") {
                try
                {
                    msg.Content = "";
                    nHerror.Content = "";
                    canvas.Background = Brushes.LightGray;
                    calculate2.IsEnabled = true;
                    nHour = Convert.ToInt32(nohourbox.Text);
                    myApp.hoursOfWork = nHour;
                }
                catch (Exception ex)
                {
                    SystemSounds.Exclamation.Play();
                    nHerror.Content = ex.Message;
                    calculate2.IsEnabled = false;
                }
            }
            else
            nHerror.Content = ""; 
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {

            IRDNo.Text = "";
            fnamebox.Text = "";
            lnamebox.Text = "";
            canvas.Background = Brushes.LightGray;
            cbox.SelectedIndex = -1;
            No.IsChecked = true;
            nohourbox.Text = "";
            IRDerrorlbl.Content = "";
            nHerror.Content = "";


        }

        private void Recent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                msg.Content = "";
                canvas.Background = Brushes.LightGray;
                myApp.acontractor.GetContractorInfo(out fn, out ln, out iRD, out noChild, out isMarried);
                fnamebox.Text = fn;
                lnamebox.Text = ln;
                IRDNo.Text = Convert.ToString(iRD);
                cbox.SelectedItem = noChild;
                if (isMarried == true)
                {
                    Yes.IsChecked = true;
                }
                else
                    No.IsChecked = true;
                nohourbox.Text = Convert.ToString(myApp.hoursOfWork);
            }
            catch (Exception)
            {
                msg.Content = "No recent information is available";
            }
        }




        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(IRDNo.Text) || !string.IsNullOrEmpty(fnamebox.Text) || !string.IsNullOrEmpty(lnamebox.Text) || !string.IsNullOrEmpty(nohourbox.Text) || cbox.SelectedIndex != -1)
            {
                SystemSounds.Exclamation.Play();
                MessageBoxResult mbr = MessageBox.Show("Closing the window will lose the contractor information ", "Do you want to close ?", MessageBoxButton.YesNo,MessageBoxImage.Exclamation);
                if (mbr == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
                else if (mbr == MessageBoxResult.No)

                    e.Cancel = true;

            }
            else
                Application.Current.Shutdown();

        }
      
        private void calculate2_Click(object sender, RoutedEventArgs e)

      {

         if (string.IsNullOrEmpty(IRDNo.Text) || string.IsNullOrEmpty(fnamebox.Text) || string.IsNullOrEmpty(lnamebox.Text) ||
                   string.IsNullOrEmpty(nohourbox.Text) || cbox.SelectedIndex == -1)
            {
                SystemSounds.Exclamation.Play();
                canvas.Background = Brushes.Red;
                msg.Content = "Please Provide Full information ";
            }
            else if (Convert.ToString(IRDNo.Text).Length < 8)
            {
                IRDerrorlbl.Content = "IRD number should be 8 or 9 digit";
                IRDNo.Focus();


            }
            else
            {
                canvas.Background = Brushes.LightGray;
                msg.Content = "";
                {
                    if (Yes.IsChecked == true)
                    {
                        isMarried = true;
                    }
                    else
                        isMarried = false;

                    noChild = Convert.ToInt32(cbox.SelectedItem);
                    myApp.acontractor = new Contractor(fn, ln, iRD, isMarried, noChild);
                    myApp.apayment = new Payment(myApp.acontractor, myApp.hoursOfWork);
                    win = new Window1();
                    win.GSTNo.Content = myApp.apayment.GetGst();
                    win.Incometax.Content = myApp.apayment.GetIncomeTax();
                    win.MembershipFee.Content = myApp.apayment.getMemberShipFee();
                    win.DeductionFee.Content = myApp.apayment.GetTotalDeduction();
                    win.netpaybox.Content = myApp.apayment.GetNetPay();
                    win.Show();

                }
            }
                    }
    
    
  
 public MainWindow()
        {
            System.Int32[] numbers = new System.Int32[31] {0, 1, 2, 3, 4, 5,6,7,8,9,10,11,12,13,14,15,
                                                           16,17,18,19,20,21,22,23,24,25,26,27,28,29,30};
            InitializeComponent();
            this.cbox.ItemsSource = numbers;
            this.cbox.SelectedIndex=-1;
            this.IRDNo.Focus();
            
           }
}
}
