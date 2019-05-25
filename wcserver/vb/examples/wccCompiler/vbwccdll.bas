Attribute VB_Name = "WildcatCompilerAPI"

'------------------------------------------------------------------------
'Visual Basic Wildcat! SDK API v6.0.451.1
'Copyright (c) 1998-2003 Santronics Software, Inc. All Rights Reserved.
'
'Automatically generated from wccdll-vb.h by CPP2BAS
'------------------------------------------------------------------------

Public Const MAX_PATH = 260

Public Const WCC_OUTPUT_WCX As Long = &H1
Public Const WCC_OUTPUT_WCL As Long = &H2
Public Const WCC_OUTPUT_REPORT As Long = &H100
Public Const WCC_OUTPUT_MAP As Long = &H200
Public Const WCC_OUTPUT_OPCODE As Long = &H400
Public Const WCC_OUTPUT_DEPEND As Long = &H800
Public Const WCC_OUTPUT_DUMP As Long = &H10000000
Public Const WCC_OUTPUT_SYMBOL As Long = &H20000000
Public Const WCC_REQ_DECLARE_OFF As Long = &H10

Public Const errNone = 0
Public Const errOpenInput = 1
Public Const errCreateOutput = 2
Public Const errSyntax = 3
Public Const errEndStatementExpected = 4
Public Const errNumberTooLarge = 5
Public Const errFloatNumber = 6
Public Const errStringNotTerminated = 7
Public Const errEqualsExpected = 8
Public Const errOpenParenExpected = 9
Public Const errCloseParenExpected = 10
Public Const errCommaExpected = 11
Public Const errTypeMismatch = 12
Public Const errThenExpected = 13
Public Const errElseNotAllowed = 14
Public Const errElseifNotAllowed = 15
Public Const errUntilWhileExpected = 16
Public Const errLoopNotAllowed = 17
Public Const errExitDoNotWithin = 18
Public Const errExitForNotWithin = 19
Public Const errDoForSubFunctionExpected = 20
Public Const errDuplicateLabel = 21
Public Const errLoopExpected = 22
Public Const errEndIfExpected = 23
Public Const errWendExpected = 24
Public Const errVariableExpected = 25
Public Const errWendNotAllowed = 26
Public Const errFunctionExpected = 27
Public Const errSubroutineExpected = 28
Public Const errFunctionSubExpected = 29
Public Const errIdentifierExpected = 30
Public Const errTypeCharacterIllegal = 31
Public Const errAsExpected = 32
Public Const errTypeNameExpected = 33
Public Const errTypeSpecificationIllegal = 34
Public Const errParameterListMismatch = 35
Public Const errParameterListFewer = 36
Public Const errParameterListMore = 37
Public Const errNoNestedFunctionSub = 38
Public Const errExitNotInMain = 39
Public Const errAsNotAllowed = 40
Public Const errDuplicateDefinition = 41
Public Const errDuplicateIdentifier = 42
Public Const errConstantExpressionRequired = 43
Public Const errArrayExpected = 44
Public Const errIntegerExpected = 45
Public Const errInvalidBounds = 46
Public Const errForExpected = 47
Public Const errFileModeExpected = 48
Public Const errAccessModeExpected = 49
Public Const errShareModeExpected = 50
Public Const errLenExpected = 51
Public Const errToExpected = 52
Public Const errNextExpected = 53
Public Const errNextNotAllowed = 54
Public Const errNextWithoutFor = 55
Public Const errCaseExpected = 56
Public Const errEndSelectExpected = 57
Public Const errCaseNotAllowed = 58
Public Const errElseIsExpected = 59
Public Const errStatementsNotAllowed = 60
Public Const errCaseOperatorExpected = 61
Public Const errEndSubFunctionExpected = 62
Public Const errExitFunctionExpected = 63
Public Const errExitSubExpected = 64
Public Const errEndFunctionExpected = 65
Public Const errEndSubExpected = 66
Public Const errUndeclaredIdentifier = 67
Public Const errEndTypeExpected = 68
Public Const errDuplicateTypeDefinition = 69
Public Const errTypeCharNotAllowed = 70
Public Const errStructExpected = 71
Public Const errFieldNameExpected = 72
Public Const errDynamicStringNotAllowed = 73
Public Const errParameterRequired = 74
Public Const errDefaultArgsNotInDefinition = 75
Public Const errWhenConditionExpected = 76
Public Const errDoExpected = 77
Public Const errEndWhenExpected = 78
Public Const errEndDialogExpected = 79
Public Const errControlTypeExpected = 80
Public Const errDialogVariableExpected = 81
Public Const errFieldRequiredWithControl = 82
Public Const errFieldNotAllowedWithControl = 83
Public Const errDialogTypeExpected = 84
Public Const errControlIdExpected = 85
Public Const errDialogFunction = 86
Public Const errDialogSub = 87
Public Const errStringAfterAlias = 88
Public Const errStringAfterLib = 89
Public Const errLibOnlyWithDeclare = 90
Public Const errFunctionResultSimple = 91
Public Const errFixedStringParameterNotAllowed = 92
Public Const errFunctionAlreadyDefined = 93
Public Const errCatchNotAllowed = 94
Public Const errLabelNotDeclared = 95
Public Const errFunctionNotDefined = 96
Public Const errInputOutputExpected = 97
Public Const errPositiveIdRequired = 98
Public Const errDialCommandRequired = 99
Public Const errNoLocalsInWhen = 100
Public Const errExpressionTooComplex = 101
Public Const errTooManyArguments = 102
Public Const errRipCommandExpected = 103
Public Const errStringExpected = 104
Public Const errTooMuchGlobalData = 105
Public Const errMath = 106
Public Const errLenOnlyWithRandom = 107
Public Const errFixedStringTooLong = 108
Public Const errByvalOnlyWithScalar = 109
Public Const errCantGetPutString = 110
Public Const errDynamicArrayExpected = 111
Public Const errModuleAlreadyDeclared = 112
Public Const errScalarValueExpected = 113
Public Const errStringAfterDll = 114
Public Const errPragmaEndifExpected = 115
Public Const errLastOrdinal = 116

Type TScriptCompilerStatus
  dwSize As Long
  status As String * MAX_PATH
  MainFile As String * MAX_PATH
  CurrentFile As String * MAX_PATH
  TotalLines As Long
  CurrentLine As Long
  dwOptions As Long
  ErrorNumber As Long
  Reserved(1 To 992) As Long
End Type

Type TScriptCompilerError
  Number As Long
  String As String * MAX_PATH
  Filename As String * MAX_PATH
  LineNumber As Long
  FullLinePos As Long
  AdjustedPos As Long
  Line As String * 1024
End Type

Declare Function wccInit Lib "d:\wc5beta\wccdll.dll" _
            (ByRef status As TScriptCompilerStatus, _
             ByVal version As Integer, _
             ByVal regnum As String, _
             ByVal sourceFileName As String, _
             ByVal objectFileName As String, _
             ByVal dwOptions As Long) As Long
             

Declare Function wccDone Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long) As Long

Declare Function wccProcess Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ByRef status As TScriptCompilerStatus) As Long

Declare Function wccGetError Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ei As TScriptCompilerError) As Long

Declare Function wccFindError Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ByVal ei As TScriptCompilerError, _
             ByVal address As Long) As Long

Declare Function wccVersion Lib "d:\wc5beta\wccdll.dll" () As Long

Declare Function wccGetStatus Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ByRef status As TScriptCompilerStatus) As Long

Declare Function wccSetOptions Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ByVal dwOptions As Long) As Long

Declare Function wccGetOptions Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long) As Long

Declare Function wccMakeDependency Lib "d:\wc5beta\wccdll.dll" _
            (ByVal source As String) As Boolean

Declare Function wccSetIncludePath Lib "d:\wc5beta\wccdll.dll" _
            (ByVal sc As Long, _
             ByVal szpath As String) As Long

Public Function TrimNull(item As String)
   Dim pos As Integer
   pos = InStr(item, Chr$(0))
   If pos Then
         TrimNull = Left$(item, pos - 1)
   Else: TrimNull = item
   End If
End Function

