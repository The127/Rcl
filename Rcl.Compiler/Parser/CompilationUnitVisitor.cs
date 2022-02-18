using Rcl.Compiler.Models;

namespace Rcl.Compiler.Parser;

public class CompilationUnitVisitor : ParserVisitorBase<CompilationUnitModel>
{
    public override CompilationUnitModel VisitCompilationUnit(RaccoonLangParser.CompilationUnitContext context) =>
        new(
            new ImportsVisitor().VisitAll(context),
            context.@namespace().identifierListDot().GetText(),
            new TypeDeclarationsVisitor().VisitAll(context)
        );
}