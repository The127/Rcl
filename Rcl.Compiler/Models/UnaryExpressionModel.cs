namespace Rcl.Compiler.Models;

public record UnaryExpressionModel(UnaryOperator Op, ExpressionModel Child) : ExpressionModel;