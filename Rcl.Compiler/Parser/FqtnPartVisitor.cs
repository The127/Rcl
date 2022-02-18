using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class FqtnPartVisitor : ParserVisitorBase<FqtnPartModel>
{
    public override FqtnPartModel VisitFqtnPart(RaccoonLangParser.FqtnPartContext context) =>
        new(context.Identifier().GetText(),
            context.fqtnGenericPart()?.fqtn().Select(x => new FqtnVisitor().Visit(x)).ToList()?? new List<FqtnModel>());
}