<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReleaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckForUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallWithoutCheckingVersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DevelopmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InstallLatestBuildToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilitiesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeveloperCreditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UninstallElvUIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReleaseToolStripMenuItem, Me.DevelopmentToolStripMenuItem, Me.UtilitiesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(484, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReleaseToolStripMenuItem
        '
        Me.ReleaseToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckForUpdateToolStripMenuItem, Me.InstallUpdateToolStripMenuItem})
        Me.ReleaseToolStripMenuItem.Name = "ReleaseToolStripMenuItem"
        Me.ReleaseToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.ReleaseToolStripMenuItem.Text = "Release"
        '
        'CheckForUpdateToolStripMenuItem
        '
        Me.CheckForUpdateToolStripMenuItem.Name = "CheckForUpdateToolStripMenuItem"
        Me.CheckForUpdateToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.CheckForUpdateToolStripMenuItem.Text = "Check for update"
        '
        'InstallUpdateToolStripMenuItem
        '
        Me.InstallUpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallWithoutCheckingVersionToolStripMenuItem})
        Me.InstallUpdateToolStripMenuItem.Name = "InstallUpdateToolStripMenuItem"
        Me.InstallUpdateToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InstallUpdateToolStripMenuItem.Text = "Install update"
        '
        'InstallWithoutCheckingVersionToolStripMenuItem
        '
        Me.InstallWithoutCheckingVersionToolStripMenuItem.Name = "InstallWithoutCheckingVersionToolStripMenuItem"
        Me.InstallWithoutCheckingVersionToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InstallWithoutCheckingVersionToolStripMenuItem.Text = "Install latest update"
        '
        'DevelopmentToolStripMenuItem
        '
        Me.DevelopmentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem})
        Me.DevelopmentToolStripMenuItem.Name = "DevelopmentToolStripMenuItem"
        Me.DevelopmentToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.DevelopmentToolStripMenuItem.Text = "Development"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InstallLatestBuildToolStripMenuItem})
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'InstallLatestBuildToolStripMenuItem
        '
        Me.InstallLatestBuildToolStripMenuItem.Name = "InstallLatestBuildToolStripMenuItem"
        Me.InstallLatestBuildToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.InstallLatestBuildToolStripMenuItem.Text = "Install latest build"
        '
        'UtilitiesToolStripMenuItem
        '
        Me.UtilitiesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeveloperCreditToolStripMenuItem, Me.UninstallElvUIToolStripMenuItem})
        Me.UtilitiesToolStripMenuItem.Name = "UtilitiesToolStripMenuItem"
        Me.UtilitiesToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.UtilitiesToolStripMenuItem.Text = "Utilities"
        '
        'DeveloperCreditToolStripMenuItem
        '
        Me.DeveloperCreditToolStripMenuItem.Name = "DeveloperCreditToolStripMenuItem"
        Me.DeveloperCreditToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeveloperCreditToolStripMenuItem.Text = "Developer Credit"
        '
        'UninstallElvUIToolStripMenuItem
        '
        Me.UninstallElvUIToolStripMenuItem.Name = "UninstallElvUIToolStripMenuItem"
        Me.UninstallElvUIToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.UninstallElvUIToolStripMenuItem.Text = "Uninstall ElvUI"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = Global.Sapphires_ElvUI_Manager.My.Resources.Resources.splitsecond_logo
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(500, 300)
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "Form1"
        Me.Text = "Sapphire's ElvUI Manager"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ReleaseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckForUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallUpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallWithoutCheckingVersionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DevelopmentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InstallLatestBuildToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilitiesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeveloperCreditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UninstallElvUIToolStripMenuItem As ToolStripMenuItem
End Class
