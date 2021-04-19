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

namespace Task3_Bonus_Recipes
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

        #region BUTTONS ACTIONS

        private void setTxt(object sender, RoutedEventArgs e)
        {
            //AddChild TEXT TO THE BOX
            txtBox.Text = "Replace default text with initial text value";
        }

        private void selectALL(object sender, RoutedEventArgs e)
        {
            //SELECT ALL TEXT IN TEXT BOX AND FOCUS ON IT
            txtBox.SelectAll();
            txtBox.Focus();
        }

        private void clearALL(object sender, RoutedEventArgs e)
        {
            //clearALL TEXT BOX
            txtBox.Clear();
        }

        private void prependTxt(object sender, RoutedEventArgs e)
        {
            //INSERY FUNCTION TAKES START INDEX AND VALUE
            txtBox.Text = txtBox.Text.Insert(0, "*** Prepended text *** ");
        }

        private void insertTxt(object sender, RoutedEventArgs e)
        {
            //CARET INDEX GET THE INSERTION POSITION OF CARET
            txtBox.Text = txtBox.Text.Insert(txtBox.CaretIndex, " *** inserted text *** ");
        }

        private void appendTxt(object sender, RoutedEventArgs e)
        {
            txtBox.AppendText(" *** appended text ***");
        }

        private void cutTxt(object sender, RoutedEventArgs e)
        {
            //CHECK FOR THE SELECTION
            if (txtBox.SelectionLength == 0)
            {
                //INFORM THE USER TO SELECT
                MessageBox.Show("Select text to cut first.", base.Title);
                return;
            }
            //SHOW THE CUT TEXT
            MessageBox.Show("Cut: " + txtBox.SelectedText, base.Title);
            txtBox.Cut();
        }

        private void pasteTxt(object sender, RoutedEventArgs e)
        {
            txtBox.Paste();
        }

        private void undoAction(object sender, RoutedEventArgs e)
        {
            txtBox.Undo();
        }

        #endregion

        #region RADIO BUTTONS ACTIONS

        private void accessability(object sender, RoutedEventArgs e)
        {
            //UNBOXING THE OBJECT TO RADIO BUTTON
            RadioButton radioButton = e.OriginalSource as RadioButton;

            //CHECK FOR THE OPTION
            if (e.OriginalSource == editableRadioBtn)
            {
                txtBox.IsReadOnly = false;
            }
            else if (e.OriginalSource == readonlyRadioBtn)
            {
                txtBox.IsReadOnly = true;
            }

            //FOCUS ON TEXT BOX
            txtBox.Focus();
        }

        private void alignment(object sender, RoutedEventArgs e)
        {

            //UNBOXING THE OBJECT TO RADIO BUTTON
            RadioButton radioButton = e.OriginalSource as RadioButton;

            //CHECK FOR THE OPTION
            if (e.OriginalSource == leftAlignRadioButton)
            {
                txtBox.TextAlignment = TextAlignment.Left;
            }
            else if (e.OriginalSource == centerAlignRadioButton)
            {
                txtBox.TextAlignment = TextAlignment.Center;
            }
            else if (e.OriginalSource == rightAlignRadioButton)
            {
                txtBox.TextAlignment = TextAlignment.Right;
            }

            //FOCUS ON TEXT BOX
            txtBox.Focus();
        }

        #endregion

        #region WINDOW ACTION

        private void minimize(object sender, RoutedEventArgs e)
        {

            //MINIMIZE THE WINDOW
            mainWindow.WindowState = WindowState.Minimized;
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            //CLOSE THE WINDOW
            mainWindow.Close();
        }

        #endregion

    }
}
