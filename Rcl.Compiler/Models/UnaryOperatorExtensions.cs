namespace Rcl.Compiler.Models;

public static class UnaryOperatorExtensions
{
    public static UnaryOperator ToUnaryOperator(this string op) => op switch
    {
        "+" => UnaryOperator.Plus,
        "-" => UnaryOperator.Minus,
        "!" => UnaryOperator.LogicalNot,
        "~" => UnaryOperator.BinaryNot,
        "++" => UnaryOperator.Increment,
        "--" => UnaryOperator.Decrement,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}