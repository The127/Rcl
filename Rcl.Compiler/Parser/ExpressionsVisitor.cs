using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ExpressionsVisitor : ListParserVisitorBase<ExpressionModel>
{
    public override IEnumerable<ExpressionModel> VisitExpression(RaccoonLangParser.ExpressionContext context)
    {
        yield return new ExpressionVisitor().Visit(context);
    }
}