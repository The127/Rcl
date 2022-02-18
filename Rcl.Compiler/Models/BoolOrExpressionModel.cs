namespace Rcl.Compiler.Models;

public record BoolOrExpressionModel(List<ExpressionModel> Children) : ExpressionModel;