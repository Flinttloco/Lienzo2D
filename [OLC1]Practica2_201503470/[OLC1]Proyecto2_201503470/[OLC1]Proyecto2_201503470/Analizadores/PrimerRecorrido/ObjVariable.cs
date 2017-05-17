using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido
{
    class ObjVariable
    {



        public String NombreVar;
        public String TipoVar;
        public String ValorVar;
        public String AmbitoVar;
        

        public ObjVariable(String Nomv, String Tip, String Val, String Ambito)
        {
            this.NombreVar = Nomv;
            this.TipoVar = Tip;
            this.ValorVar = Val;
            this.AmbitoVar = Ambito;
          
        }

        public ObjVariable() { }

    }
}
