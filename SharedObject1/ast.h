#pragma once
#include "pch.h"
#include <string>
#include "stdio.h"
#include <iostream>
#include <stdlib.h>
 #include "nodo.h"

 using namespace  std;
//using namespace System;
//using Platform::String;

namespace CppWINRT  // test
{
 
        class ast      
	{

		int tipo;
		double num;
		int    nrolinea1;
		int    nrolinea2;
		int    subnodos;
		string  string1;

 
public:
		ast(void);
		virtual ~ast(void);

	void	setast1(int t, ast *a, double n);
	void	setast2(int t, ast *a, ast *b, double n);
	void	setast3(int t, ast *a, ast *b, ast *c, double n);
	void	setast4(int t, ast *a, ast *b, ast *c, ast *d, double n);
	void	setast5(int t, ast *a, ast *b, ast *c, ast *d, ast *e, double n);

	int     getsubnodos(); 
 

	int Tipo;
        
	double Numero;
	ast    *nodo1;
	ast    *nodo2;
	ast    *nodo3;
	ast    *nodo4;
	ast    *nodo5;

 
	};
 
}