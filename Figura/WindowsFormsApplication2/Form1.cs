using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{

    public partial class Form1 : Form
    {
        enum TipoFigura  {Rectangulo, Circulo, Linea};

        private TipoFigura figura_actual; 
        private List<Figura> rectangulos;
        private Color color_contorno, color_relleno; 
      

        public Form1()
        {
            
            figura_actual = TipoFigura.Circulo;
           
            rectangulos = new List<Figura>();
           
            InitializeComponent();

            color_contorno = Color.Black;
            color_relleno = Color.LightGreen;

            circuloToolStripMenuItem.Checked = true;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                
                contextMenuStrip1.Show(this, e.X,e.Y);
            }
            else if (MouseButtons.Left == e.Button)
            {
                if (figura_actual == TipoFigura.Circulo)
                    {
                    Circulo c = new Circulo(e.X, e.Y, color_contorno, color_relleno);
                    c.Draw(this);
                    rectangulos.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y, color_contorno, color_relleno);
                    r.Draw(this);
                    rectangulos.Add(r);
                }
                else if (figura_actual == TipoFigura.Linea)
                {
        
                    Linea l = new Linea(e.X, e.Y, color_contorno,color_relleno);
                    l.Draw(this);
                    rectangulos.Add(l);
                }
            }
   
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Polimorfismo
            foreach (Figura r in rectangulos)
                r.Draw(this);
        }

        private void rectanguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rectanguloToolStripMenuItem.Checked = true;
            this.circuloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Circulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();
           

        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = true;
            figura_actual = TipoFigura.Linea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                 color_contorno = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                color_relleno = colorDialog2.Color;
            }
        }
    }
}
