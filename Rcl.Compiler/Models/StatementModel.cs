namespace Rcl.Compiler.Models;

public abstract record StatementModel : ModelBase;

public abstract record LoopStatement(List<StatementModel> Body) : StatementModel;
public record ForeverLoopStatement(List<StatementModel> Body) : LoopStatement(Body);
public record WhileLoopStatement(ExpressionModel Condition, List<StatementModel> Body) : LoopStatement(Body);
public record ForLoopStatement(VariableDeclarationStatement VariableDeclaration, ExpressionModel Condition, ExpressionModel Increment, List<StatementModel>? Body) : LoopStatement(Body);
public record ForeachLoopStatement(string VarName, ExpressionModel IEnumerableValue, List<StatementModel> Body) : LoopStatement(Body);
public record ExpressionStatement(ExpressionModel Expression) : StatementModel;
public record VariableDeclarationStatement(bool Mutable, FqtnModel? ExplicitType, string Name, ExpressionModel Value) : StatementModel;
public record MutChangeStatement(string FullName, MutChangeOperator Operator, ExpressionModel Value) : StatementModel;
public record ReturnStatement(ExpressionModel? Value) : StatementModel;

public enum MutChangeOperator
{
    Assign,
    PlusAssign,
    MinusAssign,
    TimesAssign,
    DivideAssign,
    XorAssign,
    BinaryOrAssign,
    BinaryAndAssign,
    LogicalOrAssign,
    LogicalAndAssign,
    NullCoalesceAssign,
    ModuloAssign,
}

public static class MutChangeOperatorExtensions
{
    public static MutChangeOperator ToMutChangeOperator(this string op) => op switch
    {
        "=" => MutChangeOperator.Assign,
        "+=" => MutChangeOperator.PlusAssign,
        "-=" => MutChangeOperator.MinusAssign,
        "*=" => MutChangeOperator.TimesAssign,
        "/=" => MutChangeOperator.DivideAssign,
        "^=" => MutChangeOperator.XorAssign,
        "&=" => MutChangeOperator.BinaryAndAssign,
        "&&=" => MutChangeOperator.LogicalAndAssign,
        "|=" => MutChangeOperator.BinaryOrAssign,
        "||=" => MutChangeOperator.LogicalOrAssign,
        "??=" => MutChangeOperator.NullCoalesceAssign,
        "%=" => MutChangeOperator.ModuloAssign,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}