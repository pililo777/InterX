#include "pch.h"
//#include "ast.h"
#include <string.h>

#include <cstring>
#include <cstdio>

#include <android/log.h>
#include "android/native_activity.h"



 typedef  struct  UnmanagedStruct  {
public:
 

	  int Tipo;
	  double Numero;
 
	  int Subnodos;


	  UnmanagedStruct *  Nodo1;
	  UnmanagedStruct* Nodo2;
	  UnmanagedStruct* Nodo3;
	  UnmanagedStruct* Nodo4;
 
}  ClassWrapper;




 

 

using namespace std;
 


/*  * * * * * * * * * * * * * *  main.cpp   * * * * * * * * * * */

#include "stdio.h"
#include "nodo.h"
 
#include <iostream>
#include <stdlib.h>


extern int idx_prg;
FILE * fichero = (FILE *) 0;



extern char variables[127][127];
extern   char constantes[127][127];
extern double var[127];

extern   ast * pila_programas[32];

 

extern int nodos;







 
/* ----------------------------------------------------------------*/
namespace CppWINRT  // test
{

	extern   ast * nuevonodo();
	extern FILE * yyin;
	extern char *yytext;
	extern   char instalavar(char);
	extern   int yyparse(void);
	extern   void *  execut(ast *);
	extern  char contadorvar;
	extern   ast * nuevonodo();
	//extern UnmanagedStruct *convertir2(ast * p);
 
     class clase1  
	{

	public:
		  clase1();
		  ~clase1();
			 int main ();
	
			 int  asignar_num(int num, string *s);
		     double  run(); //retorna la primer variable, antes el parametro era String *s
			 double  buscar_valor(string *nombre);
			 UnmanagedStruct*    getmainprogram();
			 char   * getconstante(int posicion);
			 double getvar (int posicion);
			 UnmanagedStruct * convertir2(ast * p);
			 
 
	private:
		 void liberar_nodo( ast * p, int n);
 	
	};
   
 

char * clase1::getconstante(int posicion) {
	return  constantes[posicion];

}

double clase1::getvar (int posicion) {
	return ::var[posicion];
}

void clase1::liberar_nodo( ast * p, int n)

{
    
        
        if (p==NULL) return;
        

 
        if (p == pila_programas[n]) {
                if (p->subnodos == 0) 
                    {
                        free(p);
                        nodos--;
                        //printf("no hay nodos para liberar\n");
                        return;
                    }
        
            if (p->subnodos > 0) {
                liberar_nodo(p->nodo1, n);
 
            }

        if (p->subnodos > 1) {
            liberar_nodo(p->nodo2, n);
 
        }

        if (p->subnodos > 2) {
            liberar_nodo(p->nodo3,n);
 
        }

        if (p->subnodos > 3) {
            liberar_nodo(p->nodo4,n );
 
        }
		 
           free(p);
           //memoria -= (long) sizeof (struct ast);
           nodos--;
       //    printf("librando el nodo raiz: %ld\n", memoria);
            
            
        
        pila_programas[n] = NULL;
		fprintf(fichero, "%s\n", "hemos liberado memoria");
        return;
    }
    else {
           
        if (p->subnodos == 0) 
        {
            free(p);
            //memoria -= (long) sizeof (struct ast);
            nodos--;
         //   printf("librando un nodo sin subnodos: %ld\n", memoria);
            return;
        }

           
           if (p->subnodos > 0) {
            liberar_nodo(p->nodo1, n);
            
 
    }

        if (p->subnodos > 1) {
            liberar_nodo(p->nodo2, n);
 
}
 
        if (p->subnodos > 2) {
            liberar_nodo(p->nodo3, n);
 
        }

        if (p->subnodos > 3) {
            liberar_nodo(p->nodo4, n);
 
        }
 
           
           free(p);
           // memoria -= (long) sizeof (struct ast);
           nodos--;
           
       //    printf("librando el nodo: %ld\n", memoria);
		   //fprintf(fichero, "%s\n", "hemos liberado memoria(2)");
           return;

    }
    //return
        
}

UnmanagedStruct* clase1::getmainprogram() {
	UnmanagedStruct *  temp;
	//temp = new UnmanagedStruct();
	temp = convertir2(pila_programas[0]);
	liberar_nodo(pila_programas[0], 0);
		return temp;
	
	}

clase1::clase1()
{
	fprintf(stderr, "\n\nclase creada\n\n");
}

clase1::~clase1()
{
}

int clase1::main ()
{
    int i;
 //static const	char *  myFileName = "/sdcard/data/data/Andr1.Andr1/files/p1.pr";
 static const	char *  myFileName = "/sdcard/data/data/Andr1.Andr1/files/p1.pr";
 int    fd;
 
 fd = dup(fileno(stderr));
 //freopen("/sdcard/data/data/Andr1.Andr1/files/temp.txt", "w", stderr);


 
 

	if   (1) {     //  {     //LO normal es :   (argc > 1)  --  para depurar con un programa: (argc = 1)
		//yyin = fopen("c:\\inter\\tst10.pr", "r");
		i = 1;
		
		do {
		 
			fprintf(stderr, "VAMOS POR EL P1.PR");
		    yyin = fopen(myFileName, "r");    //comentar para depurar

			if (yyin == NULL) {

				fprintf(stderr, "\n\n   ERROR  EN FICHERO P1.PR....\n\n");
				return 1;

			}
			else
			{
				fprintf(stderr, "\n\n   FICHERO ABIERTO !!!!.....\n\n");
 
			}


		//	fread(a, 1, 100, yyin);
 
			
		    if (yyin != NULL){
				// vemos el tamaño del fichero
				//fprintf(stderr, "prueba numero: %ld bytes\n", 5);
				//fseek(yyin, 0L, SEEK_END);
				//sz = ftell(yyin);
				//fseek(yyin, 0L, SEEK_SET);
				//fprintf(stderr, "Tamaño programa: %ld bytes\n", sz);
			    //printf("abierto.....\n");
			    {
					   idx_prg = 0;
					    
					   yyparse();
					   fflush(stderr);
					   fprintf (stderr, "parse: %d nodos\n", nodos);
					   fclose(yyin);
					   i++;
				}
			} 
			else {
				fprintf(fichero, "imposible abrir fichero.\n");
				break;
			}
			break;
		} while    (1) ; //  (i != argc);  //   // ; para depurar:  (i==1); modificar abajo tambien(run)

		//ejecuciona los programas de la pila.


		// CORRE HASTA 32 PROGRAMAS:


		i = 1;
		do {
		
			 //	execut(pila_programas[i-1]);
				i++;
				break;
		} while (1);  // (i != argc);     //para depurar:  ( (i == 1); //



		fprintf (stderr, "se crearon: %d nodos\n", nodos);
		
		  //liberar_nodo(pila_programas[0], 0);

		 fprintf (stderr, "quedan: %d nodos\n", nodos);
		 fflush(stderr);
		 dup2(fd, fileno(stderr));
		 close(fd);
		 std::cout << "PILILO" << std::endl;
		 //nodos = 0;

	}

	else
			printf("usar: inter.exe nombreprograma [nombreprograma....]\n");
		
	return 0;
}





double clase1::run()   // antes el parametro era una string   String *s
			{
			    int argc = 2;
				char test[80];

				 
//			static const	char *  myFileName  = "/sdcard/data/data/Andr1.Andr1/files/test.txt";
			static const	char *  myFileName = "/sdcard/data/data/Andr1.Andr1/files/test.txt";
			static const char *mensaje = "por lo menos esto va bien";
				 
				fprintf(stderr, "\n\n   RUNNING.....\n\n");
				 
				 
				//strcpy (test, "p1.pr") ;
				//fichero = fopen (myFileName , "w"  ); 

				//if (fichero == NULL) {
				//
				//	fprintf(stderr, "\n\n   ERROR EN FICHERO TEST.TXT.....\n\n");
				//	return 1;
				//
				//}
				//else
				//{
				//	fprintf(stderr, "\n\n   FICHERO abierto!!!!.....\n\n");
				//	//fwrite(mensaje, 1, 25, fichero);
 
				//}
			
	 
				main();

				//fclose (fichero);
				return(::var[0]);  //gracias, intellisense
				
				
			}

int clase1::asignar_num (int num, string  *s)
   {
				char test[80];
				ast * comando, * numero, * variable;

				//std::wstring stlString = s->Data();
				//const wchar_t *  s2 =   stlString.c_str() ;
				int i = 0;

				//int l = stlString.length() ;
				//for (i=0; i<l; i++) {
				//	test[i] = (char) s2[i];
				//}
				//test[i++] = '\0';


				//wctomb(test, (wchar_t ) s2);
				
				//strcpy (test,   s2  ) ;
				

				
				variable = nuevonodo();

			

				variable->tipo = indice_strings;  //nombre de variables numéricas.
				yytext = test;
				//variable->num = (char) instalavar(contadorvar++);
				
				
				numero = nuevonodo();
				numero->tipo = un_numero;
				numero->num = num;
	//
	
				comando = nuevonodo();
				comando->tipo = asigna_num;
				comando->nodo1 = variable;
				comando->nodo2 = numero;
				comando->subnodos = 2;
				execut(comando);
				return(1);
				
   }

double  clase1::buscar_valor(string  *nombre)
{
	char test[80];
	//strcpy (test, to_cStr(nombre) ) ;
	int i= 0;
	double valor = 0;
	//for (i=0; i<127; i++) {
	//	if (!strcmp (variables[i], test)) {
	//		valor = var[i];
	//		i=127;
	//	}
	//}
	return (valor);
}



UnmanagedStruct * clase1::convertir2(ast * p)
{
	UnmanagedStruct *ast1 = new UnmanagedStruct();

	switch (p->subnodos)
	{
	case 0:

		ast1->Tipo = p->tipo;
		ast1->Numero = p->num;
		ast1->Subnodos = 0;

		break;
	case 1:


		ast1->Tipo = p->tipo;
		ast1->Nodo1 = convertir2(p->nodo1);
		ast1->Numero = p->num;
		ast1->Subnodos = 1;

		break;

	case 2:

		ast1->Tipo = p->tipo;
		ast1->Nodo1 = convertir2(p->nodo1);
		ast1->Nodo2 = convertir2(p->nodo2);
		ast1->Numero = p->num;
		ast1->Subnodos = 2;

		break;

	case 3:

		ast1->Tipo = p->tipo;
		ast1->Nodo1 = convertir2(p->nodo1);
		ast1->Nodo2 = convertir2(p->nodo2);
		ast1->Nodo3 = convertir2(p->nodo3);
		ast1->Numero = p->num;
		ast1->Subnodos = 3;

		break;

	case 4:

		ast1->Tipo = p->tipo;
		ast1->Nodo1 = convertir2(p->nodo1);
		ast1->Nodo2 = convertir2(p->nodo2);
		ast1->Nodo3 = convertir2(p->nodo3);
		ast1->Nodo4 = convertir2(p->nodo4);
		ast1->Numero = p->num;
		ast1->Subnodos = 4;

		break;

	case 5:

		ast1->Tipo = p->tipo;
		ast1->Nodo1 = convertir2(p->nodo1);
		ast1->Nodo2 = convertir2(p->nodo2);
		ast1->Nodo3 = convertir2(p->nodo3);
		ast1->Nodo4 = convertir2(p->nodo4);
		ast1->Nodo4 = convertir2(p->nodo5);
		ast1->Numero = p->num;
		ast1->Subnodos = 4;

		break;



	default:
		break;
	}

	return ast1;
}
 
 }  // end namespace

 
extern "C" char * Cpp_GetValue(  int i)
{
	try {
		char * temp;
		  
		temp = &constantes[i][0];
		 
		 return temp;
	}

	catch (exception& e)
	{
		
			fprintf(stderr, e.what());

	}
 
 }

extern "C" double Cpp_GetValue2(int i)
{
	try {
		double temp;
		temp = var[i];
		return temp;
	}

	catch (exception& e)
	{

		fprintf(stderr, e.what());

	}

}
 
#include "vars.h";

extern "C" char * Cpp_GetValue3(int i)
{
	try {
		char * temp;

		//temp = &constantes[i][0];
		temp = array_variables[i].nombre;

		return temp;
	}

	catch (exception& e)
	{

		fprintf(stderr, e.what());

	}

}

 
extern "C" UnmanagedStruct  *   PassByReferenceInOut(struct  UnmanagedStruct ** sss) {
	struct UnmanagedStruct *temp1;

	CppWINRT::clase1 *  ppp = new CppWINRT::clase1();
	fprintf(stderr, "\n\nejecucion programa  \n\n");
	int v = ppp->run();
	 //temp1 =   *sss;


	temp1 = ppp->getmainprogram();

	   //*sss =   temp1;
	   (*sss)->Tipo = temp1->Tipo;
	   (*sss)->Numero = temp1->Numero;
	   (*sss)->Nodo1 = temp1->Nodo1;
	   (*sss)->Subnodos = temp1->Subnodos;
	   (*sss)->Nodo2 = temp1->Nodo2;
	   (*sss)->Nodo3 = temp1->Nodo3;
	   (*sss)->Nodo4 = temp1->Nodo4;

	   temp1 = NULL;
	   return    *sss;

//	delete ppp;
}


