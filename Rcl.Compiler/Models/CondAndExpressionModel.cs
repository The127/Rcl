namespace Rcl.Compiler.Models;

public record CondAndExpressionModel(List<ExpressionModel> Children) : ExpressionModel;