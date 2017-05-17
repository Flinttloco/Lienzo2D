using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using _OLC1_Proyecto2_201503470.Analizadores;
using _OLC1_Proyecto2_201503470.Tablas;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;
using _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido;

namespace _OLC1_Proyecto2_201503470
{
    public partial class Principal : Form
    {

        ParseTreeNode most = null;
        public Principal()
        {
            InitializeComponent();
        }




        //ABRIR
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            String caden = "";
            String url = "";
            OpenFileDialog open = new OpenFileDialog();

            //open.Filter = "Archivos txt(*.txt)|*txt";
            open.Title = "Archivos txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                caden = open.FileName;
                url = open.FileName;
            }


            String[] partes = caden.Split('\\');


            int counter = 0;
            string line;
            string contenido = "";

            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(url);
            while ((line = file.ReadLine()) != null)
            {
                contenido += line + "\n";
                counter++;
            }

            file.Close();


            TabPage myTabPage = new TabPage(partes[partes.Length - 1]);
            myTabPage.BackColor = Color.DimGray;

            RichTextBox nuevo = new RichTextBox();
            nuevo.Name = partes[partes.Length - 1];
            nuevo.Size = new Size(775, 480);
            nuevo.BorderStyle = BorderStyle.None;
            nuevo.Location = new System.Drawing.Point(0, 0);
            nuevo.Text = contenido;
            Font myfont = new Font("Century Gothic", 12.0f);
            nuevo.Font = myfont;

            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
            tabControl1.SelectedTab.Controls.Add(nuevo);

            timer1.Start();
        }



        //MOSTRAR AST
        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            using (MostrarAST frm1 = new MostrarAST(most))
            {

                frm1.ShowDialog(this);
            }
        }

        public  void Ejecutar(String NomControl) {

            foreach (Control c in tabControl1.SelectedTab.Controls)
            {
                if (c.Name == NomControl) {


                    lenguaje = new LanguageData(gramatica);

                    Parser parser = new Parser(lenguaje);
                    ParseTree arbol = parser.Parse(c.Text);
                    ParseTreeNode raiz = arbol.Root;
                    ParseTreeNode resultado = arbol.Root;

                    if (resultado != null)
                    {
                        most = resultado;
                       RecorridoLienzos.IniciarRecorrido(resultado);
                    }
                    else
                    {

                    }
                  
                }

            }
        }

        //EJECUTAR
        Gramatica gramatica = new Gramatica();
        RecorridoLienzos PrimerRecorridoo = new RecorridoLienzos();
        LanguageData lenguaje ;
        TablaSimbolos Tabla = new TablaSimbolos();

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            RecorridoLienzos.listaLienzos.Clear();
            RecorridoLienzos.listaVariables.Clear();
            RecorridoLienzos.listaPintar.Clear();
            
            foreach (Control a in this.tabControl1.TabPages )
            {
                foreach (Control c in a.Controls) {
                    Initializer(c);
               


                    lenguaje = new LanguageData(gramatica);

                    Parser parser = new Parser(lenguaje);
                    ParseTree arbol = parser.Parse(c.Text);
                    ParseTreeNode raiz = arbol.Root;
                    ParseTreeNode resultado = arbol.Root;

                    if (resultado != null)
                    {

                        most = resultado;
                        RecorridoLienzos.IniciarRecorrido(resultado);


                    }
                    else
                    {

                    }
                    Errores errores = new Errores();
                    String er = errores.GraficarTabla(gramatica.lista);
                    TablaSimbolos Tabla = new TablaSimbolos();
                    Tabla.GraficarTabla(RecorridoLienzos.listaLienzos, RecorridoLienzos.listaVariables,RecorridoLienzos.listaArreglo);
                    String[] partes = er.Split(',');

                    foreach (String err in partes)
                    {

                        richTextBox1.Text += err + "\n";
                    }

                    List<Pintar> ListaProc = RecorridoLienzos.listaPintar;


                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#000000");
                    papel = pictureBox2.CreateGraphics();
                    Brush brush = new SolidBrush(col);
                    papel.FillRectangle(brush, 0, 0, 5, 5);

                    foreach (Pintar item in ListaProc)
                    {
                        switch (item.tipo)
                        {
                            case "p":

                                Circulo(item.posx, item.posy, item.color, item.diam);
                                break;
                            case "o":
                                Ovalo(item.posx, item.posy, item.color, item.ancho, item.alto);
                                break;
                            case "r":
                                Rectangulo(item.posx, item.posy, item.color, item.ancho, item.alto);
                                Console.WriteLine("Pintar_OR(" + item.posx + "," + item.posy + "," + item.color + "," + item.ancho + "," + item.alto + "," + item.tipo);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void Initializer(Control c) {
           
            if (c.Name == "Raton.lz")
            {
                RecorridoLienzos.listaArreglo.Clear();
                ObjArreglo nuevo = new ObjArreglo("a", 300, 400);
                RecorridoLienzos.listaArreglo.Add(nuevo);
                ObjArreglo nuevo2 = new ObjArreglo("centro", 300, 400);
                RecorridoLienzos.listaArreglo.Add(nuevo2);
            }
        }

        static Graphics papel;
       // papel.ScaleTransform(.4F, .4F);
        public void Ovalo(  float centerX, float centerY, String color, float ancho, float alto)
        {
            papel = pictureBox2.CreateGraphics();
            Brush brush = new SolidBrush(CLR(color));
            papel.FillEllipse(brush, centerX - (ancho / 2), centerY - (alto / 2), ancho, alto);
        }

        public  void Rectangulo( float centerX, float centerY, String color, float ancho, float alto)
        {
            
            papel = pictureBox2.CreateGraphics();
            Brush brush = new SolidBrush(CLR(color));
            papel.FillRectangle(brush, centerX - (ancho / 2), centerY - (alto / 2), ancho, alto);
        }

        public  void Circulo( float centerX, float centerY, String color, float diam)
        {
            papel = pictureBox2.CreateGraphics();
            Brush brush = new SolidBrush(CLR(color));
            papel.FillEllipse(brush, centerX - (diam / 2), centerY - (diam / 2), diam, diam);
        }

        public static Color CLR(String HEXA)
        {
            var color = System.Drawing.ColorTranslator.FromHtml(HEXA);
            return color;
        }







        //NUEVO
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            String a = Interaction.InputBox("Ingresa el nombre del archivo nuevo", "Nuevo");
            TabPage myTabPage = new TabPage(a + ".lz");
            myTabPage.BackColor = Color.DimGray;

            RichTextBox nuevo = new RichTextBox();

            nuevo.Name = a;
            nuevo.Size = new Size(775, 480);
            nuevo.BorderStyle = BorderStyle.None;
            nuevo.Location = new System.Drawing.Point(0, 0);
            Font myfont = new Font("Century Gothic", 12.0f);
            nuevo.Font = myfont;

            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
            tabControl1.SelectedTab.Controls.Add(nuevo);

            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {

                System.IO.File.WriteAllText(@"C:\Lienzos2D\" + a + ".lz", c.Text);

            }

            timer1.Start();
        }

        //GUARDAR
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {

                System.IO.File.WriteAllText(@"C:\Lienzos2D\" + c.Name + ".lz", c.Text);
                string message = "Archivo \"" + c.Name + "\" guardado correctamente";
                string caption = "Guardado";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);

            }
        }

        //GUARDAR COMO
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.InitialDirectory = @"C:\";
                save.RestoreDirectory = true;
                save.FileName = c.Name + ".lz";
                save.DefaultExt = "lz";
                save.Filter = "lz files (*.lz)|*.lz";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    Stream fileStream = save.OpenFile();
                    StreamWriter sw = new StreamWriter(fileStream);

                    sw.Write(c.Text);
                    sw.Close();
                    fileStream.Close();
                }
            }
        }

        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1;


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Refresh();



        }



        string[] palabrasreservadas = { "publico", "privado", "Lienzo", "extiende", "¿", "?", "var", "Conservar", "$" };
        private void Pintar(string cadena)
        {


            foreach (RichTextBox c in this.tabControl1.SelectedTab.Controls)
            {

                for (int i = 0; i < palabrasreservadas.Length; i++)
                {
                    int Inicio = c.Find(palabrasreservadas[i]);
                    int Final = c.Text.LastIndexOf(palabrasreservadas[i]);
                    if ((Inicio >= 0) && (Final >= 0))
                    {
                        c.SelectionStart = Final;
                        c.SelectionLength = palabrasreservadas[i].Length;
                        c.SelectionColor = Color.Blue;
                    }
                    else
                    {
                        int final = c.Text.LastIndexOf("//");
                        if ((c.Find("//") >= 0) && (final >= 0))
                        {
                            c.SelectionColor = Color.Green;

                        }
                        else
                        {
                            c.SelectionColor = Color.Black;
                        }
                    }
                    c.SelectionStart = c.Text.Length;
                    c.SelectionColor = Color.Black;

                }
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {



        }

        int CARACTER;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {



            if (tabControl1.TabCount != 0)
            {
                foreach (RichTextBox c in this.tabControl1.SelectedTab.Controls)
                {
                    // Console.WriteLine("-----------" + c.Name);


                    CARACTER = 0; //SE INICIALIZA A 0 EN CADA REPINTADO
                    int ALTURA = c.GetPositionFromCharIndex(0).Y; //COORDENADA Y DEL PRIMER CARACTER DEL TEXTO
                    int i = 0;


                    if (c.Lines.Length > 0) //SI HAY ALGUNA LINEA LAS RECORRERA TODAS Y ESCRIBIRA SU NUMERO AL LADO DEL PRIMER CARACTER DE LA LINEA
                    {
                        for (i = 0; i <= c.Lines.Length - 1; i++)
                        {
                            e.Graphics.DrawString(i + 1 + "", c.Font, Brushes.White, pictureBox1.Width - (e.Graphics.MeasureString(i + 1 + "", c.Font).Width + 10), ALTURA);
                            CARACTER += c.Lines[i].Length + 1;//INDICE DEL PRIMER CARACTER DE LA LINEA SIGUIENTE
                            ALTURA = c.GetPositionFromCharIndex(CARACTER).Y; //POSICION EN Y DEL PRIMER CARACTER DE LA LINEA SIGUIENTE
                        }
                    }
                    else //PARA QUE SE INICIE CON UN 1 EN EL PICTUREBOX
                    {
                        e.Graphics.DrawString("1", c.Font, Brushes.White, pictureBox1.Width - (e.Graphics.MeasureString("1", c.Font).Width + 10), ALTURA);
                    }


                }


            }

        }


        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {

                Pintar(c.Text);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            Process.Start("TablaErrores.html");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton7_Click_2(object sender, EventArgs e)
        {
            Process.Start("TablaSimbolos.html");
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            System.Drawing.Color negro = System.Drawing.ColorTranslator.FromHtml("#000000");
            System.Drawing.Color blanco = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            papel = pictureBox2.CreateGraphics();
            Brush brushN = new SolidBrush(negro);
            Brush brushB = new SolidBrush(blanco);
            Font font = new Font("Times New Roman", 9.0f);
            

            for (int i = 0; i <= 500; i += 50)
            {
                papel.FillRectangle(brushN, 0, i, 30, 30);
                papel.DrawString(i.ToString(), font, brushB, 0, i);
                papel.FillRectangle(brushB, 0, i + 25, 30, 30);
                papel.DrawString((i+25).ToString(), font, brushN, 0, i+25);
            }


            for (int i = 0; i <= 500; i += 50)
            {
                papel.FillRectangle(brushN, i, 0, 30, 30);
                papel.DrawString(i.ToString(), font, brushB, i,0 );
                papel.FillRectangle(brushB, i + 25, 0, 30, 30);
                papel.DrawString((i + 25).ToString(), font, brushN, i+25, 0);
            }
            //papel.FillRectangle(brushN, 0, 0, 25, 25);
            //papel.FillRectangle(brushB, 0, 25, 25, 25);
        }
    }
}






