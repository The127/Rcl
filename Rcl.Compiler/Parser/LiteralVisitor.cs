using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class LiteralVisitor : ParserVisitorBase<LiteralModel>
{
    public override LiteralModel VisitLiteral(RaccoonLangParser.LiteralContext context)
    {
        if (context.BoolLiteral() != null)
            return new BoolLiteral(context.BoolLiteral().GetText() == "true");
        if (context.CharacterLiteral() != null)
            return new CharLiteral(context.CharacterLiteral().GetText());
        if (context.StringLiteral() != null)
            return new StringLiteral(context.StringLiteral().GetText());
        if (context.NumberLiteral() != null)
            return new NumberLiteral(context.NumberLiteral().GetText());
        throw new Exception("Unimplemented literal type encountered");
    }
}