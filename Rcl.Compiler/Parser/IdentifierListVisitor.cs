namespace Rcl.Compiler.Parser;

public class IdentifierListVisitor : ListParserVisitorBase<string>
{
    public override IEnumerable<string> VisitIdentifierListComma(RaccoonLangParser.IdentifierListCommaContext context) =>
        context.Identifier().Select(x => x.GetText());

    public override IEnumerable<string> VisitIdentifierListDot(RaccoonLangParser.IdentifierListDotContext context) =>
        context.Identifier().Select(x => x.GetText());
}