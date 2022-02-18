namespace Rcl.Compiler.Models;

public record BoolXorExpressionModel(List<ExpressionModel> Children) : ExpressionModel;