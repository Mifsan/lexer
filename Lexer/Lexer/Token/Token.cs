using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public class Token
    {
        public TokenType TokenType { get; private set; }

        public String TokenValue { get; private set; }

        public Token(TokenType tokenType, String tokenValue = null)
        {
            TokenType = tokenType;
            TokenValue = tokenValue;
        }

        public override string ToString()
        {
            return TokenType + ": " + TokenValue;
        }
    }
}
