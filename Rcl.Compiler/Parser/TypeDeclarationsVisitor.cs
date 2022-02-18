using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class TypeDeclarationsVisitor : ListParserVisitorBase<TypeDeclarationModel>
{
    public override IEnumerable<TypeDeclarationModel> VisitTypeDeclaration(RaccoonLangParser.TypeDeclarationContext context)
    {
        yield return new TypeDeclarationVisitor(context.Modifier()).Visit(context);
    }
}