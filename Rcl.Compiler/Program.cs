using Antlr4.Runtime;
using Newtonsoft.Json;
using Rcl.Compiler.Parser;

var lexer = new RaccoonLangLexer(new AntlrFileStream("Samples/test.rcl"));
var parser = new RaccoonLangParser(new CommonTokenStream(lexer));
var compilationUnitModel = new CompilationUnitVisitor().Visit(parser.compilationUnit());

var settings = new JsonSerializerSettings()
{
    TypeNameHandling = TypeNameHandling.Objects,
};
var serializeObject = JsonConvert.SerializeObject(compilationUnitModel, Formatting.Indented, settings);
Console.WriteLine(serializeObject);