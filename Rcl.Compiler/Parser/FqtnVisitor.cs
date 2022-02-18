using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class FqtnVisitor : ParserVisitorBase<FqtnModel>
{
    public override FqtnModel VisitFqtn(RaccoonLangParser.FqtnContext context) =>
        new(context.fqtnPart().Select(x => new FqtnPartVisitor().Visit(x)).ToList(), context.nullable != null);
}