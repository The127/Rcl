using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ParametersVisitor : ListParserVisitorBase<ParameterModel>
{
    public override IEnumerable<ParameterModel> VisitParameter(RaccoonLangParser.ParameterContext context)
    {
        yield return new ParameterVisitor().Visit(context);
    }
}