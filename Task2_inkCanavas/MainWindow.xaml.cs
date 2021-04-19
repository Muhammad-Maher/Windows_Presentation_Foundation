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

#region NEW NAMESPACES

//--NEW USED NAMESPACES--//

using System.IO; //==>FileStream
using System.Windows.Ink; //==>StrokeCollection
using Microsoft.Win32; //==>SaveDialog

//-- --//                    
                    
#endregion

namespace Task2_inkCanavas
{  
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        #region BUTTONS FUNCTIONS

        private void createNewCanavas(object sender, RoutedEventArgs e)
        {
            InkCanvas.Strokes.Clear();
        }

        private void saveCanavas(object sender, RoutedEventArgs e)
        {
            //CREATE SAVE DIALOG
            SaveFileDialog saveDialog = new SaveFileDialog();

            //PUT  DEFAUT NAME FOR THE FILE DEPENDING ON THE TIME IN SECONDS
            saveDialog.FileName = $"Document-{DateTimeOffset.Now.ToUnixTimeSeconds()}";

            //SHOW THE DIALOG
            saveDialog.ShowDialog();

            //OPEN FILE STREAM TO ADD THE FILE DATA TO IT             
            FileStream saveStream = new FileStream(saveDialog.FileName, FileMode.Create, FileAccess.Write);

            //SAVE THE FILE DATA TO THE FILE STREAM
            InkCanvas.Strokes.Save(saveStream);

            //CLOSE THE FILE STREAM
            saveStream.Close();

        }

        private void loadCanavas(object sender, RoutedEventArgs e)
        {
            //CRAETE OPEN DIALOG TO LOAD THE SAVED FILES
            OpenFileDialog openDialog = new OpenFileDialog();

            //ENSURE THAT THE FILTER INCLUDE ALL FILES TYPES
            openDialog.Filter = "All files (*.*)|*.*";

            //OPEN THE LOAD DIALOG AND ENURE THAT THE STREAM CREATED AND FILE LOADED ONLY 
            //AFTER THE DIALOG RETURN FILE NAME (TRUE)
            if (openDialog.ShowDialog() == true)
            {
                //OPEN THE FILE STREAM TO LOAD THE DATA
                FileStream loadStream = new FileStream(openDialog.FileName, FileMode.Open, FileAccess.Read);

                //PUT THE DATA INSIDE STROKE COLLECTION TO LOAD IT
                StrokeCollection loadedStrokes = new StrokeCollection(loadStream);

                //ADD THE DATA TO CANVAS
                InkCanvas.Strokes = loadedStrokes;

                //CLOSE THE FILE STREAM
                loadStream.Close();
            }            
        }

        private void copyCanavas(object sender, RoutedEventArgs e)
        {
            InkCanvas.CopySelection();
        }

        private void cutCanavas(object sender, RoutedEventArgs e)
        {
            InkCanvas.CutSelection();
        }

        private void pasteCanavas(object sender, RoutedEventArgs e)
        {
            InkCanvas.Paste();
        }

        #endregion

        #region RADIO BUTTONS FUNCTIONS

        private void Colors(object sender, RoutedEventArgs e)
        {
            //CONVERT STRING TO COLOR AND ASSIGN IT TO BRUSH
            InkCanvas.DefaultDrawingAttributes.Color = (Color)ColorConverter.ConvertFromString((((RadioButton)sender).Content.ToString()));
        }

        private void Modes(object sender, RoutedEventArgs e)
        {
            //CONVER THE STRING TO MODE AND ASSIGN IT TO BRUSH EDITING MODE
            InkCanvas.EditingMode = (InkCanvasEditingMode)Enum.Parse(typeof(InkCanvasEditingMode), ((RadioButton)sender).Content.ToString());
        }

        private void Drawing_Shapes(object sender, RoutedEventArgs e)
        {
            //PARSE THE STRING TO ENUM OF TYPE 'STYLUSTIP' AND ASSIGN IT TO BRUSH STYLUS TIP
            InkCanvas.DefaultDrawingAttributes.StylusTip = (StylusTip)Enum.Parse(typeof(StylusTip), ((RadioButton)sender).Content.ToString());
        }

        private void Brush_Size(object sender, RoutedEventArgs e)
        {
            //SWITCH ON THE BRUSH SIZE RETURN STRING AND ASSIGN IT TO THE BRUSH
            switch (((RadioButton)sender).Content.ToString())
            {
                case "Small":
                    InkCanvas.DefaultDrawingAttributes.Width = 5;
                    InkCanvas.DefaultDrawingAttributes.Height = 5;
                    break;

                case "Normal":
                    InkCanvas.DefaultDrawingAttributes.Width = 10;
                    InkCanvas.DefaultDrawingAttributes.Height = 10;
                    break;

                case "Large":
                    InkCanvas.DefaultDrawingAttributes.Width = 15;
                    InkCanvas.DefaultDrawingAttributes.Height = 15;
                    break;
            }
        }

        #endregion

    }

}

