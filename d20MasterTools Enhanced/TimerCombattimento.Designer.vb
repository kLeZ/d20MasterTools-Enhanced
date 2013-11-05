<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TimerCombattimento
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimerCombattimento))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.NOME = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.INIZIATIVA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VELOCITA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BAB_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BAB_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VISTA_SPEC_1 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.VISTA_SPEC_2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TS_1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TS_2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TS_3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.NomeCombattente = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IniziativaTotale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 424)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(270, 119)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controlli"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(6, 42)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(119, 20)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Azzera Combattenti"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(131, 42)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 20)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "Azzera timer"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(82, 19)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Calcola Iniziativa"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 68)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(244, 45)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Round"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(152, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 20)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Nuovo Round"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(76, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 20)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Cancella"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(6, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(64, 20)
        Me.TextBox1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(270, 418)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista dei Combattenti"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOME, Me.INIZIATIVA, Me.VELOCITA, Me.CA, Me.BAB_1, Me.BAB_2, Me.VISTA_SPEC_1, Me.VISTA_SPEC_2, Me.TS_1, Me.TS_2, Me.TS_3, Me.PF})
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView2.ShowCellErrors = False
        Me.DataGridView2.ShowRowErrors = False
        Me.DataGridView2.Size = New System.Drawing.Size(264, 399)
        Me.DataGridView2.TabIndex = 0
        '
        'NOME
        '
        Me.NOME.HeaderText = "Nome"
        Me.NOME.Name = "NOME"
        Me.NOME.Width = 58
        '
        'INIZIATIVA
        '
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.INIZIATIVA.DefaultCellStyle = DataGridViewCellStyle1
        Me.INIZIATIVA.HeaderText = "Iniziativa"
        Me.INIZIATIVA.Name = "INIZIATIVA"
        Me.INIZIATIVA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.INIZIATIVA.Width = 71
        '
        'VELOCITA
        '
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = "4,5"
        Me.VELOCITA.DefaultCellStyle = DataGridViewCellStyle2
        Me.VELOCITA.HeaderText = "Velocità"
        Me.VELOCITA.Name = "VELOCITA"
        Me.VELOCITA.Width = 68
        '
        'CA
        '
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "10"
        Me.CA.DefaultCellStyle = DataGridViewCellStyle3
        Me.CA.HeaderText = "CA"
        Me.CA.Name = "CA"
        Me.CA.Width = 44
        '
        'BAB_1
        '
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = "0"
        Me.BAB_1.DefaultCellStyle = DataGridViewCellStyle4
        Me.BAB_1.HeaderText = "Bonus Attacco Base Mischia"
        Me.BAB_1.Name = "BAB_1"
        Me.BAB_1.Width = 119
        '
        'BAB_2
        '
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.BAB_2.DefaultCellStyle = DataGridViewCellStyle5
        Me.BAB_2.HeaderText = "Bonus Attacco Base Distanza"
        Me.BAB_2.Name = "BAB_2"
        Me.BAB_2.Width = 119
        '
        'VISTA_SPEC_1
        '
        Me.VISTA_SPEC_1.HeaderText = "Scurovisione"
        Me.VISTA_SPEC_1.Name = "VISTA_SPEC_1"
        Me.VISTA_SPEC_1.Width = 72
        '
        'VISTA_SPEC_2
        '
        Me.VISTA_SPEC_2.HeaderText = "Visione Crepuscolare"
        Me.VISTA_SPEC_2.Name = "VISTA_SPEC_2"
        Me.VISTA_SPEC_2.Width = 99
        '
        'TS_1
        '
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = "0"
        Me.TS_1.DefaultCellStyle = DataGridViewCellStyle6
        Me.TS_1.HeaderText = "Tiro Salvezza Tempra"
        Me.TS_1.Name = "TS_1"
        Me.TS_1.Width = 122
        '
        'TS_2
        '
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.TS_2.DefaultCellStyle = DataGridViewCellStyle7
        Me.TS_2.HeaderText = "Tiro Salvezza Riflessi"
        Me.TS_2.Name = "TS_2"
        Me.TS_2.Width = 119
        '
        'TS_3
        '
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = "0"
        Me.TS_3.DefaultCellStyle = DataGridViewCellStyle8
        Me.TS_3.HeaderText = "Tiro Salvezza Volontà"
        Me.TS_3.Name = "TS_3"
        Me.TS_3.Width = 122
        '
        'PF
        '
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = "0"
        Me.PF.DefaultCellStyle = DataGridViewCellStyle9
        Me.PF.HeaderText = "Punti Ferita"
        Me.PF.Name = "PF"
        Me.PF.Width = 77
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomeCombattente, Me.IniziativaTotale})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(536, 543)
        Me.DataGridView1.TabIndex = 1
        '
        'NomeCombattente
        '
        Me.NomeCombattente.HeaderText = ""
        Me.NomeCombattente.Name = "NomeCombattente"
        Me.NomeCombattente.Width = 17
        '
        'IniziativaTotale
        '
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = "0"
        Me.IniziativaTotale.DefaultCellStyle = DataGridViewCellStyle10
        Me.IniziativaTotale.HeaderText = "Iniziativa"
        Me.IniziativaTotale.Name = "IniziativaTotale"
        Me.IniziativaTotale.Width = 71
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(810, 543)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 2
        '
        'TimerCombattimento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 543)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TimerCombattimento"
        Me.ShowInTaskbar = False
        Me.Text = "TimerCombattimento"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents NomeCombattente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IniziativaTotale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents NOME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INIZIATIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VELOCITA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BAB_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BAB_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VISTA_SPEC_1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents VISTA_SPEC_2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TS_1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TS_2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TS_3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
