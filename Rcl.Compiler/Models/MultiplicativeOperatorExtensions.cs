namespace Rcl.Compiler.Models;

public static class MultiplicativeOperatorExtensions
{
    public static MultiplicativeOperator ToMultiplicativeOperator(this string op) => op switch
    {
        "*" => MultiplicativeOperator.Times,
        "/" => MultiplicativeOperator.Division,
        "%" => MultiplicativeOperator.Modulo,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null),
    };
}