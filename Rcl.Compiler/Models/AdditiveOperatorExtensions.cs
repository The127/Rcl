namespace Rcl.Compiler.Models;

public static class AdditiveOperatorExtensions
{
    public static AdditiveOperator ToAdditiveOperator(this string op) => op switch
    {
        "+" => Models.AdditiveOperator.Plus,
        "-" => Models.AdditiveOperator.Minus,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}