' COURSE CODE: SPH 4U1
' SECTION: 02
' Submitted to: Mr. Cuschieri
' Created by: Dexter Floreza, David Antao, & Christopher Chua
' Date: Thursday October 18, 2018.
' Name of Form: IsraeliTrajectorySoftware2
' 
' Main Purpose: To provide a more user-friendly interface that calculates the trajectory of a missile needed to hit a target at a certain distance.
' This form also identifies risk, transmits a signal to control team, and simulates the missiles firing.

Imports System.Math

Public Class IsraeliTrajectorySoftware2

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit() ' Exits application
    End Sub

    Private Sub Button1_Click_(sender As Object, e As EventArgs) Handles Button1.Click
        Dim distance, dAngle, angle As Double
        ' Declaring variables needed to calculate angle

        ' The calculation process is simply the typical range equation
        ' with a vertical displacement of 0, manipulated to solve for the angle
        ' when given the initial velocity, acceleration due to gravity (-9.8m/s^2) 
        ' or in this case (9.8m/s^2), and the horizontal distance inputted as range
        ' by the user. 

        ' The initial velocity in this case is given to be 828 m/s, which is comparable with
        ' that of the Israeli Iron-Dome missile defense system.
        ' The length range of this particular projectile launch system is around 11 km.

        ' The angle in degrees found after converting from radians, and given to the user.
        distance = Val(textboxDistance.Text)
        dAngle = (Math.Asin(distance * 9.8 / 686000)) / 2
        angle = dAngle * (180 / 3.14)

        MsgBox("Trajectory Calculated. Identify risk and alert control team before firing. Then, you may fire when ready.", MsgBoxStyle.Information, "ATTENTION")
        Me.lblResult.Text = "Result: " & angle & "°" ' display trajectory 
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close() ' close button
    End Sub

    Private Sub lblFireMissiles_Click(sender As Object, e As EventArgs) Handles lblFireMissiles.Click
        ' When the fire missiles button is clicked by user
        ' Authentication procedure begins
        Dim result As Integer = MessageBox.Show("Missile Launch request received. Confirm launch request.", "ATTENTION", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then ' If user clicks cancel button
            MessageBox.Show("Missile Launch Request Cancelled.") 'display cancel msg
        ElseIf result = DialogResult.No Then ' if user clicks no button
            MessageBox.Show("Missile Launch Request Withdrawn.")
        ElseIf result = DialogResult.Yes Then ' if user clicks yes button
            MessageBox.Show("Missile Launch Request Confirmed.") 'User must confirm launch request
            Dim QuantityMissiles As String = InputBox("Enter to confirm quantity of missiles", "Message", "") 'User must confirm missile quantity to launch
            MessageBox.Show("Missile Quantity confirmed. " & QuantityMissiles & " missiles will be launched. All systems secure. Prepare for launch.", "ATTENTION") 'User gets notification that missile quantity is confirmed

            'missile launch sound begins
            Dim mpath As String
            Dim MissileSound As Media.SoundPlayer
            ' declare variables
            'access sound file on path
            mpath = "C:\Users\DeRya\Desktop\SPH 4U1\Sound Effect - Missile Launch.wav"
            MissileSound = New Media.SoundPlayer(mpath)
            MissileSound.Play() ' play missile launch sound effect

        End If
    End Sub

    Private Sub lblControlTeam_Click(sender As Object, e As EventArgs) Handles lblControlTeam.Click
        ' When the control team button is clicked by the user
        MsgBox("Information transmitted to control team. Signal transmission in progress.", MsgBoxStyle.Exclamation, "ATTENTION")
        Me.lblStatus.Text = "Signal transmitted to control team." ' Transmits signal 

        ' Signal sound
        Dim signalPath As String
        Dim signalSound As Media.SoundPlayer

        signalPath = "C:\Users\DeRya\Desktop\SPH 4U1\Apple iOS Ringtones - Sonar.wav"
        signalSound = New Media.SoundPlayer(signalPath)
        signalSound.Play() ' play signal sound effect
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ' When identify risk button is clicked
        Dim statNumber As Integer

        statNumber = Int((3 - 1 + 1) * Rnd() + 1)
        If statNumber = 1 Then
            Me.lblRiskStatus.Text = "Low."
            lblRiskStatus.BackColor = Color.LightGreen
            MsgBox("RISK STATUS LOW. Incoming missile headed towards open land.")
        ElseIf statNumber = 2 Then
            Me.lblRiskStatus.Text = "Medium."
            lblRiskStatus.BackColor = Color.Yellow
            MsgBox("RISK STATUS MEDIUM. Incoming missile headed towards suburbia and key point around border.")
        ElseIf statNumber = 3 Then
            Me.lblRiskStatus.Text = "HIGH."
            lblRiskStatus.BackColor = Color.Red
            MsgBox("RISK STATUS HIGH. Incoming missile headed towards military bases, factories, energy plants, and population centres. Take action now.")

            'Alert risk sound effect
            Dim spath As String
            Dim sirenSound As Media.SoundPlayer

            spath = "C:\Users\DeRya\Desktop\SPH 4U1\siren alarm   sound effect.wav"
            sirenSound = New Media.SoundPlayer(spath)
            sirenSound.play()
        End If

    End Sub

End Class