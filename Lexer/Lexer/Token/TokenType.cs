using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public enum TokenType
    {
        Void,
        WhiteSpace,
        LBracket,
        RBracket,
        Plus,
        Minus,
        Equals,
        HashTag,
        Identifier,
        Comma,
        OpenParenth,
        CloseParenth,
        Asterix,
        Slash,
        Carat,
        DeRef,
        Ampersand,
        GreaterThan,
        LessThan,
        SemiColon,
        If,
        Return,
        While,
        Else,
        ScopeStart,
        EOF,
        For,
        Float,
        FloatValue,
        Dot,
        True,
        False,
        Boolean,
        Or,
        Int,
        IntValue,
        Char,
        CharValue,
        String,
        StringValue,
        Compare,
        NotCompare,
        LSquareBracket,
        RSquareBracket
    }
}
