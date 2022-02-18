namespace Rcl.Compiler.Models;

public record TypeNameModel(string Name, List<string> Generics) : ModelBase;