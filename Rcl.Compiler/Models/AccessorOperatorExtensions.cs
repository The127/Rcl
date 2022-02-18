namespace Rcl.Compiler.Models;

public static class AccessorOperatorExtensions
{
    public static AccessorOperator ToAccessorOperator(this string op) => op switch
    {
        "." => AccessorOperator.Dot,
        "?." => AccessorOperator.Elvis,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}