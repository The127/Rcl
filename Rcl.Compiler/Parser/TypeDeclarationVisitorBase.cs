using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public abstract class TypeDeclarationVisitorBase : ParserVisitorBase<TypeDeclarationModel>
{
    public Modifier Modifier { get; }

    protected TypeDeclarationVisitorBase(Modifier modifier) => Modifier = modifier;
}