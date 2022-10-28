Imports System.ComponentModel

Public Class SMform
    Dim opRand As Integer = 0
    Dim d As Integer
    Dim tiempo As Integer = 0
    Dim aLabels() As Label = {}
    Dim combo As Integer
    Dim maxcombo As Integer
    Dim aSimon() As Integer = {}
    Dim game As String = ""
    Dim contSimon As Integer = -1
    Dim vacio As Integer = 0
    Dim puntos As Integer
    Public agujero As Image = New Bitmap(Image.FromFile("Empty.png"), New Size(40, 20))
    Public diglett As Image = New Bitmap(Image.FromFile("Diglett.png"), New Size(40, 40))
    Function Reset(auxArray)
        For Each oLabel As Label In auxArray
            With oLabel
                .Image = agujero
            End With
        Next
        Return True
    End Function
    Function Siguiente() As Integer
        Label6.Text = tiempo
        Randomize()
        If opRand > 0 Then
            aLabels(opRand - 1).Image = agujero
        End If
        opRand = (-(aLabels.Length - 1) * Rnd() + aLabels.Length)
        aLabels(opRand - 1).Image = diglett
        Return 1
    End Function
    Public Sub Intento(a As Integer)
        If opRand = a Then
            combo += 1
            d += 10
            Siguiente()
        Else
            If maxcombo < combo Then
                maxcombo = combo
            End If
            combo = 0
            d -= 10
            tiempo -= 1
            If tiempo <= 0 Then
                Timer1.Enabled = False
                tiempo = 0
                Label6.Text = tiempo
                CargarPuntaje("Speed", d, 0, maxcombo)
            End If
            Label6.Text = tiempo
        End If
        Label5.Text = d
    End Sub
    Public Sub SimonNew()
        Dim test As Integer
        Randomize()
        'MsgBox(aSimon.Length)
        ReDim Preserve aSimon(aSimon.Length)
        test = (-3 * Rnd() + 4)
        aSimon(aSimon.Length - 1) = test
        Label1.Text = aSimon.Length

        If aSimon.Length Mod 2 = 0 Then
            Timer2.Interval = Timer2.Interval - 30%
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tiempo -= 1
        Label6.Text = tiempo
        If tiempo <= 0 Then
            Timer1.Enabled = False
            CargarPuntaje("Speed", d, 0, maxcombo)
        End If
    End Sub



    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If vacio = 0 Then
            If contSimon > -1 Then
                PictureBox1.Load("0.png")
            End If
            vacio = 1
        Else
            contSimon += 1
            If contSimon <= aSimon.Length - 1 Then
                Beep()
                Select Case aSimon(contSimon)
                    Case 1
                        PictureBox1.Load("1.png")
                    Case 2
                        PictureBox1.Load("2.png")
                    Case 3
                        PictureBox1.Load("3.png")
                    Case 4
                        PictureBox1.Load("4.png")
                End Select
            Else
                contSimon = 0
                PictureBox1.Enabled = True
                Timer2.Enabled = False
                'SimonNew()
            End If
            vacio = 0
        End If
    End Sub
    Public Sub SPG()
        If game <> "Speed" Then
            Dim j, k As Integer
            For i = 0 To aLabels.Length - 1
                Me.Controls.Remove(aLabels(i))
            Next
            PictureBox1.Visible = False
            Label1.Visible = False
            ReDim Preserve aLabels(8)
            For i = 0 To aLabels.Length - 1

                aLabels(i) = New Label
                k += 1
                If k = 4 Then
                    k = 1
                    j += 1
                End If
                With aLabels(i)
                    .Name = i + 1 ' Asignas el nombre del objeto
                    '.Text = i + 1    ' Asignas el texto del objeto
                    .Size = New System.Drawing.Size(40, 20) ' Asignas el tamaño del objeto
                    .Image = agujero
                    .ImageAlign = ContentAlignment.BottomCenter
                    .Location = New System.Drawing.Point(70 * k, 30 + 70 * j)  ' Asignas la posición del objeto
                    .Size = New System.Drawing.Size(40, 60)
                    '.BorderStyle = BorderStyle.FixedSingle
                    .TextAlign = ContentAlignment.MiddleCenter
                End With

                AddHandler aLabels(i).Click, AddressOf SpeedMem_Click   ' Asocias el evento al método SpeedMem_Click

                Me.Controls.Add(aLabels(i))  ' Agregas el Label al formulario.
            Next
            game = "Speed"
        End If

    End Sub
    Private Sub SpeedMem_Click(sender As Object, e As EventArgs)
        Intento(sender.name)
    End Sub
    Private Sub SpeedGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpeedGameToolStripMenuItem.Click
        SPG()
    End Sub
    Public Sub SSG()
        If game <> "Simon" Then
            For i = 0 To aLabels.Length - 1
                Me.Controls.Remove(aLabels(i))
                RemoveHandler aLabels(i).Click, AddressOf SpeedMem_Click
            Next
            Label1.Visible = True
            PictureBox1.Visible = True
            game = "Simon"
        End If
    End Sub
    Private Sub SimonSaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SimonSaysToolStripMenuItem.Click
        SSG()

    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        If Timer1.Enabled = False And game = "Speed" Then
            opRand = -1
            tiempo = 8
            Timer1.Enabled = True
            combo = 0
            maxcombo = 0
            Reset(aLabels)
            Siguiente()
        End If
        If Timer2.Enabled = False And game = "Simon" Then
            vacio = 1
            combo = 0
            maxcombo = 0
            puntos = 0
            ReDim aSimon(-1)
            SimonNew()
            Timer2.Enabled = True
            Timer4.Enabled = True
        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As MouseEventArgs) Handles PictureBox1.Click

        ' Obtenemos el punto donde se ha efectuado el clic
        '
        'PictureBox1.Enabled = False
        Dim pt As Point = e.Location
        Dim dentro As Double
        Dim r1 As Double = PictureBox1.Width / 2
        Dim r2 As Double = 25
        Dim xc As Double = PictureBox1.Width / 2
        Dim yc As Double = PictureBox1.Height / 2
        dentro = ((e.X - xc) ^ 2 + (e.Y - yc) ^ 2) ^ (1 / 2)
        If dentro < r2 Then
            'MessageBox.Show("Centro")
        Else
            If dentro < r1 Then
                'MessageBox.Show("Dentro")
                If e.X < xc Then
                    If e.Y < yc Then
                        PictureBox1.Load("1.png")
                        If aSimon(contSimon) = 1 Then
                            puntos += 20 + 10 * contSimon
                            Label6.Text = puntos
                            contSimon += 1

                        Else
                            Timer4.Enabled = False
                            CargarPuntaje("Simon", aSimon.Length, puntos, tiempo)
                            'Timer4.Enabled = False
                            contSimon = -1
                        End If
                    Else
                        PictureBox1.Load("3.png")
                        If aSimon(contSimon) = 3 Then
                            puntos += 20 + 10 * contSimon
                            Label6.Text = puntos
                            contSimon += 1
                        Else
                            Timer4.Enabled = False
                            CargarPuntaje("Simon", aSimon.Length, puntos, tiempo)

                            contSimon = -1
                        End If
                    End If
                Else
                    If e.Y < yc Then
                        PictureBox1.Load("2.png")
                        If aSimon(contSimon) = 2 Then
                            puntos += 20 + 10 * contSimon
                            Label6.Text = puntos
                            contSimon += 1
                        Else
                            Timer4.Enabled = False
                            CargarPuntaje("Simon", aSimon.Length, puntos, tiempo)
                            'Timer4.Enabled = False
                            contSimon = -1
                        End If
                    Else
                        PictureBox1.Load("4.png")
                        If aSimon(contSimon) = 4 Then
                            puntos += 20 + 10 * contSimon
                            Label6.Text = puntos
                            contSimon += 1
                        Else
                            Timer4.Enabled = False
                            CargarPuntaje("Simon", aSimon.Length, puntos, tiempo)
                            'Timer4.Enabled = False
                            contSimon = -1
                        End If
                    End If
                End If
            Else
                'MessageBox.Show("Fuera")
            End If
        End If



        Timer3.Enabled = True

        'PictureBox1.Enabled = True
        ' MessageBox.Show(pt.ToString())
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        PictureBox1.Load("0.png")
        'PictureBox1.Enabled = True
        Timer3.Enabled = False
        If contSimon > aSimon.Length - 1 Then
            PictureBox1.Enabled = False
            System.Threading.Thread.Sleep(100)
            SimonNew()
            vacio = 1
            contSimon = -1
            Timer2.Enabled = True
        End If

    End Sub

    Private Sub DonkeyKongToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonkeyKongToolStripMenuItem.Click
        Me.Hide()
        DKform.Show()
    End Sub

    Private Sub SMform_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Me.Hide()
        GMenu.Show()
    End Sub

    Private Sub SorteoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SorteoToolStripMenuItem.Click
        Me.Hide()
        NSform.Show()
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        tiempo += 1
        Label5.Text = tiempo
    End Sub

End Class
