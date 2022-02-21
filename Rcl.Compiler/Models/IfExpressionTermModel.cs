namespace Rcl.Compiler.Models;

public record IfExpressionTermModel(ExpressionModel Condition, ExpressionModel Body, List<ElifPartModel> Elifs, ExpressionModel? Else) : TermnModel;