namespace Rcl.Compiler.Models;

public record AdditiveExpressionModel(List<ExpressionModel> Children, List<AdditiveOperator> Ops) : ExpressionModel;