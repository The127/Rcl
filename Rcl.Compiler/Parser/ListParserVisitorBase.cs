using Antlr4.Runtime.Tree;

namespace Rcl.Compiler.Parser;

public class ListParserVisitorBase<T> : RaccoonLangBaseVisitor<IEnumerable<T>>
{
    public override IEnumerable<T> Visit(IParseTree tree)
    {
        return tree == null ? Enumerable.Empty<T>() : base.Visit(tree);
    }

    protected override IEnumerable<T> AggregateResult(IEnumerable<T> aggregate, IEnumerable<T> nextResult)
    {
        aggregate ??= Enumerable.Empty<T>();
        nextResult ??= Enumerable.Empty<T>();
        return aggregate.Concat(nextResult);
    }

    public List<T> VisitAll(IParseTree tree) => base.Visit(tree).ToList();
}