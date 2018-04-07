using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = @"void int ""void int"" {} ->*/ test^void,5,6,7 5e-3 5e6 8.0,";

            var tokens = new Lexer(test).Lex().ToList();

            foreach (var token in tokens)
            {
                Console.WriteLine(token.TokenType + " - " + token.TokenValue);
            }
        }
    }
}
