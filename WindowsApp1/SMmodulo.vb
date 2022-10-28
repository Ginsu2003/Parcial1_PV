
Module SMmodulo

    Public aJugadores() As Jugadores = {}

    Public Class SoundTrack
        Private oPlayer As Object = CreateObject("WMPlayer.OCX")
        Public Sub PlayM(name As String)
            oPlayer.URL = name
            oPlayer.controls.play()
        End Sub
        Public Sub StopM()
            oPlayer.controls.stop()
        End Sub
    End Class
    Public Class Jugadores
        Private sNombre As String
        Private iPuntos As Integer
        Private sGame As String
        Private iCombo As Integer
        Private iTiempo As Integer
        Public Sub New(name As String, game As String, puntos As Integer, tiempo As Integer, combo As Integer)
            sNombre = name
            sGame = game
            iPuntos = puntos
            iTiempo = tiempo
            iCombo = combo
        End Sub

        Public Sub SetPuntos(puntos As Integer)
            iPuntos = puntos
        End Sub
        Public Sub SetTime(tiempo As Integer)
            iTiempo = tiempo
        End Sub
        Public Sub SetName(nombre As String)
            sNombre = nombre
        End Sub
        Public Sub SetGame(game As String)
            sGame = game
        End Sub
        Public Sub SetCombo(combo As Integer)
            iCombo = combo
        End Sub
        Public Function GetName()
            Return sNombre
        End Function
        Public Function GetPuntos()
            Return iPuntos
        End Function
        Public Function GetGame()
            Return sGame
        End Function
        Public Function GetTime()
            Return iTiempo
        End Function
        Public Function GetCombo()
            Return iCombo
        End Function
    End Class
    Function CargarPuntaje(game As String, puntos As Integer, tiempo As Integer, combo As Integer)
        Dim name As String
        name = InputBox("Ingrese su nombre", "Nuevo puntaje")
        If aJugadores.Length = 0 Then
            ReDim Preserve aJugadores(aJugadores.Length)
            aJugadores(aJugadores.Length - 1) = New Jugadores(name, game, puntos, tiempo, combo)
        Else
            For i = 0 To aJugadores.Length - 1
                If aJugadores(i).GetGame = game Then
                    With aJugadores(i)
                        If .GetPuntos < puntos Then
                            .SetName(name)
                            .SetPuntos(puntos)
                            .SetTime(tiempo)
                            .SetCombo(combo)
                        End If
                    End With
                Else
                    ReDim Preserve aJugadores(aJugadores.Length)
                    aJugadores(aJugadores.Length - 1) = New Jugadores(name, game, puntos, tiempo, combo)
                End If
            Next
        End If

        If GMenu.Button6.Enabled = False Then
            GMenu.Button6.Enabled = True
        End If

        Return 0
    End Function
End Module
