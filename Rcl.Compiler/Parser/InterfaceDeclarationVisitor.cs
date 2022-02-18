using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class InterfaceDeclarationVisitor : TypeDeclarationVisitorBase
{
    public InterfaceDeclarationVisitor(Modifier modifier) : base(modifier) { }

    public override TypeDeclarationModel VisitInterfaceDeclaration(RaccoonLangParser.InterfaceDeclarationContext context) =>
        new InterfaceDeclarationModel(
            Modifier,
            new TypeNameVisitor().Visit(context.typeName()),
            context.interfaceParents() == null ? new List<FqtnModel>() : context.interfaceParents().fqtn().Select(x => new FqtnVisitor().Visit(x)).ToList(),
            new InterfaceMembersVisitor().Visit(context.interfaceBody()).ToList());
}