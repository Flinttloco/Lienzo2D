using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido
{
    class ObjArreglo
    {
        public String NombreArr;
        public int[] valores = new int[3];


        public ObjArreglo() { }

        public ObjArreglo(String Nombre,int valor1,int valor2)
        {
            this.NombreArr = Nombre;
            this.valores[0] = valor1;
            this.valores[1] = valor2;

        }

    }
}
