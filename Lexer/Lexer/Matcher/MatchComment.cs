﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public class MatchComment : MatcherBase
    {
        public static Tuple<string, string> BLOCK_COMMENT = new Tuple<string, string>("/*", "*/");

        public static Tuple<string, string> LINE_COMMENT = new Tuple<string, string>("//", "\\n");

        private Tuple<string, string> CommentDelim { get; set; }

        public MatchComment(Tuple<string, string> delim)
        {
            CommentDelim = delim;
        }

        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {
            if (new MatchKeyword(TokenType.Unknown, CommentDelim.Item1).IsMatch(tokenizer) == null)
            {
                return null;
            }
            else
            {
                tokenizer.Consume();

                while (!tokenizer.End() && new MatchKeyword(TokenType.Unknown, CommentDelim.Item2).IsMatch(tokenizer) == null)
                {
                    tokenizer.Consume();
                }

                if (new MatchKeyword(TokenType.Unknown, CommentDelim.Item2).IsMatch(tokenizer) == null)
                {
                    tokenizer.Consume();
                }

                TokenType tokenType = TokenType.OpenBlockComment;

                if(CommentDelim == LINE_COMMENT)
                {
                    tokenType = TokenType.OpenLineComment;
                }

                return new Token(tokenType, CommentDelim.Item1);
            }
        }
    }
}
