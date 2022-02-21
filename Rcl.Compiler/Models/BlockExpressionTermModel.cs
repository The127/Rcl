namespace Rcl.Compiler.Models;

public record BlockExpressionTermModel(List<StatementModel> Statements, ExpressionModel? Value) : TermnModel;