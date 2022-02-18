namespace Rcl.Compiler.Models;

public static class ShiftOperatorExtensions
{
    public static ShiftOperator ToShiftOperator(this string op) => op switch
    {
        "<<" => ShiftOperator.Left,
        ">" => ShiftOperator.Right,
        _ => throw new ArgumentOutOfRangeException(nameof(op), op, null)
    };
}