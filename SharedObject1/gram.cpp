#include "pch.h"
#include "ast.h"

//#include "nodo.h"

extern   elnodo * pila_programas[32]; 
extern   elnodo * procedimientos[127]; //cambiar esta forma
extern   int idx_prg;
extern   int idx_prc;
extern   void yyerror(char *);




namespace CppWINRT
 {
#define YYDEBUG 1
#include "malloc.h"

extern  int yylex();



/*  A Bison parser, made from grammar.y with Bison version GNU Bison version 1.24
  */

#define YYBISON 1  /* Identify Bison output.  */

#define	LLAMAR	258
#define	PROC	259
#define	END	260
#define	PROCNAME	261
#define	EQ	262
#define	TERMINAR	263
#define	DECIMALES	264
#define	NE	265
#define	LT	266
#define	LE	267
#define	GT	268
#define	GE	269
#define	PLUS	270
#define	MINUS	271
#define	MULT	272
#define	DIVIDE	273
#define	RPAREN	274
#define	LPAREN	275
#define	ASSIGN	276
#define	SEMICOLON	277
#define	COMMA	278
#define	IF	279
#define	THEN	280
#define	ELSE	281
#define	FI	282
#define	WHILE	283
#define	FOR	284
#define	TO	285
#define	DO	286
#define	OD	287
#define	PRINT	288
#define	LEER	289
#define	BORRAR	290
#define	NUMBER	291
#define	NAME	292
#define	SNAME	293
#define	LITERAL	294

//#linea 2 "grammar.y"


//#define MSDOS
//char constantes[127][127];
//char variables[127][127];

//#linea 12 "grammar.y"
typedef union   {
 elnodo * nodo;
} YYSTYPE;

#ifndef YYLTYPE
typedef
  struct yyltype
    {
      int timestamp;
      int first_line;
      int first_column;
      int last_line;
      int last_column;
      char *text;
   }
  yyltype;

#define YYLTYPE yyltype
#endif

#include <stdio.h>

#ifndef __cplusplus
#ifndef __STDC__
#define const
#endif
#endif

extern  elnodo *nodo1(tiponodo, elnodo *);
extern  elnodo *nodo2(tiponodo, elnodo *,elnodo *);
extern  elnodo *nodo3(tiponodo, elnodo *,elnodo *,elnodo *);
extern  elnodo *nodo4(tiponodo, elnodo *,elnodo *,elnodo *,elnodo *);

#define	YYFINAL		96
#define	YYFLAG		-32768
#define	YYNTBASE	40

#define YYTRANSLATE(x) ((unsigned)(x) <= 294 ? yytranslate[x] : 54)

static const char yytranslate[] = {     0,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
     2,     2,     2,     2,     2,     1,     2,     3,     4,     5,
     6,     7,     8,     9,    10,    11,    12,    13,    14,    15,
    16,    17,    18,    19,    20,    21,    22,    23,    24,    25,
    26,    27,    28,    29,    30,    31,    32,    33,    34,    35,
    36,    37,    38,    39
};

#if YYDEBUG != 0
static const short yyprhs[] = {     0,
     0,     2,     6,     8,    11,    15,    19,    22,    25,    28,
    31,    34,    36,    44,    50,    56,    66,    68,    72,    74,
    76,    78,    81,    83,    85,    89,    93,    97,   101,   105,
   109,   113,   115,   119,   123,   125,   129,   133,   136,   139,
   143,   145,   147,   149,   151,   153
};

static const short yyrhs[] = {    45,
     0,    45,     8,    41,     0,    53,     0,    41,    53,     0,
    51,     7,    46,     0,    50,     7,    39,     0,     3,    52,
     0,     9,    36,     0,    33,    43,     0,    34,    50,     0,
    34,    51,     0,    35,     0,    24,    46,    25,    45,    26,
    45,    27,     0,    24,    46,    25,    45,    27,     0,    28,
    46,    31,    45,    32,     0,    29,    51,     7,    46,    30,
    46,    31,    45,    32,     0,    44,     0,    43,    23,    44,
     0,    46,     0,    39,     0,    50,     0,    45,    42,     0,
    42,     0,    47,     0,    47,     7,    47,     0,    47,    10,
    47,     0,    47,    11,    47,     0,    47,    12,    47,     0,
    47,    13,    47,     0,    47,    14,    47,     0,    50,     7,
    39,     0,    48,     0,    47,    15,    48,     0,    47,    16,
    48,     0,    49,     0,    48,    17,    49,     0,    48,    18,
    49,     0,    15,    49,     0,    16,    49,     0,    20,    46,
    19,     0,    36,     0,    51,     0,    38,     0,    37,     0,
    37,     0,     4,    52,    45,     5,     0
};

#endif

#if YYDEBUG != 0
static const short yyrline[] = { 0,
    54,    60,    66,    68,    71,    73,    74,    75,    76,    77,
    78,    79,    80,    81,    82,    83,    87,    89,    92,    94,
    95,    98,   100,   104,   106,   107,   108,   109,   110,   111,
   112,   116,   118,   119,   122,   124,   125,   128,   130,   131,
   132,   133,   136,   139,   142,   146
};

static const char * const yytname[] = {   "$","error","$undefined.","LLAMAR",
"PROC","END","PROCNAME","EQ","TERMINAR","DECIMALES","NE","LT","LE","GT","GE",
"PLUS","MINUS","MULT","DIVIDE","RPAREN","LPAREN","ASSIGN","SEMICOLON","COMMA",
"IF","THEN","ELSE","FI","WHILE","FOR","TO","DO","OD","PRINT","LEER","BORRAR",
"NUMBER","NAME","SNAME","LITERAL","ROOT","procedimientos","statement","lista_expr",
"lista_expr2","stmtseq","expression","expr2","expr3","expr4","sdesignator","designator",
"proc_designator","procedimiento",""
};
#endif

static const short yyr1[] = {     0,
    40,    40,    41,    41,    42,    42,    42,    42,    42,    42,
    42,    42,    42,    42,    42,    42,    43,    43,    44,    44,
    44,    45,    45,    46,    46,    46,    46,    46,    46,    46,
    46,    47,    47,    47,    48,    48,    48,    49,    49,    49,
    49,    49,    50,    51,    52,    53
};

static const short yyr2[] = {     0,
     1,     3,     1,     2,     3,     3,     2,     2,     2,     2,
     2,     1,     7,     5,     5,     9,     1,     3,     1,     1,
     1,     2,     1,     1,     3,     3,     3,     3,     3,     3,
     3,     1,     3,     3,     1,     3,     3,     2,     2,     3,
     1,     1,     1,     1,     1,     4
};

static const short yydefact[] = {     0,
     0,     0,     0,     0,     0,     0,     0,    12,    44,    43,
    23,     1,     0,     0,    45,     7,     8,     0,     0,     0,
    41,     0,    24,    32,    35,     0,    42,     0,     0,    20,
     9,    17,    19,    21,    10,    11,     0,    22,     0,     0,
    38,    39,     0,     0,     0,     0,     0,     0,     0,     0,
     0,     0,     0,     0,     0,     0,     0,     0,     0,     2,
     3,     6,     5,    40,     0,    25,    26,    27,    28,    29,
    30,    33,    34,    36,    37,    31,     0,     0,    18,     0,
     4,     0,    14,    15,     0,     0,     0,     0,    46,    13,
     0,     0,    16,     0,     0,     0
};

static const short yydefgoto[] = {    94,
    60,    11,    31,    32,    12,    33,    23,    24,    25,    13,
    27,    16,    61
};

static const short yypact[] = {   181,
   -34,   -26,    16,    16,   -31,    25,   -29,-32768,-32768,-32768,
-32768,    94,     8,    21,-32768,-32768,-32768,   143,   143,    16,
-32768,     4,   210,     2,-32768,    26,-32768,     3,    28,-32768,
    14,-32768,-32768,    26,-32768,-32768,    35,-32768,     7,    16,
-32768,-32768,    23,   181,   143,   143,   143,   143,   143,   143,
   143,   143,   143,   143,     9,   181,    16,    25,   -34,    35,
-32768,-32768,-32768,-32768,    72,    11,    11,    11,    11,    11,
    11,     2,     2,-32768,-32768,-32768,   110,    13,-32768,   181,
-32768,   181,-32768,-32768,    16,   132,   148,    20,-32768,-32768,
   181,   165,-32768,    66,    70,-32768
};

static const short yypgoto[] = {-32768,
-32768,    -8,-32768,    15,   -33,    -2,   182,   -30,     6,    10,
     0,    12,    29
};


#define	YYLAST		232


static const short yytable[] = {    14,
    22,    28,    15,    38,    29,     9,    36,     9,    10,    17,
    65,    14,    26,    26,    39,    34,    35,    43,    53,    54,
    72,    73,    77,    41,    42,    51,    52,    40,    44,    26,
    18,    19,    55,    56,    57,    20,    58,    63,    59,    18,
    19,    64,    85,    14,    20,    62,    86,    76,    87,    26,
    91,    21,     9,    10,    78,    14,    38,    92,    74,    75,
    21,     9,    10,    30,    14,    95,    26,    34,    38,    96,
    80,     0,    79,     0,     1,     0,    14,    38,    38,    14,
     2,    14,    88,    38,     0,    14,    14,     0,    81,     0,
    14,    14,     0,     0,    26,     3,     1,    82,    83,     4,
     5,    37,     2,     0,     6,     7,     8,     0,     9,    10,
     0,     0,     1,     0,     0,     0,     0,     3,     2,     0,
     0,     4,     5,     0,     0,     0,     6,     7,     8,     0,
     9,    10,     0,     3,     1,     0,    89,     4,     5,     0,
     2,    84,     6,     7,     8,     0,     9,    10,     0,     0,
     1,     0,     0,     0,     0,     3,     2,    18,    19,     4,
     5,     0,    20,     0,     6,     7,     8,     1,     9,    10,
     0,     3,     0,     2,    90,     4,     5,     0,    21,     9,
     6,     7,     8,     1,     9,    10,     0,     0,     3,     2,
     0,     0,     4,     5,     0,     0,    93,     6,     7,     8,
     0,     9,    10,     0,     3,     0,     0,     0,     4,     5,
     0,     0,     0,     6,     7,     8,    45,     9,    10,    46,
    47,    48,    49,    50,    51,    52,    66,    67,    68,    69,
    70,    71
};

static const short yycheck[] = {     0,
     3,     4,    37,    12,     5,    37,     7,    37,    38,    36,
    44,    12,     3,     4,     7,     6,     7,    20,    17,    18,
    51,    52,    56,    18,    19,    15,    16,     7,    25,    20,
    15,    16,     7,    31,     7,    20,    23,    40,     4,    15,
    16,    19,    30,    44,    20,    39,    80,    39,    82,    40,
    31,    36,    37,    38,    57,    56,    65,    91,    53,    54,
    36,    37,    38,    39,    65,     0,    57,    58,    77,     0,
    59,    -1,    58,    -1,     3,    -1,    77,    86,    87,    80,
     9,    82,    85,    92,    -1,    86,    87,    -1,    60,    -1,
    91,    92,    -1,    -1,    85,    24,     3,    26,    27,    28,
    29,     8,     9,    -1,    33,    34,    35,    -1,    37,    38,
    -1,    -1,     3,    -1,    -1,    -1,    -1,    24,     9,    -1,
    -1,    28,    29,    -1,    -1,    -1,    33,    34,    35,    -1,
    37,    38,    -1,    24,     3,    -1,     5,    28,    29,    -1,
     9,    32,    33,    34,    35,    -1,    37,    38,    -1,    -1,
     3,    -1,    -1,    -1,    -1,    24,     9,    15,    16,    28,
    29,    -1,    20,    -1,    33,    34,    35,     3,    37,    38,
    -1,    24,    -1,     9,    27,    28,    29,    -1,    36,    37,
    33,    34,    35,     3,    37,    38,    -1,    -1,    24,     9,
    -1,    -1,    28,    29,    -1,    -1,    32,    33,    34,    35,
    -1,    37,    38,    -1,    24,    -1,    -1,    -1,    28,    29,
    -1,    -1,    -1,    33,    34,    35,     7,    37,    38,    10,
    11,    12,    13,    14,    15,    16,    45,    46,    47,    48,
    49,    50
};
/* -*-C-*-  Note some compilers choke on comments on `//#linea' lines.  */
//#linea 3 "bison.simple"

/* Skeleton output parser for bison,
   Copyright (C) 1984, 1989, 1990 Free Software Foundation, Inc.

   This program is free software; you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation; either version 2, or (at your option)
   any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program; if not, write to the Free Software
   Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.  */

/* As a special exception, when this file is copied by Bison into a
   Bison output file, you may use that output file without restriction.
   This special exception was added by the Free Software Foundation
   in version 1.24 of Bison.  */

#ifndef alloca
#ifdef __GNUC__
#define alloca __builtin_alloca
#else /* not GNU C.  */
#if (!defined (__STDC__) && defined (sparc)) || defined (__sparc__) || defined (__sparc) || defined (__sgi)
#include <alloca.h>
#else /* not sparc */
#if defined (MSDOS) && !defined (__TURBOC__)
#include <malloc.h>
#else /* not MSDOS, or __TURBOC__ */
#if defined(_AIX)
#include <malloc.h>
 #pragma alloca
#else /* not MSDOS, __TURBOC__, or _AIX */
#ifdef __hpux
#ifdef __cplusplus
extern "C" {
void *alloca (unsigned int);
};
#else /* not __cplusplus */
void *alloca ();
#endif /* not __cplusplus */
#endif /* __hpux */
#endif /* not _AIX */
#endif /* not MSDOS, or __TURBOC__ */
#endif /* not sparc.  */
#endif /* not GNU C.  */
#endif /* alloca not defined.  */

/* This is the parser code that is written into each bison parser
  when the %semantic_parser declaration is not specified in the grammar.
  It was written by Richard Stallman by simplifying the hairy parser
  used when %semantic_parser is specified.  */

/* Note: there must be only one dollar sign in this file.
   It is replaced by the list of actions, each action
   as one case of the switch.  */

#define yyerrok		(yyerrstatus = 0)
#define yyclearin	(yychar = YYEMPTY)
#define YYEMPTY		-2
#define YYEOF		0
#define YYACCEPT	return(0)
#define YYABORT 	return(1)
#define YYERROR		goto yyerrlab1
/* Like YYERROR except do call yyerror.
   This remains here temporarily to ease the
   transition to the new meaning of YYERROR, for GCC.
   Once GCC version 2 has supplanted version 1, this can go.  */
#define YYFAIL		goto yyerrlab
#define YYRECOVERING()  (!!yyerrstatus)
#define YYBACKUP(token, value) \
do								\
  if (yychar == YYEMPTY && yylen == 1)				\
    { yychar = (token), yylval = (value);			\
      yychar1 = YYTRANSLATE (yychar);				\
      YYPOPSTACK;						\
      goto yybackup;						\
    }								\
  else								\
    { yyerror ("syntax error: cannot back up"); YYERROR; }	\
while (0)

#define YYTERROR	1
#define YYERRCODE	256

#ifndef YYPURE
#define YYLEX		yylex()
#endif

#ifdef YYPURE
#ifdef YYLSP_NEEDED
#ifdef YYLEX_PARAM
#define YYLEX		yylex(&yylval, &yylloc, YYLEX_PARAM)
#else
#define YYLEX		yylex(&yylval, &yylloc)
#endif
#else /* not YYLSP_NEEDED */
#ifdef YYLEX_PARAM
#define YYLEX		yylex(&yylval, YYLEX_PARAM)
#else
#define YYLEX		yylex(&yylval)
#endif
#endif /* not YYLSP_NEEDED */
#endif

/* If nonreentrant, generate the variables here */

#ifndef YYPURE

int	yychar;			/*  the lookahead symbol		*/
YYSTYPE	yylval;			/*  the semantic value of the		*/
				/*  lookahead symbol			*/

#ifdef YYLSP_NEEDED
YYLTYPE yylloc;			/*  location data for the lookahead	*/
				/*  symbol				*/
#endif

int yynerrs;			/*  number of parse errors so far       */
#endif  /* not YYPURE */

#if YYDEBUG != 0
int yydebug = 1;			/*  nonzero means print parse trace	*/
/* Since this is uninitialized, it does not stop multiple parsers
   from coexisting.  */
#endif

/*  YYINITDEPTH indicates the initial size of the parser's stacks	*/

#ifndef	YYINITDEPTH
#define YYINITDEPTH 200
#endif

/*  YYMAXDEPTH is the maximum size the stacks can grow to
    (effective only if the built-in stack extension method is used).  */

#if YYMAXDEPTH == 0
#undef YYMAXDEPTH
#endif

#ifndef YYMAXDEPTH
#define YYMAXDEPTH 10000
#endif

/* Prevent warning if -Wstrict-prototypes.  */
//#ifdef __GNUC__
int yyparse (void);
//#endif

#if __GNUC__ > 1		/* GNU C and GNU C++ define this.  */
#define __yy_memcpy(FROM,TO,COUNT)	__builtin_memcpy(TO,FROM,COUNT)
#else				/* not GNU C or C++ */
#ifndef __cplusplus

/* This is the most reliable way to avoid incompatibilities
   in available built-in functions on various systems.  */
static void
__yy_memcpy (from, to, count)
     char *from;
     char *to;
     int count;
{
  register char *f = from;
  register char *t = to;
  register int i = count;

  while (i-- > 0)
    *t++ = *f++;
}

#else /* __cplusplus */

/* This is the most reliable way to avoid incompatibilities
   in available built-in functions on various systems.  */
static void
__yy_memcpy (char *from, char *to, int count)
{
  register char *f = from;
  register char *t = to;
  register int i = count;

  while (i-- > 0)
    *t++ = *f++;
}

#endif
#endif

//#linea 192 "bison.simple"

/* The user can define YYPARSE_PARAM as the name of an argument to be passed
   into yyparse.  The argument should have type void *.
   It should actually point to an object.
   Grammar actions can access the variable by casting it
   to the proper pointer type.  */

#ifdef YYPARSE_PARAM
#define YYPARSE_PARAM_DECL void *YYPARSE_PARAM;
#else
#define YYPARSE_PARAM
#define YYPARSE_PARAM_DECL
#endif

 
int yyparse(YYPARSE_PARAM)
     YYPARSE_PARAM_DECL
{
  register int yystate;
  register int yyn;
  register short *yyssp;
  register YYSTYPE *yyvsp;
  int yyerrstatus;	/*  number of tokens to shift before error messages enabled */
  int yychar1 = 0;		/*  lookahead token as an internal (translated) token number */

  short	yyssa[YYINITDEPTH];	/*  the state stack			*/
  YYSTYPE yyvsa[YYINITDEPTH];	/*  the semantic value stack		*/

  short *yyss = yyssa;		/*  refer to the stacks thru separate pointers */
  YYSTYPE *yyvs = yyvsa;	/*  to allow yyoverflow to reallocate them elsewhere */

#ifdef YYLSP_NEEDED
  YYLTYPE yylsa[YYINITDEPTH];	/*  the location stack			*/
  YYLTYPE *yyls = yylsa;
  YYLTYPE *yylsp;

#define YYPOPSTACK   (yyvsp--, yyssp--, yylsp--)
#else
#define YYPOPSTACK   (yyvsp--, yyssp--)
#endif

  int yystacksize = YYINITDEPTH;

#ifdef YYPURE
  int yychar;
  YYSTYPE yylval;
  int yynerrs;
#ifdef YYLSP_NEEDED
  YYLTYPE yylloc;
#endif
#endif

  YYSTYPE yyval;		/*  the variable used to return		*/
				/*  semantic values from the action	*/
				/*  routines				*/

  int yylen;

#if YYDEBUG != 0
  if (yydebug)
    fprintf(stderr, "Starting parse\n");
#endif

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY;		/* Cause a token to be read.  */

  /* Initialize stack pointers.
     Waste one element of value and location stack
     so that they stay on the same level as the state stack.
     The wasted elements are never initialized.  */

  yyssp = yyss - 1;
  yyvsp = yyvs;
#ifdef YYLSP_NEEDED
  yylsp = yyls;
#endif

/* Push a new state, which is found in  yystate  .  */
/* In all cases, when you get here, the value and location stacks
   have just been pushed. so pushing a state here evens the stacks.  */
yynewstate:

  *++yyssp = yystate;

  if (yyssp >= yyss + yystacksize - 1)
    {
      /* Give user a chance to reallocate the stack */
      /* Use copies of these so that the &'s don't force the real ones into memory. */
      YYSTYPE *yyvs1 = yyvs;
      short *yyss1 = yyss;
#ifdef YYLSP_NEEDED
      YYLTYPE *yyls1 = yyls;
#endif

      /* Get the current used size of the three stacks, in elements.  */
      int size = yyssp - yyss + 1;

#ifdef yyoverflow
      /* Each stack pointer address is followed by the size of
	 the data in use in that stack, in bytes.  */
#ifdef YYLSP_NEEDED
      /* This used to be a conditional around just the two extra args,
	 but that might be undefined if yyoverflow is a macro.  */
      yyoverflow("parser stack overflow",
		 &yyss1, size * sizeof (*yyssp),
		 &yyvs1, size * sizeof (*yyvsp),
		 &yyls1, size * sizeof (*yylsp),
		 &yystacksize);
#else
      yyoverflow("parser stack overflow",
		 &yyss1, size * sizeof (*yyssp),
		 &yyvs1, size * sizeof (*yyvsp),
		 &yystacksize);
#endif

      yyss = yyss1; yyvs = yyvs1;
#ifdef YYLSP_NEEDED
      yyls = yyls1;
#endif
#else /* no yyoverflow */
      /* Extend the stack our own way.  */
      if (yystacksize >= YYMAXDEPTH)
	{
	  fprintf(stderr, "parser stack overflow");
	  return 2;
	}
      yystacksize *= 2;
      if (yystacksize > YYMAXDEPTH)
	yystacksize = YYMAXDEPTH;
      yyss = (short *) malloc (yystacksize * sizeof (*yyssp));
      __yy_memcpy ((char *)yyss1, (char *)yyss, size * sizeof (*yyssp));
      yyvs = (YYSTYPE *) malloc (yystacksize * sizeof (*yyvsp));
      __yy_memcpy ((char *)yyvs1, (char *)yyvs, size * sizeof (*yyvsp));
#ifdef YYLSP_NEEDED
      yyls = (YYLTYPE *) alloca (yystacksize * sizeof (*yylsp));
      __yy_memcpy ((char *)yyls1, (char *)yyls, size * sizeof (*yylsp));
#endif
#endif /* no yyoverflow */

      yyssp = yyss + size - 1;
      yyvsp = yyvs + size - 1;
#ifdef YYLSP_NEEDED
      yylsp = yyls + size - 1;
#endif

#if YYDEBUG != 0
      if (yydebug)
	fprintf(stderr, "Stack size increased to %d\n", yystacksize);
#endif

      if (yyssp >= yyss + yystacksize - 1)
	YYABORT;
    }

#if YYDEBUG != 0
  if (yydebug)
    fprintf(stderr, "Entering state %d\n", yystate);
#endif

  goto yybackup;
 yybackup:

/* Do appropriate processing given the current state.  */
/* Read a lookahead token if we need one and don't already have one.  */
/* yyresume: */

  /* First try to decide what to do without reference to lookahead token.  */

  yyn = yypact[yystate];
  if (yyn == YYFLAG)
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* yychar is either YYEMPTY or YYEOF
     or a valid token in external form.  */

  if (yychar == YYEMPTY)
    {
#if YYDEBUG != 0
      if (yydebug)
	fprintf(stderr, "Reading a token: ");
#endif
      yychar = YYLEX;
	  fprintf(stderr, "SE HA ESCANEADO EL CARACTER CODIGO %d\n", yychar);
    }

  /* Convert token to internal form (in yychar1) for indexing tables with */

  if (yychar <= 0)		/* This means end of input. */
    {
      yychar1 = 0;
      yychar = YYEOF;		/* Don't call YYLEX any more */

#if YYDEBUG != 0
      if (yydebug)
	fprintf(stderr, "Now at end of input.\n");
#endif
    }
  else
    {
      yychar1 = YYTRANSLATE(yychar);

#if YYDEBUG != 0
      if (yydebug)
	{
	  fprintf (stderr, "Next token is %d (%s", yychar, yytname[yychar1]);
	  /* Give the individual parser a way to print the precise meaning
	     of a token, for further debugging info.  */
#ifdef YYPRINT
	  YYPRINT (stderr, yychar, yylval);
#endif
	  fprintf (stderr, ")\n");
	}
#endif
    }

  yyn += yychar1;
  if (yyn < 0 || yyn > YYLAST || yycheck[yyn] != yychar1)
    goto yydefault;

  yyn = yytable[yyn];

  /* yyn is what to do for this token type in this state.
     Negative => reduce, -yyn is rule number.
     Positive => shift, yyn is new state.
       New state is final state => don't bother to shift,
       just return success.
     0, or most negative number => error.  */

  if (yyn < 0)
    {
      if (yyn == YYFLAG)
	goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }
  else if (yyn == 0)
    goto yyerrlab;

  if (yyn == YYFINAL)
    YYACCEPT;

  /* Shift the lookahead token.  */

#if YYDEBUG != 0
  if (yydebug)
    fprintf(stderr, "Shifting token %d (%s), ", yychar, yytname[yychar1]);
#endif

  /* Discard the token being shifted unless it is eof.  */
  if (yychar != YYEOF)
    yychar = YYEMPTY;

  *++yyvsp = yylval;
#ifdef YYLSP_NEEDED
  *++yylsp = yylloc;
#endif

  /* count tokens shifted since error; after three, turn off error status.  */
  if (yyerrstatus) yyerrstatus--;

  yystate = yyn;
  goto yynewstate;

/* Do the default action for the current state.  */
yydefault:

  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;

/* Do a reduction.  yyn is the number of a rule to reduce with.  */
yyreduce:
  yylen = yyr2[yyn];
  if (yylen > 0)
    yyval = yyvsp[1-yylen]; /* implement default value of the action */

#if YYDEBUG != 0
  if (yydebug)
    {
      int i;

      fprintf (stderr, "Reducing via rule %d (line %d), ",
	       yyn, yyrline[yyn]);

      /* Print the symbols being reduced, and their result.  */
      for (i = yyprhs[yyn]; yyrhs[i] > 0; i++)
	fprintf (stderr, "%s ", yytname[yyrhs[i]]);
      fprintf (stderr, " -> %s\n", yytname[yyr1[yyn]]);
    }
#endif


  switch (yyn) {

case 1:
//#linea 55 "grammar.y"
{  pila_programas[idx_prg] = (yyvsp[0].nodo); /* stmtseq */ ;
      idx_prg++;
   ;
    break;}
case 2:
//#linea 60 "grammar.y"
{ pila_programas[idx_prg] = (yyvsp[-2].nodo); /* stmtseq */ ;
   idx_prg++;

   ;
    break;}
case 3:
//#linea 67 "grammar.y"
{ yyval.nodo =  yyvsp[0].nodo  ;  /* un procedimiento  */ ;
    break;}
case 4:
//#linea 68 "grammar.y"
{ yyval.nodo =  yyvsp[0].nodo ; /*varios procedim.*/ ;
    break;}
case 5:
//#linea 72 "grammar.y"
{ yyval.nodo = nodo2(asigna_num, yyvsp[-2].nodo, yyvsp[0].nodo); /*asignacion*/;
    break;}
case 6:
//#linea 73 "grammar.y"
{ yyval.nodo = nodo2(asigna_alfa, yyvsp[-2].nodo, yyvsp[0].nodo); /*asign literal*/;
    break;}
case 7:
//#linea 74 "grammar.y"
{  yyval.nodo = nodo1(llamar, yyvsp[0].nodo) ;/*llamar proced.*/;
    break;}
case 8:
//#linea 75 "grammar.y"
{ yyval.nodo = nodo1(decimales, yyvsp[0].nodo ) ; ;
    break;}
case 9:
//#linea 76 "grammar.y"
{ yyval.nodo = nodo1(imprimir_varios,  yyvsp[0].nodo); /*imprimir lista expr*/;
    break;}
case 10:
//#linea 77 "grammar.y"
{ yyval.nodo = nodo1(leertexto,  yyvsp[0].nodo) ; /*leer variable alfa*/;
    break;}
case 11:
//#linea 78 "grammar.y"
{ yyval.nodo = nodo1(leer,  yyvsp[0].nodo) ; /*leer variable numerica*/;
    break;}
case 12:
//#linea 79 "grammar.y"
{ ;   /*borrar*/;
    break;}
case 13:
//#linea 80 "grammar.y"
{ yyval.nodo = nodo3(si, yyvsp[-5].nodo, yyvsp[-3].nodo, yyvsp[-1].nodo); /*if con else */;
    break;}
case 14:
//#linea 81 "grammar.y"
{ yyval.nodo = nodo2(si, yyvsp[-3].nodo, yyvsp[-1].nodo); /*if sin else*/;
    break;}
case 15:
//#linea 82 "grammar.y"
{ yyval.nodo = nodo2(mientras, yyvsp[-3].nodo, yyvsp[-1].nodo); /*while*/;
    break;}
case 16:
//#linea 83 "grammar.y"
{yyval.nodo = nodo4(desde, yyvsp[-7].nodo, yyvsp[-5].nodo, yyvsp[-3].nodo, yyvsp[-1].nodo); /*for*/;
    break;}
case 17:
//#linea 88 "grammar.y"
{ yyval.nodo=yyvsp[0].nodo ; /*lista expr*/ ;
    break;}
case 18:
//#linea 89 "grammar.y"
{ yyval.nodo=nodo2 (secuencia, yyvsp[-2].nodo, yyvsp[0].nodo)  ; /*varias lista expr, separadas por coma*/ ;
    break;}
case 19:
//#linea 93 "grammar.y"
{ yyval.nodo=nodo1(imprimir_expresion, yyvsp[0].nodo); /*lista expresion2*/;
    break;}
case 20:
//#linea 94 "grammar.y"
{ yyval.nodo=nodo1(imprimir_literal, yyvsp[0].nodo ); /* un literal*/;
    break;}
case 21:
//#linea 95 "grammar.y"
{ yyval.nodo=nodo1(imprimir_var_alfa, yyvsp[0].nodo); /* una variable literal*/;
    break;}
case 22:
//#linea 99 "grammar.y"
{ yyval.nodo = nodo2(secuencia, yyvsp[-1].nodo, yyvsp[0].nodo); /*una seq de comandos*/;
    break;}
case 23:
//#linea 100 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /*un comando*/;
    break;}
case 24:
//#linea 105 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /* expresion2*/;
    break;}
case 25:
//#linea 106 "grammar.y"
{ yyval.nodo = nodo2(igualque,      yyvsp[-2].nodo, yyvsp[0].nodo); /*igualdad*/;
    break;}
case 26:
//#linea 107 "grammar.y"
{ yyval.nodo = nodo2(noigualque,    yyvsp[-2].nodo, yyvsp[0].nodo); /*no igual*/;
    break;}
case 27:
//#linea 108 "grammar.y"
{ yyval.nodo = nodo2(menorque,      yyvsp[-2].nodo, yyvsp[0].nodo); /*menor que*/;
    break;}
case 28:
//#linea 109 "grammar.y"
{ yyval.nodo = nodo2(menorigualque, yyvsp[-2].nodo, yyvsp[0].nodo); /*menor o igual que*/;
    break;}
case 29:
//#linea 110 "grammar.y"
{ yyval.nodo = nodo2(mayorque,      yyvsp[-2].nodo, yyvsp[0].nodo); /*mayor que*/;
    break;}
case 30:
//#linea 111 "grammar.y"
{ yyval.nodo = nodo2(mayorigualque, yyvsp[-2].nodo, yyvsp[0].nodo); /*mayor o igual que*/;
    break;}
case 31:
//#linea 112 "grammar.y"
{ yyval.nodo = nodo2(comparaliteral, yyvsp[-2].nodo, yyvsp[0].nodo) ; /*asigna literal*/;
    break;}
case 32:
//#linea 117 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /* expr2*/;
    break;}
case 33:
//#linea 118 "grammar.y"
{ yyval.nodo = nodo2(suma, yyvsp[-2].nodo, yyvsp[0].nodo); /*suma*/;
    break;}
case 34:
//#linea 119 "grammar.y"
{ yyval.nodo = nodo2(resta, yyvsp[-2].nodo, yyvsp[0].nodo); /*resta*/;
    break;}
case 35:
//#linea 123 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; ;
    break;}
case 36:
//#linea 124 "grammar.y"
{ yyval.nodo = nodo2(multiplica, yyvsp[-2].nodo, yyvsp[0].nodo); /*multiplicar*/;
    break;}
case 37:
//#linea 125 "grammar.y"
{ yyval.nodo = nodo2 (divide, yyvsp[-2].nodo, yyvsp[0].nodo); /*dividir*/;
    break;}
case 38:
//#linea 129 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /*positivo*/;
    break;}
case 39:
//#linea 130 "grammar.y"
{ yyval.nodo = nodo1(negativo, yyvsp[0].nodo); /*negativo*/;
    break;}
case 40:
//#linea 131 "grammar.y"
{ yyval.nodo = yyvsp[-1].nodo; /*expr enter parentesis*/;
    break;}
case 41:
//#linea 132 "grammar.y"
{ yyval.nodo =  yyvsp[0].nodo; /*numero*/;
    break;}
case 42:
//#linea 133 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /*designador variable*/;
    break;}
case 43:
//#linea 137 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo; /*designador string*/;
    break;}
case 44:
//#linea 140 "grammar.y"
{ yyval.nodo = yyvsp[0].nodo;  /* nombre designador */ ;
    break;}
case 45:
//#linea 143 "grammar.y"
{ yyval.nodo =  yyvsp[0].nodo ;  /*designador proced.*/ ;
    break;}
case 46:
//#linea 147 "grammar.y"
{ 
			yyval.nodo = nodo2(procedimiento, yyvsp[-2].nodo, yyvsp[-1].nodo) ;/*un procedimiento*/
                        procedimientos[(int) yyvsp[-2].nodo->num] = yyvsp[-1].nodo   ;   /* revisar este metodo */
			idx_prc++;
			
			;
    break;}
}
   /* the action file gets copied in in place of this dollarsign */
//#linea 487 "bison.simple"

  yyvsp -= yylen;
  yyssp -= yylen;
#ifdef YYLSP_NEEDED
  yylsp -= yylen;
#endif

#if YYDEBUG != 0
  if (yydebug)
    {
      short *ssp1 = yyss - 1;
      fprintf (stderr, "state stack now");
      while (ssp1 != yyssp)
	fprintf (stderr, " %d", *++ssp1);
      fprintf (stderr, "\n");
    }
#endif

  *++yyvsp = yyval;

#ifdef YYLSP_NEEDED
  yylsp++;
  if (yylen == 0)
    {
      yylsp->first_line = yylloc.first_line;
      yylsp->first_column = yylloc.first_column;
      yylsp->last_line = (yylsp-1)->last_line;
      yylsp->last_column = (yylsp-1)->last_column;
      yylsp->text = 0;
    }
  else
    {
      yylsp->last_line = (yylsp+yylen-1)->last_line;
      yylsp->last_column = (yylsp+yylen-1)->last_column;
    }
#endif

  /* Now "shift" the result of the reduction.
     Determine what state that goes to,
     based on the state we popped back to
     and the rule number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTBASE] + *yyssp;
  if (yystate >= 0 && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTBASE];

  goto yynewstate;

yyerrlab:   /* here on detecting error */

  if (! yyerrstatus)
    /* If not already recovering from an error, report this error.  */
    {
      ++yynerrs;

#ifdef YYERROR_VERBOSE
      yyn = yypact[yystate];

      if (yyn > YYFLAG && yyn < YYLAST)
	{
	  int size = 0;
	  char *msg;
	  int x, count;

	  count = 0;
	  /* Start X at -yyn if nec to avoid negative indexes in yycheck.  */
	  for (x = (yyn < 0 ? -yyn : 0);
	       x < (sizeof(yytname) / sizeof(char *)); x++)
	    if (yycheck[x + yyn] == x)
	      size += strlen(yytname[x]) + 15, count++;
	  msg = (char *) malloc(size + 15);
	  if (msg != 0)
	    {
	      strcpy(msg, "parse error");

	      if (count < 5)
		{
		  count = 0;
		  for (x = (yyn < 0 ? -yyn : 0);
		       x < (sizeof(yytname) / sizeof(char *)); x++)
		    if (yycheck[x + yyn] == x)
		      {
			strcat(msg, count == 0 ? ", expecting `" : " or `");
			strcat(msg, yytname[x]);
			strcat(msg, "'");
			count++;
		      }
		}
	      yyerror(msg);
	      free(msg);
	    }
	  else
	    yyerror ("parse error; also virtual memory exceeded");
	}
      else
#endif /* YYERROR_VERBOSE */
	fprintf(stderr, "parse error");
    }

  goto yyerrlab1;
yyerrlab1:   /* here on error raised explicitly by an action */

  if (yyerrstatus == 3)
    {
      /* if just tried and failed to reuse lookahead token after an error, discard it.  */

      /* return failure if at end of input */
      if (yychar == YYEOF)
	YYABORT;

#if YYDEBUG != 0
      if (yydebug)
	fprintf(stderr, "Discarding token %d (%s).\n", yychar, yytname[yychar1]);
#endif

      yychar = YYEMPTY;
    }

  /* Else will try to reuse lookahead token
     after shifting the error token.  */

  yyerrstatus = 3;		/* Each real token shifted decrements this */

  goto yyerrhandle;

yyerrdefault:  /* current state does not do anything special for the error token. */

#if 0
  /* This is wrong; only states that explicitly want error tokens
     should shift them.  */
  yyn = yydefact[yystate];  /* If its default is to accept any token, ok.  Otherwise pop it.*/
  if (yyn) goto yydefault;
#endif

yyerrpop:   /* pop the current state because it cannot handle the error token */

  if (yyssp == yyss) YYABORT;
  yyvsp--;
  yystate = *--yyssp;
#ifdef YYLSP_NEEDED
  yylsp--;
#endif

#if YYDEBUG != 0
  if (yydebug)
    {
      short *ssp1 = yyss - 1;
      fprintf (stderr, "Error: state stack now");
      while (ssp1 != yyssp)
	fprintf (stderr, " %d", *++ssp1);
      fprintf (stderr, "\n");
    }
#endif

yyerrhandle:

  yyn = yypact[yystate];
  if (yyn == YYFLAG)
    goto yyerrdefault;

  yyn += YYTERROR;
  if (yyn < 0 || yyn > YYLAST || yycheck[yyn] != YYTERROR)
    goto yyerrdefault;

  yyn = yytable[yyn];
  if (yyn < 0)
    {
      if (yyn == YYFLAG)
	goto yyerrpop;
      yyn = -yyn;
      goto yyreduce;
    }
  else if (yyn == 0)
    goto yyerrpop;

  if (yyn == YYFINAL)
    YYACCEPT;

#if YYDEBUG != 0
  if (yydebug)
    fprintf(stderr, "Shifting error token, ");
#endif

  *++yyvsp = yylval;
#ifdef YYLSP_NEEDED
  *++yylsp = yylloc;
#endif

  yystate = yyn;
  goto yynewstate;
}
//#linea 153 "grammar.y"


}