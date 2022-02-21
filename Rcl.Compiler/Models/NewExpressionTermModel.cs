namespace Rcl.Compiler.Models;

public record NewExpressionTermModel(FqtnModel? Type, List<ExpressionModel> Arguments) : TermnModel;