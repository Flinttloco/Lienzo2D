using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido
{
    class Pintar
    {
        public float posx,posy,diam,ancho,alto;
        public String color,tipo;


        public  Pintar() { }

        public  Pintar(float posx,float posy,string color,float diammetro)
        {
            this.posx = posx;
            this.posy = posy;
            this.color = color;
            this.diam = diammetro;
            this.tipo = "p";
        }

        public Pintar(float posx, float posy, string color,float anch, float alt,string tip)
        {
            this.posx = posx;
            this.posy = posy;
            this.color = color;
            this.ancho = anch;
            this.alto = alt;
            this.tipo = tip;
        }
    }
}
