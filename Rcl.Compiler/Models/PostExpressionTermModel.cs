namespace Rcl.Compiler.Models;

public record PostExpressionTermModel(string Name, PostOperator? Op) : TermnModel;