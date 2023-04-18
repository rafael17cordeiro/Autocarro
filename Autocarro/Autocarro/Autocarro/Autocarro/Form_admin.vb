Imports System.Threading
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
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
    Dim str_lugares(15) As String
    Dim lugares_button(8, 3) As BunifuImageButton
    Private Sub Form_admin_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.White, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub
    Private Sub Form_admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim aux As Integer
        Dim x As Integer
        Dim y As Integer
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
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
                lugares_button(i, j).Visible = False
                lugares_button(i, j).BackColor = Color.White
                lugares_button(i, j).Cursor = Cursors.Hand

                lugares_button(i, j).Image = My.Resources.seats
                lugares_button(i, j).Size = New Size(35, 35)
                lugares_button(i, j).Location = New Point(x, y)



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

                Panel2.Controls.Add(lugares_button(i, j))
                lugares_button(i, j).BringToFront()
                AddHandler lugares_button(i, j).Click, AddressOf Selected
            Next

        Next
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
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        FileOpen(1, "total.txt", OpenMode.Input)
        Dim str As String = ""
        While Not EOF(1)
            str &= LineInput(1)
        End While
        FileClose(1)
        TextBox1.Text = str
    End Sub


    Dim cont As Integer
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
        TextBox1.Text = ""
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        TextBox1.Text = ""
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
        Dim nova_pass As String
        nova_pass = InputBox("Insira a nova senha para o admin!")
        If nova_pass = "" Then
            MsgBox("Senha inválida")
        Else
            BunifuCircleProgressbar1.Visible = True
            BunifuCircleProgressbar1.Value = 0


            Timer1.Interval = 10
            Timer1.Enabled = True




            FileOpen(2, "admin.txt", OpenMode.Output)
            Print(2, nova_pass)
            FileClose(2)

        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        BunifuCircleProgressbar1.Value += 1
        If BunifuCircleProgressbar1.Value = 100 Then

            Timer1.Enabled = False
            BunifuCircleProgressbar1.Visible = False
            MsgBox("Senha alterada com sucesso!")


        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        Dim linha As Integer
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        FileOpen(3, "vendas.txt", OpenMode.Input)
        Dim str As String = ""
        While Not EOF(3)

            str &= LineInput(3) & vbNewLine
            linha += 1
        End While
        FileClose(3)
        TextBox1.Text = str

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = True
            Next
        Next
        BunifuThinButton21.Visible = True
        BunifuThinButton22.Visible = True
    End Sub


    Sub Selected(ByVal sender As Object, e As EventArgs)
        If sender.tag = 0 Then
            sender.tag = 2
            sender.Image = My.Resources.check_mark



        ElseIf sender.tag = 2 Then
            sender.image = My.Resources.seats
            sender.tag = 0



        ElseIf sender.tag = 3 Then
            sender.tag = 4
            sender.Image = My.Resources.check_mark


        ElseIf sender.tag = 4 Then
            sender.image = My.Resources.seats
            sender.tag = 3


        ElseIf sender.tag = 1 Then
            MsgBox("O Lugar escolhido já está ocupado ")
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Dim lugares(8) As String
        Dim cont As Integer = 0
        Dim linha As Integer = 0


        FileOpen(1, "lugares.txt", OpenMode.Input)
        While Not EOF(1)
            lugares(linha) = LineInput(1)
            linha += 1
        End While
        FileClose(1)


        For i = 0 To 8
                For j = 0 To 3
                    If lugares_button(i, j).Tag = 2 Or lugares_button(i, j).Tag = 4 Then
                        lugares(i) = lugares(i).Substring(0, j) & "1" & lugares(i).Substring(j + 1)
                        cont += 1
                        lugares_button(i, j).Tag = 1
                        lugares_button(i, j).Image = My.Resources.not_seat
                        lugares_button(i, j).Cursor = Cursors.No
                        lugares_button(i, j).Tag = 1
                    End If
                Next
            Next

            FileOpen(2, "lugares.txt", OpenMode.Output)
            For i = 0 To 8
                PrintLine(2, lugares(i))
            Next
        FileClose(2)

        MsgBox("Lugares marcados com sucesso")
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        BunifuThinButton21.Visible = False
        BunifuThinButton22.Visible = False
        For i = 0 To 8
            For j = 0 To 3
                lugares_button(i, j).Visible = False
            Next
        Next
    End Sub
End Class