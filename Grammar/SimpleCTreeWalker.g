tree grammar SimpleCTreeWalker;

options {
	tokenVocab=SimpleC;
	ASTLabelType=CommonTree;
}

@namespace {
	SimpleC
}

@header {
	using SimpleC.Tree;
}

walk returns [RootNode node]:
	^(PROGRAM (programStatement { node.Children.Add($programStatement.node); })*)
;

programStatement returns [ISCNode node]:
	varDef { node = $varDef.node; }
	| funcDecl
	| funcDef
;

varDef returns [VarDefNode node]:
	^(VAR_DEF varSpec) { node.VarSpec = $varSpec.node; }
;

funcDecl:
	^(FUNC_DECL typeSpec IDENT paramSpecList)
;

funcDef:
	^(FUNC_DEF typeSpec IDENT paramSpecList funcBody)
;

paramSpecList:
	^(PARAM_SPEC_LIST varSpec*)
;

varSpec returns [VarSpecNode node]:
	^(VAR_SPEC typeSpec IDENT) { 
		node.TypeSpec = $typeSpec.node; 
		node.Name = $IDENT.Text;
	}
;

typeSpec returns [TypeSpecNode node]:
	^(TYPE_SPEC IDENT) { 
		node.PrimaryTypeName = $IDENT.Text; 
	}
;

funcBody:
	^(FUNC_BODY statement*)
;

statement:
	varDef
	| ^(STATEMENT expression?)
	| ^(STATEMENT statement*)
;	

expression:
	// Binary expressions
	^(ADD expression expression)
	| ^(ADD expression expression)
	| ^(MUL expression expression)
	| ^(DIV expression expression)
	| ^(MOD expression expression)
	| ^(SHIFT_LEFT expression expression)
	| ^(SHIFT_RIGHT expression expression)
	| ^(ASSIGN expression expression)
	| ^(GREATER expression expression)
	| ^(GREATER_OR_EQUAL expression expression)
	| ^(LESS expression expression)
	| ^(LESS_OR_EQUAL expression expression)
	| ^(EQUAL expression expression)
	| ^(NOT_EQUAL expression expression)
	| ^(BOOL_AND expression expression)
	| ^(BOOL_OR expression expression)
	| ^(BIT_AND expression expression)
	| ^(BIT_OR expression expression)
	| ^(BIT_XOR expression expression)

	// Unary expressions
	| ^(DEREF expression)
	| ^(REF expression)
	| ^(U_PLUS expression)
	| ^(U_MINUS expression)
	| ^(BOOL_NOT expression)
	| ^(BIT_NOT expression)
	| ^(BIT_NOT expression)
	| ^(INC_PRE expression)
	| ^(DEC_PRE expression)
	| ^(TYPECAST expression IDENT)
	| ^(SIZEOF_EXPR expression)
	| ^(SIZEOF_TYPE typeSpec)

	// Primary expressions
	| ^(SUBSCRIPT expression expression)
	| ^(STRUCT_MEMBER expression IDENT)
	| ^(STRUCT_DEREF expression IDENT)
	| ^(INC_POST expression)
	| ^(DEC_POST expression)

	// Basic expressions
	| IDENT
	// Commenting the NUMBER intentionally
	// | NUMBER
	| ^(FUNC_CALL IDENT paramList)
;

paramList:
	^(PARAM_LIST expression*)
;