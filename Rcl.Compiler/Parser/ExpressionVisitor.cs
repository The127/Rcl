using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ExpressionVisitor : ParserVisitorBase<ExpressionModel>
{
    public override ExpressionModel VisitTerm(RaccoonLangParser.TermContext context) =>
        new TermExpressionModel(new TermVisitor().Visit(context));

    public override ExpressionModel VisitIndexerExpression(RaccoonLangParser.IndexerExpressionContext context)
    {
        var term = Visit(context.term());
        var children = context.expression()?.Select(Visit).ToList() ??new List<ExpressionModel>();
        return !children.Any() ? term : new IndexerExpressionModel(term, children);
    }

    public override ExpressionModel VisitAccessorExpression(RaccoonLangParser.AccessorExpressionContext context)
    {
        var children = context.indexerExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new AccessorExpressionModel(children, context._op.Select(x => x.Text.ToAccessorOperator()).ToList());
    }

    public override ExpressionModel VisitUnaryExpression(RaccoonLangParser.UnaryExpressionContext context)
    {
        var child = Visit(context.accessorExpression());
        return context.op == null ? child : new UnaryExpressionModel(context.op.Text.ToUnaryOperator(), child);
    }

    public override ExpressionModel VisitRangeExpression(RaccoonLangParser.RangeExpressionContext context)
    {
        var children = context.unaryExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new RangeExpressionModel(children[0], children[1]);
    }

    public override ExpressionModel VisitMultiplicativeExpression(RaccoonLangParser.MultiplicativeExpressionContext context)
    {
        var children = context.rangeExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new MultiplicativeExpressionModel(children, context._op.Select(x => x.Text.ToMultiplicativeOperator()).ToList());
    }

    public override ExpressionModel VisitAdditiveExpression(RaccoonLangParser.AdditiveExpressionContext context)
    {
        var children = context.multiplicativeExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new AdditiveExpressionModel(children, context._op.Select(x => x.Text.ToAdditiveOperator()).ToList());
    }

    public override ExpressionModel VisitShiftExpression(RaccoonLangParser.ShiftExpressionContext context)
    {
        var children = context.additiveExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new ShiftExpressionModel(children, context._op.Select(x => x.Text.ToShiftOperator()).ToList());
    }

    public override ExpressionModel VisitRelationalExpression(RaccoonLangParser.RelationalExpressionContext context)
    {
        var children = context.shiftExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new RelationalExpressionModel(children, context._op.Select(x => x.Text.ToRelationalOperator()).ToList());
    }

    public override ExpressionModel VisitEqualityExpression(RaccoonLangParser.EqualityExpressionContext context)
    {
        var children = context.relationalExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new EqualityExpressionModel(children, context._op.Select(x => x.Text.ToEqualityOperator()).ToList());
    }

    public override ExpressionModel VisitBoolAndExpression(RaccoonLangParser.BoolAndExpressionContext context)
    {
        var children = context.equalityExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new BoolAndExpressionModel(children);
    }
    
    public override ExpressionModel VisitBoolXorExpression(RaccoonLangParser.BoolXorExpressionContext context)
    {
        var children = context.boolAndExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new BoolXorExpressionModel(children);
    }

    public override ExpressionModel VisitBoolOrExpression(RaccoonLangParser.BoolOrExpressionContext context)
    {
        var children = context.boolXorExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new BoolOrExpressionModel(children);
    }

    public override ExpressionModel VisitCondAndExpression(RaccoonLangParser.CondAndExpressionContext context)
    {
        var children = context.boolOrExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new CondAndExpressionModel(children);
    }

    public override ExpressionModel VisitCondOrExpression(RaccoonLangParser.CondOrExpressionContext context)
    {
        var children = context.condAndExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new CondOrExpressionModel(children);
    }

    public override ExpressionModel VisitNullCoalescingExpression(RaccoonLangParser.NullCoalescingExpressionContext context)
    {
        var children = context.condOrExpression().Select(Visit).ToList();
        return children.Count == 1 ? children[0] : new NullCoalescingExpressionModel(children);
    }
}