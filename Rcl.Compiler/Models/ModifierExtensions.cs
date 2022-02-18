namespace Rcl.Compiler.Models;

public static class ModifierExtensions
{
    public static Modifier ToModifier(this string text) => text switch
    {
        "public" => Modifier.Public,
        "private" => Modifier.Private,
        "protected" => Modifier.Protected,
        "internal" => Modifier.Internal,
        _ => throw new Exception($"unknown modifier {text}"),
    };
}