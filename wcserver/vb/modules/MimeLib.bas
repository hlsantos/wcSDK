Attribute VB_Name = "WildcatMimeLibrary"
'//***********************************************************************
'// (c) Copyright 1998-2001 Santronics Software, Inc. All Rights Reserved.
'// This WCBASIC source is copyrighted by Santronics Software Inc. Any
'// modification made must retrained this copyright information.
'//-----------------------------------------------------------------------
'// File Name : mimelib.wch
'// Subsystem : mimelib.dll wcBASIC protocol header file
'// Date      : 07/11/2001
'// Author    : SSI
'//
'// Revision History:
'// Build  Date      Author  Comments
'// -----  --------  ------  ---------------------------------------------
'//***********************************************************************

'/////////////////////////////////////////////////////////////////////////
'// How to use mimelib.wch:
'//
'// The purpose of mimelib is to parse a Wildcat! message which may or
'// may not be in RFC MIME multipart format and break up the mail parts
'// into temporary files in the wcBASIC session TempPath directory.
'//
'// NEW 450.3! If you are using mimelib from outside wcBASIC, see
'//            the new CreateMimeObjectEx() function describing
'//            the issue with the work path.
'//
'// First, use CreateMimeObject() to create a "mime object" giving
'// it the msg conference and msg id numbers.  You can also tell it
'// which part (text or html) you want to save in the temporary
'// file called; tempPath+"mimemail.dat"
'//
'//    dim mobj as long = CreateMimeObject(conf,msgid,"html")
'//
'// This will allow you to read this file using the GetLocalText()
'// function (msgutil.wch)
'//
'//    dim body as string = GetLocalText(TempPath+"MimeMail.Dat")
'//
'// If no "html" part was found, then all text parts will be
'// saved in TempPath+"mimemail.dat".
'//
'// If there are other parts in the messages, you can use the
'// GetMimePartsCount() function to get the total number of parts.
'//
'// Use the GetMimeAttachmentCount() function to find out if there
'// any mime attachments (not wildcat attachments) in the message.
'//
'// Then use the various Get/Find Attachment functions to extract
'// file information.
'//
'// When you are finished, you must call DeleteMimeObject() to delete
'// the mime object.
'//
'//   DeleteMimeObject(mobj)
'//
'/////////////////////////////////////////////////////////////////////////

'//#include "windows.wch"

Type TMimeAttachmentInfo
   tempName As String * MAX_PATH
   RealName As String * MAX_PATH
   size As Long
   datetime As FileTime
End Type

'//---------------------------------------------------------------------
'// CreateMimeObject()
'//
'// Pass the msgarea and msgid and the part "html" or "text" to
'// create a mime message object.
'//
'// If successful, the function returns a non-zero object number and
'// the message mime parts be stored in the TempPath directory.
'//
'// If not successful, the function returns zero (0).
'//
'// The object must be deleted using DeleteMimeObject() when you
'// are done using the object.
'//---------------------------------------------------------------------

Declare Function CreateMimeObject Lib "mimelib.dll" _
   (ByVal msgarea As Long, _
    ByVal msgid As Long, _
    ByVal part As String) As Long

'//---------------------------------------------------------------------
'// NEW 450.3
'// CreateMimeObjectEx()
'//
'// Similar to CreateMimeObject(), this extended function allows
'// the work path to be defined by the calling process.
'//
'// By default, CreateMimeObject() assumes the "wcwork\nodeX"
'// work path to store the mime message file parts.
'//
'// If mimelib is being used by a wcBASIC application for a
'// logged in session, you don't need to use the extended function.
'// The wcBASIC core engine will automatically create the work path
'// for the current node.
'//
'// On the other hand, if mimelib is being used by external applets
'// (i.e, Visual Basic), you can use the extended function to defined
'// a work path.  You need to create this work path and clean it up
'// yourself.
'//
'//      myCreateWorkPathFunction("myWorkPath\")
'//      mobj = CreateMimeObjectEx(mh.conference,mh.id,"html","myWorkPath\")
'//      myDeleteWorkPathFunction("myWorkPath\")
'//
'// Note: If mimelib is being used with a wcBASIC application for a
'// non-node session, the wcBASIC core engine automatically creates
'// and removes the specific work path "wcwork\node0".
'//
'//---------------------------------------------------------------------

Declare Function CreateMimeObjectEx Lib "mimelib.dll" _
   (ByVal msgarea As Long, _
    ByVal msgid As Long, _
    ByVal part As String, _
    ByVal path As String) As Long

'//---------------------------------------------------------------------
'// DeleteMimeObject(obj)
'//
'// Deletes the mime object created with CreateMimeObject()
'//---------------------------------------------------------------------

Declare Function DeleteMimeObject Lib "mimelib.dll" _
   (ByVal obj As Long) As Long

'//---------------------------------------------------------------------
'// GetMimePartsCount()
'//
'// Returns the numbers of mime parts to the messages.  There should
'// always be atleast 1 part (tempPath+"MimeMail.dat") which means
'// the message was probably not a RFC MIME based message.
'//---------------------------------------------------------------------

Declare Function GetMimePartsCount Lib "mimelib.dll" _
   (ByVal obj As Long) As Long

'///////////////////////////////////////////////////////////////////////
'// GetMimeAttachmentCount()
'//
'// Returns the numbers of attachments in the messages.

Declare Function GetMimeAttachmentCount Lib "mimelib.dll" _
   (ByVal obj As Long) As Long

'///////////////////////////////////////////////////////////////////////
'// GetMimeAttachmentName(obj, idx, realname)
'//
'// Gets the real name of the attachment by its attachment index.
'//
'// Return TRUE if the mime attachment part was found.
'// Return FALSE if the obj was invalid or the index was not found.
'//
'// Note: Attachments are stored in the tempPath under their
'// temporary file name.

Declare Function GetMimeAttachmentName Lib "mimelib.dll" _
   (ByVal obj As Long, _
    ByVal idx As Long, _
    pszRealName As Long) As Boolean

'//---------------------------------------------------------------------
'// GetMimeAttachmentInfo()
'//
'// Get the TMimeAttachmentInfo Structure of the attachment by
'// attachment index, 1 to GetMimeAttachmentTotal().
'//
'// Return TRUE if found, otherwise FALSE
'//---------------------------------------------------------------------

Declare Function GetMimeAttachmentInfo Lib "mimelib.dll" _
   (ByVal obj As Long, _
    ByVal idx As Long, _
    info As TMimeAttachmentInfo) As Boolean

'//---------------------------------------------------------------------
'// FindMimeAttachmentTempName()
'//
'// Searches for the real name in the list of attachments and
'// gets the name of the temporary file in the TempPath directory.
'//
'// If found, returns the attachment index otherwise return 0.
'//
'//---------------------------------------------------------------------

Declare Function FindMimeAttachmentTempName Lib "mimelib.dll" _
   (ByVal obj As Long, _
    ByVal RealName As String, _
    pszTempName As Long) As Long

'//---------------------------------------------------------------------
'// FindMimeAttachmentIndex()
'//
'// Searches for the real name in the list of attachments and
'// returns the attachment index. If not found, return 0.
'//
'// Optional CopyPath:  If the location CopyPath is non blank,
'// the attachment will be copied to this location.
'//---------------------------------------------------------------------

Declare Function FindMimeAttachmentIndex Lib "mimelib.dll" _
   (ByVal obj As Long, _
    ByVal RealName As String, _
    ByVal Copypath As String) As Long


'//---------------------------------------------------------------------
'// CreateMimeObjectWorkPath(workpath)
'// DeleteMimeObjectWorkPath(workpath)
'//
'// These functions are used to create and remove the work path
'// where MIMELIB will place the mime file part when you call
'// CreateMimeObjectEx().
'//
'// You don't need to call these functions if you are using wcBASIC
'// since the work path is always managed by the wcBASIC core engine.
'// Outside of wcBASIC, you can create and  remove your own work path
'// or use this helper functions.
'//
'// See the extended function CreateMimeObjectEx()
'//
'// Example usage:
'//
'//   CreateMimeObjectWorkPath("myWorkPath\");
'//   mobj = CreateMimeObjectEx(mh.conference,mh.id,"html","myWorkPath\")
'//   ...
'//   DeleteMimeObject(mobj)
'//   DeleteMimeObjectWorkPath("myWorkPath\");
'//
'// WARNING: Be careful with DeleteMimeObjectWorkPath()! It will DELETE
'// all the files in the directory before removing the directory if the
'// parameter FilesToo is passed as TRUE.  Technically, you should pass
'// FALSE because when you delete the mime object (DeleteMimeObject)
'// the temporary mime file parts are automatically deleted.  So by the
'// time you call DeleteMimeObjectWorkPath() there should be an empty
'// directory.
'//
'//---------------------------------------------------------------------

Declare Function CreateMimeObjectWorkPath Lib "mimelib.dll" _
   (ByVal workpath As String) As Boolean


Declare Sub DeleteMimeObjectWorkPath Lib "mimelib.dll" _
   (ByVal workpath As String, _
    ByVal filesToo As Long)
