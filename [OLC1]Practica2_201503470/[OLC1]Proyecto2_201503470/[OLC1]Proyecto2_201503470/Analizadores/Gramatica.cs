using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _OLC1_Proyecto2_201503470.Tablas;

using Irony.Ast;
using Irony.Parsing;

namespace _OLC1_Proyecto2_201503470.Analizadores
{
    class Gramatica : Grammar
    {

        public List<Errores> lista = new List<Errores>();

        //CONSTRUCTOR
        public Gramatica() : base(caseSensitive: true)
        {

            #region ER
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", ">>", "\n", "\r\n"); //si viene una nueva linea se termina de reconocer el comentario.
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "<-", "->");
            NonGrammarTerminals.Add(comentarioLinea);
            NonGrammarTerminals.Add(comentarioBloque);

            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
            RegexBasedTerminal num = new RegexBasedTerminal("num", "[0-9]");
            RegexBasedTerminal letra = new RegexBasedTerminal("letra", "[a-zA-Z]");
            IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion

            #region TERMINALES
            var abre = ToTerm("¿");
            var cierra = ToTerm("?");
            var publico = ToTerm("publico");
            var privado = ToTerm("privado");
            var extend = ToTerm("extiende");
            var lienzo = ToTerm("Lienzo");
            var conservar = ToTerm("Conservar");
            var vari = ToTerm("var");
            var entero = ToTerm("entero");
            var doble = ToTerm("doble");
            var booleano = ToTerm("boolean");
            var caracter = ToTerm("caracter");
            var cadena = ToTerm("cadena");
            var arreglo = ToTerm("arreglo");
            var SI = ToTerm("si");
            var SINO = ToTerm("sino");
            var PARA = ToTerm("para");
            var MIENTRAS = ToTerm("mientras");
            var HACER = ToTerm("hacer");
            var fin = ToTerm("$");
            var principal = ToTerm("Principal");
            var retorn = ToTerm("retornar");
            var punto = ToTerm("Pintar_P");
            var or = ToTerm("Pintar_OR");
            #endregion

            #region NO TERMINALES
            NonTerminal E = new NonTerminal("E");
            NonTerminal INICIO = new NonTerminal("INICIO");
            NonTerminal LIENZO = new NonTerminal("LIENZO");
            NonTerminal CUERPOLIENZO = new NonTerminal("CUERPOLIENZO");
            NonTerminal VISIBILIDAD = new NonTerminal("VISIBILIDAD");
            NonTerminal EXTENDER = new NonTerminal("EXTENDER");
            NonTerminal VARIABLES = new NonTerminal("VARIABLES");
            NonTerminal TIPO = new NonTerminal("TIPO");
            NonTerminal TIPOARR = new NonTerminal("TIPOARREGLO");
            NonTerminal VARENTERO = new NonTerminal("VARENTERO");
            NonTerminal ARRENTERO = new NonTerminal("VARENTERO");
            NonTerminal VARDOBLE = new NonTerminal("VARDOBLE");
            NonTerminal ARRDOBLE = new NonTerminal("VARDOBLE");
            NonTerminal VARBOOL = new NonTerminal("VARDOBLE");
            NonTerminal BOOL = new NonTerminal("BOOL");
            NonTerminal CARACTER = new NonTerminal("CARACTER");
            NonTerminal LISTCARACTER = new NonTerminal("LISTCARACTER");
            NonTerminal CADENA = new NonTerminal("CADENA");
            NonTerminal LISTCADENA = new NonTerminal("LISTCADENA");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal ASIGNACIONARR = new NonTerminal("ASIGNACIONARR");
            NonTerminal ARREGLOS = new NonTerminal("ASIGNACION");
            NonTerminal DIMENSIONES = new NonTerminal("DIMENSIONES");
            NonTerminal VALARRENTERO = new NonTerminal("VALARRENTERO");
            NonTerminal VALARRBOOLEANO = new NonTerminal("VALARRBOOLEANO");
            NonTerminal VALARRCARACTER = new NonTerminal("VALARRCARACTER");
            NonTerminal VALARRCADENA = new NonTerminal("VALARRCADENA");
            NonTerminal ARRBOOLEANO = new NonTerminal("ARRBOOLEANO");
            NonTerminal ARRCARACTER = new NonTerminal("ARRCARACTER");
            NonTerminal ARRCADENA = new NonTerminal("ARRCADENA");
            NonTerminal CONDICION = new NonTerminal("CONDICION");
            NonTerminal CUERPOGENERAL = new NonTerminal("CUERPOGENERAL");
            NonTerminal CICLOS = new NonTerminal("CICLOS");
            NonTerminal ASIGNACIONPARA = new NonTerminal("ASIGNACIONPARA");
            NonTerminal AUMENTOPARA = new NonTerminal("AUMENTOPARA");

            NonTerminal PRINCIPAL = new NonTerminal("PRINCIPAL");
            NonTerminal PROCEDIMIENTOS = new NonTerminal("PROCEDIMIENTOS");
            NonTerminal PROCNATIVOS = new NonTerminal("PROCNATIVOS");
            NonTerminal TIPOPROC = new NonTerminal("TIPOPROC");
            NonTerminal PARAMETROS = new NonTerminal("PARAMETROS");
            NonTerminal TIPOVAR = new NonTerminal("TIPOVAR");

            NonTerminal METODOS = new NonTerminal("METODOS");




            #endregion

            #region GRAMATICA
            //---------------------------------LIENZO-------------------------------------------
            INICIO.Rule = LIENZO;

            VISIBILIDAD.Rule = publico  
                             | privado 
                             ;

            EXTENDER.Rule = EXTENDER + ToTerm(",") + id
                          | id;


            LIENZO.Rule = VISIBILIDAD +lienzo+ id + abre + CUERPOLIENZO + cierra
                        | VISIBILIDAD +lienzo + id + extend + EXTENDER + abre + CUERPOLIENZO + cierra
                        ;
            LIENZO.ErrorRule = SyntaxError + "¿";
            //------------------------------------CUERPO----------------------------------------------

            CUERPOLIENZO.Rule = CUERPOLIENZO + VARIABLES
                              | VARIABLES
                              | CUERPOLIENZO + ARREGLOS
                              | ARREGLOS
                              | CUERPOLIENZO + CICLOS
                              | CICLOS
                              |CUERPOLIENZO + PRINCIPAL
                              |PRINCIPAL
                              |CUERPOLIENZO + PROCEDIMIENTOS
                              |PROCEDIMIENTOS;

            CUERPOGENERAL.Rule = CUERPOGENERAL + VARIABLES
                                | VARIABLES
                                | CUERPOGENERAL + ARREGLOS
                                | ARREGLOS
                                | CUERPOGENERAL + CICLOS
                                | CICLOS
                                |CUERPOGENERAL + PROCNATIVOS
                                | PROCNATIVOS
                                |CUERPOGENERAL+ METODOS
                                |METODOS
                                ;
            METODOS.Rule = id + ToTerm("(") + ToTerm(")") + ToTerm("$")
                         |id + ToTerm("(")+PARAMETROS+ToTerm(")")+ ToTerm("$");

            #region ARREGLOS

            ARREGLOS.Rule = conservar + vari + TIPOARR
                           | vari + TIPOARR
                           | ASIGNACIONARR;

            ASIGNACIONARR.Rule = id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + VARENTERO + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + ARRENTERO + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + VALARRBOOLEANO + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + ARRBOOLEANO + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + VALARRCADENA + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + ARRCADENA + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + VALARRCARACTER + ToTerm("}") + fin
                                | id + ToTerm("[") + E + ("]") + ToTerm("=") + ToTerm("{") + ARRCARACTER + ToTerm("}") + fin;
            ASIGNACIONARR.ErrorRule = SyntaxError + "$";

            TIPOARR.Rule = entero + arreglo + EXTENDER + DIMENSIONES + fin
                      | entero + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + VALARRENTERO + ToTerm("}") + fin
                      | entero + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + ARRENTERO + ToTerm("}") + fin
                      | entero + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + E+ fin
                      | doble + arreglo + EXTENDER + DIMENSIONES + fin
                      | doble + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + VALARRENTERO + ToTerm("}") + fin
                      | doble + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + ARRENTERO + ToTerm("}") + fin
                      | doble + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + E + fin
                      | booleano + arreglo + EXTENDER + DIMENSIONES + fin
                      | booleano + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + VALARRBOOLEANO + ToTerm("}") + fin
                      | booleano + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + ARRBOOLEANO + ToTerm("}") + fin
                      | booleano + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + E + fin
                      | caracter + arreglo + EXTENDER + DIMENSIONES + fin
                      | caracter + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + VALARRCARACTER + ToTerm("}") + fin
                      | caracter + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + ARRCARACTER + ToTerm("}") + fin
                      | caracter + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + E + fin
                      | cadena + arreglo + EXTENDER + DIMENSIONES + fin
                      | cadena + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + VALARRCADENA + ToTerm("}") + fin
                      | cadena + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + ToTerm("{") + ARRCADENA + ToTerm("}") + fin
                      | cadena + arreglo + EXTENDER + DIMENSIONES + ToTerm("=") + E + fin;
            TIPOARR.ErrorRule = SyntaxError + "$";


            //-----------------DIMENSIONES ARREGLO----------

            DIMENSIONES.Rule = DIMENSIONES + ToTerm("[") + E + ToTerm("]")
                             | ToTerm("[") + E + ToTerm("]");

            //-----------------ARREGLO ENTERO Y DOBLE----------
            ARRENTERO.Rule = ARRENTERO + ToTerm(",") + ToTerm("{") + VALARRENTERO + ToTerm("}")
                            | ToTerm("{") + VALARRENTERO + ToTerm("}");


            VALARRENTERO.Rule = VALARRENTERO + ToTerm(",") + E
                                | E;
            //-----------------ARREGLO BOOLEANO----------
            ARRBOOLEANO.Rule = ARRBOOLEANO + ToTerm(",") + ToTerm("{") + VALARRBOOLEANO + ToTerm("}")
                             | ToTerm("{") + VALARRBOOLEANO + ToTerm("}");

            VALARRBOOLEANO.Rule = VALARRBOOLEANO + ToTerm(",") + BOOL
                                | BOOL;

            //-----------------ARREGLO CARACTER----------
            ARRCARACTER.Rule = ARRCARACTER + ToTerm(",") + ToTerm("{") + VALARRCARACTER + ToTerm("}")
                             | ToTerm("{") + VALARRCARACTER + ToTerm("}");

            VALARRCARACTER.Rule = VALARRCARACTER + ToTerm(",") + ToTerm("'") + LISTCARACTER + ToTerm("'")
                                | ToTerm("'") + LISTCARACTER + ToTerm("'");

            //-----------------ARREGLO CADENA----------
            ARRCADENA.Rule = ARRCADENA + ToTerm(",") + ToTerm("{") + VALARRCADENA + ToTerm("}")
                             | ToTerm("{") + VALARRCADENA + ToTerm("}");

            VALARRCADENA.Rule = VALARRCADENA + ToTerm(",") + ToTerm("\"") + LISTCADENA + ToTerm("\"")
                                | ToTerm("\"") + LISTCADENA + ToTerm("\"");


            #endregion


            #region VARIABLES
            VARIABLES.Rule = conservar + vari + TIPO
                           | vari + TIPO
                           | ASIGNACION;

            ASIGNACION.Rule = EXTENDER + ToTerm("=") + E + fin
                           | EXTENDER + ToTerm("=") + BOOL + fin
                           | EXTENDER + ToTerm("=") + ToTerm("'") + LISTCARACTER + ToTerm("'") + fin
                           | EXTENDER + ToTerm("=") + ToTerm("\"") + LISTCADENA + ToTerm("\"") + fin
                           | id + ToTerm("++")
                           | id + ToTerm("--")
                           | numero + ToTerm("++")
                           | numero + ToTerm("--")
                           | E + ToTerm("++")
                           | E + ToTerm("--")
                           | id + ToTerm("++")+fin
                           | id + ToTerm("--") + fin
                           | numero + ToTerm("++") + fin
                           | numero + ToTerm("--") + fin
                           | E + ToTerm("++") + fin
                           | E + ToTerm("--")+fin
                           | E + ToTerm("+=")+E+fin
                           | E + ToTerm("-=")+E+fin;
            ASIGNACION.ErrorRule = SyntaxError + "$";

            TIPO.Rule = entero + VARENTERO + fin
                      | doble + VARDOBLE + fin
                      | booleano + VARBOOL + fin
                      | caracter + CARACTER + fin
                      | cadena + CADENA + fin;
            TIPO.ErrorRule = SyntaxError + "$";

            VARENTERO.Rule = VARENTERO + ToTerm(",") + id
                            | id
                            | VARENTERO + ToTerm(",") + id + ToTerm("=") + E
                            | id + ToTerm("=") + E
                            ;



            VARDOBLE.Rule = VARDOBLE + ToTerm(",") + id
                            | id
                            | VARDOBLE + ToTerm(",") + id + ToTerm("=") + numero + ToTerm(".") + numero
                            | id + ToTerm("=") + numero + ToTerm(".") + numero
                            | VARDOBLE + ToTerm(",") + id + ToTerm("=") + E
                            | id + ToTerm("=") + E;

            VARBOOL.Rule = VARBOOL + ToTerm(",") + id
                            | id
                            | VARBOOL + ToTerm(",") + id + ToTerm("=") + BOOL
                            | id + ToTerm("=") + BOOL
                            | VARBOOL + ToTerm(",") + id + ToTerm("=") + E
                            | id + ToTerm("=") + E;

            BOOL.Rule = ToTerm("true")
                       | ToTerm("false")
                       | ToTerm("1")
                       | ToTerm("0");

            CARACTER.Rule = CARACTER + ToTerm(",") + id
                          | id
                          | CARACTER + ToTerm(",") + id + ToTerm("=") + ToTerm("'") + LISTCARACTER + ToTerm("'")
                          | id + ToTerm("=") + ToTerm("'") + LISTCARACTER + ToTerm("'");
            #region listaCARAC
            LISTCARACTER.Rule = letra
                             | num
                             | ToTerm("#t")
                             | ToTerm("#n")
                             | ToTerm("#r")
                             | ToTerm("^^")
                             | ToTerm("^'")
                             | ToTerm("!")
                             | ToTerm("#")
                             | ToTerm("$")
                             | ToTerm("%")
                             | ToTerm("&")
                             | ToTerm("(")
                             | ToTerm(")")
                             | ToTerm("*")
                             | ToTerm("+")
                             | ToTerm("-")
                             | ToTerm("_")
                             | ToTerm("/")
                             | ToTerm("=")
                             | ToTerm("<")
                             | ToTerm(">")
                             | ToTerm(":")
                             | ToTerm(";")
                             | ToTerm("?")
                             | ToTerm("¿")
                             | ToTerm("¡")
                             | ToTerm("\\")
                             | ToTerm("[")
                             | ToTerm("]")
                             | ToTerm("{")
                             | ToTerm("}");
            #endregion 

            CADENA.Rule = CADENA + ToTerm(",") + id
                        | id
                        | CADENA + ToTerm(",") + id + ToTerm("=") + ToTerm("\"") + LISTCADENA + ToTerm("\"")
                        | id + ToTerm("=") + ToTerm("\"") + LISTCADENA + ToTerm("\"");

            #region ListaCadena
            LISTCADENA.Rule = LISTCADENA + id
                         | LISTCADENA + numero
                         | LISTCADENA + ToTerm("#t")
                         | LISTCADENA + ToTerm("#n")
                         | LISTCADENA + ToTerm("#r")
                         | LISTCADENA + ToTerm("^^")
                         | LISTCADENA + ToTerm("^'")
                         | LISTCADENA + ToTerm("!")
                         | LISTCADENA + ToTerm("#")
                         | LISTCADENA + ToTerm("$")
                         | LISTCADENA + ToTerm("%")
                         | LISTCADENA + ToTerm("&")
                         | LISTCADENA + ToTerm("(")
                         | LISTCADENA + ToTerm(")")
                         | LISTCADENA + ToTerm("*")
                         | LISTCADENA + ToTerm("+")
                         | LISTCADENA + ToTerm("-")
                         | LISTCADENA + ToTerm("_")
                         | LISTCADENA + ToTerm("/")
                         | LISTCADENA + ToTerm("=")
                         | LISTCADENA + ToTerm("<")
                         | LISTCADENA + ToTerm(">")
                         | LISTCADENA + ToTerm(":")
                         | LISTCADENA + ToTerm(";")
                         | LISTCADENA + ToTerm("?")
                         | LISTCADENA + ToTerm("¿")
                         | LISTCADENA + ToTerm("¡")
                         | LISTCADENA + ToTerm("\\")
                         | LISTCADENA + ToTerm("[")
                         | LISTCADENA + ToTerm("]")
                         | LISTCADENA + ToTerm("{")
                         | LISTCADENA + ToTerm("}")
                         | id
                         | numero
                         | ToTerm("#t")
                         | ToTerm("#n")
                         | ToTerm("#r")
                         | ToTerm("^^")
                         | ToTerm("^'")
                         | ToTerm("!")
                         | ToTerm("#")
                         | ToTerm("$")
                         | ToTerm("%")
                         | ToTerm("&")
                         | ToTerm("(")
                         | ToTerm(")")
                         | ToTerm("*")
                         | ToTerm("+")
                         | ToTerm("-")
                         | ToTerm("_")
                         | ToTerm("/")
                         | ToTerm("=")
                         | ToTerm("<")
                         | ToTerm(">")
                         | ToTerm(":")
                         | ToTerm(";")
                         | ToTerm("?")
                         | ToTerm("¿")
                         | ToTerm("¡")
                         | ToTerm("\\")
                         | ToTerm("[")
                         | ToTerm("]")
                         | ToTerm("{")
                         | ToTerm("}");

            #endregion


            #endregion

            #region CICLOS
            CICLOS.Rule = SI + ToTerm("(") + CONDICION + (")") + abre + CUERPOGENERAL + cierra
                        | SI + ToTerm("(") + CONDICION + (")") + abre + CUERPOGENERAL + cierra + SINO + abre + CUERPOGENERAL + cierra
                        | PARA + ToTerm("(") + ASIGNACIONPARA + ToTerm(";") + CONDICION + ToTerm(";") + AUMENTOPARA + ToTerm(")") + abre + CUERPOGENERAL + cierra
                        | MIENTRAS + ToTerm("(") + CONDICION + ToTerm(")") + abre + CUERPOGENERAL + cierra
                        | HACER + abre + CUERPOGENERAL + cierra + MIENTRAS + ToTerm("(") + CONDICION + ToTerm(")") + fin
                        | SI + ToTerm("(") + CONDICION + (")") + abre + cierra
                        | SI + ToTerm("(") + CONDICION + (")") + abre + cierra + SINO + abre + CUERPOGENERAL + cierra
                        | PARA + ToTerm("(") + ASIGNACIONPARA + ToTerm(";") + CONDICION + ToTerm(";") + AUMENTOPARA + ToTerm(")") + abre + cierra
                        | MIENTRAS + ToTerm("(") + CONDICION + ToTerm(")") + abre + cierra
                        | HACER + abre + cierra + MIENTRAS + ToTerm("(") + CONDICION + ToTerm(")") + fin;

            ASIGNACIONPARA.Rule = vari + entero + id + ToTerm("=") + E
                                | id + ToTerm("=") + E;

            AUMENTOPARA.Rule = id + ToTerm("++")
                           | id + ToTerm("--")
                           | numero + ToTerm("++")
                           | numero + ToTerm("--")
                           | E + ToTerm("++")
                           | E + ToTerm("--");
            #endregion

            #region ARITMETICA
            E.Rule = E + ToTerm("+") + E
                     | E + ToTerm("-") + E
                     | E + ToTerm("*") + E
                     | E + ToTerm("/") + E
                     | ToTerm("(") + E + (")")
                     | ToTerm("[") + E + ("]")
                     | numero
                     | E + ToTerm(".") + E
                     | id
                     |id + ToTerm("(")+ToTerm(")")
                     |id + ToTerm("(")+ PARAMETROS + ToTerm(")")
                     |id + ToTerm("[") + E + ("]")
                     ;
            #endregion

            #region CONDICION
            CONDICION.Rule = CONDICION + ToTerm("+") + E
                    | CONDICION + ToTerm("-") + CONDICION
                    | CONDICION + ToTerm("*") + CONDICION
                    | CONDICION + ToTerm("/") + CONDICION
                    | CONDICION + ToTerm("<") + CONDICION
                    | CONDICION + ToTerm(">") + CONDICION
                    | CONDICION + ToTerm("==") + CONDICION
                    | CONDICION + ToTerm("!=") + CONDICION
                    | CONDICION + ToTerm("<=") + CONDICION
                    | CONDICION + ToTerm(">=") + CONDICION
                    | CONDICION + ToTerm("||") + CONDICION
                    | CONDICION + ToTerm("&&") + CONDICION
                    | CONDICION + ToTerm("!&&") + CONDICION
                    | CONDICION + ToTerm("!||") + CONDICION
                    | CONDICION + ToTerm("&|") + CONDICION
                    | ToTerm("!") + CONDICION
                    | ToTerm("(") + CONDICION + (")")
                    | ToTerm("[") + CONDICION + ("]")
                    | numero
                    | CONDICION + ToTerm(".") + CONDICION
                    | id;

            #endregion

            #region PROCEDIMIENTOS

            PRINCIPAL.Rule = principal + ToTerm("(") + ToTerm(")") + abre + CUERPOGENERAL + cierra
                           | principal + ToTerm("(") + ToTerm(")") + abre + cierra;

            PROCEDIMIENTOS.Rule = VISIBILIDAD + conservar + TIPOPROC
                                | conservar + TIPOPROC
                                |TIPOPROC
                                | VISIBILIDAD + TIPOPROC;

            TIPOPROC.Rule = TIPOVAR +  id + ToTerm("(") + PARAMETROS + ToTerm(")") + abre + CUERPOGENERAL + retorn + E +fin+ cierra
                          | id + ToTerm("(") + PARAMETROS + ToTerm(")") + abre + CUERPOGENERAL +  cierra
                          | booleano +id + ToTerm("(") + PARAMETROS + ToTerm(")") + abre + CUERPOGENERAL + retorn+fin+ BOOL + cierra
                          | cadena +id + ToTerm("(") + PARAMETROS + ToTerm(")") + abre + CUERPOGENERAL + retorn +ToTerm("'")+ LISTCADENA +ToTerm("'") + fin + cierra
                          | caracter + id + ToTerm("(") + PARAMETROS + ToTerm(")") + abre + CUERPOGENERAL + retorn + ToTerm("\"")+LISTCADENA+ToTerm("\"") + fin + cierra


                          | TIPOVAR + id + ToTerm("(") +ToTerm(")") + abre + CUERPOGENERAL + retorn + E + fin + cierra
                          | id + ToTerm("(") + ToTerm(")") + abre + CUERPOGENERAL + cierra
                          | booleano + id + ToTerm("(") +  ToTerm(")") + abre + CUERPOGENERAL + retorn + BOOL + fin + cierra
                          | cadena + id + ToTerm("(") +  ToTerm(")") + abre + CUERPOGENERAL + retorn + ToTerm("'") + LISTCADENA + ToTerm("'") + fin + cierra
                          | caracter + id + ToTerm("(") + ToTerm(")") + abre + CUERPOGENERAL + retorn + ToTerm("\"") + LISTCADENA + ToTerm("\"") + fin + cierra;

            PARAMETROS.Rule = PARAMETROS + ToTerm(",") + TIPOVAR + E
                            | TIPOVAR + E
                            |PARAMETROS + ToTerm(",")+E
                            |E
                            |PARAMETROS + ToTerm(",")+ id + E
                            | id + E
                            ;

            TIPOVAR.Rule = entero
                         | doble
                         | booleano
                         | cadena
                         | caracter
                         | entero + ToTerm("[")+ToTerm("]")
                         | doble + ToTerm("[") + ToTerm("]")
                         | booleano + ToTerm("[") + ToTerm("]")
                         | cadena + ToTerm("[") + ToTerm("]")
                         | caracter + ToTerm("[") + ToTerm("]");

            PROCNATIVOS.Rule = punto + ToTerm("(") + E+ ToTerm(",")+E+ToTerm(",")+ToTerm("\"")+LISTCADENA+ToTerm("\"")+ToTerm(",")+E+ToTerm(")")+ToTerm("$")
                             | or + ToTerm("(") + E + ToTerm(",") + E + ToTerm(",") + ToTerm("\"") + LISTCADENA + ToTerm("\"") + ToTerm(",") + E+ ToTerm(",") + E+ ToTerm(",") + ToTerm("'") +ToTerm("o")+ ToTerm("'") + ToTerm(")") + ToTerm("$")
                             | or + ToTerm("(") + E + ToTerm(",") + E + ToTerm(",") + ToTerm("\"") + LISTCADENA + ToTerm("\"") + ToTerm(",") + E + ToTerm(",") + E + ToTerm(",") + ToTerm("'") + ToTerm("r") + ToTerm("'") + ToTerm(")") + ToTerm("$");

            #endregion

            #endregion

            #region PREFERENCIAS
            this.Root = INICIO;
            #endregion

        }


        public override void ReportParseError(ParsingContext context)
        {
            String error = (String)context.CurrentToken.ValueString;

            String tipo;
            int fila;
            int columna;

            if (error.Contains("Invalid character"))
            {
                tipo = "Error Lexico";
                string delimStr = ":";
                char[] delimiter = delimStr.ToCharArray();
                string[] division = error.Split(delimiter, 2);
                division = division[1].Split('.');
                error = "Caracter Invalido: " + division[0];
            }
            else
            {
                tipo = "Error Sintactico";
                error = "No se esperaba: " + error;
            }

            fila = context.Source.Location.Line;
            columna = context.Source.Location.Column;
            Errores nuevo = new Errores(tipo, error, columna, fila);
            this.lista.Add(nuevo);
            base.ReportParseError(context);
        }




    }
}
