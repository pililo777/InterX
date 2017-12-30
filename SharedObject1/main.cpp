#include "pch.h"
#include "ast.h"
#include <string.h>

#include <cstring>
#include <cstdio>

#include <android/log.h>
#include "android/native_activity.h"

 

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

extern   elnodo * pila_programas[32];

 

int nodos = 0;







 
/* ----------------------------------------------------------------*/
namespace CppWINRT  // test
{

	extern   elnodo * nuevonodo();
	extern FILE * yyin;
	extern char *yytext;
	extern   char instalavar(char);
	extern   int yyparse(void);
	extern   void *  execut(elnodo *);
	extern  char contadorvar;
	extern   elnodo * nuevonodo();
	extern ast *convertir(elnodo * p);
 
     class clase1  
	{

	public:
		  clase1();
		  ~clase1();
			 int main ();
	
			 int  asignar_num(int num, string *s);
		     double  run(); //retorna la primer variable, antes el parametro era String *s
			 double  buscar_valor(string *nombre);
			 ast*    getmainprogram(); 
			 char   * getconstante(int posicion);
			 double getvar (int posicion);
			 
 
	private:
		 void liberar_nodo( elnodo * p, int n);
 	
	};
   
 

char * clase1::getconstante(int posicion) {
	return  constantes[posicion];

}

double clase1::getvar (int posicion) {
	return ::var[posicion];
}

void clase1::liberar_nodo( elnodo * p, int n)

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

ast* clase1::getmainprogram() {
		ast*   temp;
		temp =   new ast();
		temp = convertir(pila_programas[0]);
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
 static const	char *  myFileName = "/data/data/Andr1.Andr1/files/p1.pr";

 

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
		
			 	execut(pila_programas[i-1]);
				i++;
				break;
		} while (1);  // (i != argc);     //para depurar:  ( (i == 1); //

		fprintf (stderr, "se crearon: %d nodos\n", nodos);
		
		  liberar_nodo(pila_programas[0], 0);

		 fprintf (stderr, "quedan: %d nodos\n", nodos);

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
			static const	char *  myFileName = "/data/data/Andr1.Andr1/files/test.txt";
			static const char *mensaje = "por lo menos esto va bien";
				 
				fprintf(stderr, "\n\n   RUNNING.....\n\n");
				 
				 
				strcpy (test, "p1.pr") ;
				fichero = fopen (myFileName , "w"  ); 

				if (fichero == NULL) {
				
					fprintf(stderr, "\n\n   ERROR EN FICHERO TEST.TXT.....\n\n");
					return 1;
				
				}
				else
				{
					fprintf(stderr, "\n\n   FICHERO abierto!!!!.....\n\n");
					//fwrite(mensaje, 1, 25, fichero);
 
				}
			
	 
				main();

				fclose (fichero);
				return(::var[0]);  //gracias, intellisense
				
				
			}

int clase1::asignar_num (int num, string  *s)
   {
				char test[80];
				elnodo * comando, * numero, * variable;

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
				variable->num = (char) instalavar(contadorvar++);
				
				
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
	for (i=0; i<127; i++) {
		if (!strcmp (variables[i], test)) {
			valor = var[i];
			i=127;
		}
	}
	return (valor);
}



 }  // end namespace


 //int clickCount = 1;
 //int GetClickCount() {

	// return clickCount++;

 //}


extern "C" int Cpp_GetValue()
{
	try {

		CppWINRT::clase1 *  p = new CppWINRT::clase1();
		fprintf(stderr, "\n\nejecucion programa  \n\n");
		int v = p->run();
		delete p;
		return v;
	}

	catch (exception& e)
	{
		
			fprintf(stderr, e.what());

	}



 }



