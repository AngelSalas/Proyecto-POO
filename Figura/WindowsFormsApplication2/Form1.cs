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
        
        enum TipoFigura  {Rectangulo, Circulo, Linea, Triangulo};

        private TipoFigura figura_actual; 
        private List<Figura> rectangulos;
        public int ancho;
        public int largo;
        public int v1, v2, v3;
        public int grosor;
        private Color color_contorno, color_relleno;
        Form2 FormaCaptura = new Form2();
        Form3 FormaGrosor = new Form3();

        public Form1()
        {
            
            figura_actual = TipoFigura.Circulo;
           
            rectangulos = new List<Figura>();
           
            InitializeComponent();

            color_contorno = Color.Black;
            color_relleno = Color.LightGreen;
            largo = 40;
            ancho = 40;
            v1 = 20;
            v2 = 20;
            v3 = 20;
            grosor = 4;

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
                    Circulo c = new Circulo(e.X, e.Y, color_contorno, color_relleno,ancho,largo,grosor);
                    c.Draw(this);
                    rectangulos.Add(c);
                }
                else if (figura_actual == TipoFigura.Rectangulo)
                {
                    Rectangulo r = new Rectangulo(e.X, e.Y, color_contorno,color_relleno,ancho, largo,grosor);
                    r.Draw(this);
                    rectangulos.Add(r);
                }
                else if (figura_actual == TipoFigura.Linea)
                {
        
                    Linea l = new Linea(e.X, e.Y, color_contorno,color_relleno,ancho, largo,grosor);
                    l.Draw(this);
                    rectangulos.Add(l);
                }
                else if (figura_actual == TipoFigura.Triangulo)
                {

                    Triangulo t = new Triangulo(e.X, e.Y, color_contorno, color_relleno, ancho, largo,v1,v2,v3, grosor);
                    t.Draw(this);
                    rectangulos.Add(t);
                    FormaCaptura.txtLargo.Focus();
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
            this.trianguloToolStripMenuItem.Checked = false;
            button3.Text = "&Tamaño";
            figura_actual = TipoFigura.Rectangulo;
        }

        private void circuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = true;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = false;
            button3.Text = "&Tamaño";
            figura_actual = TipoFigura.Circulo;
        }

        private void ordenarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rectangulos.Sort();
            rectangulos.Reverse();
            this.Refresh();
           

        }

        private void lineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = true;
            button3.Text = "C&oordenadas";
            this.trianguloToolStripMenuItem.Checked = false;
            figura_actual = TipoFigura.Linea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                 color_contorno = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormaCaptura.txtLargo.Focus();
            if (figura_actual == TipoFigura.Linea)
            {
                FormaCaptura.Text = "Coordenadas";
                FormaCaptura.lblAncho.Text = "X:";
                FormaCaptura.lblLargo.Text = "Y:";
                FormaCaptura.lblVertice3.Visible = false;
                FormaCaptura.txtVertice3.Visible = false;
            }
            else if (figura_actual == TipoFigura.Triangulo)
            {

                FormaCaptura.Text = "Vertices";
                FormaCaptura.lblAncho.Text = "Vertice 2:";
                FormaCaptura.lblLargo.Text = "Vertice 1:";
                FormaCaptura.lblVertice3.Visible = true;
                FormaCaptura.txtVertice3.Visible = true;
            }
            else
            {
                FormaCaptura.Text = "Tamaño";
                FormaCaptura.lblAncho.Text = "Ancho:";
                FormaCaptura.lblLargo.Text = "Largo:";
                FormaCaptura.lblVertice3.Visible = false;
                FormaCaptura.txtVertice3.Visible = false;
            }
            if (figura_actual == TipoFigura.Triangulo)
            {
                if (FormaCaptura.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        v1 = int.Parse(FormaCaptura.txtLargo.Text);
                        v2 = int.Parse(FormaCaptura.txtAncho.Text);
                        v3 = int.Parse(FormaCaptura.txtVertice3.Text);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error, porfavor vuelve a llenar los campos");
                        FormaCaptura.txtAncho.Clear();
                        FormaCaptura.txtVertice3.Clear();
                        FormaCaptura.txtLargo.Clear();
                        FormaCaptura.txtLargo.Focus();

                    }
                    FormaCaptura.txtAncho.Clear();
                    FormaCaptura.txtLargo.Clear();
                    FormaCaptura.txtVertice3.Clear();

                }
            }
            else
            {
                if (FormaCaptura.ShowDialog() == DialogResult.OK)
                {

                    try
                    {
                        largo = int.Parse(FormaCaptura.txtLargo.Text);
                        ancho = int.Parse(FormaCaptura.txtAncho.Text);

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error, porfavor vuelve a llenar los campos");
                        FormaCaptura.txtAncho.Clear();
                        FormaCaptura.txtLargo.Clear();
                        FormaCaptura.txtLargo.Focus();

                    }
                    FormaCaptura.txtAncho.Clear();
                    FormaCaptura.txtLargo.Clear();
                    FormaCaptura.txtVertice3.Clear();
             

                }
            }
        }

        private void trianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.circuloToolStripMenuItem.Checked = false;
            this.rectanguloToolStripMenuItem.Checked = false;
            this.lineaToolStripMenuItem.Checked = false;
            this.trianguloToolStripMenuItem.Checked = true;
            button3.Text = "&Vertices";
            figura_actual = TipoFigura.Triangulo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (FormaGrosor.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    grosor = int.Parse(FormaGrosor.txtGrosor.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error, porfavor vuelve a llenar los campos");
                    FormaGrosor.txtGrosor.Clear();
                }
                    FormaGrosor.txtGrosor.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.rectangulos.Clear();
            this.Refresh();
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
