Public Class VisualizzaImmagine
    Private m_PanStartPoint As New Point

    Private Sub VisualizzaImmagine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        m_PanStartPoint = New Point(e.X, e.Y)
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        'Verify Left Button is pressed while the mouse is moving
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'Here we get the change in coordinates.
            'We multiply it by -1 because of how the panels autoscroll works.
            'Dim DeltaX As Integer = (e.X - m_PanStartPoint.X) * -1
            'Dim DeltaY As Integer = (e.Y - m_PanStartPoint.Y) * -1
            Dim DeltaX As Integer = (m_PanStartPoint.X - e.X)
            Dim DeltaY As Integer = (m_PanStartPoint.Y - e.Y)
            'Set the new autoscroll position.
            'ALWAYS pass positive integers to the panels autoScrollPosition method
            Panel1.AutoScrollPosition = New Drawing.Point((DeltaX - Panel1.AutoScrollPosition.X), (DeltaY - Panel1.AutoScrollPosition.Y))
        End If
    End Sub
End Class