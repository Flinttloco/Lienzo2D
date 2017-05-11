using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;

namespace _OLC1_Proyecto2_201503470.Grafica
{
    class GenerarGrafica
    {



        private static int contador;
        private static String grafo;

        public static String GenerarEstructura(ParseTreeNode raiz)
        {
            grafo = "digraph G{\n";
            grafo += "node[shape=\"box\"];\n";
            grafo += "nodo0[label =\"" + Borrar(raiz.ToString()) + "\"];\n";
            contador = 1;
            RecorrerArbol("nodo0", raiz);
            grafo += "}";
            return grafo;
        }


        private static String Borrar(String cadena)
        {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }

        private static void RecorrerArbol(String padre, ParseTreeNode hijos)
        {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombrehijo = "nodo" + contador.ToString();
                grafo += nombrehijo + "[label=\"" + Borrar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nombrehijo + ";\n";
                contador++;
                RecorrerArbol(nombrehijo, hijo);

            }

        }
    }
}
