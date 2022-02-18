using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class DataClassDeclarationVisitor : TypeDeclarationVisitorBase
{
    public DataClassDeclarationVisitor(Modifier modifier) : base(modifier) { }

    public override TypeDeclarationModel VisitDataClassDeclaration(
        RaccoonLangParser.DataClassDeclarationContext context) =>
        new DataClassDeclarationModel(
            Modifier,
            new TypeNameVisitor().Visit(context.typeName()),
            new DataClassMembersVisitor().Visit(context.dataClassBody()).ToList());
}