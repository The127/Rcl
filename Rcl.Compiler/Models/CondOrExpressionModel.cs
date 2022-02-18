namespace Rcl.Compiler.Models;

public record CondOrExpressionModel(List<ExpressionModel> Children) : ExpressionModel;