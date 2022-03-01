using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class FunctionDeclarationVisitor : TypeDeclarationVisitorBase
{
    public FunctionDeclarationVisitor(Modifier modifier) : base(modifier) { }

    public override TypeDeclarationModel VisitFunctionDeclaration(RaccoonLangParser.FunctionDeclarationContext context)
    {
        return new FunctionDeclarationModel(
            Modifier,
            new FqtnVisitor().Visit(context.fqtn()),
            new TypeNameVisitor().Visit(context.name),
            new ParametersVisitor().Visit(context.parameters()).ToList(),
            new ExpressionVisitor().Visit(context.functionBody()));
    }
}