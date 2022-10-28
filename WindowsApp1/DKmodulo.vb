Module DKmodulo
    Public time = 0
    Public random As Integer
    'aca delacaro el randomx porque lo voy a usar en distintos eventos
    Public randomX As Integer
    Public aciertos = 0
    Public errores = 0
    Public tiempoTranscurrido = 0
    Public ContadorVidas = 0
    Public ContadorErrores = 0
    Public ContadorAciertos = 0
    Public combo As Integer
    Public maxCombo As Integer




    Function PosicionDeObjetos()
        With DKform
            'bananas comunes y rancias
            .PictureBox1.SetBounds(0, 20, 40, 50)
            .PictureBox2.SetBounds(150, 20, 40, 50)
            .PictureBox3.SetBounds(300, 20, 40, 50)
            .PictureBox4.SetBounds(450, 20, 40, 50)
            .PictureBox5.SetBounds(600, 20, 40, 50)
            .PictureBox6.SetBounds(750, 20, 40, 50)
            'barriles
            .PictureBox8.SetBounds(randomX, 20, 50, 60)
            .PictureBox9.SetBounds(randomX + 200, 20, 50, 60)
            .PictureBox10.SetBounds(randomX + 700, 20, 50, 60)
            .PictureBox11.SetBounds(randomX, 900, 50, 60)
            'mono
            .PictureBox7.SetBounds(400, 390, 100, 100)
        End With

        Return 0
    End Function

    Function ContadorDeVidas()
        With DKform
            Select Case ContadorVidas
                Case 1
                    .PictureBox16.Visible = False
                Case 2
                    .PictureBox15.Visible = False
                Case 3
                    .PictureBox14.Visible = False
                Case 4
                    .PictureBox13.Visible = False
                Case 5
                    .PictureBox12.Visible = False
                    TimeStop()
                    .PictureBox17.Visible = True
                    DKpuntos.Show()
            End Select
        End With
        Return 0
    End Function

    Function AccionColosionBarriles()
        TimeStop()
        OcultarObjetos()
        DKpuntos.Show()
        CargarPuntaje("DKK", ContadorAciertos, tiempoTranscurrido, maxCombo)
        PosicionDeObjetos()
        Return 0
    End Function

    Function Colisiones()
        'colision  
        With DKform
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox1.Bounds) Then
                .PictureBox1.Visible = False
                .PictureBox1.Location = New Point(.PictureBox1.Location.X, 800)
                ContadorAciertos += 1
                combo += 1
            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox2.Bounds) Then
                .PictureBox2.Visible = False
                .PictureBox2.Location = New Point(.PictureBox2.Location.X, 800)
                ContadorAciertos += 1
                combo += 1

            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox3.Bounds) Then
                .PictureBox3.Visible = False
                .PictureBox3.Location = New Point(.PictureBox3.Location.X, 800)
                ContadorVidas += 1
                If maxCombo < combo Then
                    maxCombo = combo
                End If
                combo = 0


            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox4.Bounds) Then
                .PictureBox4.Visible = False
                .PictureBox4.Location = New Point(.PictureBox4.Location.X, 800)
                ContadorAciertos += 1
                combo += 1

            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox5.Bounds) Then
                .PictureBox5.Visible = False
                .PictureBox5.Location = New Point(.PictureBox5.Location.X, 800)
                ContadorVidas += 1
                If maxCombo < combo Then
                    maxCombo = combo
                End If
                combo = 0


            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox6.Bounds) Then
                .PictureBox6.Visible = False
                .PictureBox6.Location = New Point(.PictureBox6.Location.X, 800)
                ContadorAciertos += 1
                combo += 1
            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox8.Bounds) Then
                AccionColosionBarriles()

            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox9.Bounds) Then
                AccionColosionBarriles()

            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox10.Bounds) Then
                AccionColosionBarriles()

            End If
            If .PictureBox7.Bounds.IntersectsWith(.PictureBox11.Bounds) Then
                AccionColosionBarriles()

            End If
        End With
        Return 0
    End Function

    Function OcultarObjetos()
        With DKform
            .PictureBox1.Visible = False
            .PictureBox2.Visible = False
            .PictureBox3.Visible = False
            .PictureBox4.Visible = False
            .PictureBox5.Visible = False
            .PictureBox6.Visible = False
            .PictureBox7.Visible = False
            .PictureBox8.Visible = False
            .PictureBox9.Visible = False
            .PictureBox10.Visible = False
            .PictureBox11.Visible = False
            .PictureBox12.Visible = False
            .PictureBox13.Visible = False
            .PictureBox14.Visible = False
            .PictureBox15.Visible = False
            .PictureBox16.Visible = False
        End With

        Return 0
    End Function

    Function MostrarObjetosYbottonInicio()
        With DKform
            .PictureBox1.Visible = True
            .PictureBox2.Visible = True
            .PictureBox3.Visible = True
            .PictureBox4.Visible = True
            .PictureBox5.Visible = True
            .PictureBox6.Visible = True
            .PictureBox7.Visible = True
            .PictureBox8.Visible = True
            .PictureBox9.Visible = True
            .PictureBox10.Visible = True
            .PictureBox11.Visible = True
            .PictureBox12.Visible = True
            .PictureBox13.Visible = True
            .PictureBox14.Visible = True
            .PictureBox15.Visible = True
            .PictureBox16.Visible = True
            .PictureBox17.Visible = False
        End With
        Return 0
    End Function

    Function TimeStart()
        With DKform
            '.Timer1.Start()
            .Timer1.Enabled = True
            '.Timer1.Interval = 100

            ' .Timer2.Start()
            .Timer2.Enabled = True
            '.Timer2.Interval = 1000

            '.Timer3.Start()
            .Timer3.Enabled = True
            '.Timer3.Interval = 1000

            .PictureBox16.Visible = True
            .PictureBox15.Visible = True
            .PictureBox14.Visible = True
            .PictureBox13.Visible = True
            .PictureBox12.Visible = True
        End With

        Return 0
    End Function

    Function TimeStop()
        PosicionDeObjetos()
        OcultarObjetos()
        With DKform
            .Timer1.Stop()
            .Timer2.Stop()
            .Timer3.Stop()
        End With
        ContadorVidas = 0

        Return 0
    End Function

    Function Movimiento()
        With DKform
            If .PictureBox1.Location.Y <= 450 Then
                .PictureBox1.Location = New Point(.PictureBox1.Location.X, .PictureBox1.Location.Y + random + 1)
            End If
            If .PictureBox2.Location.Y <= 450 Then
                .PictureBox2.Location = New Point(.PictureBox2.Location.X, .PictureBox2.Location.Y + random + 4)
            End If
            If .PictureBox3.Location.Y <= 450 Then
                .PictureBox3.Location = New Point(.PictureBox3.Location.X, .PictureBox3.Location.Y + random * 1 / 5)
            End If
            If .PictureBox4.Location.Y <= 450 Then
                .PictureBox4.Location = New Point(.PictureBox4.Location.X, .PictureBox4.Location.Y + random + 5)
            End If
            If .PictureBox5.Location.Y <= 450 Then
                .PictureBox5.Location = New Point(.PictureBox5.Location.X, .PictureBox5.Location.Y + random * 1 / 2)
            End If
            If .PictureBox6.Location.Y <= 450 Then
                .PictureBox6.Location = New Point(.PictureBox6.Location.X, .PictureBox6.Location.Y + random + 3)
            End If
            If .PictureBox8.Location.Y <= 450 Then
                .PictureBox8.Location = New Point(.PictureBox8.Location.X, .PictureBox8.Location.Y + random * 1 / 2)
            End If
            If .PictureBox9.Location.Y <= 450 Then
                .PictureBox9.Location = New Point(.PictureBox9.Location.X, .PictureBox9.Location.Y + random * 1 / 6)
            End If
            If .PictureBox10.Location.Y <= 450 Then
                .PictureBox10.Location = New Point(.PictureBox10.Location.X, .PictureBox10.Location.Y + random * 1 / 10)
            End If
            If .PictureBox11.Location.Y <= 450 Then
                .PictureBox11.Location = New Point(.PictureBox11.Location.X, .PictureBox11.Location.Y + random * 1 / 4)
            End If
        End With
        Return 0
    End Function

    Function Perimetro()
        With DKform
            If .PictureBox1.Location.Y > 450 Then
                .PictureBox1.Visible = False
                .PictureBox1.Location = New Point(randomX + 200, 20)
                .PictureBox1.Visible = True
                ContadorErrores += 1
            End If
            If .PictureBox2.Location.Y > 450 Then
                .PictureBox2.Visible = False
                .PictureBox2.Location = New Point(randomX + 450, 20)
                .PictureBox2.Visible = True
                ContadorErrores += 1
            End If
            If .PictureBox3.Location.Y > 450 Then
                .PictureBox3.Visible = False
                .PictureBox3.Location = New Point(randomX + 100, 20)
                .PictureBox3.Visible = True

            End If
            If .PictureBox4.Location.Y > 450 Then
                .PictureBox4.Visible = False
                .PictureBox4.Location = New Point(randomX + 600, 20)
                .PictureBox4.Visible = True
                ContadorErrores += 1
            End If
            If .PictureBox5.Location.Y > 450 Then
                .PictureBox5.Visible = False
                .PictureBox5.Location = New Point(randomX + 500, 20)
                .PictureBox5.Visible = True

            End If
            If .PictureBox6.Location.Y > 450 Then
                .PictureBox6.Visible = False
                .PictureBox6.Location = New Point(randomX + 4, 20)
                .PictureBox6.Visible = True
                ContadorErrores += 1
            End If
            If .PictureBox8.Location.Y > 450 Then
                .PictureBox8.Visible = False
                .PictureBox8.Location = New Point(randomX + 100, 20)
                .PictureBox8.Visible = True

            End If
            If .PictureBox9.Location.Y > 450 Then
                .PictureBox9.Visible = False
                .PictureBox9.Location = New Point(randomX + 200, 20)
                .PictureBox9.Visible = True

            End If
            If .PictureBox10.Location.Y > 450 Then
                .PictureBox10.Visible = False
                .PictureBox10.Location = New Point(randomX + 650, 20)
                .PictureBox10.Visible = True

            End If
            If .PictureBox11.Location.Y > 450 Then
                .PictureBox11.Visible = False
                .PictureBox11.Location = New Point(randomX + 420, 20)
                .PictureBox11.Visible = True

            End If
        End With

        Return 0
    End Function
End Module
