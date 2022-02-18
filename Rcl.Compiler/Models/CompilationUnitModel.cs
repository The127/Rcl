namespace Rcl.Compiler.Models;

public record CompilationUnitModel(List<ImportStatementModel> ImportStatementModels, string Namespace,
    List<TypeDeclarationModel> Types) : ModelBase;