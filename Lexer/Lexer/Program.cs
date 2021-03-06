﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = @"321dsa void inT321  @ # & $$  ""void int"" """" 1e23 // 'dsq' {} -> test^void,5,6,7 \n 5e-3 5e6 8.0, ";

            var tokens = new Lexer(text).Lex().ToList();

            foreach (var token in tokens)
            {
                Console.WriteLine(token.ToString());
            }
        }
    }
}
