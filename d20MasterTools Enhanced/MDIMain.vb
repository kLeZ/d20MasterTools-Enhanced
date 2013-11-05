Imports System.data.OleDb

Public Class MDIMain
    Private _parametri As Sessione
    Public Randomizer As MersenneTwister
    Private numeroPerfetto As Integer = 33550336

    Public ReadOnly Property Sessione() As Sessione
        Get
            Return _parametri
        End Get
    End Property

    Private Sub CalcoloDeiPEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CalcoloDeiPEToolStripMenuItem.Click
        Calcoli.Show()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        NuovaCampagna.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.Show()
    End Sub

    Private Sub ContentsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentsToolStripMenuItem.Click
        Dim path As String = ""
        If Utils.DirSearch(My.Computer.FileSystem.CurrentDirectory.ToString, "Guida.html", path) Then
            Process.Start(path)
        Else
            MessageBox.Show("Guida in linea non disponibile." & vbCrLf & "Una reinstallazione dell'applicazione potrebbe risolvere il problema.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub MDIMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        DBADO.Close()
    End Sub

    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        _parametri = New Sessione
        AboutBox.MdiParent = Me
        ApriCampagna.MdiParent = Me
        Calcoli.MdiParent = Me
        CancellaCampagna.MdiParent = Me
        ModificaCampagna.MdiParent = Me
        ModificaPG.MdiParent = Me
        NuovaCampagna.MdiParent = Me
        NuovoPG.MdiParent = Me
        VisualizzaDatiCampagna.MdiParent = Me
        VisualizzaImmagine.MdiParent = Me
        TiraDadi.MdiParent = Me
        Movimento.MdiParent = Me
        TimerCombattimento.MdiParent = Me
        DBADO.ConnectionString() = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\d20MasterTools_Enhanced.mdb"
        Randomizer = New MersenneTwister(numeroPerfetto)
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        NuovaCampagna.Show()
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolBarToolStripMenuItem.Click
        If Not Me.ToolBarToolStripMenuItem.Checked Then
            Me.ToolStrip.Visible = False
        Else
            Me.ToolStrip.Visible = True
        End If
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each children As Windows.Forms.Form In Me.MdiChildren
            If children.CanSelect Then
                children.Dispose()
            End If
        Next
    End Sub

    Private Sub CloseOthersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseOthersToolStripMenuItem.Click
        For Each children As Windows.Forms.Form In Me.MdiChildren
            If Not children Is Me.ActiveMdiChild Then
                children.Dispose()
            End If
        Next
    End Sub

    Private Sub CloseActiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseActiveToolStripMenuItem.Click
        For Each children As Windows.Forms.Form In Me.MdiChildren
            If children Is Me.ActiveMdiChild Then
                children.Dispose()
            End If
        Next
    End Sub

    Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
        ApriCampagna.Show()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        ApriCampagna.Show()
    End Sub

    Private Sub CancellaToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancellaToolStripButton.Click
        CancellaCampagna.Show()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        CancellaCampagna.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        TiraDadi.Show()
    End Sub

    Private Sub MovimentoEDistanzaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MovimentoEDistanzaToolStripMenuItem.Click
        Movimento.Show()
    End Sub

    Private Sub TimerDiCombattimentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDiCombattimentoToolStripMenuItem.Click
        TimerCombattimento.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Dispose()
    End Sub

    Private Sub GeneratoreNomiRandomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GeneratoreNomiRandomToolStripMenuItem.Click
        RandomName.Show()
    End Sub

    Private Sub PlayerAudioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerAudioToolStripMenuItem.Click
        'Dim newForm As New MediaPlayer
        'newForm.Show()
    End Sub
    '*********************************************************************************************
    '*          ------------------------------------------------------------                     *
    '*                                  Toolstrip Schermo del DM                                 *
    '*          ------------------------------------------------------------                     *
    '*********************************************************************************************
    Private Sub ModificatoriAllaCAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificatoriAllaCAToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub AbilitaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbilitaToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ScalareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScalareToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ConcentrazioneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConcentrazioneToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub InfluenzareLatteggiamentoDeiPNGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfluenzareLatteggiamentoDeiPNGToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub EquilibrioToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EquilibrioToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub EsempiDiRaggirareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsempiDiRaggirareToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub DisattivareCongegniMDGPAG74ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisattivareCongegniMDGPAG74ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub UtilizzareCordeMDGPAG84ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilizzareCordeMDGPAG84ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub CamuffareMDGPAG71ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CamuffareMDGPAG71ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub NuotareMDGPAGToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuotareMDGPAGToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub IntrattenereMDGPAG77ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntrattenereMDGPAG77ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub CavalcareMDGPAG71ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CavalcareMDGPAG71ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub CercareMDGPAG72ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CercareMDGPAG72ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ModificatoriAlTiroPerColpireMDGPAG151ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificatoriAlTiroPerColpireMDGPAG151ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ScacciareNonMortiMDGPAG159ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScacciareNonMortiMDGPAG159ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub OsservareMDGPAG78ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OsservareMDGPAG78ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ArtistaDellaFugaMDGPAG70ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtistaDellaFugaMDGPAG70ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub AddestrareAnimaliMDGPAG67ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddestrareAnimaliMDGPAG67ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub GuarireMDGPAG76ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuarireMDGPAG76ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub SaltareMDGPAG8182ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaltareMDGPAG8182ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ProvaDiAscoltarePerIndividuareCreatureInvisibiliToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProvaDiAscoltarePerIndividuareCreatureInvisibiliToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub PercepireIntenzioniMDGPAG79ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PercepireIntenzioniMDGPAG79ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub RapiditaDiManoMDGPAG81ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RapiditaDiManoMDGPAG81ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ModificatoreAMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificatoreAMToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub SapienzaMagicaMDGPAG82ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SapienzaMagicaMDGPAG82ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub UtilizzareOggettiMagiciMDGPAG85ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtilizzareOggettiMagiciMDGPAG85ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub AzioniInCombattimentoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AzioniInCombattimentoToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub SopravvivenzaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SopravvivenzaToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub AcrobaziaMDGPAG67ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcrobaziaMDGPAG67ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub AscoltareMDGPAG70ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AscoltareMDGPAG70ToolStripMenuItem.Click
        SchermoDM.Show(sender)
    End Sub

    Private Sub ToolStripSplitButton1_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSplitButton1.ButtonClick
        If Me.ToolStripSplitButton1.DropDownButtonPressed Then
            Me.ToolStripSplitButton1.HideDropDown()
        Else
            Me.ToolStripSplitButton1.ShowDropDown()
        End If
    End Sub
    '*********************************************************************************************
    '*          ------------------------------------------------------------                     *
    '*                                  Toolstrip Schermo del DM                                 *
    '*          ------------------------------------------------------------                     *
    '*********************************************************************************************

    Private Sub GToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GToolStripMenuItem.Click
        RandomTreasure.Show()
    End Sub
End Class
