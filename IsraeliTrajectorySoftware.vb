' COURSE CODE: SPH 4U1
' SECTION: 02
' Submitted to: Mr. Cuschieri
' Created by: Dexter Floreza, David Antao, & Christopher Chua
' Date: Thursday October 18, 2018.
' Name of Form: IsraeliTrajectorySoftware
' 
' Main Purpose: To provide a title screen for the missile calculation software.
Public Class formTrajectoryCalculationSoftware
    Dim hebrewLanguage As Boolean = False
    ' Store basic yes no setting 

    Private Sub HebrewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HebrewToolStripMenuItem.Click
        Me.lblTitle.Text = "תוכנה לחישוב מסלול הטילים הישראלי"
        Me.lblPassword.Text = "סיסמה"
        Me.lblMessage.Text = "הזן את קוד ההרשאה."
        Me.btnLogin.Text = "התחברות"
        ProgramToolStripMenuItem.Text = "עִברִית"
        hebrewLanguage = True
    End Sub

    Private Sub EnglishToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnglishToolStripMenuItem.Click
        Me.lblTitle.Text = "Israeli Missile Trajectory Software"
        Me.lblPassword.Text = "Password:"
        Me.lblMessage.Text = "Please enter the 8 digit authorization code."
        Me.btnLogin.Text = "Login"
        ProgramToolStripMenuItem.Text = "Program"
        hebrewLanguage = False
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If textboxPassword.Text = "12345678" Then
            If hebrewLanguage = False Then ' For English successful login
                MsgBox("You are now logged in.", MsgBoxStyle.Information, "Login")
                Me.Hide()
                IsraeliTrajectorySoftware2.Show()
            Else ' For Hebrew successful login
                MsgBox("כעת אתה מחובר.", MsgBoxStyle.Information, "התחברות")
                Me.Hide()
                IsraeliTrajectorySoftware2.Show()
            End If
        Else
            If hebrewLanguage = False Then  ' For English failed login
                MsgBox("UNAUTHORIZED ENTRY DENIED. YOUR LOCATION HAS BEEN TRACKED AND " & _
                       "YOU WILL BE TERMINATED IN T-5 MINUTES. HAVE A NICE DAY.", MsgBoxStyle.Information, "ATTENTION")
                Application.Exit()
            Else ' For Hebrew Failed Login 
                MsgBox("כניסה לא מאושרת. המיקום שלך נעצר ואתה תבוטל ב- T-5" & _
                       "דקות. יש לך יום נייס.", MsgBoxStyle.Information, "תְשׁוּמַת לֵב")
                Application.Exit()
            End If


        End If
    End Sub

End Class
