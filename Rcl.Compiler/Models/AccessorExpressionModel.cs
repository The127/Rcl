namespace Rcl.Compiler.Models;

public record AccessorExpressionModel(List<ExpressionModel> Children, List<AccessorOperator> Ops) : ExpressionModel;