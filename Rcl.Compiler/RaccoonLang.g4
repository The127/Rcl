grammar RaccoonLang;

compilationUnit
    : importStatement* namespace? typeDeclaration*
    ;
    
importStatement
    : 'import' (
          namespaceImport
        | aliasImport
        | groupImport
    ) ';'
    ;
    
namespaceImport
    : identifierListDot
    ;
    
aliasImport
    : identifierListDot 'as' Identifier
    ;
    
groupImport
    : identifierListDot '{' groupImportItemList '}'
    ;
    
groupImportItem
    : name=Identifier ('as' alias=Identifier)?
    ;
    
groupImportItemList
    : groupImportItem (',' groupImportItem)* ','?
    ;
    
namespace
    : 'namespace' identifierListDot ';'
    ;
    
typeDeclaration
    : Modifier (
          functionDeclaration
        | interfaceDeclaration
        | classDeclaration
        | dataClassDeclaration
    )
    ;
    
Modifier
    : 'public' | 'private' | 'internal' | 'protected'
    ;
    
functionDeclaration
    : 'fn' fqtn name=typeName parameters functionBody
    ;
    
parameters
    : '('( parameter (',' parameter)*)? ')'
    ;
    
parameter
    : fqtn Identifier
    ;
    
functionBody
    : functionBlockBody
    | functionLambdaBody
    ;
    
functionBlockBody
    : blockExpression
    ;
    
functionLambdaBody
    : '=>' expression ';'
    ;
    
interfaceDeclaration
    : 'interface' typeName interfaceParents? interfaceBody
    ;
    
interfaceParents
    : 'extends' fqtn (',' fqtn)*
    ;
    
interfaceBody
    : '{' interfaceMember* '}'
    ;
    
interfaceMember
    : interfaceMethodOrFunction
    | interfaceProperty
    ;
    
interfaceMethodOrFunction
    : fn='fn'? fqtn name=Identifier interfaceMethodParameters ';'
    ;
    
interfaceMethodParameters
    : '(' (fqtn (',' fqtn)*)? ')'
    ;
    
interfaceProperty
    : fqtn name=Identifier interfacePropertyAccessors
    ;
    
interfacePropertyAccessors
    : autoAccessors
    | getOnlyAccessor
    | setOnlyAccessor
    | getAndSetAccessors
    ;
    
getAndSetAccessors
    : '{' 'get' ';' 'set' '}'
    ;
    
getOnlyAccessor
    : '{' 'get' '}'
    ;
    
setOnlyAccessor
    : '{' 'set' '}'
    ;

autoAccessors
    : ';'
    ;
    
classDeclaration
    : 'class' typeName classParents classBody
    ;
    
classParents
    : baseClass? interfaces?
    ;
    
interfaces
    : 'implements' fqtn (',' fqtn)*
    ;
    
baseClass
    : 'extends' fqtn
    ;
    
classBody
    : '{' classMember* '}'
    ;
    
classMember
    : Modifier (  
          classProperty
        | classMethodOrFunction
        | ctor
    )
    ;
    
ctor
    : 'new' parameters otherCtorCall? ctorBody
    ;
    
ctorBody
    : shortCtorBody
    | longCtorBody
    ;
    
shortCtorBody
    : ';'
    ;

longCtorBody
    : '{' statement* '}'
    ;
    
otherCtorCall
    : (name='this' | name='base') '(' expressionList ')'
    ;
    
classProperty
    : fqtn Identifier classPropertyAccessors initializer?
    ;
    
initializer
    : '=' expression ';'
    ;
    
classPropertyAccessors
    : autoAccessors
    | classPropertyFullAccessors
    | setOnlyAccessor
    | getOnlyAccessor
    ;
    
classPropertyFullAccessors
    : '{' fullGetAccessor ';' fullSetAccessor '}'
    ;
    
fullGetAccessor
    : Modifier? 'get' accessorBody?
    ;
    
fullSetAccessor
    : Modifier? 'set' accessorBody?
    ;
    
accessorBody
    : '{' statement* '}'
    ;
    
classMethodOrFunction
    : fn='fn'? fqtn typeName parameters functionBody
    ;
    
dataClassDeclaration
    : 'data' 'class' typeName dataClassBody
    ;
    
dataClassBody
    : ';'
    ;

// type names
fqtn
    : fqtnPart ('.' fqtnPart)* nullable='?'?
    ;
    
fqtnPart
    : Identifier fqtnGenericPart?
    ;
    
fqtnGenericPart
    : '<' fqtn (',' fqtn)* '>'
    ;

typeName
    : Identifier genericPart?
    ;
    
genericPart
    : '<' identifierListComma '>'
    ;
    
// statements
statement
    : loopStatement
    | expressionStatement
    | variableDeclarationStatement
    | mutChangeStatement
    | returnStatement
    ;
    
returnStatement
    : 'return' expression? ';'
    ;
    
mutChangeStatement
    : identifierListDot (op='=' | op='+=' | op='-=' | op='*=' | op='/=' | op='^=' | op='|=' | op='||=' | op='&=' | op='&&=' | op='??=' | op='%=') expression ';'
    ;
    
variableDeclarationStatement
    : mut='mut'? variableDeclaration ';'
    ;
    
variableDeclaration
    : ('var' | fqtn) Identifier '=' expression
    ;
    
loopStatement
    : 'loop' (
          whileLoop
        | foreachLoop
        | forLoop
    )? '{' statement* '}'
    ;
    
whileLoop
    : expression
    ;
    
foreachLoop
    : 'var' Identifier 'in' expression
    ;
    
forLoop
    : 'mut' variableDeclaration? ';' cond=expression? ';' inc=postExpression?
    ;
    
expressionStatement
    : expression ';'
    ;
    
// expressions
expression
    : nullCoalescingExpression
    ;
    
nullCoalescingExpression
    : condOrExpression ('??' condOrExpression)*
    ;
    
condOrExpression
    : condAndExpression ('||' condAndExpression)*
    ;
    
condAndExpression
    : boolOrExpression ('&&' boolOrExpression)*
    ;
    
boolOrExpression
    : boolXorExpression ('|' boolXorExpression)*
    ;
    
boolXorExpression
    : boolAndExpression ('^' boolAndExpression)*
    ;
    
boolAndExpression
    : equalityExpression ('&' equalityExpression)*
    ;
    
equalityExpression
    : relationalExpression ((op+='==' | op+='!=') relationalExpression)*
    ;
    
relationalExpression
    : shiftExpression ((op+='<' | op+='>' | op+='>=' | op+='<=') shiftExpression)*
    ;
    
shiftExpression
    : additiveExpression ((op+='<<' | op+='>' '>') additiveExpression)*
    ;
    
additiveExpression
    : multiplicativeExpression ((op+='+' | op+='-') multiplicativeExpression)*
    ;
    
multiplicativeExpression
    : rangeExpression ((op+='*' | op+='/' | op+='%') rangeExpression)*
    ;
    
rangeExpression
    : unaryExpression ('..' unaryExpression)?
    ;
    
unaryExpression
    : (op='+' | op='-' | op='!' | op='~' | op='++' | op='--')? accessorExpression
    ;
    
accessorExpression
    : indexerExpression ((op+='.' | op+='?.') indexerExpression)*
    ;
    
indexerExpression
    : term ('[' expression ']')*
    ;
    
term
    : postExpression
    | blockExpression
    | ifExpression
    | newExpression
    | literal
    | parExpression
    | functionCallExpression
    ;
    
functionCallExpression
    : fqtn'(' expressionList? ')'?
    ;

postExpression
    : (name=Identifier | 'this' | 'base') (op='++' | op='--')?
    ;
    
parExpression
    : '(' expression ')'
    ;
    
ifExpression
    : 'if' expression blockExpression elifPart* elsePart?
    ;
    
elifPart
    : 'elif' expression blockExpression
    ;
    
elsePart
    : 'else' blockExpression
    ;
    
newExpression
    : 'new' fqtn? '(' expressionList? ')'
    ;
    
literal
    : BoolLiteral
    | CharacterLiteral
    | StringLiteral
    | NumberLiteral
    ;

blockExpression
    : '{' statement* expression? '}'
    ;
    
expressionList
    : expression (',' expression)*
    ;
    
// identifiers    
identifierListComma
    : Identifier (',' Identifier)*
    ;
    
identifierListDot
    : (Identifier | 'this' | 'base') ('.' (Identifier | 'this' | 'base'))*
    ;
    
Identifier
    : IdentifierNamePart
    ;
    
fragment
IdentifierNamePart
    : [a-zA-Z_][a-zA-Z_]*
    ;
    
// literals
BoolLiteral
    : 'true' | 'false'
    ;
    
NumberLiteral
    : '-'? DecimalNumberLiteral
    | HexNumberLiteral
    | OctNumberLiteral
    | BinaryNumberLiteral
    ;

fragment
DecimalNumberLiteral
    : DecimalNumberPart
    | DecimalNumberPart? '.' DecimalNumberPart
    ;
    
fragment
DecimalNumberPart
    : [0-9][0-9_]*
    ;
    
fragment
HexNumberLiteral
    : '0x' HexNumberPart ('_' | HexNumberPart)*
    ;

fragment
HexNumberPart
    : [0-9a-fA-F]
    ;
    
fragment
OctNumberLiteral
    : '0o' OctalNumberPart ('_' | OctalNumberPart)*
    ;
    
fragment
OctalNumberPart
    : [0-7]
    ;
    
fragment
BinaryNumberLiteral
    : '0b' BinaryNumberPart ('_' | BinaryNumberPart)*
    ;
    
fragment
BinaryNumberPart
    : '0' | '1'
    ;

CharacterLiteral
    : '\'' SingleCharacter '\''
    | '\'' EscapedCharacter '\''
    ;
    
fragment
SingleCharacter
    : ~['\\]
    ;
    
StringLiteral
    : '"' StringCharacter* '"'
    ;
    
fragment
StringCharacter
    : ~["\\]
    | EscapedCharacter
    ;
    
fragment
EscapedCharacter
    : '\\' (
          [btnfr"'\\]
        | UnicodeEscape
    )
    ;
    
fragment
UnicodeEscape
    : 'u' HexNumberPart HexNumberPart HexNumberPart HexNumberPart
    ;
    
// ignored tokens
WhiteSpace
    :  [ \t\r\n\u000C]+ -> skip
    ;

SingleLineComment
    :   '/*' .*? '*/' -> skip
    ;

MultiLineComment
    :   '//' ~[\r\n]* -> skip
    ;
