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

namespace task1_form
{
    
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void showDetails(object sender, RoutedEventArgs e)
        {
            //START STRING BUILDER
            StringBuilder inputedString = new StringBuilder();

            #region APPEND DATA FROM TEXTBOXES
            //FN
            inputedString.Append("You have Entered: "+
                "\nName =" + FNameTxtBox.Text + "  " + LNameTxtBox.Text);
            //LN
            inputedString.Append("\n Gender=" + GenderTxtBox.Text + 
                "\n Address=" + AddressTxtBox.Text);
            //TITLE
            inputedString.Append("\n Job Title =" + JobTitleTxtBox.Text);
            //PHONE
            inputedString.Append("\n phone =" + PhoneTxtBox.Text);
            //MOBILE
            inputedString.Append("\n mobile =" + MobileTxtBox.Text);
            //MAIL
            inputedString.Append("\n email =" + EmailTxtBox.Text);

            #endregion
            
            MessageBoxResult result = MessageBox.Show(inputedString.ToString(), "Personal Information", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);

            if (result == MessageBoxResult.OK)
            {
                MessageBox.Show("Data Saved Successfully", "Saving", MessageBoxButton.OK);
            }

        }

        private void CancelForm(object sender, RoutedEventArgs e)
        {
            SignIn_Form.Close();
        }
       
    }

}
