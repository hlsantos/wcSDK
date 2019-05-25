Option Strict Off
Option Explicit On

Friend Class Form1

    Inherits System.Windows.Forms.Form

    Private Sub CommandCompile_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CommandCompile.Click

        Dim sc As Integer
        Dim st As New TScriptCompilerStatus
        Dim srcName As String
        Dim ObjName As String
        Dim Options As Integer

        txtOutput.Text = ""

        Options = WCC_OUTPUT_WCX

        srcName = textMainFile.Text
        If srcName.Substring(srcName.Length - 4, 4).ToUpper = ".WCC" Then
            ObjName = srcName.Substring(0, srcName.Length - 4) & ".wcx"
        Else
            ObjName = srcName & ".wcx"
        End If
        txtOutput.Text = txtOutput.Text & "Initializing WCC Compiler ..."
        txtOutput.Refresh()
        sc = wccInit(st, 0, "", srcName, ObjName, Options)
        txtOutput.Text = txtOutput.Text & vbNewLine & "Starting compile of " & ObjName.Trim & " from " & srcName.Trim
        txtOutput.Text = txtOutput.Text & vbNewLine & "_________________________________________________" & vbNewLine
        txtOutput.Refresh()
        If (sc = 0) Then
            MsgBox("Error")
            txtOutput.Text = "! WCC DLL Error !"
            txtOutput.Refresh()
        Else
            Dim nlines As Short
            nlines = 0
            Dim LastFile As String
            LastFile = ""
            While (wccProcess(sc, st) <> 0)
                nlines = nlines + 1
                If nlines > 15 Then
                    nlines = 0
                    If st.Status <> LabelStatus.Text Then
                        LabelStatus.Text = st.Status.Trim
                        LabelStatus.Refresh()
                    End If
                    LabelTotalLines.Text = st.TotalLines.ToString.Trim
                    LabelTotalLines.Refresh()
                End If
                If LastFile <> st.CurrentFile Then
                    LastFile = st.CurrentFile
                    txtOutput.Text = txtOutput.Text & vbNewLine & "Compiling File:  " & st.CurrentFile & " ... "
                    txtOutput.Refresh()
                End If


            End While
            Dim ei As New TScriptCompilerError
            If (st.ErrorNumber = errNone) Then
                txtOutput.Text = txtOutput.Text & vbNewLine & "_________________________________________________" & vbNewLine
                txtOutput.Text = txtOutput.Text & vbNewLine & vbNewLine & "Successful compile"
                txtOutput.Text = txtOutput.Text & vbNewLine & "Total Lines Compiled:  " & st.TotalLines.ToString.Trim
                txtOutput.Refresh()
                LabelStatus.Text = ""
                LabelTotalLines.Text = st.TotalLines.ToString.Trim
            Else
                If (wccGetError(sc, ei) <> 0) Then
                    txtOutput.Text = txtOutput.Text & vbNewLine & "_________________________________________________" & vbNewLine
                    txtOutput.Text = txtOutput.Text & vbNewLine & "Total Lines compiled:  " & st.TotalLines.ToString.Trim
                    txtOutput.Text = txtOutput.Text & vbNewLine & vbNewLine & "=================================================================="
                    txtOutput.Text = txtOutput.Text & vbNewLine & "! Error == (" & st.ErrorNumber.ToString.Trim & ") " & ei.ErrorString.Trim
                    txtOutput.Text = txtOutput.Text & vbNewLine & "! Error == File:  " & ei.Filename.Trim
                    txtOutput.Text = txtOutput.Text & vbNewLine & "! Error == Line #:  " & ei.LineNumber.ToString.Trim
                    txtOutput.Text = txtOutput.Text & vbNewLine & "! Error == Code Line:  " & ei.Line.Trim
                    txtOutput.Text = txtOutput.Text & vbNewLine & "=================================================================="
                    LabelTotalLines.Text = st.TotalLines.ToString.Trim
                End If
            End If

            wccDone(sc)
        End If

    End Sub

End Class