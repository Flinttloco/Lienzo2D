using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto2_201503470.Analizadores
{
    class Recorrido
    {
        public static void IniciarRecorrido(ParseTreeNode raiz)
        {

            Lienzo(raiz.ChildNodes.ElementAt(0) );
        }

        private static void Lienzo(ParseTreeNode raiz)
        {
            switch (raiz.ChildNodes.Count)
            {
                case 5:
                    Console.WriteLine("VISIBLIDAD: "+ Visibilidad(raiz.ChildNodes.ElementAt(0)) + "TIPO: Lienzo" + "NOMBRE: " + raiz.ChildNodes.ElementAt(1).ToString() + "AMBITO: Principal()" );
                    break;

                case 7:
                    Console.WriteLine("dsfasdf");
                    break;
            }

        }

        private static String Visibilidad(ParseTreeNode raiz) {
            String retornado="publico";

            switch (raiz.ChildNodes.Count)
            {
                case 2:
                    return raiz.ChildNodes.ElementAt(0).ToString();
                   

                case 1:
                    return "Publico";


            }

                    return retornado;
            
        }
    }
}
