using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Practica1_283
{
    public partial class Img : Form
    {
        PictureBox pb = new PictureBox();

        public Img()
        {
            InitializeComponent();
            
            imagne();

        }

        public void imagne()
        {
            
            string path = @"../../img/ListaCircular.dot.jpg";
            pb.Image = Image.FromFile(path);
            int alto = pb.Image.Height;
            int ancho = pb.Image.Width;
            pb.Height = alto;
            pb.Width = ancho;
            pb.SizeMode = PictureBoxSizeMode.CenterImage;
            panel.Controls.Add(pb);
            
        
        }



    }
}
