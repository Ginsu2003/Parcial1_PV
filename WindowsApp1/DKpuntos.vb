Imports System.ComponentModel

Public Class DKpuntos
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Color.Transparent
        Label4.BackColor = Color.Transparent
        Label5.BackColor = Color.Transparent
        Label6.BackColor = Color.Transparent



        Label4.Text = ContadorAciertos
        Label5.Text = ContadorErrores
        Label6.Text = tiempoTranscurrido
        'CargarPuntaje("DKK", ContadorAciertos, tiempoTranscurrido, 0)

        PictureBox1.BackColor = Color.Transparent
        PictureBox2.BackColor = Color.Transparent

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        DKform.Show()
        Me.Close()
        DKform.PictureBox17.Visible = True
        PosicionDeObjetos()
        ContadorAciertos = 0
        ContadorErrores = 0
        tiempoTranscurrido = 0
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
        DKform.Close()
    End Sub

    Private Sub DKpuntos_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        GMenu.Show()
    End Sub

    Private Sub SpeedGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeedGameToolStripMenuItem.Click
        Me.Hide()
        SMform.Show()
        SMform.SPG()
        DKform.Close()



    End Sub

    Private Sub SimonSaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimonSaysToolStripMenuItem.Click
        Me.Hide()
        SMform.Show()
        SMform.SSG()
        DKform.Close()

    End Sub

    Private Sub DonkeyKongToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonkeyKongToolStripMenuItem.Click
        Me.Hide()
        NSform.Show()
        DKform.Close()
    End Sub
End Class