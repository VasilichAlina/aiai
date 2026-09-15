using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MO32_2_Vasileva_Meleme
{
    public partial class FormMain : Form
    {
        private double[] inputPixels; //массив входных данных
        public FormMain()
        {

            InitializeComponent();

            inputPixels = new double[15]; //инициализация массива

        }

      

        private void Changing_Status_button(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = Color.Black;
                inputPixels[((Button)sender).TabIndex] = 1d;
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
                inputPixels[((Button)sender).TabIndex] = 0d;

            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveTrainSemp_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveTestSemp_Click(object sender, EventArgs e)
        {

        }
    }
}
