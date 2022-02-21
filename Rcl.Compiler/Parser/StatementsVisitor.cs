using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class StatementsVisitor : ListParserVisitorBase<StatementModel>
{
    public override IEnumerable<StatementModel> VisitStatement(RaccoonLangParser.StatementContext context)
    {
        yield return new StatementVisitor().Visit(context);
    }
}

public class StatementVisitor : ParserVisitorBase<StatementModel>
{
    public override StatementModel VisitLoopStatement(RaccoonLangParser.LoopStatementContext context)
    {
        var statements = context.statement().Select(Visit).ToList();
        
        var whileContext = context.whileLoop();
        if (whileContext != null)
        {
            return new WhileLoopStatement(new ExpressionVisitor().Visit(whileContext.expression()), statements);
        }

        var foreachContext = context.foreachLoop();
        if (foreachContext != null)
        {
            return new ForeachLoopStatement(
                foreachContext.Identifier().GetText(),
                new ExpressionVisitor().Visit(foreachContext.expression()),
                statements);
        }

        var forContext = context.forLoop();
        if (forContext != null)
        {
            var varContext = forContext.variableDeclaration();
            return new ForLoopStatement(
                new VariableDeclarationStatement(true, new FqtnVisitor().Visit(varContext.fqtn()), varContext.Identifier().GetText(), new ExpressionVisitor().Visit(varContext.expression())),
                new ExpressionVisitor().Visit(forContext.cond),
                new ExpressionVisitor().Visit(forContext.inc),
                statements);
        }

        return new ForeverLoopStatement(statements);
    }

    public override StatementModel VisitExpressionStatement(RaccoonLangParser.ExpressionStatementContext context) =>
        new ExpressionStatement(new ExpressionVisitor().Visit(context.expression()));

    public override StatementModel VisitVariableDeclarationStatement(RaccoonLangParser.VariableDeclarationStatementContext context)
    {
        var vContext = context.variableDeclaration();
        return new VariableDeclarationStatement(context.mut != null, new FqtnVisitor().Visit(vContext.fqtn()), vContext.Identifier().GetText(), new ExpressionVisitor().Visit(vContext.expression()));
    }

    public override StatementModel VisitMutChangeStatement(RaccoonLangParser.MutChangeStatementContext context) =>
        new MutChangeStatement(context.identifierListDot().GetText(), context.op.Text.ToMutChangeOperator(), new ExpressionVisitor().Visit(context.expression()));

    public override StatementModel VisitReturnStatement(RaccoonLangParser.ReturnStatementContext context) =>
        new ReturnStatement(new ExpressionVisitor().Visit(context.expression()));
}