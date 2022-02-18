namespace Rcl.Compiler.Models;

public record IndexerExpressionModel(ExpressionModel Term, List<ExpressionModel> Children) : ExpressionModel;