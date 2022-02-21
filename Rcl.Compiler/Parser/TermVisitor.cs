using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class TermVisitor : ParserVisitorBase<TermnModel>
{
    public override TermnModel VisitFunctionCallExpression(RaccoonLangParser.FunctionCallExpressionContext context) =>
        new FunctionCallExpressionTermModel(new FqtnVisitor().Visit(context.fqtn()), new ExpressionsVisitor().Visit(context.expressionList()).ToList());

    public override TermnModel VisitParExpression(RaccoonLangParser.ParExpressionContext context) =>
        new ParExpressionTermModel(new ExpressionVisitor().Visit(context.expression()));

    public override TermnModel VisitLiteral(RaccoonLangParser.LiteralContext context) =>
        new LiteralTermModel(new LiteralVisitor().Visit(context));

    public override TermnModel VisitNewExpression(RaccoonLangParser.NewExpressionContext context) =>
        new NewExpressionTermModel(new FqtnVisitor().Visit(context.fqtn()), new ExpressionsVisitor().Visit(context.expressionList()).ToList());

    public override TermnModel VisitIfExpression(RaccoonLangParser.IfExpressionContext context)
    {
        var elifPartModels = context.elifPart().Select(x => new ElifPartModel(new ExpressionVisitor().Visit(x.expression()), new ExpressionVisitor().Visit(x.blockExpression()))).ToList();
        var elsePart = new ExpressionVisitor().Visit(context.elsePart());
        return new IfExpressionTermModel(
            new ExpressionVisitor().Visit(context.expression()),
            new ExpressionVisitor().Visit(context.blockExpression()),
            elifPartModels,
            elsePart);
    }

    public override TermnModel VisitBlockExpression(RaccoonLangParser.BlockExpressionContext context) =>
        new BlockExpressionTermModel(new StatementsVisitor().Visit(context).ToList(), new ExpressionVisitor().Visit(context.expression()));

    public override TermnModel VisitPostExpression(RaccoonLangParser.PostExpressionContext context) =>
        new PostExpressionTermModel(context.Identifier().GetText(), context.op?.Text.ToPostOperator());
}