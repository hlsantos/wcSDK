Option Strict Off
Option Explicit On
Module WildcatCompilerAPI
	
	'------------------------------------------------------------------------
	'Visual Basic Wildcat! SDK API v6.0.451.1
	'Copyright (c) 1998-2003 Santronics Software, Inc. All Rights Reserved.
	'
	'Automatically generated from wccdll-vb.h by CPP2BAS
	'------------------------------------------------------------------------
	
	Public Const MAX_PATH As Short = 260
	
	Public Const WCC_OUTPUT_WCX As Integer = &H1s
	Public Const WCC_OUTPUT_WCL As Integer = &H2s
	Public Const WCC_OUTPUT_REPORT As Integer = &H100s
	Public Const WCC_OUTPUT_MAP As Integer = &H200s
	Public Const WCC_OUTPUT_OPCODE As Integer = &H400s
	Public Const WCC_OUTPUT_DEPEND As Integer = &H800s
	Public Const WCC_OUTPUT_DUMP As Integer = &H10000000
	Public Const WCC_OUTPUT_SYMBOL As Integer = &H20000000
	Public Const WCC_REQ_DECLARE_OFF As Integer = &H10s
	
	'-- NEW --
	Public Const WCC_OUTPUT_WCX54 As Integer = &H20s
	Public Const WCC_OUTPUT_PREPROCESSOR As Integer = &H40s
	'--
	
	Public Const errNone As Short = 0
	Public Const errOpenInput As Short = 1
	Public Const errCreateOutput As Short = 2
	Public Const errSyntax As Short = 3
	Public Const errEndStatementExpected As Short = 4
	Public Const errNumberTooLarge As Short = 5
	Public Const errFloatNumber As Short = 6
	Public Const errStringNotTerminated As Short = 7
	Public Const errEqualsExpected As Short = 8
	Public Const errOpenParenExpected As Short = 9
	Public Const errCloseParenExpected As Short = 10
	Public Const errCommaExpected As Short = 11
	Public Const errTypeMismatch As Short = 12
	Public Const errThenExpected As Short = 13
	Public Const errElseNotAllowed As Short = 14
	Public Const errElseifNotAllowed As Short = 15
	Public Const errUntilWhileExpected As Short = 16
	Public Const errLoopNotAllowed As Short = 17
	Public Const errExitDoNotWithin As Short = 18
	Public Const errExitForNotWithin As Short = 19
	Public Const errDoForSubFunctionExpected As Short = 20
	Public Const errDuplicateLabel As Short = 21
	Public Const errLoopExpected As Short = 22
	Public Const errEndIfExpected As Short = 23
	Public Const errWendExpected As Short = 24
	Public Const errVariableExpected As Short = 25
	Public Const errWendNotAllowed As Short = 26
	Public Const errFunctionExpected As Short = 27
	Public Const errSubroutineExpected As Short = 28
	Public Const errFunctionSubExpected As Short = 29
	Public Const errIdentifierExpected As Short = 30
	Public Const errTypeCharacterIllegal As Short = 31
	Public Const errAsExpected As Short = 32
	Public Const errTypeNameExpected As Short = 33
	Public Const errTypeSpecificationIllegal As Short = 34
	Public Const errParameterListMismatch As Short = 35
	Public Const errParameterListFewer As Short = 36
	Public Const errParameterListMore As Short = 37
	Public Const errNoNestedFunctionSub As Short = 38
	Public Const errExitNotInMain As Short = 39
	Public Const errAsNotAllowed As Short = 40
	Public Const errDuplicateDefinition As Short = 41
	Public Const errDuplicateIdentifier As Short = 42
	Public Const errConstantExpressionRequired As Short = 43
	Public Const errArrayExpected As Short = 44
	Public Const errIntegerExpected As Short = 45
	Public Const errInvalidBounds As Short = 46
	Public Const errForExpected As Short = 47
	Public Const errFileModeExpected As Short = 48
	Public Const errAccessModeExpected As Short = 49
	Public Const errShareModeExpected As Short = 50
	Public Const errLenExpected As Short = 51
	Public Const errToExpected As Short = 52
	Public Const errNextExpected As Short = 53
	Public Const errNextNotAllowed As Short = 54
	Public Const errNextWithoutFor As Short = 55
	Public Const errCaseExpected As Short = 56
	Public Const errEndSelectExpected As Short = 57
	Public Const errCaseNotAllowed As Short = 58
	Public Const errElseIsExpected As Short = 59
	Public Const errStatementsNotAllowed As Short = 60
	Public Const errCaseOperatorExpected As Short = 61
	Public Const errEndSubFunctionExpected As Short = 62
	Public Const errExitFunctionExpected As Short = 63
	Public Const errExitSubExpected As Short = 64
	Public Const errEndFunctionExpected As Short = 65
	Public Const errEndSubExpected As Short = 66
	Public Const errUndeclaredIdentifier As Short = 67
	Public Const errEndTypeExpected As Short = 68
	Public Const errDuplicateTypeDefinition As Short = 69
	Public Const errTypeCharNotAllowed As Short = 70
	Public Const errStructExpected As Short = 71
	Public Const errFieldNameExpected As Short = 72
	Public Const errDynamicStringNotAllowed As Short = 73
	Public Const errParameterRequired As Short = 74
	Public Const errDefaultArgsNotInDefinition As Short = 75
	Public Const errWhenConditionExpected As Short = 76
	Public Const errDoExpected As Short = 77
	Public Const errEndWhenExpected As Short = 78
	Public Const errEndDialogExpected As Short = 79
	Public Const errControlTypeExpected As Short = 80
	Public Const errDialogVariableExpected As Short = 81
	Public Const errFieldRequiredWithControl As Short = 82
	Public Const errFieldNotAllowedWithControl As Short = 83
	Public Const errDialogTypeExpected As Short = 84
	Public Const errControlIdExpected As Short = 85
	Public Const errDialogFunction As Short = 86
	Public Const errDialogSub As Short = 87
	Public Const errStringAfterAlias As Short = 88
	Public Const errStringAfterLib As Short = 89
	Public Const errLibOnlyWithDeclare As Short = 90
	Public Const errFunctionResultSimple As Short = 91
	Public Const errFixedStringParameterNotAllowed As Short = 92
	Public Const errFunctionAlreadyDefined As Short = 93
	Public Const errCatchNotAllowed As Short = 94
	Public Const errLabelNotDeclared As Short = 95
	Public Const errFunctionNotDefined As Short = 96
	Public Const errInputOutputExpected As Short = 97
	Public Const errPositiveIdRequired As Short = 98
	Public Const errDialCommandRequired As Short = 99
	Public Const errNoLocalsInWhen As Short = 100
	Public Const errExpressionTooComplex As Short = 101
	Public Const errTooManyArguments As Short = 102
	Public Const errRipCommandExpected As Short = 103
	Public Const errStringExpected As Short = 104
	Public Const errTooMuchGlobalData As Short = 105
	Public Const errMath As Short = 106
	Public Const errLenOnlyWithRandom As Short = 107
	Public Const errFixedStringTooLong As Short = 108
	Public Const errByvalOnlyWithScalar As Short = 109
	Public Const errCantGetPutString As Short = 110
	Public Const errDynamicArrayExpected As Short = 111
	Public Const errModuleAlreadyDeclared As Short = 112
	Public Const errScalarValueExpected As Short = 113
	Public Const errStringAfterDll As Short = 114
	Public Const errPragmaEndifExpected As Short = 115
	Public Const errLastOrdinal As Short = 116
	
	Structure TScriptCompilerStatus
		Dim dwSize As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public status() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public MainFile() As Char
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public CurrentFile() As Char
		Dim TotalLines As Integer
		Dim CurrentLine As Integer
		Dim dwOptions As Integer
		Dim ErrorNumber As Integer
		<VBFixedArray(992)> Dim Reserved() As Integer
		
		'UPGRADE_TODO: "Initialize" must be called to initialize instances of this structure. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="B4BFF9E0-8631-45CF-910E-62AB3970F27B"'
		Public Sub Initialize()
			'UPGRADE_WARNING: Lower bound of array Reserved was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
			ReDim Reserved(992)
		End Sub
	End Structure
	
	Structure TScriptCompilerError
		Dim Number As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		'UPGRADE_NOTE: String was upgraded to String_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public String_Renamed() As Char ' FIXME VB TYPE name conflict
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(MAX_PATH),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=MAX_PATH)> Public Filename() As Char
		Dim LineNumber As Integer
		Dim FullLinePos As Integer
		Dim AdjustedPos As Integer
		'UPGRADE_WARNING: Fixed-length string size must fit in the buffer. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="3C1E4426-0B80-443E-B943-0627CD55D48B"'
		<VBFixedString(1024),System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray,SizeConst:=1024)> Public Line() As Char
	End Structure
	
	'UPGRADE_WARNING: Structure TScriptCompilerStatus may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function wccInit Lib "d:\wc5beta\wccdll.dll" (ByRef status As TScriptCompilerStatus, ByVal version As Short, ByVal regnum As String, ByVal sourceFileName As String, ByVal objectFileName As String, ByVal dwOptions As Integer) As Integer
	
	
	Declare Function wccDone Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer) As Integer
	
	'UPGRADE_WARNING: Structure TScriptCompilerStatus may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function wccProcess Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByRef status As TScriptCompilerStatus) As Integer
	
	'UPGRADE_WARNING: Structure TScriptCompilerError may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function wccGetError Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByRef ei As TScriptCompilerError) As Integer
	
	'UPGRADE_WARNING: Structure TScriptCompilerError may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function wccFindError Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByRef ei As TScriptCompilerError, ByVal address As Integer) As Integer
	
	Declare Function wccVersion Lib "d:\wc5beta\wccdll.dll" () As Integer
	
	'UPGRADE_WARNING: Structure TScriptCompilerStatus may require marshalling attributes to be passed as an argument in this Declare statement. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="C429C3A5-5D47-4CD9-8F51-74A1616405DC"'
	Declare Function wccGetStatus Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByRef status As TScriptCompilerStatus) As Integer
	
	Declare Function wccSetOptions Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByVal dwOptions As Integer) As Integer
	
	Declare Function wccGetOptions Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer) As Integer
	
	Declare Function wccMakeDependency Lib "d:\wc5beta\wccdll.dll" (ByVal source As String) As Boolean
	
	Declare Function wccSetIncludePath Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByVal szpath As String) As Integer
	
	Declare Function wccSetDefines Lib "d:\wc5beta\wccdll.dll" (ByVal sc As Integer, ByVal szdefines As String) As Integer
	
	Public Function TrimNull(ByRef item As String) As Object
		Dim pos As Short
		pos = InStr(item, Chr(0))
		If pos Then
			TrimNull = Left(item, pos - 1)
		Else
			'UPGRADE_WARNING: Couldn't resolve default property of object TrimNull. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			TrimNull = item
		End If
	End Function
	
	Public Function HexStr(ByRef i As Integer, ByRef size As Short) As String
		HexStr = Right("00000000" & Hex(i), size)
	End Function
End Module