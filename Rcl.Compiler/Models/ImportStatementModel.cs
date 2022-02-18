namespace Rcl.Compiler.Models;

public record ImportStatementModel(string FromNamespace, List<(string name, string? alias)> Types) : ModelBase;