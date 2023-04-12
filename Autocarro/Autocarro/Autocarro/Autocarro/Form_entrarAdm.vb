Public Class Form_entrarAdm
    Private Function RoundedRectangle(rect As RectangleF, diam As Single) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        path.AddArc(rect.Left, rect.Top, diam, diam, 180, 90)
        path.AddArc(rect.Right - diam, rect.Top, diam, diam, 270, 90)
        path.AddArc(rect.Right - diam, rect.Bottom - diam, diam, diam, 0, 90)
        path.AddArc(rect.Left, rect.Bottom - diam, diam, diam, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub Form_entrarAdm_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim r As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim path As Drawing2D.GraphicsPath = RoundedRectangle(r, 48)
        Using pn As New Pen(Color.White, 2)
            e.Graphics.DrawPath(pn, path)
        End Using
    End Sub
    Private Sub Form_entrarAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AutoSize = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.AutoSizeMode = AutoSizeMode.GrowOnly
        Me.BackColor = Color.FromArgb(20, 30, 48)
        Me.StartPosition = FormStartPosition.CenterScreen

        With Me

            .Region = New Region(RoundedRectangle(.ClientRectangle, 50))
        End With
    End Sub
End Class