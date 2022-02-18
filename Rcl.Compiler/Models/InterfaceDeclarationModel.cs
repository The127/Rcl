namespace Rcl.Compiler.Models;

public record InterfaceDeclarationModel(Modifier Modifier, TypeNameModel Name, List<FqtnModel> Parents, List<InterfaceMemberModel> Members) : TypeDeclarationModel(Modifier);