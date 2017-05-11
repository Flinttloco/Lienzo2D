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

namespace _OLC1_Proyecto2_201503470
{
    public partial class MostrarAST : Form
    {
        ParseTreeNode resultado = null;
        public MostrarAST(ParseTreeNode most)
        {
            InitializeComponent();

            pictureBox1.Image = Sintactico.getImage(most);
        }

        private void MostrarAST_Load(object sender, EventArgs e)
        {

           

        }
    }
}
