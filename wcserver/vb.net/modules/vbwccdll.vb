Option Strict Off
Option Explicit On

Imports System.Runtime.InteropServices

Module vbwccCompiler

#Region "Credits ..."
    '------------------------------------------------------------------------
    'Visual Basic Wildcat! SDK API v6.0.451.1
    'Copyright (c) 1998-2003 Santronics Software, Inc. All Rights Reserved.
    '
    'Automatically generated from wccdll-vb.h by CPP2BAS
    '
    'Converted to Visual Basic .NET by Mark Bappe of S and T Software
    '------------------------------------------------------------------------
#End Region

#Region "Public Constants ..."
    Public Const MAX_PATH As Short = 260

    Public Const WCC_OUTPUT_WCX As Integer = &H1S
    Public Const WCC_OUTPUT_WCL As Integer = &H2S
    Public Const WCC_OUTPUT_REPORT As Integer = &H100S
    Public Const WCC_OUTPUT_MAP As Integer = &H200S
    Public Const WCC_OUTPUT_OPCODE As Integer = &H400S
    Public Const WCC_OUTPUT_DEPEND As Integer = &H800S
    Public Const WCC_OUTPUT_DUMP As Integer = &H10000000
    Public Const WCC_OUTPUT_SYMBOL As Integer = &H20000000
    Public Const WCC_REQ_DECLARE_OFF As Integer = &H10S

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
#End Region

#Region "Public Structures ..."
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TScriptCompilerStatus
        Public dwSize As Int32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Status As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public MainFile As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public CurrentFile As String
        Public TotalLines As Int32
        Public CurrentLine As Int32
        Public dwOptions As Int32
        Public ErrorNumber As Int32
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3688)> Public Reserved() As Char
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)> Public Structure TScriptCompilerError
        Dim Number As Int32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public ErrorString As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public Filename As String
        Dim LineNumber As Int32
        Dim FullLinePos As Int32
        Dim AdjustedPos As Int32
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1024)> Public Line As String
    End Structure
#End Region

#Region "DLL Imports ..."
    <DllImport("WCCDLL.DLL")> Public Function wccInit(ByRef status As TScriptCompilerStatus, ByVal version As Int16, ByVal regnum As String, ByVal sourceFileName As String, ByVal objectFileName As String, ByVal dwOptions As Int32) As Int32
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccDone(ByVal sc As Integer) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccProcess(ByVal sc As Integer, ByRef status As TScriptCompilerStatus) As Int32
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccGetError(ByVal sc As Integer, ByRef ei As TScriptCompilerError) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccFindError(ByVal sc As Integer, ByVal ei As TScriptCompilerError, ByVal address As Integer) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccVersion() As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccGetStatus(ByVal sc As Integer, ByRef status As TScriptCompilerStatus) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccSetOptions(ByVal sc As Integer, ByVal dwOptions As Integer) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccGetOptions(ByVal sc As Integer) As Integer
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccMakeDependency(ByVal source As String) As Boolean
    End Function

    <DllImport("WCCDLL.DLL")> Public Function wccSetIncludePath(ByVal sc As Integer, ByVal szpath As String) As Integer
    End Function
#End Region

End Module