Public Class Game4



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = True
        Randomize()
        Dim valor As Integer
        valor = (-9 * Rnd() + 10)
        TextBox2.Text = valor

        NumericUpDown1.Enabled = False
        If NumericUpDown1.Value = valor Then
            MessageBox.Show("FELICIDADES GANASTE UN PREMIO")
        Else
            MessageBox.Show("!PARA RECUPERAR TU ALMA DEBES CONTESTAR ESTE ACERTIJO Y ES POR TIEMPO! ")
            MessageBox.Show("¿Qué es lo primero que le mete un hombre a su mujer cuando se casan?")
            Timer1.Start()

        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label4.Text = Val(Label4.Text) + 1
        If Val(Label4.Text = 100) Then
            Timer1.Stop()



        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        NumericUpDown1.Enabled = True

        NumericUpDown1.Value = 0


        Button1.Enabled = True
        TextBox2.Text = 0
        Label4.Text = 0
        Timer1.Stop()



    End Sub


End Class


