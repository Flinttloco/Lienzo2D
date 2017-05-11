using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _OLC1_Proyecto2_201503470.Tablas
{
    class Errores
    {

        String Error;
        String tipo;
        int linea;
        int columna;


        public Errores(String tipo, String Error, int columna, int fila)
        {
           
            this.Error = Error;
            this.tipo = tipo;
            this.linea = fila;
            this.columna = columna;

        }

        public Errores()
        {

        }


        public string GraficarTabla(List<Errores> listaErrores)
        {
            string retornado = "";

            if (listaErrores.Count != 0)
            {
                retornado += "--------------------------------------------ANALISIS FALLIDO. ["+listaErrores.Count+"] ERRORES ENCONTRADOS-------------------------------------------\n,";
            }
            else {
                retornado += "--------------------------------------------ANALISIS EXITOSO. [0] ERRORES ENCONTRADOS---------------------------------------,";
            }

            String tablasimboloshtml = "";

            int año = DateTime.Now.Year;
            int mes = DateTime.Now.Month;
            int dia = DateTime.Now.Day;
            int hora = DateTime.Now.Hour;
            int minuto = DateTime.Now.Minute;
            int segundo = DateTime.Now.Second;

            tablasimboloshtml += "<html>\n\t<head>\n\t\t<center><title>REPORTE DE ERRORES</title></center>" + "<meta charset=" + "\"" + "utf-8" + "\"" + ">"
                    + "\n\t\t<link rel=" + "\"" + "stylesheet" + "\"" + "type=" + "\"" + "text/css" + "\"" + " href=" + "\"" + "Estilo.css"
                    + "\"" + ">\n\t</head>\n\t<body>"
                    + "\n\t\t<div style=" + "\"" + "text-align:left;" + "\"" + ">"
                    + "\n\t\t\t<center><h1>REPORTE DE ERRORES</h1></center>"
                    + "\n\t\t\t<center><h3>Dia de ejecución:" + dia + " de " + getMes(mes) + " de " + año + "</h3></center>"
                    + "\n\t\t\t<center><h3>Hora de ejecución:" + hora + ":" + minuto + ":" + segundo + " " + hora + "</h3></center>"
                    + "\n\t\t\t<center><table style=\"margin: margin: 5 auto;\" border=\"1\">\n";
            tablasimboloshtml += "\t\t\t\t<TR>\n\t\t\t\t\t<TH>Tipo</TH>   <TH>error</TH><TH>Linea</TH><TH>Columna</TH>\n\t\t\t\t</TR>";
            int con = 0;
            foreach (Errores nodo in listaErrores)
            {
                tablasimboloshtml += "\n\t\t\t\t<TR>";
                tablasimboloshtml += "\n\t\t\t\t\t<TD>" + nodo.tipo + "</TD>" + "<TD>" + nodo.Error + "</TD>" + "<TD>" + nodo.linea + "</TD>" + "<TD>" + nodo.columna + "</TD>";
                tablasimboloshtml += "\n\t\t\t\t</TR>";

                retornado += "          ["+con+"] Error encontrado en la Columna " + nodo.columna + " y Linea " + nodo.linea+",";
                con++;
            }

            tablasimboloshtml += "\n\t\t\t</table></center>\n\t\t</div>\n\t</body>\n</html>";


            System.IO.StreamWriter w = new System.IO.StreamWriter("TablaErrores.html");
            w.WriteLine(tablasimboloshtml);
            w.Close();
            return retornado;
        }



        public String getMes(int mes)
        {
            String m = "";
            switch (mes)
            {
                case 1:
                    m = "Enero";
                    break;
                case 2:
                    m = "Febrero";
                    break;
                case 3:
                    m = "Marzo";
                    break;
                case 4:
                    m = "Abril";
                    break;
                case 5:
                    m = "Mayo";
                    break;
                case 6:
                    m = "Junio";
                    break;
                case 7:
                    m = "Julio";
                    break;
                case 8:
                    m = "Agosto";
                    break;
                case 9:
                    m = "Septiembre";
                    break;
                case 10:
                    m = "Octubre";
                    break;
                case 11:
                    m = "Noviembre";
                    break;
                default:
                    m = "Diciembre";
                    break;
            }
            return m;

        }










    }
}
