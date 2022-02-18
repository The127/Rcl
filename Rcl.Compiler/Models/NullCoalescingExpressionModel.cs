namespace Rcl.Compiler.Models;

public record NullCoalescingExpressionModel(List<ExpressionModel> Children) : ExpressionModel;