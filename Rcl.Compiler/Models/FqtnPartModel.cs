namespace Rcl.Compiler.Models;

public record FqtnPartModel(string Name, List<FqtnModel> Generics) : ModelBase;