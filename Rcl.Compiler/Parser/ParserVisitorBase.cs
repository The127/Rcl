using Antlr4.Runtime.Tree;

namespace Rcl.Compiler.Parser;

public class ParserVisitorBase<T> : RaccoonLangBaseVisitor<T>
{
    public override T Visit(IParseTree tree)
    {
        return tree == null ? default : base.Visit(tree);
    }

    protected override T AggregateResult(T aggregate, T nextResult) => nextResult ?? aggregate;
}