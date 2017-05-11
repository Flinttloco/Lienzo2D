using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

using System.Drawing;
using System.IO;
using WINGRAPHVIZLib;
using _OLC1_Proyecto2_201503470.Grafica;

namespace _OLC1_Proyecto2_201503470.Analizadores
{
    class Sintactico: Grammar
    {
        public static ParseTreeNode analizar(String cadena)
        {

            Gramatica gramatica = new Gramatica();
            LanguageData lenguaje = new LanguageData(gramatica);
            Parser parser = new Parser(lenguaje);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            return arbol.Root;
        }

        public static Image getImage(ParseTreeNode raiz)
        {
            String grafica = GenerarGrafica.GenerarEstructura(raiz);
            WINGRAPHVIZLib.DOT dot = new WINGRAPHVIZLib.DOT();
            WINGRAPHVIZLib.BinaryImage img = dot.ToPNG(grafica);
            byte[] imageBytes = Convert.FromBase64String(img.ToBase64String());
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image imagen = Image.FromStream(ms, true);
            return imagen;

        }

    }
}
