namespace Rcl.Compiler.Models;

public static class PostOperatorExtensions
{
    public static PostOperator ToPostOperator(this string op) => op switch
    {
        "++" => PostOperator.Increment,
        "--" => PostOperator.Decrement,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}