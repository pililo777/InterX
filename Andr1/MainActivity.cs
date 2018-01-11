using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using Android.Content;

namespace Andr1
{

    
    //{
    //    un_numero = (int)1, desde, nombre_de_variable,
    //    indice_strings, procedimiento, secuencia, imprimir,
    //    suma, resta, multiplica, divide, si, mientras, asigna_num, asigna_alfa,
    //    mayorque, menorque, igualque, leer, leertexto, noigualque, menorigualque, mayorigualque, negativo,
    //    comparaliteral, imprimir_varios, imprimir_expresion, imprimir_literal, imprimir_var_alfa,

    //    constante_literal, llamar, decimales, vacio
    //};


enum tipos_nodo
{
	un_numero = 1, desde, nombre_de_variable, dimensionar, asigna_vector, evalua_vector, dibuja_linea, dibuja_circulo,
	indice_strings, procedimiento, secuencia, imprimir, convertir_texto_a_numero, convertir_numero_a_texto,
	suma, resta, multiplica, divide, si, mientras, asigna_num, asigna_alfa, evaluar,
	mayorque, menorque, igualque, leer, leertexto, noigualque, menorigualque, mayorigualque, negativo,
	comparaliteral, imprimir_varios, imprimir_expresion, imprimir_literal, imprimir_var_alfa, guardar_boton, secuencia_controles,
	constante_literal, llamar, decimales, ventana, defventana, crear_ventana, mostrar_ventana, mostrar_ventanas, cambiar_titulo, mensaje, guardar_etiqueta, guardar_texto, interpreta,
	graficos, stop, abrir, cerrar, leer_archivo, mostrar,
	sumar_alfa, salir, vaciar, nand, nor , continuar, buscar_clave, insertar_clave,
	eliminar_clave, use_indice, close_indice, actualizar, push, pop,
	definir_registro, buscar_registro, listacampos, imprimir_var_vectoralfa, retorno, pausa,
	asigna_alfa_var, actualizar_registro, escribir_archivo, dimensionar_alfa, asigna_vector_alfa,
	asigna_vector_alfa2, asigna_vector_alfa3, funcion, lista_argumentos, lista_parametros,
	asigna_vector_alfa4, vector_alfanum, comparaliteral2, consulta
}

    [Activity(Label = "Andr1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        System.Timers.Timer mtimer = new System.Timers.Timer();
        String[] constantes = new String[127];
        double[] var = new double[127];


        [DllImport("SharedObject1")]
        public extern static IntPtr Cpp_GetValue( int i);

        [DllImport("SharedObject1")]
        public extern static IntPtr Cpp_GetValue3(int i);


        [DllImport("SharedObject1")]
        public extern static Double Cpp_GetValue2(int i);


        [StructLayout(LayoutKind.Sequential , Pack = 1)    ]
        public struct STRINGXX
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
           public  string varstr;
        }


        [StructLayout(LayoutKind.Sequential)]
        unsafe struct elnodo
        {
            //public int n;
            public int Tipo;
            public double Numero;

            public int Subnodos;


            public IntPtr Nodo1;
            public IntPtr Nodo2;
            public IntPtr Nodo3;
            public IntPtr Nodo4;
            //public ClassWrapper nodo2;
            //public ClassWrapper nodo3;
            //public ClassWrapper nodo4;

            /* cannot wrap function PassByValue */

            /* PassByReferenceIn */
            //[DllImport("SharedObject1")]
            //public static extern
            //   void PassByReferenceIn(ClassWrapper s);

            /* PassByReferenceOut */
            //[DllImport("SharedObject1")]
            //public static extern
            //   void PassByReferenceOut([Out] ClassWrapper s);

            /* PassByReferenceInOut */
            [DllImport("SharedObject1")]
            public static extern IntPtr PassByReferenceInOut(ref IntPtr s);

            ///* cannot wrap function ReturnByValue */

            /* ReturnByReference */
            //[DllImport("SharedObject1")]
            //public static extern ClassWrapper ReturnByReference();
            /* note: this causes returned pointer to be freed
               by runtime */
            /* DoubleIndirection */
            //    [DllImport("SharedObject1")]
            //    public static extern
            //       void DoubeIndirection(ref ClassWrapper s);
        }


       public struct Struct_variable
        {
            public  char tipo;
            public string nombre;
            public string valstring;
            public double numero;
            public int procedimiento;
            public short backup;
            public int dim1;
            public int dim2;
        };

        public Struct_variable[]   array_variables  = new Struct_variable[256]    ;

        private int[]  arrayVectores   = new int[32]   ;
        private int[] arrayVectoresAlfa =  new int[32]   ;

        private double[][] arrayVectoresValores  = new double[32][];
        private string[][] arrayVectoresAlfaValores = new string[32][];


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += new EventHandler(Cpp_GetValue2Click);
            mtimer.Interval = 5000;
            mtimer.Enabled = true;
            mtimer.Elapsed += Mtimer_Elapsed;
            mtimer.Start();


        }

        void HandleTouchUpInside(object sender, EventArgs ea)
        {
            //new UIAlertView("Touch3", "TouchUpInside handled", null, "OK", null).Show();
            Toast.MakeText(this, "click en el boton3", ToastLength.Long).Show();

        }


        unsafe protected void Cpp_GetValue2Click(object sender, EventArgs e)

        {

            int i;
            //string  sb = new string(' ', 255);
            //StringBuilder sb = new StringBuilder(256);
            elnodo s = new elnodo();
           

            unsafe
            {
 
                s.Tipo = 1;
                s.Numero = 777;
                //s.Nodo1 = 0;
                // s.Nodo2 = 0;
                //s.Nodo3 = 0;
                // s.Nodo4 = 0;

                IntPtr pList = IntPtr.Zero;
                //  GetSystemLocales(ref pList);
                var pListHead = Marshal.AllocHGlobal(Marshal.SizeOf(s));

                pList = elnodo.PassByReferenceInOut(ref pListHead);

                s = (elnodo)Marshal.PtrToStructure(pList, typeof(elnodo));

                //traemos las variables numericas
                for (i = 0; i < 127; i++)
                {

                    var[i] = Cpp_GetValue2(i);

                }

                //traemos las constantes
                for (i = 0; i < 127; i++)
                {
                    byte[] arr = new byte[255];
 
                    pList = IntPtr.Zero;
 
                    pList = Cpp_GetValue( i);
 
                    Marshal.Copy(pList, arr, 0, arr.Length);
 
                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                     
                    constantes[i] = encoding.GetString(arr);

                    int index = constantes[i].IndexOf('\0');
                    if (index >= 0)
                        constantes[i] = constantes[i].Remove(index);
                }




                //traemos los nombres de  las variables
                for (i = 0; i < 127; i++)
                {
                    byte[] arr = new byte[255];

                    pList = IntPtr.Zero;

                    pList = Cpp_GetValue3(i);

                    Marshal.Copy(pList, arr, 0, arr.Length);

                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

                    array_variables[i].nombre = encoding.GetString(arr);

                    int index = array_variables[i].nombre.IndexOf('\0');
                    if (index >= 0)
                        array_variables[i].nombre = array_variables[i].nombre.Remove(index);
                }




            }

            StringWriter sw = new StringWriter();

                
                try
                {

                    sw.Close();
                    sw = new StringWriter();
                    string text2 = execut(&s);

                //edit1.Text = System.IO.File.ReadAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt");
                //edit1.Text = System.IO.File.ReadAllText("/data/data/Andr1.Andr1/files/test.txt");
                    EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);
                    System.IO.File.WriteAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt", text2);
                    edit1.Text = text2;
                    mtimer.Stop();
                }

                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);

                }



            }





        /*
     [Java.Interop.Export("button_OnClick")]
     public void button_OnClick(View v)
     {
         Toast.MakeText(this, "Hello from " + v.Id, ToastLength.Long).Show();
     }
     */

        int nro_decimales = 0;
        int indice_ctr = 0;
       long  [] counter1 = new long  [20];
        StringWriter sw = new StringWriter();
        int idx_vec = 0;
        int idx_vec2 = 0;
        int retornar = 0;
        int salir1 = 0;



        // la funcion fue migrada el 22 de diciembre de 2017
        // estaba en c++ y fue convertida a c#
        unsafe string execut(elnodo* a)
 
        {
            elnodo* p;
             
            //p = nuevonodo();

            tipos_nodo t;
            t = (tipos_nodo)a->Tipo;

            p = a;

            if (retornar == 1)
            {
                return sw.ToString();
            }



            switch (t)
            {

                case tipos_nodo.stop:
                    System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", sw.ToString());

                    //EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);

                    //edit1.Text = sw.ToString();
                    break;




                case tipos_nodo.decimales:

                    nro_decimales = ((int)((elnodo*)p->Nodo1)->Numero);
                    break;



                case tipos_nodo.secuencia:

                    execut((elnodo*)p->Nodo1);

                    execut((elnodo*)p->Nodo2);
                    break;

                case tipos_nodo.imprimir_literal:

                    sw.WriteLine(constantes[(int)((elnodo*)p->Nodo1)->Numero]);
                    //System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", sw.ToString());

                    //  edit1 = FindViewById<EditText>(Resource.Id.editText1);

                    //edit1.Text = sw.ToString();



                    break;

                case tipos_nodo.imprimir_var_alfa:
                    { 
                     int n =  (int)((elnodo*)(p->Nodo1))->Numero;
                    sw.WriteLine(array_variables[n].valstring);
                        //System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", sw.ToString());

                        //  edit1 = FindViewById<EditText>(Resource.Id.editText1);

                        //edit1.Text = sw.ToString();


                    }
                    break;

                case tipos_nodo.imprimir_expresion:


                    switch (nro_decimales)
                    {

                        case 0:
                            sw.WriteLine(evalua((elnodo*)p->Nodo1));
                            //System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", sw.ToString());

                            //EditText edit2 = FindViewById<EditText>(Resource.Id.editText1);

                            //edit2.Text = sw.ToString();




                            break;


                        default:
                            sw.WriteLine(evalua((elnodo*)p->Nodo1));
                            //System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", sw.ToString());

                            //EditText edit3 = FindViewById<EditText>(Resource.Id.editText1);

                            //edit3.Text = sw.ToString();



                            break;

                    };

                    break;



                case tipos_nodo.imprimir_varios:

                    execut((elnodo*)p->Nodo1);
                    sw.WriteLine("\r\n");
                    System.IO.File.WriteAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt", sw.ToString());
                    break;

 

                case tipos_nodo.asigna_num:
                    { 
                        int n = (int)((elnodo*)p->Nodo1)->Numero;
                        array_variables[n].numero = evalua((elnodo*)p->Nodo2);
                        //var[(int)((elnodo*)p->Nodo1)->Numero] = evalua((elnodo*)p->Nodo2);
                        array_variables[n].tipo = 'N';
                    }
                    break;

                case tipos_nodo.asigna_alfa:

                    { 
                        int n = (int)((elnodo*)p->Nodo1)->Numero;
                        int  num  =(int) ((elnodo*)p->Nodo2)->Numero;
 
                        //var[n] = num ;
 
                        array_variables[n].valstring  = constantes[num];
                        array_variables[n].tipo = 'S';
                    }
                    break;

                case tipos_nodo.mientras:

                    while (evalua((elnodo*)p->Nodo1) == (double)1)

                        execut((elnodo*)p->Nodo2);


                    break;

                case tipos_nodo.leer:

                    {
                        // elnodo *pp;    
                        // int inum = 0;
                        //double fnum;
                        //pp = p;
                        //inum = (int)p->nodo1->num;

                        //scanf("%lf", &fnum );
                        //var[inum] = fnum;
                    }
                    break;

                case tipos_nodo.leertexto:

                    {
                        //int indice;
                        //elnodo * pp ;

                        //char texto[255]  ;
                        ////pp = p;
                        // getstring(texto); 
                        // if (error_getstring )
                        //     getstring (texto);

                        //indice = (int)p->nodo1->num;
                        //strcpy ( constantes [(int)var[indice]], texto);
                    }
                    break;

                case tipos_nodo.si:

                    if (evalua((elnodo*)p->Nodo1) > 0)
                    {
                        execut((elnodo*)p->Nodo2);
                    }
                    else
                        if (p->Subnodos == 3)
                    {

                        execut((elnodo*)p->Nodo3);
                    };


                    break;

                case tipos_nodo.desde:

                    {
                        int x = (int)((elnodo*)p->Nodo1)->Numero;
                        retornar = 0;
                        indice_ctr++;
                        array_variables[x].numero =  evalua((elnodo*)p->Nodo2);
                        counter1[indice_ctr] = (long)   array_variables[x].numero;

                        for (counter1[indice_ctr] = counter1[indice_ctr]; counter1[indice_ctr] <= (long)evalua((elnodo*)p->Nodo3); counter1[indice_ctr]++)
                        {

                             array_variables[x].numero = (double) counter1[indice_ctr];
                            execut((elnodo*)p->Nodo4);
                            if (retornar == 1)
                            {
                                retornar = 0;
                                if (salir1 == 1)
                                {
                                    salir1 = 0;
                                    break;
                                }
                            }



                        }

                        indice_ctr--;

                    }

                    break;

                case tipos_nodo.dimensionar:
                    {
                        // DIM designator NUMBER  { $$ = nodo2(dimensionar, $2, $3); /*dimensionar un vector entero */ }
                        int  vector;
                        int i;
                        int j;
                        int k = 1;
                        j = (int) ((elnodo*) p->Nodo2)->Numero;  //NUMBER
                        if (p->Subnodos == 3)
                            k = (int) ((elnodo*)p->Nodo3)->Numero;
                        vector =  (j * k); // cantidad

                        arrayVectoresValores[idx_vec] = new double [vector];

                        //for (i = 0; i < (j * k); i++) vector[i] = 0;
                        arrayVectores[idx_vec] = vector;
                        //var[(int) p->nodo1->num] = idx_vec;
                        array_variables[(int)  ((elnodo*) p->Nodo1)->Numero].numero = (double)idx_vec;
                        array_variables[(int)  ((elnodo*) p->Nodo1)->Numero].dim1 = (int)j;
                        array_variables[(int)  ((elnodo*) p->Nodo1)->Numero].dim2 = (int)k;
 
                        idx_vec++;

                    }
                    break;


                case tipos_nodo.dimensionar_alfa:
                    {
                        // DIM designator NUMBER  { $$ = nodo2(dimensionar, $2, $3); /*dimensionar un vector entero */ }
                        int vector;
                        int i;
                        int j;
                        int k = 1;
                        j = (int)((elnodo*)p->Nodo2)->Numero;  //NUMBER
                        if (p->Subnodos == 3)
                            k = (int)((elnodo*)p->Nodo3)->Numero;
                        vector = (j * k); // cantidad

                        arrayVectoresAlfaValores[idx_vec2] = new string [vector];

                        //for (i = 0; i < (j * k); i++) vector[i] = 0;
                        arrayVectoresAlfa[idx_vec2] = vector;
                        //var[(int) p->nodo1->num] = idx_vec;
                        array_variables[(int)((elnodo*)p->Nodo1)->Numero].numero = (double)idx_vec2;
                        array_variables[(int)((elnodo*)p->Nodo1)->Numero].dim1 = (int)j;
                        array_variables[(int)((elnodo*)p->Nodo1)->Numero].dim2 = (int)k;

                        idx_vec2++;

                    }
                    break;



                case tipos_nodo.asigna_vector:

                    try
                    {
                        // designator '[' expression ']' EQ expression { $$ = nodo3(asigna_vector, $1, $3, $6 );  }            
                        int vector;
                        int i, j;
                        int k = 1;
                        double valor;
                        int posicion, posicion2, posicion3;
                        i = (int)((elnodo*)p->Nodo1)->Numero;    // el indice de la variable (designator)
                        j = (int)array_variables[i].numero;

                        //vector = arrayVectores[j];   // hasta 32 vectores
                        if (p->Subnodos == 3)
                        {
                            valor = (double)evalua((elnodo*)p->Nodo3);
                            posicion = (int)evalua((elnodo*)p->Nodo2);
                            arrayVectoresValores[j][posicion] = valor;   //expresion y expresion
                        }
                        else
                        {
                            k = (int)array_variables[i].dim2;
                            valor = (double)evalua((elnodo*)p->Nodo4);
                            posicion = (int)evalua((elnodo*)p->Nodo2);
                            posicion2 = (int)evalua((elnodo*)p->Nodo3);
                            posicion3 = (posicion * k) + posicion2;
                            // printf ("pos: %d  ", posicion);
                            arrayVectoresValores[j][posicion3] = valor;   //expresion y expresion
                        }

                    }
                    catch (Exception ee) {
                        Console.WriteLine(ee.StackTrace);
                    }

                    break;


                case  tipos_nodo.convertir_texto_a_numero:
                    {
 
                        string snumero;
                        int n = (int)((elnodo*)p->Nodo1)->Numero;
                        int n2 = (int)((elnodo*)p->Nodo2)->Numero;
                        snumero =  array_variables[n].valstring;
                        //constantes[(int) var[ ] ]); //constantes [(int)p->nodo1->num]
                        Console.WriteLine( DateTime.Now.ToString() +  " Conversion1: " + snumero);
                        array_variables[n2].numero = Convert.ToDouble(snumero);
                        
                    }
                    break;


                case  tipos_nodo.convertir_numero_a_texto:
                    {
 
                        double snumero;
                        int n = (int)((elnodo*)p->Nodo1)->Numero;
                        int n2 = (int)((elnodo*)p->Nodo2)->Numero;
                        snumero = array_variables[n].numero;
                        //constantes[(int) var[ ] ]); //constantes [(int)p->nodo1->num]
                        array_variables[n2].valstring = snumero.ToString();
                        Console.WriteLine("Conversion2: " + snumero.ToString());
 
                    }
                    break;


                case tipos_nodo.llamar:

                    {
                        //int procedimiento;
                        int indice_de_la_variable;
                        //char tipo;
                        

                        indice_de_la_variable = (int) ((elnodo *) p->Nodo1)->Numero;
                        if (array_variables[indice_de_la_variable].nombre == "subcadena")
                        {
                            elnodo* g; elnodo* h; elnodo* hh; elnodo * k;

                            h = (elnodo*)p->Nodo2;
                            hh = h;
                            g =  (elnodo *) h->Nodo2;
                            k = g;
                            h = (elnodo*)g->Nodo2;
                            g = h;
                            if (g != null)
                            {
                                elnodo* b = ((elnodo*)hh->Nodo1);
                                int origen = (int)b->Numero;
                                double posicion = evalua((elnodo *)k->Nodo1);
                                double cantidad = evalua((elnodo*)g->Nodo1);

                                int destino = (int)((elnodo*)p->Nodo3)->Numero;
                                string sorigen = array_variables[origen].valstring ;
                                array_variables[destino].valstring = sorigen.Substring(((int)posicion)-1, (int) cantidad);
 
                            }
                            else
                            {    // no se indica cantidad, cogemos todo el largo de la variable origen
                                elnodo* b = ((elnodo*)hh->Nodo1);
                                int origen = (int)b->Numero;
                                double posicion = evalua((elnodo*)k->Nodo1);
 
                                int destino = (int)((elnodo*)p->Nodo3)->Numero;
                                string sorigen = array_variables[origen].valstring;
                                double cantidad = sorigen.Length - posicion + 1  ;
                                // falta comprobar cantidad
                                array_variables[destino].valstring = sorigen.Substring(((int)posicion)-1, (int)cantidad);
 
                            }
                        }
                    }
                    break;



                case tipos_nodo.salir:
                    {
                        retornar = 1;
                        salir1 = 1;
                    }
                    break;




                default:
                    Console.WriteLine(p->Tipo);

                    break;
 
            }
            return sw.ToString();
        }
         


        unsafe double evalua(elnodo* p)
        {

            switch ((tipos_nodo)p->Tipo)
            {

                case tipos_nodo.indice_strings:    //una variable numerica,

                    { 
                        try
                        {
                            int n = (int)   ((elnodo*)p)->Numero;
                            return array_variables[n].numero;
                        }
                        catch (Exception ee)
                        {
                            Console.WriteLine(ee.StackTrace.ToString());

                        }
                        break;
                    }

                case tipos_nodo.un_numero:
                    
                    return p->Numero;     //un numero constante

                case tipos_nodo.resta:

                    return evalua((elnodo*)p->Nodo1) - evalua((elnodo*)p->Nodo2);

                case tipos_nodo.suma:
                    return evalua((elnodo*)p->Nodo1) + evalua((elnodo*)p->Nodo2);

                case tipos_nodo.multiplica:
                    return evalua((elnodo*)p->Nodo1) * evalua((elnodo*)p->Nodo2);

                case tipos_nodo.divide:
                    if (evalua((elnodo*)p->Nodo2) == 0)
                    {
                        return 0;

                    }

                    return evalua((elnodo*)p->Nodo1) / evalua((elnodo*)p->Nodo2);

                case tipos_nodo.mayorque:
                    if (evalua((elnodo*)p->Nodo1) > evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.mayorigualque:
                    if (evalua((elnodo*)p->Nodo1) >= evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.noigualque:
                    if (evalua((elnodo*)p->Nodo1) != evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.menorque:
                    if (evalua((elnodo*)p->Nodo1) < evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.igualque:
                    if (evalua((elnodo*)p->Nodo1) == evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.menorigualque:
                    if (evalua((elnodo*)p->Nodo1) <= evalua((elnodo*)p->Nodo2)) return 1; else return 0;

                case tipos_nodo.negativo:
                    return evalua((elnodo*)p->Nodo1) * (-1);

                case tipos_nodo.comparaliteral:

                    {

                        if (constantes[(int) array_variables[(int)((elnodo*)p->Nodo1)->Numero].numero] == constantes[(int)((elnodo*)p->Nodo2)->Numero]) return 1; else return 0;

                    }


                case tipos_nodo.evalua_vector:
                    {
                        int vector;
                        int i, k, n, m;
                        double j;
                        i = (int)((elnodo*)p->Nodo1)->Numero;
                        vector = (int)array_variables[i].numero;
                        if (p->Subnodos == 2)
                            j = arrayVectoresValores[vector][(int)evalua((elnodo*)p->Nodo2)];    //  vector[];
                        else
                        {
                            m = (int)evalua((elnodo*)p->Nodo2); //indice1
                            k = (int)evalua((elnodo*)p->Nodo3); //indice2
                            n = (int)array_variables[i].dim2; //dimension1
                            j = arrayVectoresValores[vector][m*n+k];        // vector[m * n + k];
                        }
                        return (double)j;
                    }



                case tipos_nodo.llamar:
                    // p->tipo = llamar
                    // p->nodo1->num = designator de la funcion a llamar
                    // p->nodo2  = argumentos para llamar a la funcion
                    {
                        //int procedimiento;
                        int indice_de_la_variable;
                        //char tipo;
                        indice_de_la_variable = (int)((elnodo*)p->Nodo1)->Numero;
                        string str;

                        //if (!strcmp(array_variables[indice_de_la_variable].nombre, "instr"))
                        //{
                        //    short i;
                        //    i = instr((int)p->nodo2->nodo1->num, p->nodo2->nodo2->nodo1->num);
                        //    res = (double)i;
                        //    return res;
                        //}

                        //if (!strcmp(array_variables[indice_de_la_variable].nombre, "largo"))
                        //{
                        //    short i;
                        //    i = (int)p->nodo2->nodo1->num;
                        //    i = strlen(array_variables[i].string);
                        //    res = (double)i;
                        //    return res;
                        //}


                        //if (!strcmp(array_variables[indice_de_la_variable].nombre, "potencia"))
                        //{
                        //    double i, j;
                        //    //double  k, m;
                        //    i = evalua(p->nodo2->nodo1);
                        //    j = evalua(p->nodo2->nodo2->nodo1);
                        //    // k = array_variables[i].numero;
                        //    // m = array_variables[j].numero;
                        //    res = (double)pow(i, j);
                        //    //res =  (double) i;
                        //    return res;
                        //}

                        //if (!strcmp(array_variables[indice_de_la_variable].nombre, "potencia_e"))
                        //{
                        //    double i;
                        //    //double  k, m;
                        //    i = evalua(p->nodo2->nodo1);

                        //    // k = array_variables[i].numero;
                        //    // m = array_variables[j].numero;
                        //    res = (double)exp(i);
                        //    //res =  (double) i;
                        //    return res;
                        //}

                        str = array_variables[indice_de_la_variable].nombre;

                        if   ( str == "random") 
                        {
                            double n;
                            //res = rando();
                            n= new Random().NextDouble();

                            return n;

                        }


                        if (str == "potencia_e") 
                        {
                            double i, res;
                            //double  k, m;
                            i = evalua( (elnodo*) ((elnodo*) p->Nodo2)->Nodo1);

                            // k = array_variables[i].numero;
                            // m = array_variables[j].numero;
                            res = (double)  Math.Exp (i);
                            //res =  (double) i;
                            return res;
                        }




                        //tipo = array_variables[indice_de_la_variable].tipo; //evalua


                        //procedimiento = array_variables[indice_de_la_variable].procedimiento;
                        //if ((tipo != 'P') && (tipo != 'F'))
                        //{
                        //    printf("Bprocedimiento no encontrado en linea: %d \n", p->nrolinea2);
                        //    getchar();
                        //    exit(1);
                        //}
                        //else
                        //{
                        //    //  evalua   funcion
                        //    strcpy(array_variables[255].nombre, nombrefuncion);
                        //    push_param(255);

                        //    strcpy(nombrefuncion, array_variables[indice_de_la_variable].nombre);
                        //    strcpy(array_variables[255].nombre, nombrefuncion);

                        //    if (tipo == 'P')
                        //    {
                        //        push_param(255);
                        //        execut(procedimientos[procedimiento]);
                        //        pop_param(255);
                        //        strcpy(nombrefuncion, array_variables[255].nombre);

                        //    }
                        //    else
                        //    {
                        //        // ver si es una funcion de Inter, o una funcion integrada


                        //        short i;
                        //        short nargs = 0;

                        //        ast far *g;
                        //        ast far *f = procedimientos[procedimiento];  // los argumentos
                        //                                                     //i = f->nodo1->num;   //designator de la funcion que se llama

                        //        g = p->nodo2;

                        //        // en f tenemos una funcion
                        //        // en f->nodo1 el designator de la funcion
                        //        // en f->nodo2 los argumentos
                        //        // en f->nodo3 el cuerpo de la funcion

                        //        //push parametros
                        //        push_param(255);
                        //        i = push_argumentos(f->nodo2, g, &nargs);
                        //        push_param(indice_de_la_variable);
                        //        execut(f);
                        //        pop_param(indice_de_la_variable);
                        //        pop_argumentos(nargs);
                        //        //restaura el nombre de la funcion actualmente en ejecucion
                        //        pop_param(255);
                        //        strcpy(nombrefuncion, array_variables[255].nombre);
                        //        res = array_variables[indice_de_la_variable].numero;
                        //        //pop parametros
                        //    }
                        //    pop_param(255);
                        //    strcpy(nombrefuncion, array_variables[255].nombre);
                        //}
                    }
                    break;






                default:
                    Console.WriteLine(p->Tipo);
 
                        break;

            }
            return 0;
        }

        private  void Mtimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);
            //RunOnUiThread(() => {
            //    edit1.Text = sw.ToString() ;
            //});

            //StartUpdate();



            //this.RunOnUiThread(() => { FindViewById<EditText>(Resource.Id.editText1).Text = sw.ToString(); });
            //Task.Delay(100);

            Action action = delegate { edit1.Text = sw.ToString(); };
            edit1.Post(action);
            //Thread.Sleep(1000);
            edit1.RequestFocus();




        }

        private CancellationTokenSource cts;
        public void StartUpdate()
        {
            if (cts != null) cts.Cancel();
            cts = new CancellationTokenSource();
            var ignore =   UpdaterAsync(cts.Token);
        }
 

        public async Task UpdaterAsync(CancellationToken token)
        {
            EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);
            
                edit1.Text = sw.ToString();
                await Task.Delay(100, token);
 
        }

    }
 
}

//public class TestEvent
//{
//    public async Task Func(IProgress<string> progress)
//    {
//        progress.Report("Sleeping");
//        await Task.Delay(5000);
//        progress.Report("Hello World");

//        Activity.RunOnUiThread(() => {
//            mtxtProgress.Text = string.Format("{00}:{00}:{00}", hours, min, sec);
//        });

//    }
//}



