<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RandomTreasure
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.GeneraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OggettiMinoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OggettiMediToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OggettiMaggioriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GemmeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OggettiDarteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PulisciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 12)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(307, 316)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 331)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Numero di tesori da generare"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(12, 347)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(120, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GeneraToolStripMenuItem, Me.PulisciToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(331, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'GeneraToolStripMenuItem
        '
        Me.GeneraToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OggettiMinoriToolStripMenuItem, Me.OggettiMediToolStripMenuItem, Me.OggettiMaggioriToolStripMenuItem, Me.GemmeToolStripMenuItem, Me.OggettiDarteToolStripMenuItem})
        Me.GeneraToolStripMenuItem.Name = "GeneraToolStripMenuItem"
        Me.GeneraToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.GeneraToolStripMenuItem.Text = "&Genera"
        '
        'OggettiMinoriToolStripMenuItem
        '
        Me.OggettiMinoriToolStripMenuItem.Name = "OggettiMinoriToolStripMenuItem"
        Me.OggettiMinoriToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.OggettiMinoriToolStripMenuItem.Text = "Oggetti minori"
        '
        'OggettiMediToolStripMenuItem
        '
        Me.OggettiMediToolStripMenuItem.Name = "OggettiMediToolStripMenuItem"
        Me.OggettiMediToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.OggettiMediToolStripMenuItem.Text = "Oggetti medi"
        '
        'OggettiMaggioriToolStripMenuItem
        '
        Me.OggettiMaggioriToolStripMenuItem.Name = "OggettiMaggioriToolStripMenuItem"
        Me.OggettiMaggioriToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.OggettiMaggioriToolStripMenuItem.Text = "Oggetti maggiori"
        '
        'GemmeToolStripMenuItem
        '
        Me.GemmeToolStripMenuItem.Name = "GemmeToolStripMenuItem"
        Me.GemmeToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.GemmeToolStripMenuItem.Text = "Gemme"
        '
        'OggettiDarteToolStripMenuItem
        '
        Me.OggettiDarteToolStripMenuItem.Name = "OggettiDarteToolStripMenuItem"
        Me.OggettiDarteToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.OggettiDarteToolStripMenuItem.Text = "Oggetti d'arte"
        '
        'PulisciToolStripMenuItem
        '
        Me.PulisciToolStripMenuItem.Name = "PulisciToolStripMenuItem"
        Me.PulisciToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.PulisciToolStripMenuItem.Text = "&Pulisci"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(158, 334)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(161, 33)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Visualizza Oggetto"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RandomTreasure
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 379)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "RandomTreasure"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "RandomTreasure"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GeneraToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OggettiMinoriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OggettiMediToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OggettiMaggioriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GemmeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OggettiDarteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PulisciToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
