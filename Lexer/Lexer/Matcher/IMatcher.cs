using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lexer
{
    public interface IMatcher
    {
        Token IsMatch(Tokenizer tokenizer);
    }
}
