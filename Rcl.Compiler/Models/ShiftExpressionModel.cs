namespace Rcl.Compiler.Models;

public record ShiftExpressionModel(List<ExpressionModel> Children, List<ShiftOperator> Ops) : ExpressionModel;