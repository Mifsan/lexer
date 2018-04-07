using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public class Lexer
    {
        private Tokenizer Tokenizer { get; set; }

        private List<IMatcher> Matchers { get; set; }

        public Lexer(String source)
        {
            Tokenizer = new Tokenizer(source);
        }

        public IEnumerable<Token> Lex()
        {
            Matchers = InitializeMatchList();

            var current = Next();

            while (current != null && current.TokenType != TokenType.EOF)
            {
                if (current.TokenType != TokenType.WhiteSpace)
                {
                    yield return current;
                }

                current = Next();
            }
        }

        private List<IMatcher> InitializeMatchList()
        {
            var matchers = new List<IMatcher>(64);

            var keywordmatchers = new List<IMatcher>
                                  {
                                      new MatchKeyword(TokenType.Void, "void"),
                                      new MatchKeyword(TokenType.Int, "int"),
                                      new MatchKeyword(TokenType.Float, "float"),
                                      new MatchKeyword(TokenType.Boolean, "bool"),
                                      new MatchKeyword(TokenType.Char, "char"),
                                      new MatchKeyword(TokenType.String, "string"),
                                      new MatchKeyword(TokenType.If, "if"),
                                      new MatchKeyword(TokenType.Else, "else"),
                                      new MatchKeyword(TokenType.While, "while"),
                                      new MatchKeyword(TokenType.For, "for"),
                                      new MatchKeyword(TokenType.Return, "return"),
                                      new MatchKeyword(TokenType.True, "true"),
                                      new MatchKeyword(TokenType.False, "false")
                                  };


            var specialCharacters = new List<IMatcher>
                                    {
                                        new MatchKeyword(TokenType.DeRef, "->"),
                                        new MatchKeyword(TokenType.LBracket, "{"),
                                        new MatchKeyword(TokenType.RBracket, "}"),
                                        new MatchKeyword(TokenType.LSquareBracket, "["),
                                        new MatchKeyword(TokenType.RSquareBracket, "]"),
                                        new MatchKeyword(TokenType.Plus, "+"),
                                        new MatchKeyword(TokenType.Minus, "-"),
                                        new MatchKeyword(TokenType.NotCompare, "!="),
                                        new MatchKeyword(TokenType.Compare, "=="),
                                        new MatchKeyword(TokenType.Equals, "="),
                                        new MatchKeyword(TokenType.HashTag, "#"),
                                        new MatchKeyword(TokenType.Comma, ","),
                                        new MatchKeyword(TokenType.OpenParenth, "("),
                                        new MatchKeyword(TokenType.CloseParenth, ")"),
                                        new MatchKeyword(TokenType.Asterix, "*"),
                                        new MatchKeyword(TokenType.Slash, "/"),
                                        new MatchKeyword(TokenType.Carat, "^"),
                                        new MatchKeyword(TokenType.Ampersand, "&"),
                                        new MatchKeyword(TokenType.GreaterThan, ">"),
                                        new MatchKeyword(TokenType.LessThan, "<"),
                                        new MatchKeyword(TokenType.Or, "||"),
                                        new MatchKeyword(TokenType.SemiColon, ";"),
                                        new MatchKeyword(TokenType.Dot, "."),
                                    };

            keywordmatchers.ForEach(keyword =>
            {
                var current = (keyword as MatchKeyword);
                current.AllowAsSubString = false;
                current.SpecialCharacters = specialCharacters.Select(i => i as MatchKeyword).ToList();
            });

            matchers.Add(new MatchString(MatchString.QUOTE));
            matchers.Add(new MatchString(MatchString.TIC));
            matchers.AddRange(specialCharacters);
            matchers.AddRange(keywordmatchers);
            matchers.AddRange(new List<IMatcher>
                                                {
                                                    new MatchWhiteSpace(),
                                                    new MatchNumber(),
                                                    new MatchWord(specialCharacters)
                                                });

            return matchers;
        }

        private Token Next()
        {
            if (Tokenizer.End())
            {
                return new Token(TokenType.EOF);
            }

            return
                 (from match in Matchers
                  let token = match.IsMatch(Tokenizer)
                  where token != null
                  select token).FirstOrDefault();
        }
    }
}
