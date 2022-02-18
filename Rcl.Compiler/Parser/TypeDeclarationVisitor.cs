using Antlr4.Runtime.Tree;
using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class TypeDeclarationVisitor : ParserVisitorBase<TypeDeclarationModel>
{
    private readonly Modifier _modifier;

    public TypeDeclarationVisitor(IParseTree modifier) => _modifier = modifier.GetText().ToModifier();

    public override TypeDeclarationModel VisitFunctionDeclaration(RaccoonLangParser.FunctionDeclarationContext context) =>
        new FunctionDeclarationVisitor(_modifier).Visit(context);

    public override TypeDeclarationModel VisitInterfaceDeclaration(RaccoonLangParser.InterfaceDeclarationContext context) =>
        new InterfaceDeclarationVisitor(_modifier).Visit(context);

    public override TypeDeclarationModel VisitClassDeclaration(RaccoonLangParser.ClassDeclarationContext context) =>
        new ClassDeclarationVisitor(_modifier).Visit(context);

    public override TypeDeclarationModel VisitDataClassDeclaration(RaccoonLangParser.DataClassDeclarationContext context) =>
        new DataClassDeclarationVisitor(_modifier).Visit(context);
}