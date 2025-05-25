<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_InvernaderoControl
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.hola = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnConectar = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.cmbPuerto = New System.Windows.Forms.ComboBox()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PuertoSerial = New System.IO.Ports.SerialPort(Me.components)
        Me.actualizarDgv = New System.Windows.Forms.Timer(Me.components)
        Me.labelTemp = New System.Windows.Forms.Label()
        Me.labelHum = New System.Windows.Forms.Label()
        Me.graficaTemp = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.graficaHumedad = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.hola.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graficaTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.graficaHumedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'hola
        '
        Me.hola.Controls.Add(Me.Label2)
        Me.hola.Controls.Add(Me.Label1)
        Me.hola.Controls.Add(Me.btnConectar)
        Me.hola.Controls.Add(Me.ComboBox2)
        Me.hola.Controls.Add(Me.cmbPuerto)
        Me.hola.Location = New System.Drawing.Point(26, 22)
        Me.hola.Name = "hola"
        Me.hola.Size = New System.Drawing.Size(161, 229)
        Me.hola.TabIndex = 0
        Me.hola.TabStop = False
        Me.hola.Text = "Puertos COM"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "BAUDIOS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONECTAR COM:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnConectar
        '
        Me.btnConectar.Location = New System.Drawing.Point(41, 154)
        Me.btnConectar.Name = "btnConectar"
        Me.btnConectar.Size = New System.Drawing.Size(75, 23)
        Me.btnConectar.TabIndex = 2
        Me.btnConectar.Text = "CONECTAR"
        Me.btnConectar.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"9600", "115200"})
        Me.ComboBox2.Location = New System.Drawing.Point(15, 114)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 1
        '
        'cmbPuerto
        '
        Me.cmbPuerto.FormattingEnabled = True
        Me.cmbPuerto.Items.AddRange(New Object() {"COM6"})
        Me.cmbPuerto.Location = New System.Drawing.Point(15, 51)
        Me.cmbPuerto.Name = "cmbPuerto"
        Me.cmbPuerto.Size = New System.Drawing.Size(121, 21)
        Me.cmbPuerto.TabIndex = 0
        '
        'dgvDatos
        '
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHA, Me.HORA, Me.Column1, Me.Column2})
        Me.dgvDatos.Location = New System.Drawing.Point(809, 22)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.Size = New System.Drawing.Size(489, 365)
        Me.dgvDatos.TabIndex = 1
        '
        'FECHA
        '
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        '
        'HORA
        '
        Me.HORA.HeaderText = "HORA"
        Me.HORA.Name = "HORA"
        '
        'Column1
        '
        Me.Column1.HeaderText = "HUMEDAD"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "TEMPERATURA"
        Me.Column2.Name = "Column2"
        '
        'actualizarDgv
        '
        Me.actualizarDgv.Interval = 1000
        '
        'labelTemp
        '
        Me.labelTemp.AutoSize = True
        Me.labelTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTemp.Location = New System.Drawing.Point(689, 154)
        Me.labelTemp.Name = "labelTemp"
        Me.labelTemp.Size = New System.Drawing.Size(49, 24)
        Me.labelTemp.TabIndex = 2
        Me.labelTemp.Text = "...°C"
        '
        'labelHum
        '
        Me.labelHum.AutoSize = True
        Me.labelHum.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelHum.Location = New System.Drawing.Point(689, 412)
        Me.labelHum.Name = "labelHum"
        Me.labelHum.Size = New System.Drawing.Size(44, 24)
        Me.labelHum.TabIndex = 3
        Me.labelHum.Text = "...%"
        '
        'graficaTemp
        '
        ChartArea1.Name = "ChartArea1"
        Me.graficaTemp.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.graficaTemp.Legends.Add(Legend1)
        Me.graficaTemp.Location = New System.Drawing.Point(198, 33)
        Me.graficaTemp.Name = "graficaTemp"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.LabelForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Series1.Legend = "Legend1"
        Series1.MarkerColor = System.Drawing.Color.White
        Series1.Name = "Temperatura"
        Me.graficaTemp.Series.Add(Series1)
        Me.graficaTemp.Size = New System.Drawing.Size(578, 218)
        Me.graficaTemp.TabIndex = 4
        Me.graficaTemp.Text = "temperatura"
        '
        'graficaHumedad
        '
        ChartArea2.Name = "ChartArea1"
        Me.graficaHumedad.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.graficaHumedad.Legends.Add(Legend2)
        Me.graficaHumedad.Location = New System.Drawing.Point(198, 296)
        Me.graficaHumedad.Name = "graficaHumedad"
        Series2.BorderColor = System.Drawing.Color.DeepSkyBlue
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Color = System.Drawing.Color.DeepSkyBlue
        Series2.Legend = "Legend1"
        Series2.Name = "Humedad"
        Me.graficaHumedad.Series.Add(Series2)
        Me.graficaHumedad.Size = New System.Drawing.Size(578, 193)
        Me.graficaHumedad.TabIndex = 5
        Me.graficaHumedad.Text = "Chart2"
        '
        'FRM_Control
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1317, 535)
        Me.Controls.Add(Me.labelHum)
        Me.Controls.Add(Me.graficaHumedad)
        Me.Controls.Add(Me.labelTemp)
        Me.Controls.Add(Me.graficaTemp)
        Me.Controls.Add(Me.dgvDatos)
        Me.Controls.Add(Me.hola)
        Me.Name = "FRM_Control"
        Me.Text = "Form1"
        Me.hola.ResumeLayout(False)
        Me.hola.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graficaTemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.graficaHumedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents hola As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnConectar As System.Windows.Forms.Button
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPuerto As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDatos As System.Windows.Forms.DataGridView
    Friend WithEvents PuertoSerial As System.IO.Ports.SerialPort
    Friend WithEvents actualizarDgv As System.Windows.Forms.Timer
    Friend WithEvents labelTemp As System.Windows.Forms.Label
    Friend WithEvents labelHum As System.Windows.Forms.Label
    Friend WithEvents graficaTemp As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents graficaHumedad As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
