Imports Bunifu.Framework.UI

Public Class Form_admin

    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form_admin_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.White, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub
    Private Sub Form_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With Me

            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Close()
        Form_inicial.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        FileOpen(1, "total.txt", OpenMode.Input)
        Dim str As String = ""
        While Not EOF(1)
            str &= LineInput(1)
        End While
        FileClose(1)
        TextBox1.Text = str
    End Sub



    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        TextBox1.Text = ""

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim nova_pass As String
        nova_pass = InputBox("Insira o nova password para o admin !")
        If nova_pass = "" Then
            MsgBox("invalido")

        Else
            FileOpen(2, "admin.txt", OpenMode.Output)
            Print(2, nova_pass)
            FileClose(2)
            MsgBox("Password alterada com sucesso!")
        End If

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        FileOpen(3, "vendas.txt", OpenMode.Input)
        Dim str As String = ""
        While Not EOF(3)
            str &= LineInput(3) & vbNewLine
        End While
        FileClose(3)
        TextBox1.Text = str

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim aux As Integer
        Dim str_lugares(15) As String
        Dim lugares_button(8, 3) As BunifuImageButton
        Dim x As Integer
        Dim y As Integer
        FileOpen(1, "lugares.txt", OpenMode.Input)
        While Not EOF(1)
            str_lugares(aux) = LineInput(1)
            aux += 1
        End While
        FileClose(1)

        For i = 0 To 8
            y += 45
            x = 0
            For j = 0 To 3
                x += 40
                lugares_button(i, j) = New BunifuImageButton
                lugares_button(i, j).Cursor = Cursors.Hand
                lugares_button(i, j).BackColor = Color.Transparent
                lugares_button(i, j).Image = My.Resources.seats
                lugares_button(i, j).Size = New Size(35, 35)
                lugares_button(i, j).Location = New Point(x, y)

                If j = 0 Or j = 3 Then
                    lugares_button(i, j).Tag = 3 'preço é 30
                Else
                    lugares_button(i, j).Tag = 0 'preço é 15
                End If

                If j > 1 And i = 3 Then
                    lugares_button(i, j).Visible = False
                End If

                If j = 1 Then
                    x += 30
                End If

                If str_lugares(i)(j) = "1" Then
                    lugares_button(i, j).Image = My.Resources.not_seat
                    lugares_button(i, j).Cursor = Cursors.No
                    lugares_button(i, j).Tag = 1
                End If

                Me.Controls.Add(lugares_button(i, j))
                
            Next

        Next
    End Sub
End Class