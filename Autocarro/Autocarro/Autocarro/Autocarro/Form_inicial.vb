Imports System.Media
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip
Imports Bunifu.Framework.UI

Public Class Form_inicial
    Private borderForm As New Form
    Dim autocarro_pequeno As New PictureBox


    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form_inicial_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.White, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub


    Dim str_lugares(15) As String
    Dim lugares_button(8, 3) As BunifuImageButton
    Sub Form_inicial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Me

            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With


        Dim close As New PictureBox
        Dim autocarro1 As New PictureBox
        Dim autocarro2 As New PictureBox
        Dim label_tit As New Label
        Dim botao1 As New BunifuThinButton2
        Dim botao2 As New BunifuThinButton2
        Me.AutoSize = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.AutoSizeMode = AutoSizeMode.GrowOnly
        Me.BackColor = Color.FromArgb(20, 30, 48)
        Me.StartPosition = FormStartPosition.CenterScreen

        close.Image = My.Resources.circle
        close.SizeMode = PictureBoxSizeMode.StretchImage
        close.Size = New Size(45, 45)
        close.Location = New Point(730, 10)
        close.Cursor = Cursors.Hand
        Me.Controls.Add(close)
        AddHandler close.Click, AddressOf Closer






        autocarro1.Image = My.Resources.autocarro
        autocarro1.SizeMode = PictureBoxSizeMode.StretchImage
        autocarro1.Size = New Size(250, 180)
        autocarro1.Location = New Point(10, 200)
        Me.Controls.Add(autocarro1)


        autocarro2.Image = My.Resources.autocarro2
        autocarro2.SizeMode = PictureBoxSizeMode.StretchImage
        autocarro2.Size = New Size(250, 180)
        autocarro2.Location = New Point(530, 200)
        Me.Controls.Add(autocarro2)


        autocarro_pequeno.Image = My.Resources.bus
        autocarro_pequeno.SizeMode = PictureBoxSizeMode.StretchImage
        autocarro_pequeno.Size = New Size(70, 70)
        autocarro_pequeno.Location = New Point(10, 488)
        Me.Controls.Add(autocarro_pequeno)
        AddHandler autocarro_pequeno.Click, AddressOf Show_form1

        label_tit.Font = New Font("Century Gothic", 36, FontStyle.Bold)
        label_tit.Size = New Size(400, 70)

        label_tit.Cursor = Cursors.Hand
        label_tit.Location = New Point(210, 90)
        label_tit.ForeColor = Color.White
        label_tit.Text = "Easy Buzz Leiria"
        Me.Controls.Add(label_tit)

        botao1.Location = New Point(290, 240)
        botao1.BackColor = Color.Transparent
        botao1.IdleFillColor = Color.FromArgb(20, 30, 48)
        botao1.IdleForecolor = Color.White
        botao1.IdleLineColor = Color.White
        botao1.ActiveFillColor = Color.SeaGreen
        botao1.ActiveForecolor = Color.White
        botao1.ActiveLineColor = Color.White
        botao1.Size = New Size(200, 50)
        botao1.ButtonText = "Comprar Bilhete"
        Me.Controls.Add(botao1)

        AddHandler botao1.Click, AddressOf Show_form1

        botao2.Location = New Point(290, 310)
        botao2.BackColor = Color.Transparent
        botao2.IdleFillColor = Color.FromArgb(20, 30, 48)
        botao2.IdleForecolor = Color.White
        botao2.IdleLineColor = Color.White
        botao2.ActiveFillColor = Color.RoyalBlue
        botao2.ActiveForecolor = Color.White
        botao2.ActiveLineColor = Color.White
        botao2.Size = New Size(200, 50)
        botao2.ButtonText = "Administração"
        Me.Controls.Add(botao2)
        AddHandler botao2.Click, AddressOf Show_form_admin


    End Sub


    Sub Closer(ByVal sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Sub Show_form1(ByVal sender As Object, e As EventArgs)
        Timer1.Interval = 5
        Timer1.Start()


    End Sub

    Sub Show_form_admin(ByVal sender As Object, e As EventArgs)
        Form_entrarAdm.Show()


    End Sub

    Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        For i = 0 To 10
            autocarro_pequeno.Left += 1
        Next


        If autocarro_pequeno.Left > 700 Then
            Timer1.Stop()
            If Timer1.Enabled = False Then
                Form1.Show()
                autocarro_pequeno.Location = New Point(10, 488)
            End If
        End If
    End Sub
End Class