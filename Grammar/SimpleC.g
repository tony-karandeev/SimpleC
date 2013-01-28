grammar SimpleC;

options {
  language=CSharp2;
  output=AST;
}

tokens {
    NUMBER              ;
    IDENT               ;

    PROGRAM             ;
    
    VAR_DECL            ;
    VAR_DEF             ;
    VAR_CALL            ;
    FUNC_DECL           ;
    FUNC_DEF            ;
    FUNC_CALL           ;

    VAR_SPEC            ;
	TYPE_SPEC           ;

    PARAM_SPEC_LIST     ;
    PARAM_LIST          ;
    FUNC_BODY           ;

	STATEMENT           ;
    EXPRESSION          ;

	TYPECAST            ;
	SIZEOF_EXPR         ;
	SIZEOF_TYPE         ;

	REF			        ;
	DEREF		        ;
	STRUCT_MEMBER       ;
	STRUCT_DEREF        ;
	SUBSCRIPT           ;

    U_PLUS              ;
    U_MINUS             ;

    ADD           = '+' ;
    SUB           = '-' ;
    MUL           = '*' ;
    DIV           = '/' ;
	MOD           = '%' ;

    INC_PRE             ;
    INC_POST            ;
    DEC_PRE             ;
    DEC_POST            ;

    ASSIGN        = '=' ;


    EQUAL         = '==';
    NOT_EQUAL     = '!=';
    LESS          = '<' ;
    LESS_OR_EQUAL = '<=';
    GREATER       = '>' ;
    GREATER_OR_EQUAL = '>=';

    BOOL_NOT            ;
    BOOL_AND      = '&&';
    BOOL_OR       = '||';

    BIT_NOT             ;
    BIT_AND       = '&' ;
    BIT_OR        = '|' ;
    BIT_XOR       = '^' ;

	SHIFT_LEFT    = '<<';
	SHIFT_RIGHT   = '>>';
}

@lexer::namespace { SimpleC }
@parser::namespace { SimpleC }

@parser::header { 
	using System.Collections.Generic; 
	using System.Diagnostics;
}

@parser::members
{
        bool IsRightToLeft( int type )
        {
                switch ( type )
                {
				case INC_POST:
				case DEC_POST:
					return false;
				case DEREF:
				case U_PLUS:
				case U_MINUS:
				case BIT_NOT:
				case INC_PRE:
				case DEC_PRE:
				case BOOL_NOT:
				case TYPECAST:
				case SIZEOF_EXPR:
				case SIZEOF_TYPE:
					return true;
				case MUL:
				case DIV:
				case MOD:
				case ADD:
				case SUB:
				case SHIFT_LEFT:
				case SHIFT_RIGHT:
				case LESS:
				case GREATER:
				case LESS_OR_EQUAL:
				case GREATER_OR_EQUAL:
				case EQUAL:
				case NOT_EQUAL:
				case BIT_AND:
				case BIT_XOR:
				case BIT_OR:
				case BOOL_AND:
				case BOOL_OR:
					return false;
				case ASSIGN:
					return true;
                default:
					throw new Exception(String.Format("Unexpected operator: {0}", SimpleCParser.tokenNames[type]));
                }

        }
        int OperatorPrecedence(int type)
        {
                switch (type)
                {
				case INC_POST:
				case DEC_POST:
					return 1;
				case DEREF:
				case U_PLUS:
				case U_MINUS:
				case BIT_NOT:
				case INC_PRE:
				case DEC_PRE:
				case BOOL_NOT:
				case TYPECAST:
				case SIZEOF_EXPR:
				case SIZEOF_TYPE:
					return 2;
				case MUL:
				case DIV:
				case MOD:
					return 3;
				case ADD:
				case SUB:
					return 4;
				case SHIFT_LEFT:
				case SHIFT_RIGHT:
					return 5;
				case LESS:
				case GREATER:
				case LESS_OR_EQUAL:
				case GREATER_OR_EQUAL:
					return 6;
				case EQUAL:
				case NOT_EQUAL:
					return 7;
				case BIT_AND:
					return 8;
				case BIT_XOR:
					return 9;
				case BIT_OR:
					return 10;
				case BOOL_AND:
					return 11;
				case BOOL_OR:
					return 12;
				case ASSIGN:
					return 13;
                default:
					throw new Exception(String.Format("Unexpected operator {0}: {1}", type, SimpleCParser.tokenNames[type]));
                }
        }
        int FindPivot(List<IToken> operators, int startIndex, int stopIndex)
		{
            int pivotIndex = startIndex;
            int pivotPriority = OperatorPrecedence(operators[pivotIndex].Type);
            for (int operatorIndex = startIndex; operatorIndex < stopIndex; ++operatorIndex)
            {
                    int type = operators[operatorIndex].Type;
                    int currentOperatorPriority = OperatorPrecedence(type);
                    bool rightToLeft = IsRightToLeft(type);
                    if (currentOperatorPriority > pivotPriority || (currentOperatorPriority == pivotPriority && rightToLeft))
                    {
                            pivotIndex = operatorIndex;
                            pivotPriority = currentOperatorPriority;
                    }
            }
            return pivotIndex;
        }
        ITree CreatePrecedenceTree(List<ITree> expressions, List<IToken> operators, int startIndex, int stopIndex)
        {
                if (stopIndex == startIndex)
                        return expressions[startIndex];

                int pivotIndex = FindPivot(operators, startIndex, stopIndex);
                ITree root = (ITree)adaptor.GetNilNode();
                object root_1 = (object)adaptor.GetNilNode();
                root_1 = (object)adaptor.BecomeRoot(operators[pivotIndex], root_1);
                adaptor.AddChild(root_1, CreatePrecedenceTree(expressions, operators, startIndex, pivotIndex));
                adaptor.AddChild(root_1, CreatePrecedenceTree(expressions, operators, pivotIndex + 1, stopIndex));
                adaptor.AddChild(root, root_1);
                return root;
        }
        ITree CreatePrecedenceTree(List<ITree> expressions, List<IToken> operators)
        {
			Console.WriteLine(String.Format("EXPRESSIONS COUNT: {0}", expressions.Count));
			string exprs = expressions[0] == null ? "<nullexpr>" : expressions[0].ToStringTree();
			for (int i = 1; i < expressions.Count; ++i)
			{
				exprs += " ## " + (expressions[i] == null ? "<nullexpr>" : expressions[i].ToStringTree());
			}
			Console.WriteLine("EXPRESSIONS: " + exprs);
            return CreatePrecedenceTree(expressions, operators, 0, operators.Count);
        }

        ITree CreatePrimaryPrecedenceTree(List<ITree> expressions, List<IToken> operators, int startIndex, int stopIndex)
		{
			if (stopIndex == startIndex)
				return expressions[stopIndex];

			ITree root = (ITree)adaptor.GetNilNode();
			object root_1 = (object)adaptor.GetNilNode();

			root_1 = (object)adaptor.BecomeRoot(operators[stopIndex-1], root_1);
			adaptor.AddChild(root_1, CreatePrimaryPrecedenceTree(expressions, operators, startIndex, stopIndex-1));
			adaptor.AddChild(root_1, expressions[stopIndex]); // Does nothing if expressions[stopIndex] is null
			adaptor.AddChild(root, root_1);
			return root;
		}

		ITree CreatePrimaryPrecedenceTree(List<ITree> expressions, List<IToken> operators)
		{
			Debug.Assert(expressions.Count == operators.Count + 1, "Not enough expressions for building primary precedence tree");
			return CreatePrimaryPrecedenceTree(expressions, operators, 0, operators.Count);
		}
}

Whitespace:
	( ' ' | '\t' | '\f' | '\r' | '\n' )+ {
		$channel=HIDDEN;
	}
;

Number: 
	('0'..'9')+ ('.' ('0'..'9')+)?
;

SizeOf: 'sizeof';

Identifier:  
	( 'a'..'z' | 'A'..'Z' | '_' )
	( 'a'..'z' | 'A'..'Z' | '_' | '0'..'9' )*
;
//ADD:    '+'     ;
//SUB:    '-'     ;
//MUL:    '*'     ;
//DIV:    '/'     ;
//ASSIGN: '='     ;

identifier:
	Identifier -> { adaptor.BecomeRoot(new CommonToken(IDENT, $Identifier.Text), adaptor.GetNilNode()) }
;

varDef:
	varSpec ';'
		-> ^(VAR_DEF varSpec)
		 	// { VarSpec vs = ((VarSpecAstNode)$varSpec.tree).VarSpec; }
//		->  VAR_DEF<VarDefAstNode>[((VarSpecAstNode)$varSpec.tree).VarSpec]
;

funcDecl: 
	typeSpec identifier '(' paramSpecList ')'';' -> ^(FUNC_DECL typeSpec identifier paramSpecList)
;

funcDef:
	typeSpec identifier '(' paramSpecList ')''{' funcBody '}' 
		-> ^(FUNC_DEF typeSpec identifier paramSpecList funcBody)
;

funcBody:
	statements -> ^(FUNC_BODY statements?)
;

statements:
	statement*
;

paramSpecList:
	(varSpec (',' varSpec)*)? -> ^(PARAM_SPEC_LIST varSpec*)
;

varSpec:
    typeSpec identifier
		-> ^(VAR_SPEC typeSpec identifier)
//		-> VAR_SPEC<VarSpecAstNode>[new TypeSpec($typeSpec.text), $identifier.Text]
;

paramList:
	(expr (',' expr)*)? -> ^(PARAM_LIST expr*)
;

statement:
	varDef
	| expr? ';' -> ^(STATEMENT expr?)
	| '{' statements '}' -> ^(STATEMENT statements?)
;

expr:
	binaryExpr
;

binaryExpr
@init {
	List<ITree> expressions = new List<ITree>();
	List<IToken> operators = new List<IToken>();
}	:
	left=unaryExpr { expressions.Add((ITree)left.Tree); }
	(op=binaryOperator right=unaryExpr {
		operators.Add(((CommonTree)op.Tree).Token);
		expressions.Add((ITree)right.Tree);
		Console.WriteLine(right.Tree == null ? "<nullexpr>" : ((ITree)right.Tree).ToString());
	})*
	-> { CreatePrecedenceTree(expressions, operators) }
;

unaryExpr options {
	backtrack=true;
}	:
	'*' unaryExpr -> ^(DEREF unaryExpr)
	| '&' unaryExpr -> ^(REF unaryExpr)
	| '+' unaryExpr -> ^(U_PLUS unaryExpr)
	| '-' unaryExpr -> ^(U_MINUS unaryExpr)
	| '!' unaryExpr -> ^(BOOL_NOT unaryExpr)
	| '~' unaryExpr -> ^(BIT_NOT unaryExpr)
	| '++' unaryExpr -> ^(INC_PRE unaryExpr)
	| '--' unaryExpr -> ^(DEC_PRE unaryExpr)
	| '(' typeSpec ')' unaryExpr -> ^(TYPECAST unaryExpr typeSpec)
	| SizeOf unaryExpr -> ^(SIZEOF_EXPR unaryExpr)
	| SizeOf '(' typeSpec ')' -> ^(SIZEOF_TYPE typeSpec)
	| primaryExpr

;

primaryExpr
@init {
	List<ITree> expressions = new List<ITree>();
	List<IToken> operators = new List<IToken>();
}	:
	basic=basicExpr { 
		expressions.Add((ITree)basic.Tree);
	}
	(
			'[' idx=expr ']' { 
				operators.Add(new CommonToken(SUBSCRIPT, tokenNames[SUBSCRIPT]));
				expressions.Add((ITree)idx.Tree);
			} 
		|	'.' member=identifier {
				operators.Add(new CommonToken(STRUCT_MEMBER, tokenNames[STRUCT_MEMBER]));
				expressions.Add((ITree)member.Tree);
			}
		|	'->' member=identifier {
				operators.Add(new CommonToken(STRUCT_DEREF, tokenNames[STRUCT_DEREF]));
				expressions.Add((ITree)member.Tree);
			}
		|	'++' { 
				operators.Add(new CommonToken(INC_POST, tokenNames[INC_POST]));
				expressions.Add(null);
			}
		|	'--' {
				operators.Add(new CommonToken(DEC_POST, tokenNames[DEC_POST]));
				expressions.Add(null);
			}
	)* -> { CreatePrimaryPrecedenceTree(expressions, operators) }
;

/*
primaryExpr:
	basicExpr ('[' idx=expr ']' //-> ^(SUBSCRIPT basicExpr $idx) 
		| '.' member=identifier //-> ^(STRUCT_MEMBER basicExpr $member)
		| '->' member=identifier //-> ^(STRUCT_DEREF basicExpr $member) 
		| '++' //-> ^(INC_POST basicExpr) 
		| '--' //-> ^(DEC_POST basicExpr)
	)*
;
*/

basicExpr:
	'('! expr ')'!
	| identifier //-> IDENT<IdentAstNode>[$identifier.Text]
	| Number //-> NUMBER<NumAstNode>[$Number.Text]
	| identifier '(' paramList ')' -> ^(FUNC_CALL identifier paramList)
;


binaryOperator:
	ADD
	| SUB
	| MUL
	| DIV
	| MOD
	| SHIFT_LEFT
	| SHIFT_RIGHT
	| ASSIGN
	| GREATER
	| GREATER_OR_EQUAL
	| LESS
	| LESS_OR_EQUAL
	| EQUAL
	| NOT_EQUAL
	| BOOL_AND
	| BOOL_OR
	| BIT_AND
	| BIT_OR
	| BIT_XOR
//	'*'    -> ^(MUL)
//	| '/'  -> ^(DIV)
//	| '%'  -> ^(MOD)
//	| '+'  -> ^(ADD)
//	| '-'  -> ^(SUB)
//	| '>>' -> ^(SHIFT_RIGHT)
//	| '<<' -> ^(SHIFT_LEFT)
//	| '>'  -> ^(GREATER)
//	| '<'  -> ^(LESS)
//	| '>=' -> ^(GREATER_OR_EQUAL)
//	| '<=' -> ^(LESS_OR_EQUAL)
//	| '==' -> ^(EQUAL)
//	| '!=' -> ^(NOT_EQUAL)
//	| '&'  -> ^(BIT_AND)
//	| '^'  -> ^(BIT_XOR)
//	| '|'  -> ^(BIT_OR)
//	| '&&' -> ^(BOOL_AND)
//	| '||' -> ^(BOOL_OR)
//	| '='  -> ^(ASSIGN)
;

typeSpec:
	identifier
;

funcCall:
	identifier '(' paramList ')' -> ^(FUNC_CALL identifier paramList)
;

programStatement:
	varDef | funcDecl | funcDef
;

program: 
	programStatement* EOF
	-> ^(PROGRAM programStatement*)
;

