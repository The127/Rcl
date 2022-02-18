namespace Rcl.Compiler.Models;

public record ClassDeclarationModel(Modifier Modifier, TypeNameModel Name, FqtnModel? Parent, List<FqtnModel> Interfaces, List<ClassMemberModel> Members) : TypeDeclarationModel(Modifier);