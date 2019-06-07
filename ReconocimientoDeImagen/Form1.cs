using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;


namespace ReconocimientoDeImagen
{
    public partial class Form1 : Form
    {

        private Image<Bgr, byte> newImage;
        private Image<Gray, byte> grayImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                newImage = new Emgu.CV.Image<Bgr, byte>(ofd.FileName);
                imageBox1.Image = newImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (newImage is null) return;
            grayImage = newImage.Convert<Gray, byte>();
            imageBox1.Image = grayImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (newImage is null) return;
            newImage = newImage.Convert<Bgr, byte>();
            imageBox1.Image = newImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (newImage is null) return;
            if(grayImage is null)
            {
                grayImage = newImage.Convert<Gray, byte>();
            }
            var SobelImage = grayImage.Sobel(
                1, //x order
                1, //y order
                3 // aperture Size
                );
            imageBox1.Image = SobelImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (newImage is null) return;
            if (grayImage is null)
            {
                grayImage = newImage.Convert<Gray, byte>();
            }
            var cannyImage = grayImage.Canny(
                50, //ThresHold
                20//Treshold Link
                );
            imageBox1.Image = cannyImage;
        }
    }
}
