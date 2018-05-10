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


 public    enum tipos_nodo
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
    // 
    [Activity(Label = "Andr1", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")  ]

    public class MainActivity : Activity
    {
        System.Timers.Timer mtimer = new System.Timers.Timer();
        String[] constantes = new String[127];
        double[] var = new double[127];


        [DllImport("SharedObject1")]
        public extern static IntPtr Cpp_GetValue(int i);

        [DllImport("SharedObject1")]
        public extern static IntPtr Cpp_GetValue3(int i);


        [DllImport("SharedObject1")]
        public extern static Double Cpp_GetValue2(int i);

        [DllImport("SharedObject1")]
        public extern static int Cpp_GetValue4();


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRINGXX
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string varstr;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct variableTemp
        {
            public IntPtr nombre;
            public char tipo;
            public int procedimiento;
        };


        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct elnodo
        {
            //public int n;
            public int Tipo;
            public double Numero;

            public int Subnodos;


            public IntPtr Nodo1;
            public IntPtr Nodo2;
            public IntPtr Nodo3;
            public IntPtr Nodo4;
            public IntPtr Nodo5;
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

            [DllImport("SharedObject1")]
            public static extern IntPtr PassByReferenceInOut2(int s);

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
            public char tipo;
            public string nombre;
            public string valstring;
            public double numero;
            public int procedimiento;
            public short backup;
            public int dim1;
            public int dim2;
        };

        public Struct_variable[] array_variables = new Struct_variable[256];

        private int[] arrayVectores = new int[32];
        private int[] arrayVectoresAlfa = new int[32];

        private double[][] arrayVectoresValores = new double[32][];
        private string[][] arrayVectoresAlfaValores = new string[32][];


        public nodo[] procedimientos = new nodo[127];

        public Struct_variable[] pila = new Struct_variable[512];



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
            nodo programa;


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

                programa = convertir3(&s);

                //traemos los procedimientos
                int n = Cpp_GetValue4();

                for (i = 0; i < n; i++)
                {
                    //pListHead = Marshal.AllocHGlobal(Marshal.SizeOf(s));
                    pList = elnodo.PassByReferenceInOut2(i);
                    s = (elnodo)Marshal.PtrToStructure(pList, typeof(elnodo));
                    procedimientos[i] = convertir3(&s);

                }

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

                    pList = Cpp_GetValue(i);

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
                    variableTemp temp = new variableTemp();
                    byte[] arr = new byte[255];

                    pList = IntPtr.Zero;


                    pList = Cpp_GetValue3(i);

                    temp = (variableTemp)Marshal.PtrToStructure(pList, typeof(variableTemp));

                    Marshal.Copy(temp.nombre, arr, 0, arr.Length);

                    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

                    array_variables[i].nombre = encoding.GetString(arr);
                    array_variables[i].tipo = temp.tipo;
                    array_variables[i].procedimiento = temp.procedimiento;

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
                string text2 = execut(programa);

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
        long[] counter1 = new long[20];
        StringWriter sw = new StringWriter();
        int idx_vec = 0;
        int idx_vec2 = 0;
        int retornar = 0;
        int salir1 = 0;
        int idx_pila = 0;
        string nombrefuncion;


        // la funcion fue migrada el 22 de diciembre de 2017
        // estaba en c++ y fue convertida a c#
        unsafe string execut(nodo a)

        {
            nodo p;

            //p = nuevonodo();

            tipos_nodo t;
            t = (tipos_nodo)a.Tipo;

            p = a;

            if (retornar == 1)
            {
                return sw.ToString();
            }

            switch (t)
            {

                case tipos_nodo.stop:

                    Console.WriteLine(sw.ToString());

                    //EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);

                    //edit1.Text = sw.ToString();
                    break;

                case tipos_nodo.decimales:

                    nro_decimales = ((int)p.Nodo1.Numero);
                    break;

                case tipos_nodo.secuencia:

                    execut(p.Nodo1);

                    execut(p.Nodo2);
                    break;

                case tipos_nodo.imprimir_literal:

                    sw.Write (constantes[(int)(p.Nodo1).Numero]);

                    //  edit1 = FindViewById<EditText>(Resource.Id.editText1);

                    //edit1.Text = sw.ToString();

                    break;

                case tipos_nodo.imprimir_var_alfa:
                    {
                        int n = (int)((p.Nodo1)).Numero;
                        sw.Write (array_variables[n].valstring);
                        

                        //  edit1 = FindViewById<EditText>(Resource.Id.editText1);

                        //edit1.Text = sw.ToString();

                    }
                    break;

                case tipos_nodo.imprimir_expresion:


                    switch (nro_decimales)
                    {

                        case 0:
                            sw.Write (evalua(p.Nodo1));
                            

                            //EditText edit2 = FindViewById<EditText>(Resource.Id.editText1);

                            //edit2.Text = sw.ToString();

                            break;

                        default:
                            sw.Write (evalua(p.Nodo1));
                            

                            //EditText edit3 = FindViewById<EditText>(Resource.Id.editText1);

                            //edit3.Text = sw.ToString();

                            break;

                    };

                    break;



                case tipos_nodo.imprimir_varios:

                    execut(p.Nodo1);
                    sw.WriteLine("\n");
                    System.IO.File.WriteAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt", sw.ToString());
                    break;



                case tipos_nodo.asigna_num:
                    {
                        int n = (int)(p.Nodo1).Numero;
                        array_variables[n].numero = evalua(p.Nodo2);
                        //var[(int)( p.Nodo1).Numero] = evalua( p.Nodo2);
                        array_variables[n].tipo = 'N';
                    }
                    break;

                case tipos_nodo.asigna_alfa:

                    {
                        int n = (int)(p.Nodo1).Numero;
                        int num = (int)(p.Nodo2).Numero;

                        //var[n] = num ;

                        array_variables[n].valstring = constantes[num];
                        array_variables[n].tipo = 'S';
                    }
                    break;

                case tipos_nodo.mientras:

                    while (evalua(p.Nodo1) == (double)1)

                        execut(p.Nodo2);


                    break;

                case tipos_nodo.leer:

                    {
                        // elnodo *pp;    
                        // int inum = 0;
                        //double fnum;
                        //pp = p;
                        //inum = (int)p.nodo1.num;

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

                        //indice = (int)p.nodo1.num;
                        //strcpy ( constantes [(int)var[indice]], texto);
                    }
                    break;

                case tipos_nodo.si:

                    if (evalua(p.Nodo1) > 0)
                    {
                        execut(p.Nodo2);
                    }
                    else
                        if (p.Subnodos == 3)
                    {

                        execut(p.Nodo3);
                    };


                    break;

                case tipos_nodo.desde:

                    {
                        int x = (int)(p.Nodo1).Numero;
                        retornar = 0;
                        indice_ctr++;
                        array_variables[x].numero = evalua(p.Nodo2);
                        counter1[indice_ctr] = (long)array_variables[x].numero;

                        for (counter1[indice_ctr] = counter1[indice_ctr]; counter1[indice_ctr] <= (long)evalua(p.Nodo3); counter1[indice_ctr]++)
                        {

                            array_variables[x].numero = (double)counter1[indice_ctr];
                            execut(p.Nodo4);
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
                        int vector;
                        int i;
                        int j;
                        int k = 1;
                        j = (int)(p.Nodo2).Numero;  //NUMBER
                        if (p.Subnodos == 3)
                            k = (int)(p.Nodo3).Numero;
                        vector = (j * k); // cantidad

                        arrayVectoresValores[idx_vec] = new double[vector];

                        //for (i = 0; i < (j * k); i++) vector[i] = 0;
                        arrayVectores[idx_vec] = vector;
                        //var[(int) p.nodo1.num] = idx_vec;
                        array_variables[(int)(p.Nodo1).Numero].numero = (double)idx_vec;
                        array_variables[(int)(p.Nodo1).Numero].dim1 = (int)j;
                        array_variables[(int)(p.Nodo1).Numero].dim2 = (int)k;

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
                        j = (int)(p.Nodo2).Numero;  //NUMBER
                        if (p.Subnodos == 3)
                            k = (int)(p.Nodo3).Numero;
                        vector = (j * k); // cantidad

                        arrayVectoresAlfaValores[idx_vec2] = new string[vector];

                        //for (i = 0; i < (j * k); i++) vector[i] = 0;
                        arrayVectoresAlfa[idx_vec2] = vector;
                        //var[(int) p.nodo1.num] = idx_vec;
                        array_variables[(int)(p.Nodo1).Numero].numero = (double)idx_vec2;
                        array_variables[(int)(p.Nodo1).Numero].dim1 = (int)j;
                        array_variables[(int)(p.Nodo1).Numero].dim2 = (int)k;

                        idx_vec2++;

                    }
                    break;



                case tipos_nodo.asigna_vector:

                    try
                    {
                        // designator '[' expression ']' EQ expression { $$ = nodo3(asigna_vector, $1, $3, $6 );  }            
                        //int vector;
                        int i, j;
                        int k = 1;
                        double valor;
                        int posicion, posicion2, posicion3;
                        i = (int)(p.Nodo1).Numero;    // el indice de la variable (designator)
                        j = (int)array_variables[i].numero;

                        //vector = arrayVectores[j];   // hasta 32 vectores
                        if (p.Subnodos == 3)
                        {
                            valor = (double)evalua(p.Nodo3);
                            posicion = (int)evalua(p.Nodo2);
                            arrayVectoresValores[j][posicion] = valor;   //expresion y expresion
                        }
                        else
                        {
                            k = (int)array_variables[i].dim2;
                            valor = (double)evalua(p.Nodo4);
                            posicion = (int)evalua(p.Nodo2);
                            posicion2 = (int)evalua(p.Nodo3);
                            posicion3 = (posicion * k) + posicion2;
                            // printf ("pos: %d  ", posicion);
                            arrayVectoresValores[j][posicion3] = valor;   //expresion y expresion
                        }

                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.StackTrace);
                    }

                    break;


                case tipos_nodo.asigna_vector_alfa2:
                    {
                        // sdesignator '[' expression ']' EQ sdesignator { $$ = nodo3(asigna_vector, $1, $3, $6 );  }            
                        
                        int i;
                        int j;
                        int k;
                        //i = var[(int) p->nodo1->num];    // el indice de la variable (designator)
                        i = (int)array_variables[(int)p.Nodo1.Numero].numero;    // el indice de la variable (designator)
                        j = (int)(evalua(p.Nodo2)  );
                        k = (int)p.Nodo3.Numero;
                         arrayVectoresAlfaValores[i][j]   = array_variables[k].valstring;   // hasta 32 vectores

                        
                    }
                    break;


                case tipos_nodo.convertir_texto_a_numero:
                    {

                        string snumero;
                        int n = (int)(p.Nodo1).Numero;
                        int n2 = (int)(p.Nodo2).Numero;
                        snumero = array_variables[n].valstring;
                        //constantes[(int) var[ ] ]); //constantes [(int)p.nodo1.num]
                        Console.WriteLine(DateTime.Now.ToString() + " Conversion1: " + snumero);
                        array_variables[n2].numero = Convert.ToDouble(snumero);

                    }
                    break;


                case tipos_nodo.convertir_numero_a_texto:
                    {

                        double snumero;
                        int n = (int)(p.Nodo1).Numero;
                        int n2 = (int)(p.Nodo2).Numero;
                        snumero = array_variables[n].numero;
                        //constantes[(int) var[ ] ]); //constantes [(int)p.nodo1.num]
                        array_variables[n2].valstring = snumero.ToString();
                        Console.WriteLine("Conversion2: " + snumero.ToString());

                    }
                    break;


                case tipos_nodo.llamar:

                    {
                        //int procedimiento;
                        int indice_de_la_variable;
                        
                        //char tipo;


                        indice_de_la_variable = (int)(p.Nodo1).Numero;
                        if (array_variables[indice_de_la_variable].nombre == "subcadena")
                        {
                            nodo g; nodo h; nodo hh; nodo k;

                            h = p.Nodo2;
                            hh = h;
                            g = h.Nodo2;
                            k = g;
                            h = g.Nodo2;
                            g = h;
                            if (g != null)
                            {
                                nodo b = (hh.Nodo1);
                                int origen = (int)b.Numero;
                                double posicion = evalua(k.Nodo1);
                                double cantidad = evalua(g.Nodo1);

                                int destino = (int)(p.Nodo3).Numero;
                                string sorigen = array_variables[origen].valstring;
                                try
                                {
                                    array_variables[destino].valstring = sorigen.Substring(((int)posicion) - 1, (int)cantidad);
                                }
                                catch (Exception ee)
                                {
                                    //Console.WriteLine(ee.Message);
                                    //throw;
                                    array_variables[destino].valstring = string.Empty;
                                }
                                
                                break;
                            }
                            else
                            {    // no se indica cantidad, cogemos todo el largo de la variable origen
                                nodo b = (hh.Nodo1);
                                int origen = (int)b.Numero;
                                double posicion = evalua(k.Nodo1);

                                int destino = (int)(p.Nodo3).Numero;
                                string sorigen = array_variables[origen].valstring;
                                double cantidad = sorigen.Length - posicion + 1;
                                // falta comprobar cantidad
                                array_variables[destino].valstring = sorigen.Substring(((int)posicion) - 1, (int)cantidad);
                                break;
                            }
                        }

                        if (array_variables[indice_de_la_variable].nombre == "derecha")
                        {
                            derecha((int) p.Nodo2.Nodo1.Numero,
                                     p.Nodo2.Nodo2.Nodo1,
                                   (int)p.Nodo3.Numero);
                            break;
                        }

                        if (array_variables[indice_de_la_variable].nombre == "izquierda")
                        {
                            izquierda((int)p.Nodo2.Nodo1.Numero,
                                     p.Nodo2.Nodo2.Nodo1,
                                   (int)p.Nodo3.Numero);
                            break;
                        }



                        //llamar a un procedimiento o funcion
                        char tipo = array_variables[indice_de_la_variable].tipo;
                        int procedimiento = array_variables[indice_de_la_variable].procedimiento;
                        if ((tipo != 'P') && (tipo != 'F'))
                        {
                            sw.WriteLine("Aprocedimiento no encontrado en linea: %d \n");  //, p->nrolinea2);
                            sw.WriteLine(array_variables[indice_de_la_variable].nombre);

                            //getchar();
                            //exit(1);
                            break;
                        }
                        else
                        {
                            //escribir el nombre del proc o funcio en un buffer

                            //array_variables[indice_de_la_variable].nombre

                            //execut      funcion
                            array_variables[255].nombre = nombrefuncion  ;
                            push_param(255);

                            nombrefuncion = array_variables[indice_de_la_variable].nombre;


                            array_variables[255].nombre = nombrefuncion;


                            if (tipo == 'P')
                            {
                                push_param(255);
                                execut(procedimientos[procedimiento]);
                                pop_param(255);
                                nombrefuncion = array_variables[255].nombre;
                            }
                            else
                            {
                                short i;
                                short cantidad = 0;

                                nodo g;
                                nodo f = procedimientos[procedimiento];  // los argumentos
                                i = (short) f.Nodo1.Numero;   //designator de la funcion que se llama

                                g = p.Nodo2;

                                //// en f tenemos una funcion
                                //// en f->nodo1 el designator de la funcion
                                //// en f->nodo2 los argumentos
                                //// en f->nodo3 el cuerpo de la funcion

                                //push parametros
                                push_param(255);
                                i = push_argumentos(f.Nodo2, g, ref cantidad);  // tenia &cantidad, pasar por ref????
                                push_param(indice_de_la_variable);
                                execut(f);
                                pop_param(indice_de_la_variable);
                                pop_argumentos(cantidad);
                                pop_param(255);
                                nombrefuncion =  array_variables[255].nombre;
                                g = p.Nodo3;
                                if (g != null)
                                {
                                     i = (short )p.Nodo3.Numero;
                                    if (array_variables[i].tipo == 'S')
                                    {
                                      array_variables[i].valstring = array_variables[indice_de_la_variable].valstring;
                                     }
                                     else
                                    {
                                         array_variables[i].numero = array_variables[indice_de_la_variable].numero;
                                     }
                                     /*
                                                                push_param(indice_de_la_variable);
                                                                 pop_param(i);
                                     */
                                }
                                 
                                 //pop parametros
                            }
                             pop_param(255);
                             nombrefuncion =  array_variables[255].nombre;

                        }

                    }
                    break;

                case tipos_nodo.retorno:
                    {
                        double resul;
                        int i, j, k;
                        tipos_nodo tt;
                        string str1;

                        tt =   p.Nodo1.Tipo;
                        if (tt == tipos_nodo.nombre_de_variable)
                        {
                            char tipo;
                            k = (int) p.Nodo1.Numero;
                            tipo = array_variables[k].tipo;
                            if (tipo == 'S')
                            {  //string
                                i = idx_pila - 1;
                                //k = p->nodo1->num;
                                if (pila[i].valstring!= null  ) {
                                    str1 = pila[i].valstring;
                                    if ((j = (str1).Length) > 0)
                                    {
                                        
                                        str1 = null;
                                        
                                    }
                                }

                                j = (array_variables[k].valstring).Length + 1;
                                 
                                str1 =  array_variables[k].valstring;
                                pila[i].valstring = str1;
                                break;
                            }
                        }

                        else

                        {
                            resul = evalua(p.Nodo1);
                            i = idx_pila - 1;
                            pila[i].numero = resul;
                        }

                    }
                    break;




                case tipos_nodo.procedimiento:
                    {
                        execut(p.Nodo2);
                    }
                    break;


                case tipos_nodo.funcion:
                    {
                        execut(p.Nodo3);
                    }
                    break;



                case tipos_nodo.salir:
                    {
                        retornar = 1;
                        salir1 = 1;
                    }
                    break;

                case tipos_nodo.continuar:
                    {
                        retornar = 1;
                        salir1 = 0;
                    }
                    break;


                case tipos_nodo.vaciar:
                    {
                        int n;
                        n = (int)p.Nodo1.Numero;
                        array_variables[n].valstring = string.Empty;
                    }
                    break;

                case tipos_nodo.sumar_alfa:
                    {
                        int n, m, x, y;  string str1;
                        n = (int)p.Nodo1.Numero ;
                        m = (int)p.Nodo2.Numero;
                        x =  (array_variables[n].valstring).Length + 1;
                        y =  (array_variables[m].valstring).Length + x + 1;
 
                         str1  =  array_variables[n].valstring;
 
                        str1 = string.Concat(str1, array_variables[m].valstring);
                        array_variables[n].valstring = str1;
                         

                    }
                    break;

                case tipos_nodo.asigna_vector_alfa:
                    {
                        // designator '[' expression ']' EQ expression { $$ = nodo3(asigna_vector, $1, $3, $6 );  }            
 
                        int i;
                        int j;
                        int k;
                   
                        i = (int)array_variables[(int)p.Nodo1.Numero].numero;    // el indice de la variable (designator)
                        j = (int)(evalua(p.Nodo2)  );
                        k = (int)p.Nodo3.Numero;
  
                        arrayVectoresAlfaValores[i][j] = constantes[k];
                    }

                    break;


                case tipos_nodo.asigna_vector_alfa3:
                    {
                        // sdesignator EQ sdesignator  '[' expression ']'  { $$ = nodo3(asigna_vector, $1, $3, $5 );  }  
                       
                        int i;
                        int j;
                        int k;
                        //i = var[(int) p->nodo2->num];    // el indice de la variable vector (designator)
                        i = (int)array_variables[(int)p.Nodo2.Numero].numero;    // el indice de la variable vector (designator)
                        j = (int)(evalua(p.Nodo3)  );  // posicion en el vector
                        k = (int)p.Nodo1.Numero;
 
                        array_variables[k].valstring  = arrayVectoresAlfaValores[i][j]  ;
                    }
                    break;

                case tipos_nodo.asigna_vector_alfa4:
                    {
                        // pausar();
                        //char* vector, *vector2;
                        int i, i2;
                        int j, j2;

                        i = (int)array_variables[(int)p.Nodo3.Numero].numero;    //variable origen
                        j = (int)(evalua(p.Nodo4)  );  // posicion en el vector
                        //vector = arrayVectoresAlfaValores[i];   // base del vector

                        i2 = (int)array_variables[(int)p.Nodo1.Numero].numero;   //variable destino
                        j2 = (int)(evalua(p.Nodo2)  );  // posicion en el vector
                        //vector2 = arrayVectoresAlfa[i2];   // hasta 32 vectores
                        //strcpy(&vector2[j2], &vector[j]);

                        arrayVectoresAlfaValores[i2][j2] = arrayVectoresAlfaValores[i][j];

                    }

                    break;


                case tipos_nodo.imprimir_var_vectoralfa:
                    {
                       
                        int i;
                        int j;
                        //i = var[(int) p->nodo1->num];    // el indice de la variable (designator)
                        i = (int)array_variables[(int)p.Nodo1.Numero].numero;    // el indice de la variable (designator)
                        j = (int)(evalua(p.Nodo2)  );
                            // hasta 32 vectores
                        sw.Write (arrayVectoresAlfaValores[i][j]);
                    }
                    break;

                case tipos_nodo.push:
                    {
                        int i;
                        i = (int)p.Nodo1.Numero;
                        push_param(i);
                    }
                    break;

                case tipos_nodo.pop:
                    {
                        int i;
                        i = (int)p.Nodo1.Numero;

                        pop_param(i);

                    }
                    break;


                case tipos_nodo.asigna_alfa_var:
                    {
                        int i, j, k;
                        string str1;
                        //string str2;
                        i = (int)p.Nodo1.Numero; // var destino
                        j = (int)p.Nodo2.Numero; // var origen
                        if (i == j)
                        {
                            break;
                        }

                        if (array_variables[i].valstring==null || array_variables[i].valstring == string.Empty) {
                            //nada
                        } else {   //eliminamos el antiguo valor string de la variable
                            str1 =  array_variables[i].valstring;
                            k =  (str1).Length;
                            if (k > 0)
                            {
                                //printf ("liberamos memoria de la  variable destino %s\n", array_variables[i].nombre );
                                
                                
                                array_variables[i].valstring = string.Empty;
                                
                            }
                        }

                        if (array_variables[j].valstring== null || array_variables[j].valstring == string.Empty) {
                            // la variable origen es nula
                            // habria que hacer que la destino sea nula
                            //fflush(stdout);
                        } else
                        {
                            //k =  (array_variables[j].valstring).Length + 1;
                            //printf ("asignamos memoria a la variable %s\n", array_variables[i].nombre );
                            
                             array_variables[i].valstring =  array_variables[j].valstring;
                        }
                    }
                    break;


                default:
                    Console.WriteLine(p.Tipo);

                    break;




            }
            return sw.ToString();
        }



        unsafe double evalua(nodo p)
        {
            double res = 0;
            switch ((tipos_nodo)p.Tipo)
            {

                case tipos_nodo.indice_strings:    //una variable numerica,

                    {
                        try
                        {
                            int n = (int)(p).Numero;
                            return array_variables[n].numero;
                        }
                        catch (Exception ee)
                        {
                            Console.WriteLine(ee.StackTrace.ToString());

                        }
                        break;
                    }

                case tipos_nodo.un_numero:

                    return p.Numero;     //un numero constante

                case tipos_nodo.resta:

                    return evalua(p.Nodo1) - evalua(p.Nodo2);

                case tipos_nodo.suma:
                    return evalua(p.Nodo1) + evalua(p.Nodo2);

                case tipos_nodo.multiplica:
                    return evalua(p.Nodo1) * evalua(p.Nodo2);

                case tipos_nodo.divide:
                    if (evalua(p.Nodo2) == 0)
                    {
                        return 0;

                    }

                    return evalua(p.Nodo1) / evalua(p.Nodo2);

                case tipos_nodo.mayorque:
                    if (evalua(p.Nodo1) > evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.mayorigualque:
                    if (evalua(p.Nodo1) >= evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.noigualque:
                    if (evalua(p.Nodo1) != evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.menorque:
                    if (evalua(p.Nodo1) < evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.igualque:
                    if (evalua(p.Nodo1) == evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.menorigualque:
                    if (evalua(p.Nodo1) <= evalua(p.Nodo2)) return 1; else return 0;

                case tipos_nodo.negativo:
                    return evalua(p.Nodo1) * (-1);

                case tipos_nodo.comparaliteral:

                   //compara una variable a un literal

                    {
                        string string1,  string3;
                        string string2 ;
                        tipos_nodo tipo;
                        int i;
                        i = (int)p.Nodo2.Numero;
                        string1 = array_variables[(int)p.Nodo1.Numero].valstring;
                        tipo = p.Nodo2.Tipo;
                        if (tipo == tipos_nodo.constante_literal)
                        {
                            //strcpy(string1, array_variables[(int) p->nodo1->num].valor);
                            //printf("comparacion con un literal\n");
                            string2 = constantes[(int)p.Nodo2.Numero];
                            res = 0;
                            if (string1==string2) res = 1;
                        }
                        else
                        {
                            string3 = array_variables[i].valstring;
                            res = 0;
                            if(string1 == string3) res=1;
                        }
                    }
                    break;

                case tipos_nodo.comparaliteral2:   //compara una variable a una variable

                    {
                        string  string1,  string3;
                        string string2 ;
                        tipos_nodo tipo;
                        int i;
                        i = (int)p.Nodo2.Numero;
                        string1 = array_variables[(int)p.Nodo1.Numero].valstring;
                        tipo = (tipos_nodo)p.Nodo2.Tipo;
                        if (tipo == tipos_nodo.constante_literal)
                        {
                            //strcpy(string1, array_variables[(int) p->nodo1->num].valor);
                            //printf("comparacion con un literal\n");
                            string2 = constantes[(int)p.Nodo2.Numero];
                            res = 0;
 
                            if (string1 == string2) res = 1;
                        }
                        else
                        {
                            string3 = array_variables[i].valstring;
 
                            res = 0;

                            if (string1 == string3) res = 1;
 
                        }
                    }
                    break;


                case tipos_nodo.evalua_vector:
                    {
                        int vector;
                        int i, k, n, m;
                        double j;
                        i = (int)(p.Nodo1).Numero;
                        vector = (int)array_variables[i].numero;
                        if (p.Subnodos == 2)
                            j = arrayVectoresValores[vector][(int)evalua(p.Nodo2)];    //  vector[];
                        else
                        {
                            m = (int)evalua(p.Nodo2); //indice1
                            k = (int)evalua(p.Nodo3); //indice2
                            n = (int)array_variables[i].dim2; //dimension1
                            j = arrayVectoresValores[vector][m * n + k];        // vector[m * n + k];
                        }
                        return (double)j;
                    }



                case tipos_nodo.llamar:
                    // p.tipo = llamar
                    // p.nodo1.num = designator de la funcion a llamar
                    // p.nodo2  = argumentos para llamar a la funcion
                    {
                        int procedimiento;
                        int indice_de_la_variable;
                        char tipo;
                        indice_de_la_variable = (int)(p.Nodo1).Numero;
                        string str;
                        

                         if (array_variables[indice_de_la_variable].nombre == "instr")
                         {
                             short i;
                             i = instr((int)p.Nodo2.Nodo1.Numero, (int) p.Nodo2.Nodo2.Nodo1.Numero);
                             res = (double)i;
                             return res;
                         }

                         if (array_variables[indice_de_la_variable].nombre == "largo")
                        {
                            int i;
                            try
                            {
                                
                                i = (int)p.Nodo2.Nodo1.Numero;
                                i = (array_variables[i].valstring).Length;
                                res = (double)i;
                                return res;
                            }
                            catch (Exception ee)
                            {
                                
                                res=0;
                                return res;
                            }
                             
                         }


                         if (array_variables[indice_de_la_variable].nombre == "potencia")
                         {
                             double i, j;
                             //double  k, m;
                            i = evalua(p.Nodo2.Nodo1);
                             j = evalua(p.Nodo2.Nodo2.Nodo1);
                           // k = array_variables[i].numero;
                             // m = array_variables[j].numero;
                            res = (double)  Math.Pow(i, j);
                            //res =  (double) i;
                            return res;
                         }
 
                        str = array_variables[indice_de_la_variable].nombre;

                        if (str == "random")
                        {
                            double n;
                            //res = rando();
                            n = new Random().NextDouble();

                            return n;

                        }


                        if (str == "potencia_e")
                        {
                            double i  ;
                            //double  k, m;
                            i = evalua((p.Nodo2).Nodo1);

                            // k = array_variables[i].numero;
                            // m = array_variables[j].numero;
                            res = (double)Math.Exp(i);
                            //res =  (double) i;
                            return res;
                        }


                        tipo = array_variables[indice_de_la_variable].tipo; //evalua


                        procedimiento = array_variables[indice_de_la_variable].procedimiento;
                        if ((tipo != 'P') && (tipo != 'F'))
                        {
                            sw.WriteLine("B:procedimiento no encontrado en linea: %d \n");    //, p.nrolinea2);
                            return 0;
                         
                        }
                        else
                        {
                            //  evalua   funcion
                              array_variables[255].nombre =  nombrefuncion;
                             push_param(255);

                             nombrefuncion = array_variables[indice_de_la_variable].nombre;
                             array_variables[255].nombre = nombrefuncion;

                             if (tipo == 'P')
                             {
                                 push_param(255);
                                 execut(procedimientos[procedimiento]);
                                 pop_param(255);
                                 nombrefuncion =  array_variables[255].nombre;

                             }
                             else
                             {
                                 // ver si es una funcion de Inter, o una funcion integrada


                                 short i;
                                 short nargs = 0;

                                 nodo g;
                                 nodo f = procedimientos[procedimiento];  // los argumentos
                                                                             //i = f.nodo1.num;   //designator de la funcion que se llama

                                  g = p.Nodo2;

                                 // en f tenemos una funcion
                                 // en f.nodo1 el designator de la funcion
                                 // en f.nodo2 los argumentos
                                 // en f.nodo3 el cuerpo de la funcion

                                 //push parametros
                                 push_param(255);
                                 i = push_argumentos(f.Nodo2, g, ref nargs);
                                 push_param(indice_de_la_variable);
                                 execut(f);
                                 pop_param(indice_de_la_variable);
                                 pop_argumentos(nargs);
                        //        //restaura el nombre de la funcion actualmente en ejecucion
                                 pop_param(255);
                                 nombrefuncion =  array_variables[255].nombre;
                                 res = array_variables[indice_de_la_variable].numero;
                                 //pop parametros
                             }
                             pop_param(255);
                             nombrefuncion =   array_variables[255].nombre;
                        }
                    }
                    break;


                case tipos_nodo.nand:
                    {
                        int i; int j;

                        i = (int)evalua(p.Nodo1);
                        j = (int)  evalua(p.Nodo2);
                        if (i > 0 && j > 0) res = 1; else res = 0;
 
                    }
                    break;

                case tipos_nodo.nor:
                    {
                        int i; int j;

                        i = (int)evalua(p.Nodo1);
                        j = (int)evalua(p.Nodo2);
                        if (i > 0 || j > 0) res = 1; else res = 0;
                    }
                    break;




                default:
                    Console.WriteLine(p.Tipo);

                    break;

            }
            return res;
        }

        private void Mtimer_Elapsed(object sender, ElapsedEventArgs e)
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
            var ignore = UpdaterAsync(cts.Token);
        }


        public async Task UpdaterAsync(CancellationToken token)
        {
            EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);

            edit1.Text = sw.ToString();
            await Task.Delay(100, token);

        }

        unsafe public nodo convertir3(elnodo* p)
        {
            nodo res = new nodo
            {
                Numero = p->Numero,
                Tipo = (tipos_nodo)p->Tipo,
                Subnodos = p->Subnodos
            };

            switch (p->Subnodos)
            {
                case 1:
                    res.Nodo1 = convertir3((elnodo*)p->Nodo1);
                    break;

                case 2:
                    res.Nodo1 = convertir3((elnodo*)p->Nodo1);
                    res.Nodo2 = convertir3((elnodo*)p->Nodo2);
                    break;

                case 3:
                    res.Nodo1 = convertir3((elnodo*)p->Nodo1);
                    res.Nodo2 = convertir3((elnodo*)p->Nodo2);
                    res.Nodo3 = convertir3((elnodo*)p->Nodo3);
                    break;

                case 4:
                    res.Nodo1 = convertir3((elnodo*)p->Nodo1);
                    res.Nodo2 = convertir3((elnodo*)p->Nodo2);
                    res.Nodo3 = convertir3((elnodo*)p->Nodo3);
                    res.Nodo4 = convertir3((elnodo*)p->Nodo4);
                    break;

                case 5:
                    res.Nodo1 = convertir3((elnodo*)p->Nodo1);
                    res.Nodo2 = convertir3((elnodo*)p->Nodo2);
                    res.Nodo3 = convertir3((elnodo*)p->Nodo3);
                    res.Nodo4 = convertir3((elnodo*)p->Nodo4);
                    res.Nodo5 = convertir3((elnodo*)p->Nodo5);
                    break;

            }
            return res;

        }

        void push_param(int i)
        {
            try
            {
                pila[idx_pila].numero = array_variables[i].numero;
                pila[idx_pila].procedimiento = array_variables[i].procedimiento;
                pila[idx_pila].tipo = array_variables[i].tipo;
                pila[idx_pila].nombre = array_variables[i].nombre;


                if (pila[idx_pila].tipo == 'S')
                {
                    string str1;
                    int j;
                    if (  array_variables[i].valstring != null && array_variables[i].valstring != string.Empty)
                    {
                        j = (array_variables[i].valstring).Length + 1;


                        str1 = array_variables[i].valstring;
                        pila[idx_pila].valstring = str1;
                    }
                }
                pila[idx_pila].backup = (short)i;
                idx_pila++;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                //throw;
            }
           
        }


        void pop_param(int i)
        {
            int j;
            if (idx_pila == 0) return;

            idx_pila--;
            array_variables[i].numero = pila[idx_pila].numero;
            array_variables[i].procedimiento = pila[idx_pila].procedimiento;
            array_variables[i].tipo = pila[idx_pila].tipo;
            array_variables[i].nombre = pila[idx_pila].nombre;
            if (array_variables[i].tipo == 'S' || array_variables[i].tipo == 'F')
            {
                if (pila[idx_pila].valstring != null && pila[idx_pila].valstring != string.Empty)
                {
                     
                    j = (pila[idx_pila].valstring).Length + 1;

                    array_variables[i].valstring = pila[idx_pila].valstring;

                    pila[idx_pila].valstring = null;
                }
            }
        }


        short instr(int i, int a)
        {
            //i es la cadena en la cual buscar
            //a es la cadena buscada
            //var es el resultado
            string subc1;
            string subc2;
            //string result;
            short posicion;
            //short substringLen;
            //subc1 = malloc(127);
            //subc2 = malloc(127);
            subc1 = array_variables[i].valstring;
            subc2 = array_variables[a].valstring;
            //result = strstr(subc1, subc2);

             posicion = 0;
            try
            {
                posicion = (short)subc1.IndexOf(subc2);
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.ToString());
                //throw;
            }
             
            //free(subc1);
            //free(subc2);
            if (posicion >= 0) posicion++; else posicion = 0;
            return posicion;
 
        }


        void derecha(int i, nodo a, int var)
        {
            //i es la variable que se recorta
            //a es la variable que tiene la cantidad
            //var es la que recibe el recorte
            int aa, bb;
            string subc;   //     ,  subc2;
            
            //int k = 0; int j;
            aa = (int)evalua(a);

            bb = (array_variables[i].valstring).Length;
             
            
            aa = bb - aa;
            //for (j = aa; j < (bb + aa - 1); j++)
            //{
            //    subc[k] = array_variables[i].valstring[j];

            //    k++;
            //}
            //subc[k] = '\0';
            //strcpy (array_variables[var].valor, subc);
            //subc2 = array_variables[var].valstring;

            subc = array_variables[i].valstring.Substring(aa, (bb-aa));
            

            array_variables[var].valstring = subc;

            //free(subc);
        }


        void izquierda(int i, nodo a, int var)
        {
            int aa, bb;
            string subc;  //    , *subc2;
            
            //int k = 0; int j;
            aa = (int)0;
            bb = (int)evalua(a);
             
             
            //for (j = aa - 1; j < (bb + aa - 1); j++)
            //{
            //    subc[k] = array_variables[i].valstring[j];
            //    k++;
            //}
            //subc[k] = '\0';
            
            subc  = array_variables[i].valstring.Substring(aa, (bb+aa));

            //if (subc2 != NULL)
            //{
                 
            //    array_variables[var].valstring = null;
            //}
            array_variables[var].valstring = subc;
            
        }



        short push_argumentos(nodo f1, nodo g1, ref  short cantidad)
        {
            // en f tenemos el destino
            // en g tenemos el origen
            // en f son variables
            // en g son variables y/o constantes
            //short cantidad = 0;


            if (f1.Subnodos > 0)
            {
                int i;
                int j;
                char t;
                nodo p1;
                i = (int)f1.Nodo1.Numero; //designator del primer parametro
                t = array_variables[i].tipo;

                if (t == 'S' || t == 'N')
                {
                    p1 = new nodo();
                    p1.Nodo1 = f1.Nodo1;
                    p1.Nodo2 = g1.Nodo1;

                    if (t == 'N')
                    {
                        p1.Tipo = tipos_nodo.asigna_num;
                    }
                    else
                    {
                        if (t == 'S')
                        {
                            if (g1.Nodo1.Tipo == tipos_nodo.constante_literal)
                            {
                                p1.Tipo = tipos_nodo.asigna_alfa;
                            }
                            else
                            {
                                p1.Tipo = tipos_nodo.asigna_alfa_var;
                            }
                        }
                        else
                        {
                            //p1.Tipo = 'I';
                        }
                    }
                    push_param((int)p1.Nodo1.Numero);
                    cantidad++;
                    execut(p1);

                    p1 = null;
                    //nodos--;

                }

                if (g1.Subnodos > 1)
                    push_argumentos(f1.Nodo2, g1.Nodo2, ref cantidad);
            }
            return 1;
        }



        void pop_argumentos(short n)
        {
            int i;
            while (n > 0)
            {
                idx_pila--;
                i = pila[idx_pila].backup;
                idx_pila++;
                pop_param(i);
                n--;
            }
        }

    }
    public class nodo
    {

        public tipos_nodo Tipo;
        public double Numero;
        public int Subnodos;

        public nodo Nodo1;

        public nodo Nodo2;

        public nodo Nodo3;

        public nodo Nodo4;

        public nodo Nodo5;

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
 


