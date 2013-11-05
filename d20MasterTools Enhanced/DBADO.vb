Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class DBADO
    Private Shared strConnectionString As String
    Private Shared objConnection As OleDbConnection

    Public Shared Property ConnectionString() As String
        Get
            Return strConnectionString
        End Get
        Set(ByVal value As String)
            strConnectionString = value
        End Set
    End Property

    Public Shared Property Connessione() As OleDbConnection
        Get
            Return objConnection
        End Get
        Set(ByVal value As OleDbConnection)
            objConnection = value
        End Set
    End Property

    Public Shared ReadOnly Property isAlive() As Boolean
        Get
            If Not DBADO.Connessione() Is Nothing Then
                If Not DBADO.Connessione().State().ToString Is ConnectionState.Closed.ToString Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Get
    End Property

    Public Shared Sub Open()
        If Not DBADO.isAlive() And Not Object.ReferenceEquals(DBADO.Connessione, New OleDbConnection()) Then
            DBADO.Connessione = New OleDbConnection(DBADO.ConnectionString)
            DBADO.Connessione.Open()
        ElseIf Not DBADO.isAlive() And Object.ReferenceEquals(DBADO.Connessione, New OleDbConnection()) Then
            DBADO.Connessione.Open()
        End If
    End Sub

    Public Shared Sub Close()
        If DBADO.isAlive() Then
            DBADO.Connessione.Dispose()
            DBADO.Connessione.Close()
        End If
    End Sub

    Public Shared Sub flushSQLObjects(ByRef command As OleDbCommand)
        If command IsNot Nothing Then
            command.Dispose()
        End If
        command = Nothing
    End Sub

    Public Shared Sub flushSQLObjects(ByRef adapter As OleDbDataAdapter, ByRef dataset As DataSet)
        If adapter IsNot Nothing Then
            adapter.Dispose()
        End If
        If dataset IsNot Nothing Then
            dataset.Dispose()
        End If
        adapter = Nothing
        dataset = Nothing
    End Sub

    Shared Function getMaxIdCampagna() As Long
        Dim strSQL = "SELECT MAX(CAMPAGNE.ID) AS ID FROM CAMPAGNE"
        Dim ret As Long
        DBADO.Open()
        Dim dbAdp As New OleDbDataAdapter(strSQL, DBADO.Connessione)
        Dim Data As New DataSet
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        Dim row As DataRow
        If Table IsNot Nothing Then
            If Table.Rows IsNot Nothing Then
                For Each row In Table.Rows
                    If Not row.Item("ID").Equals(DBNull.Value) Then
                        ret = row.Item("ID")
                        Exit For
                    Else
                        ret = 0
                    End If
                Next row
            End If
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return ret
    End Function

    Shared Function getMaxIdPG() As Long
        Dim strSQL = "SELECT MAX(PG.ID) AS ID FROM PG"
        Dim ret As Long
        DBADO.Open()
        Dim dbAdp As New OleDbDataAdapter(strSQL, DBADO.Connessione)
        Dim Data As New DataSet
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        Dim row As DataRow
        If Table IsNot Nothing Then
            If Table.Rows IsNot Nothing Then
                For Each row In Table.Rows
                    If Not row.Item("ID").Equals(DBNull.Value) Then
                        ret = row.Item("ID")
                        Exit For
                    Else
                        ret = 0
                    End If
                Next row
            End If
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return ret
    End Function

    Shared Function getCountPG(ByVal idCampagna As Long) As Integer
        Dim strSQL = "SELECT Count(*) AS ID FROM PG WHERE PG.ID_CAMPAGNA=" & idCampagna
        Dim ret As Integer
        DBADO.Open()
        Dim dbAdp As New OleDbDataAdapter(strSQL, DBADO.Connessione)
        Dim Data As New DataSet
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        Dim row As DataRow
        If Table IsNot Nothing Then
            If Table.Rows IsNot Nothing Then
                For Each row In Table.Rows
                    If Not row.Item("ID").Equals(DBNull.Value) Then
                        ret = row.Item("ID")
                        Exit For
                    Else
                        ret = 0
                    End If
                Next row
            End If
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return ret
    End Function

    Shared Function insertCampagna(ByVal nomeCampagna As String, ByVal nomeMaster As String, ByVal inizioCampagna As Date, ByVal versioneDnd As Single, ByVal ambientazione As String) As Integer
        Dim strSQL As String = "INSERT INTO CAMPAGNE (NOME_CAMPAGNA, NOME_MASTER, INIZIO, VERSIONE_DND, AMBIENTAZIONE) VALUES ('" & nomeCampagna & "', '" & nomeMaster & "', '" & inizioCampagna & "', '" & versioneDnd & "', '" & ambientazione & "')"
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function insertPG(ByVal idCampagna As Integer, ByVal isPng As Boolean, ByVal nomePG As String, ByVal razza As String, ByVal classePartenza As String, ByVal livello As Integer, ByVal multiclasse As String, ByVal cdp As String, ByVal dataCreazione As Date, ByVal background As String, ByVal puntiEsperienza As Integer) As Integer
        Dim strSQL As String = "INSERT INTO PG (ID_CAMPAGNA, PNG, NOME_PG, RAZZA, CLASSE_PARTENZA, LIVELLO, MULTICLASSE, CDP, DATA_CREAZIONE, BACKGROUND, PUNTI_ESPERIENZA) VALUES (" & idCampagna & ", " & isPng & ", '" & nomePG & "', '" & razza & "', '" & classePartenza & "', " & livello & ", '" & multiclasse & "', '" & cdp & "', '" & dataCreazione & "', '" & background & "', " & puntiEsperienza & ")"
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function updateCampagna(ByVal idCampagna As Long, ByVal nomeCampagna As String, ByVal nomeMaster As String, ByVal inizioCampagna As Date, ByVal fineCampagna As Date, ByVal numeroSessioni As Integer, ByVal versioneDnd As Single, ByVal ambientazione As String, ByVal trama As String, ByVal mappa As String) As Integer
        Dim strSQL As String = "UPDATE CAMPAGNE SET NOME_CAMPAGNA='" & nomeCampagna & "', NOME_MASTER='" & nomeMaster & "', INIZIO='" & inizioCampagna & "', FINE='" & fineCampagna & "', NUMERO_SESSIONI='" & numeroSessioni & "', VERSIONE_DND='" & versioneDnd & "', AMBIENTAZIONE='" & ambientazione & "', TRAMA='" & trama & "', MAPPA='" & mappa & "' WHERE ID=" & idCampagna
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function updateCampagna(ByVal idCampagna As Long, ByVal nomeCampagna As String, ByVal nomeMaster As String, ByVal inizioCampagna As Date, ByVal fineCampagna As Date, ByVal numeroSessioni As Integer, ByVal versioneDnd As Single, ByVal ambientazione As String, ByVal trama As String) As Integer
        Dim strSQL As String = "UPDATE CAMPAGNE SET NOME_CAMPAGNA='" & nomeCampagna & "', NOME_MASTER='" & nomeMaster & "', INIZIO='" & inizioCampagna & "', FINE='" & fineCampagna & "', NUMERO_SESSIONI='" & numeroSessioni & "', VERSIONE_DND='" & versioneDnd & "', AMBIENTAZIONE='" & ambientazione & "', TRAMA='" & trama & "' WHERE ID=" & idCampagna
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function updatePG(ByVal idPG As Long, ByVal isPng As Boolean, ByVal nomePG As String, ByVal razza As String, ByVal classePartenza As String, ByVal livello As Integer, ByVal multiclasse As String, ByVal cdp As String, ByVal dataCreazione As Date, ByVal background As String, ByVal puntiEsperienza As Integer) As Integer
        Dim strSQL As String = "UPDATE PG SET PNG=" & isPng & ", NOME_PG='" & nomePG & "', RAZZA='" & razza & "', CLASSE_PARTENZA='" & classePartenza & "', LIVELLO='" & livello & "', MULTICLASSE='" & multiclasse & "', CDP='" & cdp & "', DATA_CREAZIONE='" & dataCreazione & "', BACKGROUND='" & background & "', PUNTI_ESPERIENZA=" & puntiEsperienza & " WHERE PG.ID=" & idPG
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function updateNumeroPG(ByVal idCampagna As Long) As Integer
        Dim strSQL As String = "UPDATE CAMPAGNE SET NUMERO_PG=" & getCountPG(idCampagna) & " WHERE CAMPAGNE.ID=" & idCampagna
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function deleteCampagna(ByVal idCampagna As Long) As Integer
        Dim strSQL As String = "DELETE FROM CAMPAGNE WHERE CAMPAGNE.ID=" & idCampagna
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function deletePG(ByVal idPG As Long) As Integer
        Dim strSQL As String = "DELETE FROM PG WHERE PG.ID=" & idPG
        DBADO.Open()
        Dim objCommand As New OleDbCommand(strSQL, DBADO.Connessione)
        Dim i As Integer
        i = objCommand.ExecuteNonQuery()
        DBADO.Close()
        DBADO.flushSQLObjects(objCommand)
        Return i
    End Function

    Shared Function getListaCampagne() As ArrayList
        Dim ret As New ArrayList
        Dim strSQL As String = "SELECT CAMPAGNE.ID, CAMPAGNE.NOME_CAMPAGNA, CAMPAGNE.INIZIO FROM CAMPAGNE"
        DBADO.Open()
        Dim dbAdp As New OleDbDataAdapter(strSQL, DBADO.Connessione)
        Dim Data As New DataSet
        dbAdp.Fill(Data)
        Dim campagna As New Campagna
        Dim Table As DataTable = Data.Tables(0)
        If Table IsNot Nothing Then
            If Table.Rows IsNot Nothing Then
                For Each row As DataRow In Table.Rows
                    campagna = New Campagna
                    campagna.ID = row.Item("ID")
                    campagna.Nome = row.Item("NOME_CAMPAGNA")
                    campagna.Inizio = row.Item("INIZIO")
                    ret.Add(campagna)
                Next
            End If
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return ret
    End Function

    Shared Function getListaPG(ByVal idCampagna As Long) As ArrayList
        Dim strSQL As String = "SELECT PG.ID, PG.NOME_PG, PG.PNG FROM PG WHERE PG.ID_CAMPAGNA=" & idCampagna
        DBADO.Open()
        Dim listaPg As New ArrayList
        Dim PG As PG
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Table IsNot Nothing Then
            If Table.Rows IsNot Nothing Then
                For Each row As DataRow In Table.Rows
                    PG = New PG
                    PG.ID = row.Item("ID")
                    PG.IDCampagna = idCampagna
                    PG.Nome = row.Item("NOME_PG")
                    PG.isPng = row.Item("PNG")
                    listaPg.Add(PG)
                Next
            End If
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return listaPg
    End Function

    Shared Function getInfoCampagna() As Campagna
        Dim campagna As New Campagna
        Dim strSQL As String = "SELECT * FROM CAMPAGNE WHERE CAMPAGNE.ID=" & getMaxIdCampagna()
        DBADO.Open()
        Dim dbAdp As OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            campagna.ID = Table.Rows.Item(0).Item("ID")
            campagna.Nome = Table.Rows.Item(0).Item("NOME_CAMPAGNA")
            campagna.Master = Table.Rows.Item(0).Item("NOME_MASTER")
            campagna.NumeroPG = Table.Rows.Item(0).Item("NUMERO_PG")
            campagna.Inizio = Table.Rows.Item(0).Item("INIZIO")
            campagna.Fine = Table.Rows.Item(0).Item("FINE")
            campagna.Sessioni = Table.Rows.Item(0).Item("NUMERO_SESSIONI")
            campagna.VersioneDND = Table.Rows.Item(0).Item("VERSIONE_DND")
            campagna.Ambientazione = Table.Rows.Item(0).Item("AMBIENTAZIONE")
            campagna.Trama = Table.Rows.Item(0).Item("TRAMA")
            campagna.Mappa = Table.Rows.Item(0).Item("MAPPA")
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return campagna
    End Function

    Shared Function getInfoCampagna(ByVal idCampagna As Long) As Campagna
        Dim campagna As New Campagna
        Dim strSQL As String = "SELECT * FROM CAMPAGNE WHERE CAMPAGNE.ID=" & idCampagna
        DBADO.Open()
        Dim dbAdp As OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            campagna.ID = Table.Rows.Item(0).Item("ID")
            campagna.Nome = Table.Rows.Item(0).Item("NOME_CAMPAGNA")
            campagna.Master = Table.Rows.Item(0).Item("NOME_MASTER")
            campagna.NumeroPG = Table.Rows.Item(0).Item("NUMERO_PG")
            campagna.Inizio = Table.Rows.Item(0).Item("INIZIO")
            campagna.Fine = Table.Rows.Item(0).Item("FINE")
            campagna.Sessioni = Table.Rows.Item(0).Item("NUMERO_SESSIONI")
            campagna.VersioneDND = Table.Rows.Item(0).Item("VERSIONE_DND")
            campagna.Ambientazione = Table.Rows.Item(0).Item("AMBIENTAZIONE")
            campagna.Trama = Table.Rows.Item(0).Item("TRAMA")
            campagna.Mappa = Table.Rows.Item(0).Item("MAPPA")
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return campagna
    End Function

    Shared Function getInfoCampagna(ByVal nomeCampagna As String) As Campagna
        Dim campagna As New Campagna
        Dim strSQL As String = "SELECT * FROM CAMPAGNE WHERE CAMPAGNE.NOME_CAMPAGNA='" & nomeCampagna & "'"
        DBADO.Open()
        Dim dbAdp As OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            campagna.ID = Table.Rows.Item(0).Item("ID")
            campagna.Nome = Table.Rows.Item(0).Item("NOME_CAMPAGNA")
            campagna.Master = Table.Rows.Item(0).Item("NOME_MASTER")
            campagna.NumeroPG = Table.Rows.Item(0).Item("NUMERO_PG")
            campagna.Inizio = Table.Rows.Item(0).Item("INIZIO")
            campagna.Fine = Table.Rows.Item(0).Item("FINE")
            campagna.Sessioni = Table.Rows.Item(0).Item("NUMERO_SESSIONI")
            campagna.VersioneDND = Table.Rows.Item(0).Item("VERSIONE_DND")
            campagna.Ambientazione = Table.Rows.Item(0).Item("AMBIENTAZIONE")
            campagna.Trama = Table.Rows.Item(0).Item("TRAMA")
            campagna.Mappa = Table.Rows.Item(0).Item("MAPPA")
        End If
        DBADO.Close()
        DBADO.flushSQLObjects(dbAdp, Data)
        Return campagna
    End Function

    Shared Function getInfoPG() As PG
        Dim pg As New PG
        Dim strSQL As String = "SELECT * FROM PG WHERE PG.ID=" & getMaxIdPG()
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            pg.ID = Table.Rows.Item(0).Item("ID")
            pg.IDCampagna = Table.Rows.Item(0).Item("ID_CAMPAGNA")
            pg.isPng = Table.Rows.Item(0).Item("PNG")
            pg.Razza = Table.Rows.Item(0).Item("RAZZA")
            pg.Classe = Table.Rows.Item(0).Item("CLASSE_PARTENZA")
            pg.Livello = Table.Rows.Item(0).Item("LIVELLO")
            pg.Multiclasse = Table.Rows.Item(0).Item("MULTICLASSE")
            pg.CDP = Table.Rows.Item(0).Item("CDP")
            pg.DataCreazione = Table.Rows.Item(0).Item("DATA_CREAZIONE")
            pg.Background = Table.Rows.Item(0).Item("BACKGROUND")
            pg.PE = Table.Rows.Item(0).Item("PUNTI_ESPERIENZA")
        End If
        DBADO.Close()
        Return pg
    End Function

    Shared Function getInfoPG(ByVal idPG As Long) As PG
        Dim pg As New PG
        Dim strSQL As String = "SELECT * FROM PG WHERE PG.ID=" & idPG
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            pg.ID = Table.Rows.Item(0).Item("ID")
            pg.Nome = Table.Rows.Item(0).Item("NOME_PG")
            pg.IDCampagna = Table.Rows.Item(0).Item("ID_CAMPAGNA")
            pg.isPng = Table.Rows.Item(0).Item("PNG")
            pg.Razza = Table.Rows.Item(0).Item("RAZZA")
            pg.Classe = Table.Rows.Item(0).Item("CLASSE_PARTENZA")
            pg.Livello = Table.Rows.Item(0).Item("LIVELLO")
            pg.Multiclasse = Table.Rows.Item(0).Item("MULTICLASSE")
            pg.CDP = Table.Rows.Item(0).Item("CDP")
            pg.DataCreazione = Table.Rows.Item(0).Item("DATA_CREAZIONE")
            pg.Background = Table.Rows.Item(0).Item("BACKGROUND")
            pg.PE = Table.Rows.Item(0).Item("PUNTI_ESPERIENZA")
        End If
        DBADO.Close()
        Return pg
    End Function

    Shared Function getInfoPG(ByVal nomePG As String) As PG
        Dim pg As New PG
        Dim strSQL As String = "SELECT * FROM PG WHERE PG.NOME_PG='" & nomePG & "'"
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            pg.ID = Table.Rows.Item(0).Item("ID")
            pg.Nome = nomePG
            pg.IDCampagna = Table.Rows.Item(0).Item("ID_CAMPAGNA")
            pg.isPng = Table.Rows.Item(0).Item("PNG")
            pg.Razza = Table.Rows.Item(0).Item("RAZZA")
            pg.Classe = Table.Rows.Item(0).Item("CLASSE_PARTENZA")
            pg.Livello = Table.Rows.Item(0).Item("LIVELLO")
            pg.Multiclasse = Table.Rows.Item(0).Item("MULTICLASSE")
            pg.CDP = Table.Rows.Item(0).Item("CDP")
            pg.DataCreazione = Table.Rows.Item(0).Item("DATA_CREAZIONE")
            pg.Background = Table.Rows.Item(0).Item("BACKGROUND")
            pg.PE = Table.Rows.Item(0).Item("PUNTI_ESPERIENZA")
        End If
        DBADO.Close()
        Return pg
    End Function

    Shared Function getInfoMovimento() As ArrayList
        Dim ret As New ArrayList
        Dim strSQL As String = "SELECT * FROM MOVIMENTO"
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        Dim velocitaMovimento As VelocitaMovimento
        If Not Table.Rows.Count = 0 Then
            For Each row As DataRow In Table.Rows
                velocitaMovimento = New VelocitaMovimento
                velocitaMovimento.ID = row.Item("ID")
                velocitaMovimento.Descrizione = row.Item("DESCRIZIONE_MEZZO")
                velocitaMovimento.Velocità = row.Item("VELOCITA_ORARIA")
                ret.Add(velocitaMovimento)
            Next
        End If
        DBADO.Close()
        Return ret
    End Function

    Shared Sub GetTabellaPerSchermoDM(ByVal Caller As Object, ByRef dataGridView1 As DataGridView, ByRef dataGridView2 As DataGridView, ByRef label1 As Label, ByRef TableName As String)
        Dim query As String = "SELECT * FROM "
        If Caller.Equals(MDIMain.ModificatoriAllaCAToolStripMenuItem) Then
            query &= "MOD_CA"
            TableName = "Modificatori alla Classe Armatura"
        ElseIf Caller.Equals(MDIMain.AbilitaToolStripMenuItem) Then
            query &= "ABILITA_SDM"
            TableName = "Abilit"
        ElseIf Caller.Equals(MDIMain.ScalareToolStripMenuItem) Then
            query &= "SCALARE"
            TableName = "Scalare"
        ElseIf Caller.Equals(MDIMain.ConcentrazioneToolStripMenuItem) Then
            query &= "CONCENTRAZIONE"
            TableName = "Concentrazione"
        ElseIf Caller.Equals(MDIMain.InfluenzareLatteggiamentoDeiPNGToolStripMenuItem) Then
            query &= "ATT_PNG"
            TableName = "Influenzare l'atteggiamento dei PNG"
        ElseIf Caller.Equals(MDIMain.EquilibrioToolStripMenuItem) Then
            query &= "EQUILIBRIO"
            TableName = "Equilibrio"
        ElseIf Caller.Equals(MDIMain.EsempiDiRaggirareToolStripMenuItem) Then
            query &= "ES_RAGGIRARE"
            TableName = "Esempi di Raggirare"
        ElseIf Caller.Equals(MDIMain.DisattivareCongegniMDGPAG74ToolStripMenuItem) Then
            query &= "DISATT_CONG"
            TableName = "Disattivare Congegni"
        ElseIf Caller.Equals(MDIMain.UtilizzareCordeMDGPAG84ToolStripMenuItem) Then
            query &= "UTILIZZ_CORDE"
            TableName = "Utilizzare Corde"
        ElseIf Caller.Equals(MDIMain.CamuffareMDGPAG71ToolStripMenuItem) Then
            query &= "CAMUFFARE"
            TableName = "Camuffare"
        ElseIf Caller.Equals(MDIMain.NuotareMDGPAGToolStripMenuItem) Then
            query &= "NUOTARE"
            TableName = "Nuotare"
        ElseIf Caller.Equals(MDIMain.IntrattenereMDGPAG77ToolStripMenuItem) Then
            query &= "INTRATTENERE"
            TableName = "Intrattenere"
        ElseIf Caller.Equals(MDIMain.CavalcareMDGPAG71ToolStripMenuItem) Then
            query &= "CAVALCARE"
            TableName = "Cavalcare"
        ElseIf Caller.Equals(MDIMain.CercareMDGPAG72ToolStripMenuItem) Then
            query &= "CERCARE"
            TableName = "Cercare"
        ElseIf Caller.Equals(MDIMain.ModificatoriAlTiroPerColpireMDGPAG151ToolStripMenuItem) Then
            query &= "MOD_TXC"
            TableName = "Modificatori al Tiro per colpire"
        ElseIf Caller.Equals(MDIMain.ScacciareNonMortiMDGPAG159ToolStripMenuItem) Then
            query &= "SCACCIARE_NM"
            TableName = "Scacciare non morti"
        ElseIf Caller.Equals(MDIMain.OsservareMDGPAG78ToolStripMenuItem) Then
            query &= "OSSERVARE"
            TableName = "Osservare"
        ElseIf Caller.Equals(MDIMain.AcrobaziaMDGPAG67ToolStripMenuItem) Then
            query &= "ACROBAZIA"
            TableName = "Acrobazia"
        ElseIf Caller.Equals(MDIMain.AddestrareAnimaliMDGPAG67ToolStripMenuItem) Then
            query &= "ADDES_ANIMALI"
            TableName = "Addestrare animali"
        ElseIf Caller.Equals(MDIMain.ArtistaDellaFugaMDGPAG70ToolStripMenuItem) Then
            query &= "ART_FUGA"
            TableName = "Artista della fuga"
        ElseIf Caller.Equals(MDIMain.AscoltareMDGPAG70ToolStripMenuItem) Then
            query &= "ASCOLTARE"
            TableName = "Ascoltare"
        ElseIf Caller.Equals(MDIMain.AzioniInCombattimentoToolStripMenuItem) Then
            query &= "AZ_COMBAT"
            TableName = "Azioni in combattimento"
        ElseIf Caller.Equals(MDIMain.GuarireMDGPAG76ToolStripMenuItem) Then
            query &= "GUARIRE"
            TableName = "Guarire"
        ElseIf Caller.Equals(MDIMain.SaltareMDGPAG8182ToolStripMenuItem) Then
            query &= "SALTARE"
            TableName = "Saltare"
        ElseIf Caller.Equals(MDIMain.ProvaDiAscoltarePerIndividuareCreatureInvisibiliToolStripMenuItem) Then
            query &= "ASCOL_X_CRE_INVIS"
            TableName = "Prova di Ascoltare per individuare creature invisibili"
        ElseIf Caller.Equals(MDIMain.PercepireIntenzioniMDGPAG79ToolStripMenuItem) Then
            query &= "PERC_INT"
            TableName = "Percepire intenzioni"
        ElseIf Caller.Equals(MDIMain.RapiditaDiManoMDGPAG81ToolStripMenuItem) Then
            query &= "RAP_MANO"
            TableName = "Rapidit di mano"
        ElseIf Caller.Equals(MDIMain.ModificatoreAMToolStripMenuItem) Then
            query &= "MOD_MUOV_SILENZ"
            TableName = "Modificatore a Muoversi Silenziosamente"
        ElseIf Caller.Equals(MDIMain.SapienzaMagicaMDGPAG82ToolStripMenuItem) Then
            query &= "SAPIENZA_MAGICA"
            TableName = "Sapienza magica"
        ElseIf Caller.Equals(MDIMain.UtilizzareOggettiMagiciMDGPAG85ToolStripMenuItem) Then
            query &= "UTILIZZ_OGG_MAG"
            TableName = "Utilizzare oggetti magici"
        ElseIf Caller.Equals(MDIMain.SopravvivenzaToolStripMenuItem) Then
            query &= "SOPRAVVIVENZA"
            TableName = "Sopravvivenza"
        End If
        If query.EndsWith("FROM ") Then
            MsgBox("Tabella inesistente nella Base Dati." & vbCrLf & "Popolare la Base Dati.")
            Exit Sub
        End If
        query &= " ORDER BY ID ASC"
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(query, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        Dim i As Integer = 0
        Dim switch As Integer = 0
        If Not Table.Rows.Count = 0 Then
            For Each column As DataColumn In Table.Columns
                If column.Caption.Equals("ID") Then
                    dataGridView1.Columns.Add("COL" & i, "Riga")
                    dataGridView2.Columns.Add("COL" & i, "Riga")
                Else
                    dataGridView1.Columns.Add("COL" & i, column.Caption)
                    dataGridView2.Columns.Add("COL" & i, column.Caption)
                End If
                i += 1
            Next
            For Each row As DataRow In Table.Rows
                If row.Item(1).Equals("NOTE") Then
                    switch = 2
                    Continue For
                ElseIf row.Item(1).Equals("MODIFICATORI") Then
                    switch = 1
                    Continue For
                End If
                If switch = 0 Then
                    dataGridView1.Rows.Add(row.ItemArray)
                ElseIf switch = 1 Then
                    dataGridView2.Rows.Add(row.ItemArray)
                ElseIf switch = 2 Then
                    label1.Text &= row.Item(1) & vbCrLf
                End If
            Next
            If dataGridView2.Rows.Count = 0 Then
                dataGridView2.Columns.Clear()
            End If
        End If
        DBADO.Close()
        Utils.SortNSetNotSortable(dataGridView1, System.ComponentModel.ListSortDirection.Ascending)
        Utils.SortNSetNotSortable(dataGridView2, System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Shared Function GetTreasure() As ArrayList
        Dim ret As New ArrayList
        Dim strSQL As String = "SELECT * FROM TESORI"
        DBADO.Open()
        Dim dbAdp As OleDb.OleDbDataAdapter
        Dim Data As New DataSet
        dbAdp = New OleDb.OleDbDataAdapter(strSQL, DBADO.Connessione)
        dbAdp.Fill(Data)
        Dim Table As DataTable = Data.Tables(0)
        If Not Table.Rows.Count = 0 Then
            Dim tesoro As Tesoro
            For Each row As DataRow In Table.Rows
                tesoro = New Tesoro
                tesoro.ID = row.Item("ID")
                tesoro.Nome = row.Item("NOME")
                tesoro.Descrizione = row.Item("DESCRIZIONE")
                tesoro.Pagina = row.Item("PAGINA")
                tesoro.Manuale = row.Item("MANUALE")
                tesoro.Prezzo = row.Item("PREZZO")
                tesoro.TipoOggetto = row.Item("TIPO_OGGETTO")
                ret.Add(tesoro)
            Next
        End If
        DBADO.Close()
        Return ret
    End Function
End Class
