// $ANTLR 3.2 Sep 23, 2009 12:02:23 antlr_temp_dir\\MathExpr.g 2012-09-25 14:02:39

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


namespace  MathExpr 
{
public partial class MathExprLexer : Lexer {
    public const int WS = 9;
    public const int T__18 = 18;
    public const int T__17 = 17;
    public const int UNKNOWN = 4;
    public const int BLOCK = 7;
    public const int NUMBER = 10;
    public const int ASSIGN = 16;
    public const int IDENT = 11;
    public const int PROGRAM = 8;
    public const int SUB = 13;
    public const int VAR = 5;
    public const int DIV = 15;
    public const int EOF = -1;
    public const int MUL = 14;
    public const int PRINT = 6;
    public const int ADD = 12;

    // delegates
    // delegators

    public MathExprLexer() 
    {
		InitializeCyclicDFAs();
    }
    public MathExprLexer(ICharStream input)
		: this(input, null) {
    }
    public MathExprLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "antlr_temp_dir\\MathExpr.g";} 
    }

    // $ANTLR start "PRINT"
    public void mPRINT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PRINT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:9:7: ( 'print' )
            // antlr_temp_dir\\MathExpr.g:9:9: 'print'
            {
            	Match("print"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PRINT"

    // $ANTLR start "T__17"
    public void mT__17() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__17;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:10:7: ( '(' )
            // antlr_temp_dir\\MathExpr.g:10:9: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__17"

    // $ANTLR start "T__18"
    public void mT__18() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__18;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:11:7: ( ')' )
            // antlr_temp_dir\\MathExpr.g:11:9: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__18"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:35:3: ( ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+ )
            // antlr_temp_dir\\MathExpr.g:36:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
            {
            	// antlr_temp_dir\\MathExpr.g:36:3: ( ' ' | '\\t' | '\\f' | '\\r' | '\\n' )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= '\t' && LA1_0 <= '\n') || (LA1_0 >= '\f' && LA1_0 <= '\r') || LA1_0 == ' ') )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || (input.LA(1) >= '\f' && input.LA(1) <= '\r') || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


            	    _channel=HIDDEN;
            	  

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "NUMBER"
    public void mNUMBER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NUMBER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:42:7: ( ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )? )
            // antlr_temp_dir\\MathExpr.g:42:9: ( '0' .. '9' )+ ( '.' ( '0' .. '9' )+ )?
            {
            	// antlr_temp_dir\\MathExpr.g:42:9: ( '0' .. '9' )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:42:10: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	// antlr_temp_dir\\MathExpr.g:42:21: ( '.' ( '0' .. '9' )+ )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '.') )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // antlr_temp_dir\\MathExpr.g:42:22: '.' ( '0' .. '9' )+
            	        {
            	        	Match('.'); 
            	        	// antlr_temp_dir\\MathExpr.g:42:26: ( '0' .. '9' )+
            	        	int cnt3 = 0;
            	        	do 
            	        	{
            	        	    int alt3 = 2;
            	        	    int LA3_0 = input.LA(1);

            	        	    if ( ((LA3_0 >= '0' && LA3_0 <= '9')) )
            	        	    {
            	        	        alt3 = 1;
            	        	    }


            	        	    switch (alt3) 
            	        		{
            	        			case 1 :
            	        			    // antlr_temp_dir\\MathExpr.g:42:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 

            	        			    }
            	        			    break;

            	        			default:
            	        			    if ( cnt3 >= 1 ) goto loop3;
            	        		            EarlyExitException eee3 =
            	        		                new EarlyExitException(3, input);
            	        		            throw eee3;
            	        	    }
            	        	    cnt3++;
            	        	} while (true);

            	        	loop3:
            	        		;	// Stops C# compiler whining that label 'loop3' has no statements


            	        }
            	        break;

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NUMBER"

    // $ANTLR start "IDENT"
    public void mIDENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IDENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:44:6: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
            // antlr_temp_dir\\MathExpr.g:44:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// antlr_temp_dir\\MathExpr.g:45:9: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '0' && LA5_0 <= '9') || (LA5_0 >= 'A' && LA5_0 <= 'Z') || LA5_0 == '_' || (LA5_0 >= 'a' && LA5_0 <= 'z')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // antlr_temp_dir\\MathExpr.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop5;
            	    }
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IDENT"

    // $ANTLR start "ADD"
    public void mADD() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ADD;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:47:4: ( '+' )
            // antlr_temp_dir\\MathExpr.g:47:9: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ADD"

    // $ANTLR start "SUB"
    public void mSUB() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SUB;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:48:4: ( '-' )
            // antlr_temp_dir\\MathExpr.g:48:9: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SUB"

    // $ANTLR start "MUL"
    public void mMUL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MUL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:49:4: ( '*' )
            // antlr_temp_dir\\MathExpr.g:49:9: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MUL"

    // $ANTLR start "DIV"
    public void mDIV() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DIV;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:50:4: ( '/' )
            // antlr_temp_dir\\MathExpr.g:50:9: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIV"

    // $ANTLR start "ASSIGN"
    public void mASSIGN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ASSIGN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // antlr_temp_dir\\MathExpr.g:51:7: ( '=' )
            // antlr_temp_dir\\MathExpr.g:51:9: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ASSIGN"

    override public void mTokens() // throws RecognitionException 
    {
        // antlr_temp_dir\\MathExpr.g:1:8: ( PRINT | T__17 | T__18 | WS | NUMBER | IDENT | ADD | SUB | MUL | DIV | ASSIGN )
        int alt6 = 11;
        alt6 = dfa6.Predict(input);
        switch (alt6) 
        {
            case 1 :
                // antlr_temp_dir\\MathExpr.g:1:10: PRINT
                {
                	mPRINT(); 

                }
                break;
            case 2 :
                // antlr_temp_dir\\MathExpr.g:1:16: T__17
                {
                	mT__17(); 

                }
                break;
            case 3 :
                // antlr_temp_dir\\MathExpr.g:1:22: T__18
                {
                	mT__18(); 

                }
                break;
            case 4 :
                // antlr_temp_dir\\MathExpr.g:1:28: WS
                {
                	mWS(); 

                }
                break;
            case 5 :
                // antlr_temp_dir\\MathExpr.g:1:31: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 6 :
                // antlr_temp_dir\\MathExpr.g:1:38: IDENT
                {
                	mIDENT(); 

                }
                break;
            case 7 :
                // antlr_temp_dir\\MathExpr.g:1:44: ADD
                {
                	mADD(); 

                }
                break;
            case 8 :
                // antlr_temp_dir\\MathExpr.g:1:48: SUB
                {
                	mSUB(); 

                }
                break;
            case 9 :
                // antlr_temp_dir\\MathExpr.g:1:52: MUL
                {
                	mMUL(); 

                }
                break;
            case 10 :
                // antlr_temp_dir\\MathExpr.g:1:56: DIV
                {
                	mDIV(); 

                }
                break;
            case 11 :
                // antlr_temp_dir\\MathExpr.g:1:60: ASSIGN
                {
                	mASSIGN(); 

                }
                break;

        }

    }


    protected DFA6 dfa6;
	private void InitializeCyclicDFAs()
	{
	    this.dfa6 = new DFA6(this);
	}

    const string DFA6_eotS =
        "\x01\uffff\x01\x06\x0a\uffff\x03\x06\x01\x10\x01\uffff";
    const string DFA6_eofS =
        "\x11\uffff";
    const string DFA6_minS =
        "\x01\x09\x01\x72\x0a\uffff\x01\x69\x01\x6e\x01\x74\x01\x30\x01"+
        "\uffff";
    const string DFA6_maxS =
        "\x01\x7a\x01\x72\x0a\uffff\x01\x69\x01\x6e\x01\x74\x01\x7a\x01"+
        "\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
        "\x08\x01\x09\x01\x0a\x01\x0b\x04\uffff\x01\x01";
    const string DFA6_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x02\x04\x01\uffff\x02\x04\x12\uffff\x01\x04\x07\uffff\x01"+
            "\x02\x01\x03\x01\x09\x01\x07\x01\uffff\x01\x08\x01\uffff\x01"+
            "\x0a\x0a\x05\x03\uffff\x01\x0b\x03\uffff\x1a\x06\x04\uffff\x01"+
            "\x06\x01\uffff\x0f\x06\x01\x01\x0a\x06",
            "\x01\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x0d",
            "\x01\x0e",
            "\x01\x0f",
            "\x0a\x06\x07\uffff\x1a\x06\x04\uffff\x01\x06\x01\uffff\x1a"+
            "\x06",
            ""
    };

    static readonly short[] DFA6_eot = DFA.UnpackEncodedString(DFA6_eotS);
    static readonly short[] DFA6_eof = DFA.UnpackEncodedString(DFA6_eofS);
    static readonly char[] DFA6_min = DFA.UnpackEncodedStringToUnsignedChars(DFA6_minS);
    static readonly char[] DFA6_max = DFA.UnpackEncodedStringToUnsignedChars(DFA6_maxS);
    static readonly short[] DFA6_accept = DFA.UnpackEncodedString(DFA6_acceptS);
    static readonly short[] DFA6_special = DFA.UnpackEncodedString(DFA6_specialS);
    static readonly short[][] DFA6_transition = DFA.UnpackEncodedStringArray(DFA6_transitionS);

    protected class DFA6 : DFA
    {
        public DFA6(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 6;
            this.eot = DFA6_eot;
            this.eof = DFA6_eof;
            this.min = DFA6_min;
            this.max = DFA6_max;
            this.accept = DFA6_accept;
            this.special = DFA6_special;
            this.transition = DFA6_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( PRINT | T__17 | T__18 | WS | NUMBER | IDENT | ADD | SUB | MUL | DIV | ASSIGN );"; }
        }

    }

 
    
}
}
