namespace Rcl.Compiler.Models;

public record EqualityExpressionModel(List<ExpressionModel> Children, List<EqualityOperator> Ops) : ExpressionModel;