namespace Rcl.Compiler.Models;

public record FqtnModel(List<FqtnPartModel> NameParts, bool IsNullable) : ModelBase;