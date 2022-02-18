using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class TypeNameVisitor : ParserVisitorBase<TypeNameModel>
{
    public override TypeNameModel VisitTypeName(RaccoonLangParser.TypeNameContext context) =>
        new(context.Identifier().GetText(), new IdentifierListVisitor().Visit(context).ToList());
}