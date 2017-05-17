using _OLC1_Proyecto2_201503470.Analizadores;
using _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OLC1_Proyecto2_201503470.Tablas
{
    class TablaSimbolos
    {
 

        public TablaSimbolos() { }
  

        public void GraficarTabla(List<RecorridoLienzos> listaLienzos, List<ObjVariable> listaVariables,List<ObjArreglo> listaArr)
        {

            String tablasimboloshtml = "";


            tablasimboloshtml = "<html> \n " +
                                "<head>" +
                                    "<meta http-equiv=\"Content - Type\" content=\"text / html; charset = ISO - 8859 - 1\">" +
                                "</head>" +
                                "<body>" +
                                    "<center>" +
                                        "<table style=\" border: black 4px solid; \" width=\"80%\">" +
                                             "<tr>" +
                                                "<td bgcolor =\"black\">" +
                                                    "<center><font face=\"verdana\" color=\"White\" size=\"5px\">TABLA DE SIMBOLOS</font></center>" +
                                                "</td>" +
                                             "</tr>" +

                                             " <tr>" +
                                                "<td style =\"padding: 15px;\"> " +
                                                     "<center>" +
                                                         "<table border=\"1\" width=\"90%\" style=\"border-collapse: collapse;\">" +
                                                             "<tr>" +
                                                                 "<td colspan=\"6\" bgcolor=\"#1c2833\">" +
                                                                     "<center><font face=\"verdana\" size=\"4px\" color=\"White\">Lienzos</font></center>" +
                                                                 "</td>" +
                                                             "</tr>" +

                                                             "<tr bgcolor=\"#154360\" >" +
                                                                "<td><center><font face=\"verdana\" size=\"3px\" color=\"White\">Visibilidad</font></td>" +
                                                                "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Tipo</font></td>" +
                                                                "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Nombre</font></td>" +
                                                                "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Ambito</font></td>" +
                                                                "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Extiende</font></td>" +
                                                             "</tr>";
                                                            //LIENZOS
                                                            foreach (RecorridoLienzos nodo in listaLienzos)
                                                            {
                                                                tablasimboloshtml += "<tr>";
                                                                    tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\"> "+separar(nodo.VisibilidadLienzo)+"</font></td>";
                                                                    tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">"+separar(nodo.Tipo)+"</font></td>";
                                                                    tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">"+separar(nodo.NombreLienzo)+"</font></td>";
                                                                    tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">" + separar(nodo.AmbitoLienzo) + "</font></td>";
                                                                    tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">{" + nodo.Extiende + "}</font></td>";
                                                                tablasimboloshtml += "</tr>";

                                                            }
                                        tablasimboloshtml += "</table>" +
                                                    "</center>" +
                                             "</td>" +
                                        "</tr>";

            //-----------------------------------------------------------------
            tablasimboloshtml += " <tr>" +
                                   "<td style =\"padding: 15px;\"> " +
                                        "<center>" +
                                            "<table border=\"1\" width=\"90%\" style=\"border-collapse: collapse;\">" +
                                                "<tr>" +
                                                    "<td colspan=\"6\" bgcolor=\"#1c2833\">" +
                                                        "<center><font face=\"verdana\" size=\"4px\" color=\"White\">Variables</font></center>" +
                                                    "</td>" +
                                                "</tr>" +

                                                "<tr bgcolor=\"#154360\" >" +
                                                   "<td><center><font face=\"verdana\" size=\"3px\" color=\"White\">Nombre</font></td>" +
                                                   "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Tipo</font></td>" +
                                                   "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Valor</font></td>" +
                                                   "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Ambito</font></td>" +
                                                "</tr>";
            //LIENZOS
            foreach (ObjVariable nodo in listaVariables )
            {
                tablasimboloshtml += "<tr>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\"> " + separar(nodo.NombreVar) + "</font></td>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">" + separar(nodo.TipoVar) + "</font></td>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">" + separar(nodo.ValorVar) + "</font></td>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">" + separar(nodo.AmbitoVar) + "</font></td>";
                
                tablasimboloshtml += "</tr>";

            }
            tablasimboloshtml += "</table>" +
                        "</center>" +
                 "</td>" +
            "</tr>";

            //-----------------------------------------------------------------
            tablasimboloshtml += " <tr>" +
                                   "<td style =\"padding: 15px;\"> " +
                                        "<center>" +
                                            "<table border=\"1\" width=\"90%\" style=\"border-collapse: collapse;\">" +
                                                "<tr>" +
                                                    "<td colspan=\"6\" bgcolor=\"#1c2833\">" +
                                                        "<center><font face=\"verdana\" size=\"4px\" color=\"White\">Arreglos</font></center>" +
                                                    "</td>" +
                                                "</tr>" +

                                                "<tr bgcolor=\"#154360\" >" +
                                                   "<td><center><font face=\"verdana\" size=\"3px\" color=\"White\">Nombre</font></td>" +
                                                   "<td><center><font face=\"verdana\" size =\"3px\" color=\"White\">Valores</font></td>" +
                                                  
                                                   
                                                "</tr>";
            //LIENZOS
            foreach (ObjArreglo nodo in listaArr)
            {
                tablasimboloshtml += "<tr>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\"> " + nodo.NombreArr + "</font></td>";
                tablasimboloshtml += "<td><center><font face=\"verdana\" size=\"3px\">" + nodo.valores[0]+","+nodo.valores[1] + "</font></td>";
                

                tablasimboloshtml += "</tr>";

            }
            tablasimboloshtml += "</table>" +
                        "</center>" +
                 "</td>" +
            "</tr>";



            tablasimboloshtml +=    "</table>"+
                "</body>"+
                "</html>";





            System.IO.StreamWriter w = new System.IO.StreamWriter("TablaSimbolos.html");
            w.WriteLine(tablasimboloshtml);
            w.Close();
           
        }


        public string separar(String palabra)
        {
            Char delimiter = ' ';
            String[] sepa = palabra.Split(delimiter);
            return sepa[0];
        }

    }
}
