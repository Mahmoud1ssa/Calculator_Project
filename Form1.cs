using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsTools_File;

namespace Calculator_Project
{
    // Enum that has cases for stupid actions by user...
    enum enStupidAttemptCasesHandling
    {
        enCaseResultPressAtStart = 0, enImpossibleDeviding = 1, 
        enCaseDoublyDotIn1NumberString = 2, enCaseOperationButtonPressedDoubly = 3
    }

    // Enum that has cases for any Operation button press by user...
    enum enOperationButtonClickCaseHandling
    {
        enCaseOperationButtonPressedForSide1Number = 0, enCaseOperationButtonPressedForSide2Number = 1
    }


    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }




        // Defining the general variables I am going to use in this project...
        private double? Number1 = null;
        private double? Number2 = null;
        private string OperationType = "";
        
        
        // Drawing the lines to seprate buttons method... using clsTools I created.
        private void frmCalculator_Paint(object sender, PaintEventArgs e)
        {
            // Here I created an object of the class I made "clsTools"...
            //And used the function DrawShape from it.
            clsTools PaintTool = new clsTools();
            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 106f, 78, 106f, 300);
            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 208f, 78, 208f, 300);
            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 310f, 78, 310f, 300);

            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 9f, 130, 406f, 130);
            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 9f, 190, 406f, 190);
            PaintTool.DrawShape(e, clsTools.enColor.Black, clsTools.enCap.Flat, clsTools.enShape.Line, 2, 9f, 248, 406f, 248);

        }


        // Method to handle stupid inserts or actions by user...
        private bool HandlingStupidAttempt(enStupidAttemptCasesHandling enStupidAttemptCase)
        {
            switch (enStupidAttemptCase)
            {
                case enStupidAttemptCasesHandling.enCaseResultPressAtStart:
                    {
                        // Dealing with case the user pressed = at the begining of the program with no values in Number1 & Number2.
                        if (Number1 == null & Number2 == null)
                            return true;

                        break;
                    }

                case enStupidAttemptCasesHandling.enImpossibleDeviding:
                    {
                        if (Number2 == 0)
                        {
                            return true;
                        }
                        break;
                    }
                case enStupidAttemptCasesHandling.enCaseDoublyDotIn1NumberString:
                    {
                        if (txtResults.Text.Contains(".") != false)
                        {
                            MessageBox.Show("Can't enter double dots in a string number", "Wrong Insert",
    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            return true;
                        }
                        break;
                    }
                case enStupidAttemptCasesHandling.enCaseOperationButtonPressedDoubly:
                    {
                        // This if statement deals with case the user pressed double times or more on an operation button.
                        if (txtResults.Text == "")
                        {
                            return true;
                        }
                        break;
                    }
            }

            return false;
        }


        // Calculate 2 numbers methods...
        private double? AddCalculate(double? Number1, double? Number2)
        {
            return Number1 + Number2;
        }
        private double? SubtractCalculate(double? Number1, double? Number2)
        {
            return Number1 - Number2;
        }
        private double? MultiplyCalculate(double? Number1, double? Number2)
        {
            return Number1 * Number2;
        }
        private double? DevideCalculate(double? Number1, double? Number2)
        {
            if (HandlingStupidAttempt(enStupidAttemptCasesHandling.enImpossibleDeviding))
            {
                return Number1;
            }

            return Number1 / Number2;
        }
        // The General Calculate method...
        private double? CalculateAndGetResults(double? Number1, double? Number2, string OperationType)
        {
            double? Result = null;
            switch (OperationType)
            {
                case "+":
                    {
                        Result = AddCalculate(Number1, Number2);
                        break;
                    }
                case "-":
                    {
                        Result = SubtractCalculate(Number1, Number2);
                        break;
                    }
                case "*":
                    {
                        Result = MultiplyCalculate(Number1, Number2);
                        break;
                    }
                case "/":
                    {
                        Result = DevideCalculate(Number1, Number2);
                        break;
                    }
            }

            return Result;
        }


        // Dealing with any number button click method...
        private void btnNumber_Click(object sender, MouseEventArgs e)
        {
            Button btnNumber = sender as Button;
            txtResults.Text += btnNumber.Tag;
        }


        // Button result click or call...
        private void btnResult_Click(object sender, EventArgs e)
        {
            // Dealing with case the user pressed = at the begining of the program with no values in Number1 & Number2.
            if (HandlingStupidAttempt(enStupidAttemptCasesHandling.enCaseResultPressAtStart))
                return;

            Number2 = Convert.ToDouble(txtResults.Text);
            txtResults.Text = Convert.ToString(CalculateAndGetResults(Number1, Number2, OperationType));

            // In the next Calculation... The Result in txtResults will be saved in "Number1" variable...
            // And to make sure this happen I have to make the Number1 = null... so the if statement "if (Number1 == null)"
            // in btnOperation_Click return true... and the result in txtResults will be saved in "Number1".
            Number1 = null;
            Number2 = null;
        }

        // Method To handle calculating when operation button pressed...
        private bool HandlingOperationButtonClick(enOperationButtonClickCaseHandling OperationButtonClickCase)
        {
            switch (OperationButtonClickCase)
            {
                case enOperationButtonClickCaseHandling.enCaseOperationButtonPressedForSide1Number:
                    {
                        Number1 = Convert.ToDouble(txtResults.Text);
                        txtResults.Text = "";

                        return true;
                    }

                case enOperationButtonClickCaseHandling.enCaseOperationButtonPressedForSide2Number:
                    {
                        if (Number2 == null)
                        {
                            // This if statement deals with case the user pressed double times or more on an operation button.
                            if (HandlingStupidAttempt(enStupidAttemptCasesHandling.enCaseOperationButtonPressedDoubly))
                            {
                                return true;
                            }

                            // The result of the calculating will be shown in txtResults because of this method...
                            btnResult_Click(null, null);
                            return false;
                        }
                        break;
                    }
            }

            return false;
        }


        private void btnOperation_Click(object sender, MouseEventArgs e)
        {
            //To Get the type of the operation...
            Button btnOperation = sender as Button;
            OperationType = Convert.ToString(btnOperation.Tag);



            // Dealing with all cases of any time operation button press...
            // At the beggining of the program... (Side 1 Number will be null) and I handled this in "else if (Number1 == null)"
            // And after the first opration press... (Side 2 Number will be null) and I handled this in "else if (Number2 == null)"
            if (Number1 == null)
            {
                HandlingOperationButtonClick(enOperationButtonClickCaseHandling.enCaseOperationButtonPressedForSide1Number);

                return;
            }

            else if (Number2 == null)
            {
                HandlingOperationButtonClick(enOperationButtonClickCaseHandling.enCaseOperationButtonPressedForSide2Number);

                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtResults.Text.Length != 0)
            txtResults.Text = txtResults.Text.Remove(txtResults.Text.Length - 1);
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            // Dealing with case user tried to insert another dot "." to the number string.
            if (txtResults.Text.Contains(".") == false)
            {
                Button btnNumber = sender as Button;
                txtResults.Text += btnNumber.Tag;
            }
            else
            {
                HandlingStupidAttempt(enStupidAttemptCasesHandling.enCaseDoublyDotIn1NumberString);
                return;
            }
        }
    }
}