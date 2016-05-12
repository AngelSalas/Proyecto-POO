using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace WindowsFormsApplication2
{
     
    abstract class Figura:IComparable
    {
        protected int X;
        protected int Y;
        protected int T1, T2, T3;
        protected Color C, CR;
        protected Pen pluma;
        protected int A;
        protected int L;
        protected int G;

      
        protected SolidBrush brocha;

        public Figura(int x, int y, Color c, Color cr, int a, int l, int g) {
            X = x;
            Y = y;
            C = c;
            CR = cr;
            A = a;
            G = g;
            L = l;
               
            brocha = new SolidBrush(CR);
            pluma = new Pen (C, G);
                
        }

        public abstract void Draw(Form f);

        public int CompareTo(object obj)
        {

            return this.L.CompareTo(((Figura)obj).L);
        }
    }


    class Rectangulo:Figura
    {
        
        public Rectangulo(int x, int y, Color c, Color cr, int a, int l, int g) :base(x,y,c,cr,a,l,g)
    	{
        } 

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawRectangle(pluma, this.X, this.Y, A, L);
            g.FillRectangle(brocha, this.X, this.Y, A, L);
        }

    }

    class Linea : Figura
    {
     
        public Linea(int x, int y, Color c, Color cr, int a, int l, int g) : base(x, y, c, cr, a, l, g)
        {
            
          
        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawLine(pluma, this.X, this.Y, A, L);
           
        }

    }

    class Circulo : Figura
    {
        public Circulo(int x, int y, Color c, Color cr, int a, int l, int g) : base(x, y, c, cr, a, l, g)
        {

        }

        public override void Draw(Form f)
        {
            Graphics g = f.CreateGraphics();
            g.DrawEllipse(pluma, this.X, this.Y, A, L);
            g.FillEllipse(brocha, this.X, this.Y, A, L);
        }

    }
        class Triangulo : Figura
        {
            public Triangulo( int x, int y, Color c, Color cr, int a, int l, int t1, int t2, int t3, int g) : base(x, y, c, cr, a, l,g)
            {
            T1 = t1;
            T2 = t2;
            T3 = t3;

        }

            public override void Draw(Form f)
            {
                Graphics g = f.CreateGraphics();

                //Se establecen vertices del triangulo
                Point V1 = new Point(this.T1, 100);
                Point V2 = new Point(this.T2, 20);
                Point V3 = new Point(200, this.T3);
            
                GraphicsPath ruta = new GraphicsPath();
                
                //Añadimos a ruta las lineas de V1 a V2, de V2 a V3 y de V3 a V1
                ruta.AddLine(V1, V2);
                ruta.AddLine(V2, V3);
                ruta.AddLine(V3, V1);

                //Se dibujan las lineas anteriores (contorno)
                g.DrawPath(pluma, ruta);

                //Se rellena el triangulo con la ruta establecida
                g.FillPath(brocha, ruta);
            }




        }

    }
