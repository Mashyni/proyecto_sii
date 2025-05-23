Imports System.IO.Ports
Imports System.IO

Public Class FRM_Control

    Dim puertoCerrado As Boolean = False
    Dim temperatura As Double = 0
    Dim humedad As Double = 0
    Dim actualizaUltima As Boolean = False
    Dim actualizaDato As Boolean = False
    Dim tabla As Integer = 1

    Private Sub Form1_Load(sender As Object, e As EventArgs)
        hola.Text = "9600"

        graficaTemp.Series("Temperatura").Points.AddXY(1, 0)
        graficaHumedad.Series("Humedad").Points.AddXY(1, 0)
    End Sub


    Private Sub cmbPuerto_DropDown(sender As Object, e As EventArgs) Handles cmbPuerto.DropDown, cmbPuerto.DropDown
        Dim ListaPuertos As String() = SerialPort.GetPortNames()
        cmbPuerto.Items.AddRange(ListaPuertos)
    End Sub

    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click
        If Not puertoCerrado Then
            conectar()
        Else
            noConectado()
        End If
    End Sub

    Private Sub conectar()
        Try
            puertoCerrado = True
            puertoSerial.PortName = hola.Text
            puertoSerial.BaudRate = Convert.ToInt32(hola.Text)
            puertoSerial.Open()

            btnConectar.BackColor = Color.FromArgb(92, 197, 97)
            btnConectar.FlatAppearance.MouseDownBackColor = Color.FromArgb(199, 77, 77)
            btnConectar.FlatAppearance.MouseOverBackColor = Color.FromArgb(199, 77, 77)
            btnConectar.Text = "DESCONECTAR"

            graficaTemp.Series("Temperatura").Points.Clear()
            graficaHumedad.Series("Humedad").Points.Clear()

            actualizaUltima = True

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub noConectado()
        Try
            puertoCerrado = False
            puertoSerial.Close()

            btnConectar.Text = "CONECTAR"
            btnConectar.BackColor = Color.FromArgb(79, 195, 125)
            btnConectar.FlatAppearance.MouseDownBackColor = Color.FromArgb(194, 159, 92)
            btnConectar.FlatAppearance.MouseOverBackColor = Color.FromArgb(179, 77, 103)

            actualizaUltima = False

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs)
        Try
            PuertoSerial.Close()
            actualizaUltima = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub puertoSerial_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles puertoSerial.DataReceived
        Dim dataIn As String = puertoSerial.ReadTo(vbLf)
        analizarDatos(dataIn)
        Me.BeginInvoke(New EventHandler(AddressOf mostrarDatos))
    End Sub

    Private Sub mostrarDatos(sender As Object, e As EventArgs)
        If actualizaDato Then
            labelTemp.Text = String.Format("{0}°C", temperatura.ToString("F1"))
            labelHum.Text = String.Format("{0}%", humedad.ToString("F1"))

            graficaTemp.Series("Temperatura").Points.Add(temperatura)
            graficaHumedad.Series("Humedad").Points.Add(humedad)
        End If
    End Sub

    Private Sub actualizarDgv_Tick(sender As Object, e As EventArgs) Handles actualizarDgv.Tick
        tabla = dgvDatos.Rows.Add()

        dgvDatos.Rows(tabla).Cells(0).Value = DateTime.Now.ToShortDateString()
        dgvDatos.Rows(tabla).Cells(1).Value = DateTime.Now.ToString("hh:mm:ss")
        dgvDatos.Rows(tabla).Cells(2).Value = temperatura
        dgvDatos.Rows(tabla).Cells(3).Value = humedad
    End Sub

    Private Sub analizarDatos(dato As String)
        Dim caracterInicio As Integer = dato.IndexOf("C"c)
        Dim caracterA As Integer = dato.IndexOf("A"c)
        Dim caracterB As Integer = dato.IndexOf("B"c)

        If caracterA <> -1 AndAlso caracterB <> -1 AndAlso caracterInicio <> -1 Then
            Try
                Dim str_Temperatura As String = dato.Substring(caracterInicio + 1, (caracterA - caracterInicio) - 1)
                Dim str_Humedad As String = dato.Substring(caracterA + 1, (caracterB - caracterA) - 1)

                temperatura = Convert.ToDouble(str_Temperatura) / 100
                humedad = Convert.ToDouble(str_Humedad) / 100

                actualizaDato = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            actualizaDato = False
        End If
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles graficaTemp.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles labelHum.Click

    End Sub

    Private Sub dgvDatos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick

    End Sub

    Private Sub cmbPuerto_Enter(sender As Object, e As EventArgs) Handles hola.Enter

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged

    End Sub

    Private Sub labelTemp_Click(sender As Object, e As EventArgs) Handles labelTemp.Click

    End Sub
End Class
