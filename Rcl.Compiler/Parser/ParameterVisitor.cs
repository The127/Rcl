using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ParameterVisitor : ParserVisitorBase<ParameterModel>
{
    public override ParameterModel VisitParameter(RaccoonLangParser.ParameterContext context) => 
        new(new FqtnVisitor().Visit(context.fqtn()), context.Identifier().GetText());
}