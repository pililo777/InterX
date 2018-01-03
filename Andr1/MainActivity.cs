using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

namespace Andr1
{

    enum tipos_nodo
    {
        un_numero = (int)1, desde, nombre_de_variable,
        indice_strings, procedimiento, secuencia, imprimir,
        suma, resta, multiplica, divide, si, mientras, asigna_num, asigna_alfa,
        mayorque, menorque, igualque, leer, leertexto, noigualque, menorigualque, mayorigualque, negativo,
        comparaliteral, imprimir_varios, imprimir_expresion, imprimir_literal, imprimir_var_alfa,

        constante_literal, llamar, decimales, vacio
    };

    [Activity(Label = "Andr1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        String[] constantes = new String[127];
        double[] var = new double[127];


        [DllImport("SharedObject1")]
        public extern static IntPtr Cpp_GetValue( int i);
 
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





        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += new EventHandler(Cpp_GetValue2);



        }

        void HandleTouchUpInside(object sender, EventArgs ea)
        {
            //new UIAlertView("Touch3", "TouchUpInside handled", null, "OK", null).Show();
            Toast.MakeText(this, "click en el boton3", ToastLength.Long).Show();

        }


        unsafe protected void Cpp_GetValue2(object sender, EventArgs e)

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

 
            }

            StringWriter sw = new StringWriter();

                EditText edit1 = FindViewById<EditText>(Resource.Id.editText1);
                try
                {

                    sw.Close();
                    sw = new StringWriter();
                    string text2 = execut(&s);

                //edit1.Text = System.IO.File.ReadAllText("/sdcard/data/data/Andr1.Andr1/files/test.txt");
                //edit1.Text = System.IO.File.ReadAllText("/data/data/Andr1.Andr1/files/test.txt");
                
                System.IO.File.WriteAllText("/data/data/Andr1.Andr1/files/test.txt", text2);
                edit1.Text = text2;

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
        int[] counter1 = new int[20];
        StringWriter sw = new StringWriter();



        // la funcion fue migrada el 22 de diciembre de 2017
        // estaba en c++ y fue convertida a c#
        unsafe string execut(elnodo* a)
        {
            elnodo* p;
            //p = nuevonodo();

            tipos_nodo t;
            t = (tipos_nodo)a->Tipo;

            p = a;


            switch (t)
            {

                case tipos_nodo.decimales:

                    nro_decimales = ((int)((elnodo*)p->Nodo1)->Numero);
                    break;



                case tipos_nodo.secuencia:

                    execut((elnodo*)p->Nodo1);

                    execut((elnodo*)p->Nodo2);
                    break;

                case tipos_nodo.imprimir_literal:

                    sw.WriteLine(constantes[(int)((elnodo*)p->Nodo1)->Numero]);

                    break;

                case tipos_nodo.imprimir_var_alfa:

                    sw.WriteLine(constantes[(int)var[(int)((elnodo*)(p->Nodo1))->Numero]]);
                    break;

                case tipos_nodo.imprimir_expresion:


                    switch (nro_decimales)
                    {

                        case 0:
                            sw.WriteLine(evalua((elnodo*)p->Nodo1));
                            break;


                        default:
                            sw.WriteLine(evalua((elnodo*)p->Nodo1));
                            break;

                    };

                    break;



                case tipos_nodo.imprimir_varios:

                    execut((elnodo*)p->Nodo1);
                    sw.WriteLine("\n");
                    break;

                //TODO: crear un array de procedimientos en C# y convertirlos desde c++
                case tipos_nodo.llamar:
                    //fprintf("\nllamar un procedimiento\n");
                    //if (procedimientos[(int)p->nodo1->num] == NULL)
                    //   {
                    //       fprintf(fichero, "procedimiento no encontrado en linea: \n");
                    //       getchar();
                    //exit (1);
                    //}

                    //execut ( procedimientos[ (int) (p->nodo1->num) ]  );
                    //fprintf("volvemos del procedimiento\n\n");
                    sw.WriteLine("orden llamar\n");
                    break;

                case tipos_nodo.asigna_num:

                    var[(int)((elnodo*)p->Nodo1)->Numero] = evalua((elnodo*)p->Nodo2);
                    break;

                case tipos_nodo.asigna_alfa:

                    var[(int)((elnodo*)p->Nodo1)->Numero] = ((elnodo*)p->Nodo2)->Numero;
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

                        indice_ctr++;
                        var[x] = (int)evalua((elnodo*)p->Nodo2);
                        counter1[indice_ctr] = (int)var[x];

                        for (counter1[indice_ctr] = counter1[indice_ctr]; counter1[indice_ctr] <= (int)evalua((elnodo*)p->Nodo3); counter1[indice_ctr]++)
                        {

                            var[x] = counter1[indice_ctr];
                            execut((elnodo*)p->Nodo4);
                        }

                        indice_ctr--;

                    }

                    break;


                default:
                    break;

            }
            return sw.ToString();
        }




        unsafe double evalua(elnodo* p)
        {


            switch ((tipos_nodo)p->Tipo)
            {

                case tipos_nodo.indice_strings:    //una variable numerica
                    return var[(int)p->Numero];

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

                        if (constantes[(int)var[(int)((elnodo*)p->Nodo1)->Numero]] == constantes[(int)((elnodo*)p->Nodo2)->Numero]) return 1; else return 0;

                    }

                default:

                    break;

            }
            return 0;
        }
 
    }
 
}

 



