Public Class Form1

    Dim conexion As New conexion

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.conectar()
        llenar()
        dgvpokemon.DataSource = conexion.dv
        llenarcbregion()

    End Sub

    Public Sub llenar()
        conexion.llenar("Select * From pokedex", "pokedex")
        dgvpokemon.DataSource = conexion.ds.Tables("pokedex")

    End Sub

    Private Sub btnregistrar_Click(sender As Object, e As EventArgs) Handles btnregistrar.Click
        Dim agregar As String = "Insert into pokedex values ('" + txtid.Text + "','" + txtnombre.Text + "','" + txttipo1.Text + "','" + txttipo2.Text + "','" + txtnombrejap.Text + "','" + txthuevo1.Text + "','" + txthuevo2.Text + "','" + txtgeneracion.Text + "','" + ComboBox1.Text + "', '" + txtaño.Text + "')"

        If (conexion.insert(agregar, txtid.Text)) Then
            MessageBox.Show("Datos agregados exitosamente")
            llenar()

        Else
            MsgBox("Datos ya existente", MsgBoxStyle.Critical, "Agregar Datos")
        End If
    End Sub



    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        If (conexion.Eliminar("pokedex", "Id= " + txtid.Text)) Then
            MsgBox("Datos Eliminados exitosamente", MsgBoxStyle.Information, "Eliminar datos")
            llenar()
        Else
            MsgBox("Error al Eliminar los datos", MsgBoxStyle.Critical, "Eliminar datos")
        End If
    End Sub
    Public Sub llenarcbregion()
        conexion.llenarcb()
        ComboBox1.DataSource = conexion.datos2.Tables("region")
        ComboBox1.DisplayMember = "RegNombre"
    End Sub


    Private Sub dgvpokemon_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvpokemon.CellClick
        Dim FilaActual As Integer
        FilaActual = dgvpokemon.CurrentRow.Index
        txtid.Text = dgvpokemon.Rows(FilaActual).Cells(0).Value
        txtnombre.Text = dgvpokemon.Rows(FilaActual).Cells(1).Value
        txttipo1.Text = dgvpokemon.Rows(FilaActual).Cells(2).Value
        txttipo2.Text = dgvpokemon.Rows(FilaActual).Cells(3).Value
        txtnombrejap.Text = dgvpokemon.Rows(FilaActual).Cells(4).Value
        txthuevo1.Text = dgvpokemon.Rows(FilaActual).Cells(5).Value
        txthuevo2.Text = dgvpokemon.Rows(FilaActual).Cells(6).Value
        txtgeneracion.Text = dgvpokemon.Rows(FilaActual).Cells(7).Value
        ComboBox1.Text = dgvpokemon.Rows(FilaActual).Cells(8).Value
        txtaño.Text = dgvpokemon.Rows(FilaActual).Cells(9).Value
    End Sub

    Private Sub btnactualizar_Click(sender As Object, e As EventArgs) Handles btnactualizar.Click
        Dim update As String = "Nombre='" + txtnombre.Text + "', Tipo_1= '" + txttipo1.Text + "', Tipo_2='" + txttipo2.Text + "', Nombre_JAP='" + txtnombrejap.Text + "', G_Huevo= '" + txthuevo1.Text + "', G_Huevo2='" + txthuevo2.Text + "', Generacion='" + txtgeneracion.Text + "', Region='" + ComboBox1.Text + "', Año='" + txtaño.Text + "'"
        If (conexion.actualizar("pokedex", update, "Id= '" + txtid.Text + "';")) Then
            MsgBox("Datos actualizados exitosamente", MsgBoxStyle.Information, "Actualizar datos")
            llenar()
        Else
            MsgBox("Error al actualizar los datos", MsgBoxStyle.Critical, "Actualizar Datos")
        End If
    End Sub
End Class
