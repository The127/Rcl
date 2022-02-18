namespace Rcl.Compiler.Models;

public record FunctionDeclarationModel(Modifier Modifier, FqtnModel Type, TypeNameModel Name, List<ParameterModel> Parameters, ExpressionModel Body) : TypeDeclarationModel(Modifier);