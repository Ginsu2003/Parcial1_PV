Imports System.ComponentModel

Public Class GStats
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
    Function ResetLabel()
        Me.Label2.Text = "-"
        Me.Label6.Text = "-"
        Me.Label7.Text = "-"
        Me.Label8.Text = "-"
        Return 0
    End Function
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            resetLabel()
            For i = 0 To (aJugadores.Length - 1)
                If aJugadores(i).GetGame = "Simon" Then
                    Me.Label2.Text = aJugadores(i).GetName
                    Me.Label6.Text = aJugadores(i).GetPuntos
                    Me.Label7.Text = aJugadores(i).GetTime
                    Me.Label8.Text = aJugadores(i).GetCombo
                End If
            Next
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            resetLabel()
            For i = 0 To (aJugadores.Length - 1)
                If aJugadores(i).GetGame = "Speed" Then
                    Me.Label2.Text = aJugadores(i).GetName
                    Me.Label6.Text = aJugadores(i).GetPuntos
                    Me.Label7.Text = aJugadores(i).GetTime
                    Me.Label8.Text = aJugadores(i).GetCombo
                End If
            Next
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            resetLabel()
            For i = 0 To (aJugadores.Length - 1)
                If aJugadores(i).GetGame = "DKK" Then
                    Me.Label2.Text = aJugadores(i).GetName
                    Me.Label6.Text = aJugadores(i).GetPuntos
                    Me.Label7.Text = aJugadores(i).GetTime
                    Me.Label8.Text = aJugadores(i).GetCombo
                End If
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        GMenu.Show()
    End Sub

    Private Sub GStats_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        GMenu.Show()
    End Sub

    Private Sub GStats_Load(sender As Object, e As EventArgs) Handles Me.Load
        If RadioButton1.Checked = True Then
            For i = 0 To (aJugadores.Length - 1)
                If aJugadores(i).GetGame = "Speed" Then
                    Me.Label2.Text = aJugadores(i).GetName
                    Me.Label6.Text = aJugadores(i).GetPuntos
                    Me.Label7.Text = aJugadores(i).GetTime
                    Me.Label8.Text = aJugadores(i).GetCombo
                End If
            Next
        End If
    End Sub
End Class