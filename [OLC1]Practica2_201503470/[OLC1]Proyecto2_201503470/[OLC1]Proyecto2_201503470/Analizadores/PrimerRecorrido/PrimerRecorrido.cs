using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _OLC1_Proyecto2_201503470;
using _OLC1_Proyecto2_201503470.Analizadores.PrimerRecorrido;

namespace _OLC1_Proyecto2_201503470.Analizadores
{
    class RecorridoLienzos
    {
        public static List<RecorridoLienzos> listaLienzos = new List<RecorridoLienzos>();
        public static List<ObjVariable> listaVariables = new List<ObjVariable>();
        public static List<Metodos> listaMetodos = new List<Metodos>();
        public static List<ObjArreglo> listaArreglo = new List<ObjArreglo>();
        public static List<ParseTreeNode> listaNodos = new List<ParseTreeNode>();
        public static List<Pintar> listaPintar = new List<Pintar>();
        public static List<ObjVariable> listaVar = new List<ObjVariable>();
        static String ambito = "General";


        public String VisibilidadLienzo;
        public String Tipo;
        public String NombreLienzo;
        public String AmbitoLienzo;
        public String Extiende;

        public RecorridoLienzos(String Visi, String Tip, String NombreL, String Ambito, String Extiende)
        {
            this.VisibilidadLienzo = Visi;
            this.Tipo = Tip;
            this.NombreLienzo = NombreL;
            this.AmbitoLienzo = Ambito;
            this.Extiende = Extiende;
        }

        public RecorridoLienzos() { }

        public static void IniciarRecorrido(ParseTreeNode raiz)
        {
            Lienzo(raiz.ChildNodes.ElementAt(0));
        }






        //---------------------------LIENZO--------------------------------
        private static void Lienzo(ParseTreeNode raiz)
        {
            RecorridoLienzos Nuevo;
            switch (raiz.ChildNodes.Count)
            {
                case 6:
                    Nuevo = new RecorridoLienzos(raiz.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString(), "Lienzo", raiz.ChildNodes.ElementAt(2).ToString(), "Principal()", "----");
                    listaLienzos.Add(Nuevo);
                    IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(4));
                    break;

                case 8:
                    ExtenderD(raiz.ChildNodes.ElementAt(4));
                    Nuevo = new RecorridoLienzos(raiz.ChildNodes.ElementAt(6).ChildNodes.ElementAt(0).ToString(), "Lienzo", raiz.ChildNodes.ElementAt(2).ToString(), "Principal()", extender);
                    listaLienzos.Add(Nuevo);
                    IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(6));
                    break;
            }

        }
        static String recuperado = "";
        static String extender = "";

        private static String ExtenderD(ParseTreeNode raiz) {
            Console.Write(raiz.ChildNodes.Count);
            switch (raiz.ChildNodes.Count)
            {
                case 3:
                    ExtenderD(raiz.ChildNodes.ElementAt(0));
                    //Recuperando la ultima coma
                    recuperado = raiz.ChildNodes.ElementAt(1).ToString();
                    extender += recuperado.Replace("(Key symbol)", "");
                    //Recuperando el ultimo id
                    recuperado = raiz.ChildNodes.ElementAt(2).ToString();
                    extender += recuperado.Replace("(id)", "");
                    break;


                case 1:
                    //Recuperando el id
                    recuperado = raiz.ChildNodes.ElementAt(0).ToString();
                    extender += recuperado.Replace("(id)", "");
                    break;
            }
            return "";
        }



        //-----------------------------CUERPO LIENZO------------------------------

        public static void IniciarCuerpoLienzo(ParseTreeNode raiz)
        {
            switch (raiz.ChildNodes.Count)
            {
                case 2:
                    switch (raiz.ChildNodes.ElementAt(1).ToString())
                    {
                        case "VARIABLES":
                            Console.WriteLine("Entre a variables");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            Variables(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "ARREGLOS":
                            Console.WriteLine("Entre a Arreglos");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            ARREGLOS(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "ASIGNACION":
                            Console.WriteLine("Entre a asignacion");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            ASIGNACION(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "CICLOS":
                            Console.WriteLine("Entre a ciclos");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            CICLOS(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "PRINCIPAL":
                            Console.WriteLine("Entre a Principal");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            PRINCIPAL(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "PROCEDIMIENTOS":
                            Console.WriteLine("Entre a procedimientos");
                            IniciarCuerpoLienzo(raiz.ChildNodes.ElementAt(0));
                            PROCEDIMIENTOS(raiz.ChildNodes.ElementAt(1));
                            break;

                    }
                    break;
                case 1:
                    switch (raiz.ChildNodes.ElementAt(0).ToString())
                    {
                        case "VARIABLES":
                            Console.WriteLine("Entre a variables");
                            Variables(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "ARREGLOS":
                            Console.WriteLine("Entre a Arreglos");
                            ARREGLOS(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "ASIGNACION":
                            Console.WriteLine("Entre a asignacion");
                            ASIGNACION(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "CICLOS":
                            Console.WriteLine("Entre a ciclos");        
                            CICLOS(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "PRINCIPAL":
                            Console.WriteLine("Entre a Principal");
                            PRINCIPAL(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "PROCEDIMIENTOS":
                            Console.WriteLine("Entre a procedimientos");
                            PROCEDIMIENTOS(raiz.ChildNodes.ElementAt(0));
                            break;
                    }
                    break;


            }

        }
        ////-----------------VARIABLES--------------------------------------


        public static void Variables(ParseTreeNode raiz)
        {

            switch (raiz.ChildNodes.Count)
            {


                case 2:
                    TIPO(raiz.ChildNodes.ElementAt(1));
                    break;
                case 3:
                    TIPO(raiz.ChildNodes.ElementAt(2));
                    break;

            }
        }


        public static void TIPO(ParseTreeNode raiz)
        {
            switch (separar(raiz.ChildNodes.ElementAt(0).ToString()))
            {
                case "entero":

                    VARENTERO(raiz.ChildNodes.ElementAt(1));
                    break;
                //case "doble":
                //    Console.WriteLine("doble------------------");
                //    VARDOBLE(raiz.ChildNodes.ElementAt(1));
                //    break;
                //case "booleano":
                //    Console.WriteLine("booleano------------------");
                //    VARBOOL(raiz.ChildNodes.ElementAt(1));
                //    break;
                //case "caracter":
                //    Console.WriteLine("caracter------------------");
                //    CARACTER(raiz.ChildNodes.ElementAt(1));
                //    break;
                //case "cadena":
                //    Console.WriteLine("cadena------------------");
                //    CADENA(raiz.ChildNodes.ElementAt(1));
                //    break;
                default:
                    Console.WriteLine("no ente------------------" + raiz.ChildNodes.ElementAt(0).ToString());
                    break;
            }

        }

        public static void ASIGNACION(ParseTreeNode raiz)
        {
            Console.WriteLine("Tamaño hijo--" + raiz.ChildNodes.Count);
            switch (raiz.ChildNodes.Count) {

                case 3:

                    switch (separar(raiz.ChildNodes.ElementAt(1).ToString()))
                    {

                        case "++":
                            Console.WriteLine("Entre a ++");
                            AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), 1);
                            break;
                        case "--":
                            AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), -1);
                            break;

                    }
                    break;
                case 4:
                    switch (separar(raiz.ChildNodes.ElementAt(1).ToString()))
                    {
                        case "+=":
                            AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), int.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString()));
                            break;
                        case "-=":
                            AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), -int.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString()));
                            break;
                        case "=":
                            AsignacionValor(separar(raiz.ChildNodes.ElementAt(0).ToString()), int.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString()));
                            break;
                    }
                    break;

            }

        }

        public static void VARENTERO(ParseTreeNode raiz)
        {

            ObjVariable Nuevo;

            switch (raiz.ChildNodes.Count)
            {
                case 1:
                    Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(0).ToString()), "entero", "0", ambito);
                    listaVariables.Add(Nuevo);
                    break;
                case 3:
                    if (raiz.ChildNodes.ElementAt(0).ToString() == "VARENTERO")
                    {
                        VARENTERO(raiz.ChildNodes.ElementAt(0));
                        Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(2).ToString()), "entero", "0", ambito);
                        listaVariables.Add(Nuevo);
                    }
                    else {
                        Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(0).ToString()), "entero", F(raiz.ChildNodes.ElementAt(2)).ToString(), ambito);
                        listaVariables.Add(Nuevo);
                    }
                    break;
                case 5:
                    VARENTERO(raiz.ChildNodes.ElementAt(0));
                    Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(2).ToString()), "entero", F(raiz.ChildNodes.ElementAt(4)).ToString(), ambito);
                    listaVariables.Add(Nuevo);
                    break;

            }

        }
        //ARREGLOS
        public static void ARREGLOS(ParseTreeNode raiz)
        {
            ObjArreglo NuevoAr;
            if (separar(raiz.ChildNodes.ElementAt(8).ToString())=="{")
            {
                VALORESARR(raiz.ChildNodes.ElementAt(9));
                String[] valarr = valloresArr.Split(',');
                int val1 = int.Parse( RetornarValorBuscado(valarr[0]).ToString());
                int val2 = int.Parse(RetornarValorBuscado(valarr[1]).ToString());
                NuevoAr = new ObjArreglo(separar(raiz.ChildNodes.ElementAt(3).ToString()),val1,val2);
                listaArreglo.Add(NuevoAr);
            }
            else
            {
                ObjArreglo nodo = new ObjArreglo();
                nodo = listaArreglo[0];
                NuevoAr = new ObjArreglo(separar(raiz.ChildNodes.ElementAt(3).ToString()), nodo.valores[0], nodo.valores[1]);
                listaArreglo.Add(NuevoAr);
            }
        }

        static String valloresArr="";
        public static void VALORESARR(ParseTreeNode raiz)
        {
            switch (raiz.ChildNodes.Count)
            {
                case 1:
                    valloresArr += separar(raiz.ChildNodes.ElementAt(0).ToString());
                    break;
                case 3:
                    valloresArr += separar(raiz.ChildNodes.ElementAt(2).ToString());
                    break;
            }
        }
        //PROCEDIMIENTOS
        public static void PROCEDIMIENTOS(ParseTreeNode raiz)
        {
            switch (raiz.ChildNodes.Count)
            {
                case 7:
                        ambito = raiz.ChildNodes.ElementAt(1).ToString()+"()";
                        CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));

                    break;
                case 11:
                    int x = 350;
                    int y = 400;
                    ambito = raiz.ChildNodes.ElementAt(0).ToString();
                    ObjArreglo nodo = new ObjArreglo();
                    //nodo = listaArreglo[0];
                    ObjVariable Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(3).ToString()), "entero", x.ToString(), ambito);
                    ObjVariable Nuevo2 = new ObjVariable(separar(raiz.ChildNodes.ElementAt(6).ToString()), "entero", y.ToString(), ambito);
                    listaVariables.Add(Nuevo);
                    listaVariables.Add(Nuevo2);
                    CUERPOGENERAL(raiz.ChildNodes.ElementAt(9));
                    break;
                case 10:
                    Console.WriteLine("-----------------------------------------------------------");
                    ambito = raiz.ChildNodes.ElementAt(1).ToString();
                    CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));
                    break;

            }
        }

        //METODOS
        
        public static void METODOS(ParseTreeNode raiz)
        {
            Metodos NuevoM;
            switch (raiz.ChildNodes.Count)
            {
                case 4:
                    NuevoM = new Metodos(separar(raiz.ChildNodes.ElementAt(0).ToString()), 0,0);
                    listaMetodos.Add(NuevoM);
                    break;
                case 5:
                    ObjArreglo nodo = new ObjArreglo();
                    nodo = listaArreglo[1];
                    NuevoM = new Metodos(separar(raiz.ChildNodes.ElementAt(0).ToString()), 350,400);
                    listaMetodos.Add(NuevoM);
                    break;
            }

        }

        //PROCEDIMIENTOS NATIVOS
        public static void PROCNATIVOS(ParseTreeNode raiz)

        {
            Pintar Proc;
            switch (separar(raiz.ChildNodes.ElementAt(0).ToString()))
            {
                case "Pintar_OR":
                    float posx = float.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString());
                    float posy = float.Parse(F(raiz.ChildNodes.ElementAt(4)).ToString());
                    String hex = "#" + separar(raiz.ChildNodes.ElementAt(8).ToString());
                    float ancho = float.Parse(F(raiz.ChildNodes.ElementAt(11)).ToString());
                    float alto = float.Parse(F(raiz.ChildNodes.ElementAt(13)).ToString());
                    String tipo = separar(raiz.ChildNodes.ElementAt(16).ToString());
                    Proc = new Pintar(posx, posy, hex, ancho,alto,tipo);
                    
                    listaPintar.Add(Proc);
                    break;
                case "Pintar_P":
                    float posxP = float.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString());
                    float posyP = float.Parse(F(raiz.ChildNodes.ElementAt(4)).ToString());
                    String hexP = "#" + separar(raiz.ChildNodes.ElementAt(8).ToString());
                    float diam = float.Parse(F(raiz.ChildNodes.ElementAt(11)).ToString());
                    Proc = new Pintar(posxP,posyP,hexP,diam);
                    listaPintar.Add(Proc);
                    break;
            }

        }

        //PROCEDIMIENTO PRINCIPAL
        public static void PRINCIPAL(ParseTreeNode raiz) {
            switch (raiz.ChildNodes.Count)
            {
                case 6:
                    ambito = "Principal";
                    Console.WriteLine("iniciaPrincipal------------------------");
                    CUERPOGENERAL(raiz.ChildNodes.ElementAt(4));
                    Console.WriteLine("finalizaPrincipal");
                    break;
                case 5:
                    break;
            }

        }

        //ARITMETICA
        private static Double F(ParseTreeNode raiz)
        {

            switch (raiz.ChildNodes.Count)
            {
                case 1:
                    String[] numero = raiz.ChildNodes.ElementAt(0).ToString().Split(' ');
                    if (IsNumeric(numero[0]))
                    {

                        return Convert.ToDouble(numero[0]);

                    }
                    else
                    {
                        // Console.WriteLine(numero[0]);
                        return RetornarValorBuscado(numero[0]);
                    }



                case 3:
                    switch (raiz.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            return F(raiz.ChildNodes.ElementAt(0)) + F(raiz.ChildNodes.ElementAt(2));
                        case "-":
                            return F(raiz.ChildNodes.ElementAt(0)) - F(raiz.ChildNodes.ElementAt(2));
                        case "*":
                            return F(raiz.ChildNodes.ElementAt(0)) * F(raiz.ChildNodes.ElementAt(2));
                        case "/":
                            return F(raiz.ChildNodes.ElementAt(0)) / F(raiz.ChildNodes.ElementAt(2));
                        default:
                            return F(raiz.ChildNodes.ElementAt(1));
                    }
            }

            return 0.0;

        }
        //CICLOS
        public static void CUERPOGENERAL(ParseTreeNode raiz)
        {
            switch (raiz.ChildNodes.Count)
            {
                case 2:
                    switch (raiz.ChildNodes.ElementAt(1).ToString())
                    {
                        case "VARIABLES":
                            Console.WriteLine("Entre a variables general");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            Variables(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "ARREGLOS":
                            Console.WriteLine("Entre a Arreglos");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            //ARREGLOS(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "ASIGNACION":
                            Console.WriteLine("Entre a asignacion");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            ASIGNACION(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "CICLOS":
                            Console.WriteLine("Entre a ciclos");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            CICLOS(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "PROCNATIVOS":
                            Console.WriteLine("ENTRE A PRONATIVOS");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            PROCNATIVOS(raiz.ChildNodes.ElementAt(1));
                            break;
                        case "METODOS":
                            Console.WriteLine("Entre a Metodos");
                            CUERPOGENERAL(raiz.ChildNodes.ElementAt(0));
                            METODOS(raiz.ChildNodes.ElementAt(1));
                            break;

                    }
                    break;
                case 1:
                    switch (raiz.ChildNodes.ElementAt(0).ToString())
                    {
                        case "VARIABLES":
                            Console.WriteLine("Entre a variables");
                            Variables(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "ARREGLOS":
                            Console.WriteLine("Entre a Arreglos");
                            //ARREGLOS(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "ASIGNACION":
                            Console.WriteLine("Entre a asignacion");
                            ASIGNACION(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "CICLOS":
                            Console.WriteLine("Entre a ciclos");
                            CICLOS(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "PROCNATIVOS":
                            Console.WriteLine("ENTRE A PRONATIVOS");
                            PROCNATIVOS(raiz.ChildNodes.ElementAt(0));
                            break;
                        case "METODOS":
                            Console.WriteLine("Entre a Metodos");
                            METODOS(raiz.ChildNodes.ElementAt(0));
                            break;
                    }
                    break;


            }

        }

        public static void CICLOS(ParseTreeNode raiz)
        {

            switch (separar(raiz.ChildNodes.ElementAt(0).ToString()))
            {
                case "si":
                    switch (raiz.ChildNodes.Count)
                    {
                        case 7:
                            int condicionif = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                           
   
                            if (condicionif==1)
                            {
                                CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));
                            }

                            break;
                        case 11:
                            int condicionifelse = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            if (condicionifelse==1)
                            {
                                CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));
                            }
                            else
                            {
                                CUERPOGENERAL(raiz.ChildNodes.ElementAt(9));
                            }

                            break;
                    }
                    break;
                case "para":
                    ASIGNACIONPARA(raiz.ChildNodes.ElementAt(2));
                    int cond = CONDICIONES(raiz.ChildNodes.ElementAt(4));
                    
                   

                    while (cond==1) {
                        Console.WriteLine("PARA---");
                        CUERPOGENERAL(raiz.ChildNodes.ElementAt(9));
                        AUMENTOPARA(raiz.ChildNodes.ElementAt(6));
                        cond = CONDICIONES(raiz.ChildNodes.ElementAt(4));
                    }
                    BORRAR(separar(raiz.ChildNodes.ElementAt(2).ChildNodes.ElementAt(2).ToString()));
                    break;
                case "mientras":
                    int condw = CONDICIONES(raiz.ChildNodes.ElementAt(2));


                    while (condw == 1)
                    {

                        CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));
                        condw = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                    }
                    break;
                case "hacer":

                    int conddw;
                    do
                    {

                        CUERPOGENERAL(raiz.ChildNodes.ElementAt(5));
                        conddw = CONDICIONES(raiz.ChildNodes.ElementAt(6));
                    } while (conddw==1);
                    break;
                    

            }

        }

        

        public static void ASIGNACIONPARA(ParseTreeNode raiz)
        {
            ObjVariable Nuevo;
            switch (raiz.ChildNodes.Count)
            {
                case 5:
                    VARENTERO(raiz.ChildNodes.ElementAt(0));
                    
                    Nuevo = new ObjVariable(separar(raiz.ChildNodes.ElementAt(2).ToString()), "entero", F(raiz.ChildNodes.ElementAt(4)).ToString(), ambito);
                    listaVariables.Add(Nuevo);
                    break;
                case 3:
                    AsignacionValor(separar(raiz.ChildNodes.ElementAt(0).ToString()), int.Parse(F(raiz.ChildNodes.ElementAt(2)).ToString()));
                    break;
            }

        }

        public static void AUMENTOPARA(ParseTreeNode raiz)
        {
            if (separar(raiz.ChildNodes.ElementAt(1).ToString()) == "++")
            {
                Console.WriteLine("AUMENTO PARA");
                AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), 1);
            }
            else
            {
                AumentoDecremento(separar(raiz.ChildNodes.ElementAt(0).ToString()), -1);
            }
        }

        //CONDICIONES

        public static int CONDICIONES(ParseTreeNode raiz) 
        {
            switch (raiz.ChildNodes.Count)
            {
                case 1:
                    if (separar(raiz.ChildNodes.ElementAt(0).ToString()) == "true")

                    {
                        return 1;
                    }
                    else if (separar(raiz.ChildNodes.ElementAt(0).ToString()) == "false")
                    {
                        return 0;
                    }
                    else
                    {
                        return int.Parse(F(raiz.ChildNodes.ElementAt(0)).ToString());
                    }
                case 3:

                    switch (separar(raiz.ChildNodes.ElementAt(1).ToString()))
                    {
                        case "<":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) < CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case ">":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) > CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "==":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) == CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "!=":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) != CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }


                        case "<=":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) <= CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case ">=":
                            if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) >= CONDICIONES(raiz.ChildNodes.ElementAt(2)))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "||":
                            int OR1 = CONDICIONES(raiz.ChildNodes.ElementAt(0));
                            int OR2 = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            bool or1,or2 ;
                            //PASANDO A BOOL
                            if (OR1 == 1) { or1 = true; } else { or1 = false; }
                            if (OR2 == 1) { or2 = true; } else { or2 = false; }

                            if (or1 || or2)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                           
                        case "&&":
                            int AND1 = CONDICIONES(raiz.ChildNodes.ElementAt(0));
                            int AND2 = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            bool and1, and2;
                            //PASANDO A BOOL
                            if (AND1 == 1) { and1 = true; } else { and1 = false; }
                            if (AND2 == 1) { and2 = true; } else { and2 = false; }

                            if (and1 && and2)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "!&&":
                            int NAND1 = CONDICIONES(raiz.ChildNodes.ElementAt(0));
                            int NAND2 = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            bool nand1, nand2;
                            //PASANDO A BOOL
                            if (NAND1 == 1) { nand1 = true; } else { nand1 = false; }
                            if (NAND2 == 1) { nand2 = true; } else { nand2 = false; }

                            if (!(nand1 && nand2))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "!||":
                            int NOR1 = CONDICIONES(raiz.ChildNodes.ElementAt(0));
                            int NOR2 = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            bool nor1, nor2;
                            //PASANDO A BOOL
                            if (NOR1 == 1) { nor1 = true; } else { nor1 = false; }
                            if (NOR2 == 1) { nor2 = true; } else { nor2 = false; }

                            if (!(nor1 || nor2))
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                        case "&|":
                            int XOR1 = CONDICIONES(raiz.ChildNodes.ElementAt(0));
                            int XOR2 = CONDICIONES(raiz.ChildNodes.ElementAt(2));
                            bool xor1, xor2;
                            //PASANDO A BOOL
                            if (XOR1 == 1) { xor1 = true; } else { xor1 = false; }
                            if (XOR2 == 1) { xor2 = true; } else { xor2 = false; }

                            if (xor1 ^ xor2)
                            {
                                return 1;
                            }
                            else
                            {
                                return 0;
                            }

                    }

                    switch (separar(raiz.ChildNodes.ElementAt(0).ToString()))
                    {
                        case "(":
                            return CONDICIONES(raiz.ChildNodes.ElementAt(1));
                            
                        case "[":
                            return CONDICIONES(raiz.ChildNodes.ElementAt(1));

                    }
                    break;
                case 2:
                    bool cond;
                    if (CONDICIONES(raiz.ChildNodes.ElementAt(0)) == 1) { cond = true; } else { cond = false; }

                    if (!(cond))
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                   



            }




            return 0;
        }

        //METODOS ADICIONALES

        public static string separar(String palabra)
        {
            Char delimiter = ' ';
            String[] sepa = palabra.Split(delimiter);
            return sepa[0];
        }


        public static double RetornarValorBuscado(String busc)
        {
            foreach (ObjVariable nodo in listaVariables)
            {
                
                if (nodo.NombreVar == busc && nodo.AmbitoVar == ambito) {
                   
                        return double.Parse(nodo.ValorVar);
                    
                }

                if (nodo.NombreVar == busc)
                {
                   
                        return double.Parse(nodo.ValorVar);
                    
                }

            }

      
            return 0.0;
        }

        public static void BORRAR(String busc)
        {
            Console.WriteLine("jaja----"+busc);
            ObjVariable nod=null;
            foreach (ObjVariable nodo in listaVariables)
            {



                if (nodo.NombreVar == busc)
                {
                    nod = nodo;
                    break;


                }
                
            }

            listaVariables.Remove(nod);

        }


        public static void AumentoDecremento(String busc, int cambio)
        {
            foreach (ObjVariable nodo in listaVariables)
            {
               // Console.WriteLine(nodo.NombreVar + "=" + busc);
                if (nodo.NombreVar == busc)
                {
                    nodo.ValorVar = (int.Parse(nodo.ValorVar) + cambio).ToString();
                }
            }

        }

        public static void AsignacionValor(String busc, int valor)
        {
            foreach (ObjVariable nodo in listaVariables)
            {
                // Console.WriteLine(nodo.NombreVar + "=" + busc);
                if (nodo.NombreVar == busc )
                {
                    nodo.ValorVar = valor.ToString();
                }

            }

        }

        public static bool IsNumeric(object Expression)

        {
            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum;

        }
    }
}
