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

namespace _OLC1_Proyecto2_201503470
{
    public partial class Form1 : Form
    {

        ParseTreeNode most = null;
        public Form1()
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
            //System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            //System.Console.ReadLine();

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


        //EJECUTAR
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            foreach (Control c in this.tabControl1.SelectedTab.Controls)
            {



                Gramatica gramatica = new Gramatica();
                LanguageData lenguaje = new LanguageData(gramatica);
                Parser parser = new Parser(lenguaje);
                ParseTree arbol = parser.Parse(c.Text);
                ParseTreeNode raiz = arbol.Root;
                ParseTreeNode resultado = arbol.Root;

                if (resultado != null)
                {

                    most = resultado;
                    //  Recorrido.IniciarRecorrido(resultado);

                }
                else
                {

                }
                Errores errores = new Errores();
                String er = errores.GraficarTabla(gramatica.lista);

                String[] partes = er.Split(',');

                foreach (String err in partes)
                {

                    richTextBox1.Text += err + "\n";
                }

            }
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
    }
}






