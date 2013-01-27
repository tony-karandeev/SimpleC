// $ANTLR 3.2 Sep 23, 2009 12:02:23 antlr_temp_dir\\MathExpr.g 2012-09-25 14:02:38

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


  using System.Collections.Generic;
  using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

namespace  MathExpr 
{
public partial class MathExprParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"UNKNOWN", 
		"VAR", 
		"PRINT", 
		"BLOCK", 
		"PROGRAM", 
		"WS", 
		"NUMBER", 
		"IDENT", 
		"ADD", 
		"SUB", 
		"MUL", 
		"DIV", 
		"ASSIGN", 
		"'('", 
		"')'"
    };

    public const int WS = 9;
    public const int T__18 = 18;
    public const int T__17 = 17;
    public const int UNKNOWN = 4;
    public const int BLOCK = 7;
    public const int ASSIGN = 16;
    public const int NUMBER = 10;
    public const int IDENT = 11;
    public const int SUB = 13;
    public const int PROGRAM = 8;
    public const int VAR = 5;
    public const int DIV = 15;
    public const int EOF = -1;
    public const int MUL = 14;
    public const int PRINT = 6;
    public const int ADD = 12;

    // delegates
    // delegators



        public MathExprParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public MathExprParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return MathExprParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "antlr_temp_dir\\MathExpr.g"; }
    }


      // "культуронезависимый" формат для чисел (с разделителем точкой)
      public static readonly NumberFormatInfo NFI = new NumberFormatInfo();
      
      // значения идентификаторов
      private Dictionary<string, IdentDescr> identTable = new Dictionary<string, IdentDescr>();


    public class ident_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ident"
    // antlr_temp_dir\\MathExpr.g:54:1: ident : id= IDENT -> VAR[varDescr] ;
    public MathExprParser.ident_return ident() // throws RecognitionException [1]
    {   
        MathExprParser.ident_return retval = new MathExprParser.ident_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken id = null;

        object id_tree=null;
        RewriteRuleTokenStream stream_IDENT = new RewriteRuleTokenStream(adaptor,"token IDENT");

        try 
    	{
            // antlr_temp_dir\\MathExpr.g:54:6: (id= IDENT -> VAR[varDescr] )
            // antlr_temp_dir\\MathExpr.g:55:3: id= IDENT
            {
            	id=(IToken)Match(input,IDENT,FOLLOW_IDENT_in_ident345);  
            	stream_IDENT.Add(id);


            	    string identifier=((id != null) ? id.Text : null);
            	    
            	    // работа с таблицей идентификаторов
            	    VarDescr varDescr = null;
            	    if (identTable.ContainsKey(identifier)) {
            	      IdentDescr identDescr = identTable[identifier];
            	      if (identDescr is VarDescr)
            	        varDescr = (VarDescr)identDescr;
            	      else
            	        throw new ParserBaseException(string.Format("Идентификатор {0} не является переменной (pos={1},{2})", identifier, id.Line, id.CharPositionInLine));
            	    }
            	    else {
            	      varDescr = new VarDescr(identifier);
            	      identTable[identifier] = varDescr;
            	    }
            	  


            	// AST REWRITE
            	// elements:          
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 71:5: -> VAR[varDescr]
            	{
            	    adaptor.AddChild(root_0, new VarAstNode(VAR, varDescr));

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "ident"

    public class group_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "group"
    // antlr_temp_dir\\MathExpr.g:75:1: group : ( '(' term ')' | NUMBER -> NUMBER[double.Parse($NUMBER.text, NFI)] | ident );
    public MathExprParser.group_return group() // throws RecognitionException [1]
    {   
        MathExprParser.group_return retval = new MathExprParser.group_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken char_literal1 = null;
        IToken char_literal3 = null;
        IToken NUMBER4 = null;
        MathExprParser.term_return term2 = default(MathExprParser.term_return);

        MathExprParser.ident_return ident5 = default(MathExprParser.ident_return);


        object char_literal1_tree=null;
        object char_literal3_tree=null;
        object NUMBER4_tree=null;
        RewriteRuleTokenStream stream_NUMBER = new RewriteRuleTokenStream(adaptor,"token NUMBER");

        try 
    	{
            // antlr_temp_dir\\MathExpr.g:75:6: ( '(' term ')' | NUMBER -> NUMBER[double.Parse($NUMBER.text, NFI)] | ident )
            int alt1 = 3;
            switch ( input.LA(1) ) 
            {
            case 17:
            	{
                alt1 = 1;
                }
                break;
            case NUMBER:
            	{
                alt1 = 2;
                }
                break;
            case IDENT:
            	{
                alt1 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d1s0 =
            	        new NoViableAltException("", 1, 0, input);

            	    throw nvae_d1s0;
            }

            switch (alt1) 
            {
                case 1 :
                    // antlr_temp_dir\\MathExpr.g:76:3: '(' term ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal1=(IToken)Match(input,17,FOLLOW_17_in_group366); 
                    	PushFollow(FOLLOW_term_in_group369);
                    	term2 = term();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, term2.Tree);
                    	char_literal3=(IToken)Match(input,18,FOLLOW_18_in_group371); 

                    }
                    break;
                case 2 :
                    // antlr_temp_dir\\MathExpr.g:77:3: NUMBER
                    {
                    	NUMBER4=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_group376);  
                    	stream_NUMBER.Add(NUMBER4);



                    	// AST REWRITE
                    	// elements:          NUMBER
                    	// token labels:      
                    	// rule labels:       retval
                    	// token list labels: 
                    	// rule list labels:  
                    	// wildcard labels: 
                    	retval.Tree = root_0;
                    	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

                    	root_0 = (object)adaptor.GetNilNode();
                    	// 77:10: -> NUMBER[double.Parse($NUMBER.text, NFI)]
                    	{
                    	    adaptor.AddChild(root_0, new NumAstNode(NUMBER, double.Parse(((NUMBER4 != null) ? NUMBER4.Text : null), NFI)));

                    	}

                    	retval.Tree = root_0;retval.Tree = root_0;
                    }
                    break;
                case 3 :
                    // antlr_temp_dir\\MathExpr.g:78:3: ident
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_ident_in_group388);
                    	ident5 = ident();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, ident5.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "group"

    public class mult_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "mult"
    // antlr_temp_dir\\MathExpr.g:82:1: mult : group ( ( MUL | DIV ) group )* ;
    public MathExprParser.mult_return mult() // throws RecognitionException [1]
    {   
        MathExprParser.mult_return retval = new MathExprParser.mult_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set7 = null;
        MathExprParser.group_return group6 = default(MathExprParser.group_return);

        MathExprParser.group_return group8 = default(MathExprParser.group_return);


        object set7_tree=null;

        try 
    	{
            // antlr_temp_dir\\MathExpr.g:82:5: ( group ( ( MUL | DIV ) group )* )
            // antlr_temp_dir\\MathExpr.g:82:7: group ( ( MUL | DIV ) group )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_group_in_mult397);
            	group6 = group();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, group6.Tree);
            	// antlr_temp_dir\\MathExpr.g:82:13: ( ( MUL | DIV ) group )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= MUL && LA2_0 <= DIV)) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:82:15: ( MUL | DIV ) group
            			    {
            			    	set7=(IToken)input.LT(1);
            			    	set7 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= MUL && input.LA(1) <= DIV) ) 
            			    	{
            			    	    input.Consume();
            			    	    root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set7), root_0);
            			    	    state.errorRecovery = false;
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_group_in_mult412);
            			    	group8 = group();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, group8.Tree);

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "mult"

    public class add_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "add"
    // antlr_temp_dir\\MathExpr.g:83:1: add : mult ( ( ADD | SUB ) mult )* ;
    public MathExprParser.add_return add() // throws RecognitionException [1]
    {   
        MathExprParser.add_return retval = new MathExprParser.add_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set10 = null;
        MathExprParser.mult_return mult9 = default(MathExprParser.mult_return);

        MathExprParser.mult_return mult11 = default(MathExprParser.mult_return);


        object set10_tree=null;

        try 
    	{
            // antlr_temp_dir\\MathExpr.g:83:4: ( mult ( ( ADD | SUB ) mult )* )
            // antlr_temp_dir\\MathExpr.g:83:7: mult ( ( ADD | SUB ) mult )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_mult_in_add424);
            	mult9 = mult();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, mult9.Tree);
            	// antlr_temp_dir\\MathExpr.g:83:13: ( ( ADD | SUB ) mult )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= ADD && LA3_0 <= SUB)) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:83:15: ( ADD | SUB ) mult
            			    {
            			    	set10=(IToken)input.LT(1);
            			    	set10 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= ADD && input.LA(1) <= SUB) ) 
            			    	{
            			    	    input.Consume();
            			    	    root_0 = (object)adaptor.BecomeRoot((object)adaptor.Create(set10), root_0);
            			    	    state.errorRecovery = false;
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_mult_in_add440);
            			    	mult11 = mult();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, mult11.Tree);

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "add"

    public class term_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "term"
    // antlr_temp_dir\\MathExpr.g:84:1: term : add ;
    public MathExprParser.term_return term() // throws RecognitionException [1]
    {   
        MathExprParser.term_return retval = new MathExprParser.term_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        MathExprParser.add_return add12 = default(MathExprParser.add_return);



        try 
    	{
            // antlr_temp_dir\\MathExpr.g:84:5: ( add )
            // antlr_temp_dir\\MathExpr.g:84:7: add
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_add_in_term452);
            	add12 = add();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, add12.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "term"

    public class expr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr"
    // antlr_temp_dir\\MathExpr.g:86:1: expr : ( PRINT term | ident ASSIGN term );
    public MathExprParser.expr_return expr() // throws RecognitionException [1]
    {   
        MathExprParser.expr_return retval = new MathExprParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken PRINT13 = null;
        IToken ASSIGN16 = null;
        MathExprParser.term_return term14 = default(MathExprParser.term_return);

        MathExprParser.ident_return ident15 = default(MathExprParser.ident_return);

        MathExprParser.term_return term17 = default(MathExprParser.term_return);


        object PRINT13_tree=null;
        object ASSIGN16_tree=null;

        try 
    	{
            // antlr_temp_dir\\MathExpr.g:86:5: ( PRINT term | ident ASSIGN term )
            int alt4 = 2;
            int LA4_0 = input.LA(1);

            if ( (LA4_0 == PRINT) )
            {
                alt4 = 1;
            }
            else if ( (LA4_0 == IDENT) )
            {
                alt4 = 2;
            }
            else 
            {
                NoViableAltException nvae_d4s0 =
                    new NoViableAltException("", 4, 0, input);

                throw nvae_d4s0;
            }
            switch (alt4) 
            {
                case 1 :
                    // antlr_temp_dir\\MathExpr.g:87:3: PRINT term
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PRINT13=(IToken)Match(input,PRINT,FOLLOW_PRINT_in_expr463); 
                    		PRINT13_tree = (object)adaptor.Create(PRINT13);
                    		root_0 = (object)adaptor.BecomeRoot(PRINT13_tree, root_0);

                    	PushFollow(FOLLOW_term_in_expr466);
                    	term14 = term();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, term14.Tree);

                    }
                    break;
                case 2 :
                    // antlr_temp_dir\\MathExpr.g:88:3: ident ASSIGN term
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_ident_in_expr470);
                    	ident15 = ident();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, ident15.Tree);
                    	ASSIGN16=(IToken)Match(input,ASSIGN,FOLLOW_ASSIGN_in_expr472); 
                    		ASSIGN16_tree = (object)adaptor.Create(ASSIGN16);
                    		root_0 = (object)adaptor.BecomeRoot(ASSIGN16_tree, root_0);

                    	PushFollow(FOLLOW_term_in_expr475);
                    	term17 = term();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, term17.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr"

    public class program_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "program"
    // antlr_temp_dir\\MathExpr.g:91:1: program : ( expr )* ;
    public MathExprParser.program_return program() // throws RecognitionException [1]
    {   
        MathExprParser.program_return retval = new MathExprParser.program_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        MathExprParser.expr_return expr18 = default(MathExprParser.expr_return);



        try 
    	{
            // antlr_temp_dir\\MathExpr.g:91:8: ( ( expr )* )
            // antlr_temp_dir\\MathExpr.g:91:10: ( expr )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// antlr_temp_dir\\MathExpr.g:91:10: ( expr )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == PRINT || LA5_0 == IDENT) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:91:10: expr
            			    {
            			    	PushFollow(FOLLOW_expr_in_program483);
            			    	expr18 = expr();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, expr18.Tree);

            			    }
            			    break;

            			default:
            			    goto loop5;
            	    }
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "program"

    public class result_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "result"
    // antlr_temp_dir\\MathExpr.g:93:1: result : program -> ^( PROGRAM program ) ;
    public MathExprParser.result_return result() // throws RecognitionException [1]
    {   
        MathExprParser.result_return retval = new MathExprParser.result_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        MathExprParser.program_return program19 = default(MathExprParser.program_return);


        RewriteRuleSubtreeStream stream_program = new RewriteRuleSubtreeStream(adaptor,"rule program");
        try 
    	{
            // antlr_temp_dir\\MathExpr.g:93:7: ( program -> ^( PROGRAM program ) )
            // antlr_temp_dir\\MathExpr.g:93:9: program
            {
            	PushFollow(FOLLOW_program_in_result492);
            	program19 = program();
            	state.followingStackPointer--;

            	stream_program.Add(program19.Tree);


            	// AST REWRITE
            	// elements:          program
            	// token labels:      
            	// rule labels:       retval
            	// token list labels: 
            	// rule list labels:  
            	// wildcard labels: 
            	retval.Tree = root_0;
            	RewriteRuleSubtreeStream stream_retval = new RewriteRuleSubtreeStream(adaptor, "rule retval", retval!=null ? retval.Tree : null);

            	root_0 = (object)adaptor.GetNilNode();
            	// 93:17: -> ^( PROGRAM program )
            	{
            	    // antlr_temp_dir\\MathExpr.g:93:20: ^( PROGRAM program )
            	    {
            	    object root_1 = (object)adaptor.GetNilNode();
            	    root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PROGRAM, "PROGRAM"), root_1);

            	    adaptor.AddChild(root_1, stream_program.NextTree());

            	    adaptor.AddChild(root_0, root_1);
            	    }

            	}

            	retval.Tree = root_0;retval.Tree = root_0;
            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "result"

    public class execute_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "execute"
    // antlr_temp_dir\\MathExpr.g:95:1: execute : result ;
    public MathExprParser.execute_return execute() // throws RecognitionException [1]
    {   
        MathExprParser.execute_return retval = new MathExprParser.execute_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        MathExprParser.result_return result20 = default(MathExprParser.result_return);



        try 
    	{
            // antlr_temp_dir\\MathExpr.g:95:8: ( result )
            // antlr_temp_dir\\MathExpr.g:96:3: result
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_result_in_execute509);
            	result20 = result();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, result20.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "execute"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_IDENT_in_ident345 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_17_in_group366 = new BitSet(new ulong[]{0x0000000000020C00UL});
    public static readonly BitSet FOLLOW_term_in_group369 = new BitSet(new ulong[]{0x0000000000040000UL});
    public static readonly BitSet FOLLOW_18_in_group371 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_group376 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ident_in_group388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_group_in_mult397 = new BitSet(new ulong[]{0x000000000000C002UL});
    public static readonly BitSet FOLLOW_set_in_mult401 = new BitSet(new ulong[]{0x0000000000020C00UL});
    public static readonly BitSet FOLLOW_group_in_mult412 = new BitSet(new ulong[]{0x000000000000C002UL});
    public static readonly BitSet FOLLOW_mult_in_add424 = new BitSet(new ulong[]{0x0000000000003002UL});
    public static readonly BitSet FOLLOW_set_in_add429 = new BitSet(new ulong[]{0x0000000000020C00UL});
    public static readonly BitSet FOLLOW_mult_in_add440 = new BitSet(new ulong[]{0x0000000000003002UL});
    public static readonly BitSet FOLLOW_add_in_term452 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PRINT_in_expr463 = new BitSet(new ulong[]{0x0000000000020C00UL});
    public static readonly BitSet FOLLOW_term_in_expr466 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ident_in_expr470 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_ASSIGN_in_expr472 = new BitSet(new ulong[]{0x0000000000020C00UL});
    public static readonly BitSet FOLLOW_term_in_expr475 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expr_in_program483 = new BitSet(new ulong[]{0x0000000000020C42UL});
    public static readonly BitSet FOLLOW_program_in_result492 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_result_in_execute509 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}
