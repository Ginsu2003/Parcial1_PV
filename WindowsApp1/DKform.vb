Imports System.ComponentModel

Public Class DKform
    Dim music As New SoundTrack
    Private Sub DKform_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'damos el movimiento
        If e.KeyCode = Keys.Up Then
            PictureBox7.Top = PictureBox7.Top - 20
        End If
        If e.KeyCode = Keys.Down Then
            PictureBox7.Top = PictureBox7.Top + 20
        End If
        If e.KeyCode = Keys.Left Then
            PictureBox7.Left = PictureBox7.Left - 20
        End If
        If e.KeyCode = Keys.Right Then
            PictureBox7.Left = PictureBox7.Left + 20
        End If
        'restringimos el perimetro
        If PictureBox7.Location.X >= 700 Then
            PictureBox7.Left = PictureBox7.Left - 20
        End If
        If PictureBox7.Location.X <= -20 Then
            PictureBox7.Left = PictureBox7.Left + 20
        End If
        If PictureBox7.Location.Y >= 420 Then
            PictureBox7.Top = PictureBox7.Top - 20
        End If
        If PictureBox7.Location.Y <= 200 Then
            PictureBox7.Top = PictureBox7.Top + 20
        End If
        'colisiones mientras nos movemos
        Colisiones()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Randomize()


        'declaramos random entre 10 y 20 para que la velocidad sea aleatorea
        random = (21 * Rnd() + 10)

        randomX = (375 * Rnd() + 1)

        'movimiento 
        Movimiento()
        'restriccion de perimetro
        Perimetro()

        'Label1.Text = ContadorVidas
        ' Label2.Text = ContadorAciertos
        ' Label3.Text = ContadorErrores 



    End Sub

    Private Sub DKform_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        music.PlayM("DKt.mp4")
        OcultarObjetos()


        'posicionamos los picturebox(bananas) y damos altura y ancho con el metodo setbounds
        PosicionDeObjetos()

        'damos a los pictures un fondo verde para que combine
        PictureBox1.BackColor = Color.Transparent
        PictureBox2.BackColor = Color.Transparent
        PictureBox3.BackColor = Color.Transparent
        PictureBox4.BackColor = Color.Transparent
        PictureBox5.BackColor = Color.Transparent
        PictureBox6.BackColor = Color.Transparent
        PictureBox7.BackColor = Color.Transparent
        PictureBox8.BackColor = Color.Transparent
        PictureBox9.BackColor = Color.Transparent
        PictureBox10.BackColor = Color.Transparent
        PictureBox11.BackColor = Color.Transparent
        PictureBox12.BackColor = Color.Transparent
        PictureBox13.BackColor = Color.Transparent
        PictureBox14.BackColor = Color.Transparent
        PictureBox15.BackColor = Color.Transparent
        PictureBox16.BackColor = Color.Transparent
        PictureBox17.BackColor = Color.Transparent
        'posicionamos las estrellas y tamaño
        PictureBox12.SetBounds(25, 10, 20, 20)
        PictureBox13.SetBounds(50, 10, 20, 20)
        PictureBox14.SetBounds(75, 10, 20, 20)
        PictureBox15.SetBounds(100, 10, 20, 20)
        PictureBox16.SetBounds(125, 10, 20, 20)
        PictureBox17.SetBounds(250, 162.5, 300, 200)




        'posicionamos al monkey y damos alto y ancho
        PictureBox7.SetBounds(400, 390, 100, 100)
        'damos el tamaño al form dado por las dimensiones donde puede moverse el monkey
        Me.Size = New System.Drawing.Size(800, 525)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Colisiones()

        ContadorDeVidas()

    End Sub

    Private Sub PictureBox17_Click(sender As Object, e As EventArgs) Handles PictureBox17.Click

        MostrarObjetosYbottonInicio()
        combo = 0
        maxCombo = 0

        TimeStart()


    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        tiempoTranscurrido += 1
    End Sub

    Private Sub DKform_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        music.StopM()
        GMenu.Show()
    End Sub
End Class