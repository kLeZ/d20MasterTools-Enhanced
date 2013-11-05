Imports Microsoft.DirectX
Imports Microsoft.DirectX.AudioVideoPlayback

Public Class MediaPlayer
    Dim audio As Audio
    Dim flagStop As Boolean = False
    Dim SelectedSong As Integer = 0
    Friend WithEvents SelectedListBox As New ListBox
    Dim ModoRiproduzione As PlayMode
    Dim ProgNewPL As Integer = 1
    Friend WithEvents RenameTextBox As ToolStripTextBox
    Friend WithEvents AnnullaRinomina As ToolStripButton
    Friend WithEvents OkRinomina As ToolStripButton
    Friend WithEvents separatore As ToolStripSeparator

    Enum PlayMode As Integer
        [Default] = 0
        [Random] = 1
    End Enum

    Private Sub MediaPlayer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If audio IsNot Nothing Then
            If Not audio.Stopped Then
                audio.Stop()
            End If
            audio.Dispose()
        End If
    End Sub

    Private Sub MediaPlayer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        ResizeControls()
        Me.Label1.Text = "00:00"
        Me.Label3.Text = "00:00"
        Me.Label4.Text = "-00:00"
        Me.Label2.Text = "Nessun File Caricato"
        Me.Button1.Enabled = False
        Me.Button2.Enabled = False
        Me.Button5.Enabled = False
        Me.Button6.Enabled = False
        Me.ComboBox1.SelectedIndex = PlayMode.Default
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If audio.Playing Then
            audio.Pause()
        Else
            audio.Play()
        End If
        Me.Button2.Enabled = True
        flagStop = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not audio.Stopped Then
            audio.Stop()
            Me.Button2.Enabled = False
            flagStop = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.TrackBar1.Value = audio.CurrentPosition
        Me.Label3.Text = Utils.MinutesAndSecondsFromSeconds(audio.CurrentPosition)
        Me.Label4.Text = "-" & Utils.MinutesAndSecondsFromSeconds(audio.Duration - audio.CurrentPosition)
        If audio.Duration.Equals(audio.CurrentPosition) Then
            Dim song As Integer
            If Me.CheckBox1.Checked Then
                song = SelectedSong
            Else
                song = NextSong()
            End If
            SelectedSong = song
            LoadSong(SelectedListBox.Items.Item(song), True)
        End If
    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If audio IsNot Nothing Then
            audio.CurrentPosition = Me.TrackBar1.Value
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If (Me.Label2.Left + Me.Label2.Width) > 0 Then
            Me.Label2.Left = Me.Label2.Left - 5
        Else
            Me.Label2.Left = Me.Panel1.Size.Width
            Me.Label2.Left = Me.Label2.Left - 5
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.Click
        If Me.Timer2.Enabled Then
            Me.Timer2.Enabled = False
            Me.Label2.Left = Me.Panel1.Left
        Else
            Me.Timer2.Enabled = True
        End If
    End Sub

    Private Sub TrackBar2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBar2.MouseDown
        Me.TrackBar2.Value = 0
        audio.Balance = 0
    End Sub

    Private Sub TrackBar2_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar2.Scroll
        audio.Balance = Me.TrackBar2.Value
    End Sub

    Private Sub TrackBar3_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles TrackBar3.Scroll
        Try
            audio.Volume = Me.TrackBar3.Value
        Catch ex As NullReferenceException
        End Try
    End Sub

    Private Sub MediaPlayer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ResizeControls()
    End Sub

    Sub ResizeControls()
        Me.TrackBar3.Size = New Size(Me.TrackBar3.Size.Width, (Me.GroupBox2.Size.Height - Me.TrackBar3.Location.Y) - 12)
        Me.Panel1.Size = New Size((Me.TabPage1.Size.Width - Me.GroupBox2.Size.Width) - 12, Me.Panel1.Size.Height)
        Me.TrackBar1.Size = New Size((Me.TabPage1.Size.Width - Me.GroupBox2.Size.Width) - 12, Me.TrackBar1.Size.Height)
    End Sub

    Sub ClearPlayer()
        Me.Timer1.Stop()
        audio = Nothing
        Me.Button1.Enabled = False
        Me.Button2.Enabled = False
        Me.TrackBar1.Value = 0
        Me.Label1.Text = "00:00"
        Me.Label2.Text = "Nessun file caricato"
        Me.Label3.Text = "00:00"
        Me.Label4.Text = "-00:00"
    End Sub

    Sub InitSongInPlayer()
        Me.Button1.Enabled = True
        Me.Button2.Enabled = True
        Me.Label1.Text = Utils.MinutesAndSecondsFromSeconds(audio.Duration)
        Me.Label2.Text = Utils.GetFileName(SelectedListBox.Items.Item(SelectedSong))
        Me.TrackBar1.Maximum = audio.Duration
        Me.Timer1.Enabled = True
        Me.Timer1.Start()
        SelectedListBox.SelectedIndex = SelectedSong
    End Sub

    Sub LoadSong(ByVal songFileName As String, ByVal autoPlay As Boolean)
        Try
            If audio Is Nothing Then
                audio = New Audio(songFileName, autoPlay)
            Else
                audio.Open(songFileName, autoPlay)
            End If
        Catch ex As DirectXException
            ClearPlayer()
            Dim exerror As String = ex.ErrorString
            If exerror.Contains("VFW_E_INVALIDMEDIATYPE") Then
                MsgBox("Formato file non valido.")
            ElseIf exerror.Contains("VFW_E_CANNOT_RENDER") Then
                MsgBox("Impossibile renderizzare il file.")
            ElseIf exerror.Contains("VFW_E_UNSUPPORTED_STREAM") Then
                MsgBox("Formato di stream non supportato.")
            Else
                MsgBox("Eccezione DirectX generica.")
            End If
            Exit Sub
        End Try
        InitSongInPlayer()
    End Sub

    Private Sub ToolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        SelectedListBox = CType(Me.TabControl1.Controls.Item(Me.ToolStripComboBox1.SelectedItem), TabPage).Controls.Item(0)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SelectedSong = NextSong()
        If SelectedSong < SelectedListBox.Items.Count And SelectedSong >= 0 Then
            LoadSong(SelectedListBox.Items.Item(SelectedSong), True)
        ElseIf SelectedSong > SelectedListBox.Items.Count Or SelectedSong < 0 Then
            SelectedSong = 0
        End If
        Me.Button2.Enabled = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SelectedSong = PrevSong()
        If SelectedSong < SelectedListBox.Items.Count And SelectedSong >= 0 Then
            LoadSong(SelectedListBox.Items.Item(SelectedSong), True)
        ElseIf SelectedSong > SelectedListBox.Items.Count Or SelectedSong < 0 Then
            SelectedSong = 0
        End If
        Me.Button2.Enabled = True
    End Sub

    Function NextSong() As Integer
        Select Case modoRiproduzione
            Case PlayMode.Default
                Return SelectedSong + 1
            Case PlayMode.Random
                Return MDIMain.Randomizer.Next(0, SelectedListBox.Items.Count - 1)
        End Select
    End Function

    Function PrevSong() As Integer
        Select Case ModoRiproduzione
            Case PlayMode.Default
                Return SelectedSong - 1
            Case PlayMode.Random
                Return MDIMain.Randomizer.Next(0, SelectedListBox.Items.Count - 1)
        End Select
    End Function

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case Me.ComboBox1.SelectedIndex
            Case 0
                ModoRiproduzione = PlayMode.Default
            Case 1
                ModoRiproduzione = PlayMode.Random
        End Select
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ' OpenFileDialog Settings
        With Me.OpenFileDialog1
            .CheckFileExists = True
            .CheckPathExists = True
            .Filter = "File Audio (mp2, mp3, wav, ac3, ogg)|*.mp2;*.mp3;*.wav;*.ac3;*.ogg|Tutti i file (*.*)|*.*"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyMusic
            .Multiselect = True
            .RestoreDirectory = True
            .SupportMultiDottedExtensions = True
            .ValidateNames = True
            .FileName = ""
            If Me.TabControl1.Controls.Count <= 1 Then
                MsgBox("Non hai caricato nessuna playlist!")
                Exit Sub
            End If
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                SelectedListBox.Items.Add(.FileNames)
            End If
        End With
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ' OpenFileDialog Settings
        With Me.OpenFileDialog1
            .CheckFileExists = True
            .CheckPathExists = True
            .Filter = "File Playlist (m3u)|*.m3u|Tutti i file (*.*)|*.*"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyMusic
            .Multiselect = False
            .RestoreDirectory = True
            .SupportMultiDottedExtensions = True
            .FileName = ""
            .ValidateNames = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim name As String = Utils.GetFileName(.FileName)
                If Me.TabControl1.Controls.ContainsKey(name) Then
                    MsgBox("Playlist gi caricata!")
                    Exit Sub
                End If
                NewPlaylist(name, False)
                Utils.fillListBoxFromArrayList(SelectedListBox, Utils.getListFromString(My.Computer.FileSystem.ReadAllText(.FileName), New String() {vbCrLf}))
                With Me.ToolStripComboBox1
                    .Items.Add(name)
                    .SelectedItem = .Items.Item(.Items.IndexOf(name))
                End With
                Me.Button1.Enabled = True
                Me.Button2.Enabled = True
                Me.Button5.Enabled = True
                Me.Button6.Enabled = True
                If SelectedSong < SelectedListBox.Items.Count And SelectedSong >= 0 Then
                    LoadSong(SelectedListBox.Items.Item(SelectedSong), False)
                End If
            End If
        End With
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        With Me.SaveFileDialog1
            .AddExtension = True
            .DefaultExt = "m3u"
            .FileName = ""
            .Filter = "File Playlist (m3u)|*.m3u|Tutti i file (*.*)|*.*"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyMusic
            .OverwritePrompt = True
            .RestoreDirectory = True
            .SupportMultiDottedExtensions = True
            .ValidateNames = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Utils.SaveElementsFromListbox(SelectedListBox, .FileName, False)
                RenamePlaylist(Utils.GetFileName(.FileName))
            End If
        End With
    End Sub

    Private Sub SelectedListBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SelectedListBox.DoubleClick
        SelectedSong = SelectedListBox.SelectedIndex
        InitSongInPlayer()
        LoadSong(SelectedListBox.Items.Item(SelectedSong), True)
        Me.TabControl1.SelectedTab = Me.TabPage1
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim plToRem As String = Me.ToolStripComboBox1.SelectedItem
        If MessageBox.Show("Sei sicuro di voler eliminare la playlist " & plToRem & "?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            For Each tabPage As TabPage In Me.TabControl1.Controls
                If tabPage.Text.Equals(plToRem) And Not tabPage.Text.Equals("Controlli") Then
                    Me.TabControl1.Controls.Remove(tabPage)
                End If
            Next
            With Me.ToolStripComboBox1
                .Items.Remove(plToRem)
                .SelectedIndex = .Items.Count - 1
            End With
            ClearPlayer()
        End If
    End Sub

    Function NewPlaylist(ByVal name As String, ByVal NuovaPlaylist As Boolean) As String
        Dim newTab As New TabPage
        Dim newList As New ListBox
        If NuovaPlaylist Then
            name &= " " & ProgNewPL
        End If
        newTab.Name = name
        newTab.Text = name
        newList.Name = newTab.Name & "List"
        newList.Dock = DockStyle.Fill
        newList.ScrollAlwaysVisible = True
        newList.HorizontalScrollbar = True
        newTab.Controls.Add(newList)
        Me.TabControl1.Controls.Add(newTab)
        SelectedListBox = Me.TabControl1.Controls.Item(name).Controls.Item(0)
        If NuovaPlaylist Then
            ProgNewPL += 1
        End If
        Return newTab.Name
    End Function

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Dim newPL As String = NewPlaylist("Nuova playlist", True)
        With Me.ToolStripComboBox1
            .Items.Add(newPL)
            .SelectedItem = .Items.Item(.Items.IndexOf(newPL))
        End With
        ClearPlayer()
    End Sub

    Sub RenamePlaylist(ByVal newName As String)
        With SelectedListBox.Parent
            Dim oldName As String = .Name
            .Name = newName
            .Text = newName
            With Me.ToolStripComboBox1.Items
                .Item(.IndexOf(oldName)) = newName
            End With
        End With
    End Sub

    Sub RemoveRename()
        Me.ToolStrip1.Items.Remove(RenameTextBox)
        Me.ToolStrip1.Items.Remove(AnnullaRinomina)
        Me.ToolStrip1.Items.Remove(OkRinomina)
        Me.ToolStrip1.Items.Remove(separatore)
        RenameTextBox = Nothing
        AnnullaRinomina = Nothing
        OkRinomina = Nothing
        separatore = Nothing
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        If SelectedListBox.Parent IsNot Nothing And separatore Is Nothing And AnnullaRinomina Is Nothing And OkRinomina Is Nothing And RenameTextBox Is Nothing Then
            RenameTextBox = New ToolStripTextBox
            AnnullaRinomina = New ToolStripButton
            OkRinomina = New ToolStripButton
            separatore = New ToolStripSeparator
            RenameTextBox.AcceptsReturn = True
            RenameTextBox.Text = SelectedListBox.Parent.Text
            RenameTextBox.Size = New Size(300, RenameTextBox.Size.Height)
            AnnullaRinomina.Text = "Annulla"
            OkRinomina.Text = "Ok"
            Me.ToolStrip1.Items.Add(separatore)
            Me.ToolStrip1.Items.Add(AnnullaRinomina)
            Me.ToolStrip1.Items.Add(OkRinomina)
            Me.ToolStrip1.Items.Add(RenameTextBox)
        End If
    End Sub

    Private Sub AnnullaRinomina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AnnullaRinomina.Click
        RemoveRename()
    End Sub

    Private Sub RenameTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RenameTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            RenamePlaylist(RenameTextBox.Text)
            RemoveRename()
        End If
    End Sub

    Private Sub OkRinomina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OkRinomina.Click
        RenamePlaylist(RenameTextBox.Text)
        RemoveRename()
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        SelectedListBox.Items.Remove(SelectedListBox.SelectedItem)
    End Sub
End Class