<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Info
        Me.Label1.Location = New System.Drawing.Point(29, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(539, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Laptop Shop Management System"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button3.Location = New System.Drawing.Point(56, 246)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(476, 59)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Transaction History"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 321)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "V 1.0.0"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.Location = New System.Drawing.Point(56, 169)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 58)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Spareparts"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.Location = New System.Drawing.Point(56, 95)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(231, 59)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Laptops"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button4.Location = New System.Drawing.Point(305, 168)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(227, 59)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "Employee"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.Button5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button5.Location = New System.Drawing.Point(305, 95)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(227, 59)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "Customer"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Desktop
        Me.ClientSize = New System.Drawing.Size(594, 347)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.SystemColors.Menu
        Me.Name = "MainMenu"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
End Class
