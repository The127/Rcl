namespace Rcl.Compiler.Models;

public static class EqualityOperatorExtensions
{
    public static EqualityOperator ToEqualityOperator(this string op) => op switch
    {
        "==" => EqualityOperator.Equals,
        "!=" => EqualityOperator.NotEquals,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}