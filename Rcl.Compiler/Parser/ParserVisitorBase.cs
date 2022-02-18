namespace Rcl.Compiler.Parser;

public class ParserVisitorBase<T> : RaccoonLangBaseVisitor<T>
{
    protected override T AggregateResult(T aggregate, T nextResult) => nextResult ?? aggregate;
}