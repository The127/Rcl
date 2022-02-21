namespace Rcl.Compiler.Models;

public record FunctionCallExpressionTermModel(FqtnModel Name, List<ExpressionModel> Arguments) : TermnModel;