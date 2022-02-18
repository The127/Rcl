namespace Rcl.Compiler.Models;

public static class RelationalOperatorExtensions
{
    public static RelationalOperator ToRelationalOperator(this string op) => op switch
    {
        "<" => RelationalOperator.Less,
        ">" => RelationalOperator.More,
        "<=" => RelationalOperator.LessOrEqual,
        ">=" => RelationalOperator.MoreOrEqual,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}