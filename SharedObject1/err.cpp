#include "pch.h"

 
extern "C" int exit(int);

#include "stdio.h"
extern int linenumber ;

extern FILE * fichero;

void  yyerror( char *  msg)
   
{
   fprintf(fichero, "error en linea %d: %s\n", linenumber, msg);
   //exit(1);
}

void nextline()
{
   linenumber++;
}

 