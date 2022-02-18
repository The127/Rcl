namespace Rcl.Compiler.Models;

public record MultiplicativeExpressionModel(List<ExpressionModel> Children, List<MultiplicativeOperator> Ops) : ExpressionModel;