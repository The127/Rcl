using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class ImportsVisitor : ListParserVisitorBase<ImportStatementModel>
{
    public override IEnumerable<ImportStatementModel> VisitAliasImport(RaccoonLangParser.AliasImportContext context)
    {
        var fromNamespace = context.identifierListDot().GetText();
        var lastDotIndex = fromNamespace.LastIndexOf('.');
        var name = fromNamespace[lastDotIndex..];
        fromNamespace = fromNamespace[..lastDotIndex];
        yield return new(
            fromNamespace,
            new() { (name, context.Identifier().GetText()) }
        );
    }

    public override IEnumerable<ImportStatementModel> VisitGroupImport(RaccoonLangParser.GroupImportContext context)
    {
        yield return new(
            context.identifierListDot().GetText(),
            context.groupImportItemList().groupImportItem().Select(x => (x.name.Text, x.alias?.Text)).ToList()
        );
    }

    public override IEnumerable<ImportStatementModel> VisitNamespaceImport(
        RaccoonLangParser.NamespaceImportContext context)
    {
        yield return new(context.GetText(), new());
    }
}