namespace Rcl.Compiler.Models;

public record DataClassDeclarationModel(Modifier Modifier, TypeNameModel Name, List<DataClassMemberModel> Members) : TypeDeclarationModel(Modifier);