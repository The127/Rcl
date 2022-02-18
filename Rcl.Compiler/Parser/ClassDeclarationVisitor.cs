using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ClassDeclarationVisitor : TypeDeclarationVisitorBase
{
    public ClassDeclarationVisitor(Modifier modifier) : base(modifier) { }

    public override TypeDeclarationModel VisitClassDeclaration(RaccoonLangParser.ClassDeclarationContext context) =>
        new ClassDeclarationModel(
            Modifier, 
            new TypeNameVisitor().Visit(context.typeName()),
            context.classParents().baseClass() == null ? null : new FqtnVisitor().Visit(context.classParents().baseClass()),
            context.classParents().interfaces() == null ? new List<FqtnModel>() : context.classParents().interfaces().fqtn().Select(x => new FqtnVisitor().Visit(x)).ToList(),
            new ClassMembersVisitor().Visit(context.classBody()).ToList());
}