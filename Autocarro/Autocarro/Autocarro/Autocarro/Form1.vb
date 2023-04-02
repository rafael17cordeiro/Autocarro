Imports System.Management
Imports System.Runtime.InteropServices
Imports Bunifu.Framework.[Lib]
Imports Bunifu.Framework.UI
Imports Microsoft.Win32

Public Class Form1
    Private borderForm As New Form
    Dim conter_select As Integer
    Dim valor As Integer
    Dim label_selecionados As New Label
    Dim label_valor As New Label
    Dim textbox_gmail As New BunifuMaterialTextbox
    Dim textbox_telemovel As New BunifuMaterialTextbox
    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.White, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub


    Dim str_lugares(15) As String
    Dim lugares_button(8, 3) As BunifuImageButton
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me

            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
        Dim x As Integer
        Dim y As Integer
        Dim aux As Integer
        Dim icon_compra As New PictureBox
        Dim icon_gmail As New PictureBox
        Dim label_compra As New Label
        Dim close As New PictureBox
        Dim condutor As New PictureBox
        Dim escadas As New PictureBox
        Dim icon_phone As New PictureBox
        Dim comprar_button As New BunifuThinButton2


        Me.AutoSize = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.AutoSizeMode = AutoSizeMode.GrowOnly
        Me.BackColor = Color.FromArgb(20, 30, 48)
        Me.StartPosition = FormStartPosition.CenterScreen



        label_compra.Font = New Font("Century Gothic", 22, FontStyle.Bold)
        label_compra.Size = New Size(255, 50)
        label_compra.Cursor = Cursors.Hand

        label_compra.Location = New Point(340, 45)
        label_compra.ForeColor = Color.White
        label_compra.Text = "Comprar bilhete"
        Me.Controls.Add(label_compra)


        textbox_gmail.Font = New Font("Century Gothic", 11)
        textbox_gmail.Cursor = Cursors.Hand
        textbox_gmail.Location = New Point(340, 220)
        textbox_gmail.LineFocusedColor = Color.White
        textbox_gmail.LineMouseHoverColor = Color.White
        textbox_gmail.ForeColor = Color.White
        textbox_gmail.Text = "Gmail"
        textbox_gmail.Size = New Size(300, 40)
        Me.Controls.Add(textbox_gmail)

        textbox_telemovel.Font = New Font("Century Gothic", 11)
        textbox_telemovel.Cursor = Cursors.Hand
        textbox_telemovel.Location = New Point(340, 280)
        textbox_telemovel.LineFocusedColor = Color.White
        textbox_telemovel.LineMouseHoverColor = Color.LightBlue
        textbox_telemovel.ForeColor = Color.White
        textbox_telemovel.Size = New Size(300, 40)
        textbox_telemovel.Text = "Telemovel"
        Me.Controls.Add(textbox_telemovel)

        comprar_button.Location = New Point(340, 340)
        comprar_button.BackColor = Color.Transparent
        comprar_button.IdleFillColor = Color.FromArgb(20, 30, 48)
        comprar_button.IdleForecolor = Color.White
        comprar_button.IdleLineColor = Color.White
        comprar_button.ActiveFillColor = Color.SeaGreen
        comprar_button.ActiveForecolor = Color.White
        comprar_button.ActiveLineColor = Color.White
        comprar_button.Size = New Size(300, 50)
        comprar_button.ButtonText = "Comprar Bilhete"
        Me.Controls.Add(comprar_button)
        AddHandler comprar_button.Click, AddressOf compra

        label_selecionados.Font = New Font("Century Gothic", 16)
        label_selecionados.Size = New Size(400, 30)
        label_selecionados.Cursor = Cursors.Hand
        label_selecionados.Location = New Point(340, 130)
        label_selecionados.ForeColor = Color.White
        label_selecionados.Text = "Nº de lugares selecionados : " & conter_select
        Me.Controls.Add(label_selecionados)




        label_valor.Font = New Font("Century Gothic", 16)
        label_valor.Size = New Size(400, 30)
        label_valor.Cursor = Cursors.Hand
        label_valor.Location = New Point(340, 160)
        label_valor.ForeColor = Color.White
        label_valor.Text = "valor : " & conter_select & " $"
        Me.Controls.Add(label_valor)


        '--------------------Imagem bus ticket ------------------
        icon_compra.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\bus-ticket.png")
        icon_compra.SizeMode = PictureBoxSizeMode.StretchImage
        icon_compra.Size = New Size(55, 55)
        icon_compra.Location = New Point(600, 38)
        Me.Controls.Add(icon_compra)



        icon_gmail.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\envelope.png")
        icon_gmail.SizeMode = PictureBoxSizeMode.StretchImage
        icon_gmail.Size = New Size(35, 35)
        icon_gmail.Location = New Point(650, 225)
        Me.Controls.Add(icon_gmail)


        icon_phone.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\phone.png")
        icon_phone.SizeMode = PictureBoxSizeMode.StretchImage
        icon_phone.Size = New Size(35, 35)
        icon_phone.Location = New Point(650, 280)
        Me.Controls.Add(icon_phone)



        '--------------------Imagem condutor------
        condutor.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\condutor.png")
        condutor.SizeMode = PictureBoxSizeMode.StretchImage
        condutor.Size = New Size(55, 55)
        condutor.Location = New Point(170, 450)
        Me.Controls.Add(condutor)


        '--------------------Imagem close icon ------------------
        close.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\circle.png")
        close.SizeMode = PictureBoxSizeMode.StretchImage
        close.Size = New Size(45, 45)
        close.Location = New Point(730, 10)
        close.Cursor = Cursors.Hand
        Me.Controls.Add(close)

        AddHandler close.Click, AddressOf Closer

        '--------------------Imagem escadas ------------------
        escadas.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\escadas.png")
        escadas.SizeMode = PictureBoxSizeMode.StretchImage
        escadas.Size = New Size(65, 65)
        escadas.Location = New Point(30, 450)
        Me.Controls.Add(escadas)




        '-------------------------


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
                lugares_button(i, j).Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\seats.ico")
                lugares_button(i, j).Size = New Size(35, 35)
                lugares_button(i, j).Location = New Point(x, y)
                lugares_button(i, j).Tag = 0
                If j > 1 And i = 3 Then
                    lugares_button(i, j).Visible = False
                End If

                If j = 1 Then
                    x += 30

                End If
                If str_lugares(i)(j) = "1" Then
                    lugares_button(i, j).Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\not_seat.png")
                    lugares_button(i, j).Cursor = Cursors.No
                    lugares_button(i, j).Tag = 1

                End If
                If j = 0 Or j = 3 Then
                    lugares_button(i, j).Tag = 3
                End If

                Me.Controls.Add(lugares_button(i, j))
                AddHandler lugares_button(i, j).Click, AddressOf Selected
            Next
        Next



    End Sub
    Sub compra(ByVal sender As Object, e As EventArgs)
        If conter_select = 0 Then
            MsgBox("Selecione o/os lugare/s que pretende comprar!")
        ElseIf textbox_gmail.Text = "Gmail" Or textbox_telemovel.Text = "Telemovel" Then
            MsgBox("preencha todas as informações!")
        Else
            MsgBox("compra executada com sucesso")

        End If
    End Sub
    Sub Selected(ByVal sender As Object, e As EventArgs)
        If sender.tag = 0 Then
            sender.tag = 2
            sender.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\check-mark.png")
            conter_select += 1
            label_selecionados.Text = "Nº de lugares selecionados : " & conter_select

            For i = 0 To conter_select

                valor = conter_select * 15
                label_valor.Text = "valor : " & valor & " $"


            Next
        ElseIf sender.tag = 2 Then
            sender.image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\seats.ico")
            sender.tag = 0
            conter_select -= 1
            label_selecionados.Text = "Nº de lugares selecionados : " & conter_select
            valor -= 15
            For i = 0 To conter_select
                valor = conter_select * 15
                label_valor.Text = "valor : " & valor & " $"
            Next
        ElseIf sender.tag = 3 Then
            sender.Image = Image.FromFile("C:\Users\Rafael\Desktop\Autocarro\Autocarro\Autocarro\Autocarro\Resources\check-mark.png")
            conter_select += 1
            label_selecionados.Text = "Nº de lugares selecionados : " & conter_select

            For i = 0 To conter_select

                valor = conter_select * 30
                label_valor.Text = "valor : " & valor & " $"


            Next

        ElseIf sender.tag = 1 Then
            MsgBox("O Lugar escolhido já está ocupado")
        End If
    End Sub


    Sub Closer(ByVal sender As Object, e As EventArgs)
        Me.Close()
    End Sub



End Class
