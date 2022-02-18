namespace Rcl.Compiler.Models;

public record BoolAndExpressionModel(List<ExpressionModel> Children) : ExpressionModel;