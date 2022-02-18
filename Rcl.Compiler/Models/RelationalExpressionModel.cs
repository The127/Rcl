namespace Rcl.Compiler.Models;

public record RelationalExpressionModel(List<ExpressionModel> Children, List<RelationalOperator> Ops) : ExpressionModel;