'// ------------------------------------------------------------------------
'// (c) Copyright 1998-2026 by Santronics Software Inc. All Rights Reserved.
'// Wildcat! SDK API v10.0.500.3
'//
'// RETIRED -- this module is no longer maintained.
'//
'// VB.NET uses the same Wildcat! .NET bindings as C#, from one assembly:
'//
'//     WinServerAPI.dll   built by ..\..\c#\WinServerAPI\WinServerAPI.csproj
'//                        from c#\includes\wcServerAPI.cs and wcMakeWildAPI.cs
'//
'// To use it from VB.NET:
'//
'//   1. Add a reference to WinServerAPI.csproj (or WinServerAPI.dll).
'//   2. At the top of each source file:
'//
'//          Imports wcSDK.wcServerAPI
'//          Imports wcSDK.wcMakeWildAPI      ' for the Mw* functions
'//
'//      The functions, constants and structures are then used unqualified,
'//      exactly as they were with this module.
'//
'// See vb.net\examples\wcChat.net and vb.net\examples\BSMiniRPT.NET.
'//
'// The previous hand-maintained copy of this module had drifted from the
'// wcSDK headers (wrong TMakewild size, missing functions) and is not
'// carried forward.
'// ------------------------------------------------------------------------
