namespace Rcl.Compiler.Models;

public record RangeExpressionModel(ExpressionModel Left, ExpressionModel Right) : ExpressionModel;