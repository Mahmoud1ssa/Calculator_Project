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
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

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
    }
}
